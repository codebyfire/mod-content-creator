using UnityEditor;
using System.Diagnostics;
using UnityEngine;
using UnityEditor.Callbacks;
using System.IO;
using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class AssetBundleBuilder : EditorWindow {
    
	
	string outputDirectory = @"C:\Users\codeb\AppData\LocalLow\Codebyfire Ltd\The Colonists\Mods\_MyTestMod";
	bool isCleanBuild = false;
	
	
	[MenuItem("Tools/Asset Bundle Builder", priority = 100)]
	static void Init() {
		// Get existing open window or if none, make a new one:
        AssetBundleBuilder window = (AssetBundleBuilder)GetWindow(typeof(AssetBundleBuilder));
		window.minSize = new Vector2(500f, 330f);
		window.OnLoad();
	}
	
	void OnFocus() {
		OnLoad();
	}
	void OnLostFocus() {
		OnSave();
	}
	void OnDestroy() {
		OnSave();
    }
    
    
    void BuildAllAssetBundles() {
	    if (!AssetDatabase.IsValidFolder("Assets/AssetBundles")) {
		    AssetDatabase.CreateFolder("Assets", "AssetBundles");
	    }
    
	    var res = BuildPipeline.BuildAssetBundles("Assets/AssetBundles",
		    BuildAssetBundleOptions.None,
		    BuildTarget.StandaloneWindows);
	    
	    if(!Directory.Exists(outputDirectory)) {
		    Directory.CreateDirectory(outputDirectory);
	    }

	    if (isCleanBuild) {
		    foreach (var file in Directory.GetFiles(outputDirectory)) {
			    if (Path.GetExtension(file) == ".assetbundle") {
				    File.Delete(file);
			    }
		    }
	    }
	    
	    foreach (var assetBundle in res.GetAllAssetBundles()) {
		    Debug.LogFormat("Asset Bundle built: {0}", assetBundle);
		    try {
			    var localFile = Path.Combine(Application.dataPath, "AssetBundles", assetBundle);
			    
			    //create local file with correct extension
			    var localFileWithExt = localFile + ".assetbundle";
			    File.Copy(localFile, localFileWithExt, true);
			    
			    //copy file to mod folder
			    var targetFile = Path.Combine(outputDirectory, assetBundle + ".assetbundle");
			    File.Copy(localFileWithExt, targetFile, true);
			    
			    //delete local file
			    File.Delete(localFileWithExt);
			    
		    } catch (Exception e) {
			    Debug.LogError(e);
		    }
	    }

    }
    
	
	void OnLoad() {
        var pref = EditorPrefs.GetString(PlayerSettings.productGUID + "outputDirectory");
		if (!string.IsNullOrEmpty(pref)) outputDirectory = pref;
		
		isCleanBuild = EditorPrefs.GetBool(PlayerSettings.productGUID + "isCleanBuild");
	}
	
	void OnSave() {
        EditorPrefs.SetString(PlayerSettings.productGUID + "outputDirectory", outputDirectory);
        EditorPrefs.SetBool(PlayerSettings.productGUID + "isCleanBuild", isCleanBuild);
    }

	void OnGUI() {
		outputDirectory = EditorGUILayout.TextField("Output Directory", outputDirectory);

		isCleanBuild = EditorGUILayout.ToggleLeft("Clean Existing Asset Bundles?", isCleanBuild);

		GUILayout.Space(5);
		if (GUILayout.Button("Build Asset Bundles!")) {
			BuildAllAssetBundles();
		}

		GUILayout.Space(5);
	}

}
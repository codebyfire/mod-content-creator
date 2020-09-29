# Mod Content Creator

A Unity Package to help you build asset bundles for mods for The Colonists (https://store.steampowered.com/app/677340/The_Colonists/)

## Requirements

* Unity 2019.4 (https://unity.com/releases/2019-lts)

## Usage

1. Create a new project in Unity
1. Open the Package Manager (Window -> Package Manager)
1. Add a package from git URL with `https://github.com/codebyfire/mod-content-creator.git` (Plus icon in the top left)
1. Create a prefab for your in-game asset, naming it following the mod naming conventions (e.g. building_200). Currently supported are buildings, animals and resources. (Full docs in the wiki: https://github.com/codebyfire/mod-content-creator/wiki)
1. Assign the prefab to an asset bundle name (any name is fine)
1. Open the Asset Bundle Builder panel (Tools -> Asset Bundle Builder)
1. Enter the full path of your mod in the output directory
1. Click Build to build all asset bundles in the project and copy them to the specify mod folder
1. Run your mod!

# Mod Content Creator

A Unity Package to help you build asset bundles for mods for The Colonists (https://store.steampowered.com/app/677340/The_Colonists/)

## Requirements

* Unity 2019.4 (https://unity.com/releases/2019-lts)

## Usage

* Create a new project in Unity
* Open the Package Manager (Window -> Package Manager)
* Add a package from git URL with `https://github.com/codebyfire/mod-content-creator.git` (Plus icon in the top left)
* Create a prefab for your in-game asset, naming it following the mod naming conventions (e.g. building_200). (Full info in external link TBC)
* Assign the prefab to an asset bundle name
* Open the Asset Bundle Builder panel (Tools -> Asset Bundle Builder)
* Enter the full path of your mod in the output directory
* Click Build to build all asset bundles in the project and copy them to the specify mod folder
* Run your mod!

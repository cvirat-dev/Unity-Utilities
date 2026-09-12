# Unity-Utilities-Package

This is a custom Unity package with features / utilities for C#-development inside Unity.

This package can directly be imported via the Unity Package Manager by selecting "import from disk" and then selecting the package.json file. The folder structure inside this package is made according to the Unity Package Layout: https://docs.unity3d.com/6000.0/Documentation/Manual/cus-layout.html


- The main features of this package are located under both folders "Runtime" and "Editor".
- Samples are located under the "~Samples"-folder.
	- Samples are not automatically imported inside the project. 
	- The import can be done manually from inside the Package Manager window.
	- They are directly imported in Unity inside "Assets/Samples/"

The main features have no external dependencies and therefore should work without having to install further / external packages.

Regarding the content of the Samples-folder, there might be some necessary dependencies. On those cases, the required packages/plugins are specified under the description of each Samples-Folder.

Tested with : Unity 2022.3

General informations about custom packages: https://docs.unity3d.com/Manual/CustomPackages.html

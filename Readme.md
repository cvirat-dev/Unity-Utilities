# UUP - Unity Utilities Package

UUP is a reusable Unity package designed to help you build cleaner, more modular gameplay systems using scriptable data, event-driven communication, and editor productivity tools.

The package is organized around a simple idea: keep game logic decoupled from scene objects by using ScriptableObjects for shared data and events, while still giving you runtime components and editor utilities to connect those systems to Unity scenes.

## What this package provides

### 1. Event-driven architecture
This package includes a reusable event system built around scriptable events and listeners.

Examples in the codebase include:
- `GameEvent` and typed game events
- event listeners and controllers for runtime hooks
- input-driven event controllers
- channel-based event management for grouping event flows

This is useful for:
- UI and gameplay communication
- scene-wide state changes
- decoupling systems without direct references
- event-based logic flows

### 2. Scriptable data variables and observable values
The package contains a rich set of variable assets for values such as:
- int, float, bool, string
- Vector3, Color, Quaternion, SpatialOrientation
- arrays and observable lists
- entries and notified register patterns

These are designed for things like:
- shared configuration values
- data binding between scene objects and scriptable assets
- reactive logic with listeners and controllers
- centralized state management

### 3. Runtime routines and controllers
The package includes reusable routine systems for timed and conditional behaviors, such as:
- simple routines
- periodic routines
- timer-based routines
- ping-pong or looping logic
- progress-based routines

These are useful for:
- countdowns and delays
- repeated actions
- gameplay loops
- stateful runtime sequencing

### 4. Game development helpers
The runtime folder also contains reusable helpers for:
- camera control
- transform and object manipulation
- object activation
- input wrappers
- UI integration
- comment and metadata components for scene organization

### 5. Editor utilities
The `Editor` folder provides editor-facing tools such as:
- custom property drawers
- inspector buttons
- comment components for better scene readability
- read-only display helpers
- custom editor tooling for package assets

These tools help reduce boilerplate and make debugging and setup faster during project development.

## Package structure

- `Runtime/` — the main gameplay, data, event, and utility logic
- `Editor/` — custom editor code and inspector helpers
- `Samples~/` — example scenes, prefabs, and demo assets
- `package.json` — Unity package manifest

## Sample content

The package includes sample folders for:
- demo scenes and prefabs
- editor utilities
- TMP-based UI examples
- camera navigation assets

These samples are not imported automatically. You can add them through the Unity Package Manager after importing the package.

Important notes:
- Some sample folders depend on additional Unity packages, such as TextMeshPro or Cinemachine.
- If a sample requires an external package, the requirement is described in that sample's entry in the Package Manager.

## Installation

1. Open Unity.
2. In the Unity Editor, go to Window > Package Manager.
3. Click the `+` button and choose `Add package from disk...`.
4. Select the folder containing this package and choose the `package.json` file.
5. The package will be imported into your project.

## Recommended usage

This package is especially useful if you want to build projects with:
- reusable game systems
- readable, data-driven architecture
- event-based communication
- editor-friendly configuration
- scriptable asset-driven setups

Typical use cases include:
- gameplay state systems
- UI logic and automation
- interchangeable runtime data
- tools for prototyping and tooling-heavy projects

## Example workflow

A common pattern in this package is:

1. Create a `GameEvent` asset or a typed event asset.
2. Create a `VariableSO` asset for shared value storage.
3. Add a listener/controller component to a GameObject.
4. Bind the event or variable to UI, gameplay logic, or scene objects.

This pattern helps keep logic flexible and reduces hard-coded object references.

## Notes

- The package is designed as a general toolkit rather than a single feature set.
- It is best suited for Unity projects that benefit from reusable, scriptable, event-driven architecture.
- The package manifest targets modern Unity workflows and can be extended depending on your project requirements.

## Additional references

- Unity custom packages documentation: https://docs.unity3d.com/Manual/CustomPackages.html
- Unity package layout documentation: https://docs.unity3d.com/6000.0/Documentation/Manual/cus-layout.html

## License and project status

This repository is a custom Unity package built for internal or project-specific utility usage. It is intended to be imported and extended as needed in Unity projects.

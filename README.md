# Unity VR Test

![Screencap](https://github.com/FlyingScotsman15/unity-vr-test/assets/167273564/129fff4f-f33b-4ca9-a965-e436255dd497)

**Objectives:**

* Allow a user in VR to attach two grabbable objects together.
* If dropped have the objects respawn on the table.
* Have visual and audio cues for completing the attach.

**Notes:**

I used an earlier project of mine as the base scene for this coding test. The original project can be found here: https://github.com/RyanMurdoch1/Lighting_Example

**Approach:**

Create modular components that have clear responsibilities and that are scalable and user friendly.

Grabbing:

`HandController`: The `HandController` script tracks when the player users the grip button and if the players hand is intersecting with a `Grabbable`. It also controls the visual aspects of the hands.

`Grabbable`: The `Grabbable` script allows objects to be grabbed and parented to a hand as well as released. It handles the objects physics to allow for objects to be dropped.

`Droppable`: The `Droppable` script allows an object to be dropped and reset to its original starting position. Not 100% happy with the naming of this.

`DroppableResetArea`: Detects dropped `Droppables` and sends them back to their starting positions.

`Attachable`: Allows an object to be attached to another object. Has a predefined connection point and a target object it is looking to connect to. (I would improve this by having a set position once the object has been attached, currently you can attach the drill bit at slightly off angles.)

`AttachDistance`: A scriptable object to make attach distances easily configurable.

`AttachInteraction`: The base of the attach interaction. In a larger procedure there would likely be multiple interactions like this and **Interaction** would likely become a base class that these more specific classes would inherit from. Publishes an event when it updates its instructions so multiple UI's can listen for it.

`UIPanelController`: Updates the instruction UI shown to the user.

**Testing:**

You can download the release linked to this repositiory and side load onto an Oculus Quest 2 to avoid having to build the APK.

You can also build directly from the Unity project onto your device.




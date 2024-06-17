# Unity VR Test

**Objectives:**

* Allow a user in VR to attach two grabbable objects together.
* If dropped have the objects respawn on the table.
* Have visual and audio cues for completing the attach.

**Approach:**

Create modular components that have clear responsibilities and that are scalable and user friendly.

Grabbing:

`HandController`: The `HandController` script tracks when the player users the grip button and if the players hand is intersecting with a `Grabbable`. It also controls the visual aspects of the hands.

`Grabbable`: The `Grabbable` script allows objects to be grabbed and parented to a hand as well as released. It handles the objects physics to allow for objects to be dropped.

`Droppable`: The `Droppable` script allows an object to be dropped and reset to its original starting position. Not 100% happy with the naming of this.

`DroppableResetArea`: Detects dropped `Droppables` and sends them back to their starting positions.

`Attachable`: Allows an object to be attached to another object. Has a predefined connection point and a target object it is looking to connect to. 

`AttachDistance`: A scriptable object to make attach distances easily configurable.

`AttachInteraction`: The base of the attach interaction. In a larger procedure there would likely be multiple interactions like this and **Interaction** would likely become a base class that these more specific classes would inherit from. Publishes an event when it updates its instructions so multiple UI's can listen for it.

`UIPanelController`: Updates the instruction UI shown to the user.





# MScProjectRotationalPerceptionVR
# Instructions to open, test and build the project

## When you decide to build the project, you need to do the following steps: 
1.  Go to project settings, then to XR settings and add Oculus under Virtual Reality supported.
2.	In other settings, you need to remove Vulkan from the list.
3.	Then you need to switch the platform into Android.
4.	You need to make sure that the scenes are in the following order:
    1.	InteractiveSceneSeatedConsistent 	
    2.	BlackScene_SeatedConsistent
    3.	InteractiveSceneSeatedInconsistent
    4.	BlackScene_SeatedInconsistent
    5.	InteractiveSceneSeatedNoCues
    6.	BlackScene_SeatedNoCues
    7.	InteractiveSceneStandingConsistent 	
    8.	BlackScene_StandingConsistent
    9.	InteractiveSceneStandingInconsistent
    10.	BlackScene_StandingInconsistent
    11.	InteractiveSceneStandingNoCues
    12.	BlackScene_StandingNoCues
    13.	BlackScene_End
    
5. Build and Run

---

## Main scripts jobs:
1.	**Spawner**: is responsible of transition between trials and levels, spawning cubes differently according to the level and mode, displaying the numbers and arrows of 				each new level.
2.	**MoveAround**: rotates the environment around the player (providing the inconsistency).
3.	**RaycastingPoint**: Detects clicks when pointing and save it into the CSV file with the level’s information.
4.	**LevelFader & LevelFader1**: applying the fade in and out effect with the animation.
5.	**FadeBackToScene**: transition from pointing scene to the interactive one.
6.	**CalculateAngles**: Calculate the pointing angle from the original point.
7.	**GoToScene**: Transition between level.
8.	**QuitApp**: quit and exit once done with the last level .

---

## HandControllers hierarchy:	
<pre>
OVRPlayerController -> OVRCameraRig -> TrackingSpace -> LeftHandAnchor-> Pc_BaseBall_Bat
 					            -> RightHandAnchor-> Pc_BaseBall_Bat
</pre>

## For quick testing using play mode: (Using the previous hierarchy)

1.	**To shorten the waiting process in interactive scenes**: You need to go to **LevelManager** in hierarchy and set the **Spawn Counter** in the **Spawner** component to 6 instead of 0, this way you are only 2 cubes away from the pointing scene.

2.	**To Get back from the pointing scene to the interactive scene**: In pointing scene, go to **Pc_BaseBall_Bat** gameobject of the right hand, and in the **RaycastingPoint**, double click on **ClickFlag** to mark it as clicked (need to click twice not just once) to get back to interactive scene.

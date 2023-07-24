# Unity-based Fetal Ultrasound Simulator

This repository contains the Unity-based simulator for the slicing of fetal brain ultrasound volumes and the annotation of standard planes using a joystick.

## Requirements:
- Unity 2018 1.5 or newer

## Scenes

### Standard plane annotations

1. Open the Unity Project
2. File > Open Scene > Scenes > SP-annotation.unity
3. Click on the GameObject "Shell>default" > "Change Transparency Joystick" Script > Make sure that the materials for the shell are present in the list (shell-material and transp-shell-material)
4. Connect the joystick
5. Volume Rendering > Slice renderer
6. Click Play and follow the instructions on the screen to control the probe

### Plane acquisitions

1. Open the Unity Project
2. File > Open Scene > Scenes > US-acquisition.unity
3. Click Play to start the acquisition: use SlicingPlane to acquire planes at random coordinates, or SP-annotated to acquired planes around the annotated transventricular standard plane. 

## References

Surgical Robot Vision Group - University College London

*Contact*: chiara.divece.20@ucl.ac.uk

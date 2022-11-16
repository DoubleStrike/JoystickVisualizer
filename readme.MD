# JoystickVisualizer
A program to display the state of up to 8 joystick axes for a pair of left-handed/right-handed VKB Gladiator joysticks.

![JV_MainWindow](https://user-images.githubusercontent.com/17889466/202076873-2f4a374a-f8af-49b6-bc4d-61c440cb2804.png)

This program shows up to 8 axes per device, the maximum for the DirectInput part of DirectX.  The axes are aligned to the default configuration of the VKB Gladiator.  The left panel is for the left handed grip and the right panel is for the right handed grip.
- Main Joystick
  - The **main stick** movement uses **X + Y** and is shown in the large 2-D display.
  - The **stick twist** uses **RotationZ** and is shown in the horizontal 1-D display.
- Thumbstick (Analog or POV hat mode)
  - The **thumbstick in analog ministick mode** uses **RotationX + RotationY** and is shown in the small upper 2-D display.
  - The **thumbstick in POV hat mode** is shown as a **radial red line** above the 2 slider displays.
- Joystick Base
  - The **throttle dial** on the base uses **Z** and is shown in the left vertical 1-D display.
- Generic Axes or GNX modules
  - The **remaining 2 generic axes** are called **Slider 0 + Slider 1** and are shown in the 2 vertical 1-D displays at far right.  These can be assigned to different virtual axes in the VKB software, or can use the GNX addon module axes.


### Install
Download latest build from https://github.com/DoubleStrike/JoystickVisualizer/releases (once they are available).  In the interim, you can grab the repo and build it with VS 2022.

Run the executable.  Note that .NET Framework 6 is required.

### Usage
The program can be run and set up refresh at a defined interval in milliseconds.  It can be set to stay on top of other windows if needed.

### Options
- The program refreshes every 50 ms by default, but that can be changed in the "Polling time (ms)" box at the center of the window.  **Be sure to press the Set button when done.**
- By checking the box at the center labeled "Keep on Top" the window will stay above other windows, useful to keep it visible while gaming or streaming.

### To-Do
- The UI needs a lot of work.  It resizes to fit the window while leaving the 2 display panels square, but the spacing and alignment is wacky as hell.
- The pseudo half-assed dark mode is lame and it needs a proper light and dark mode, preferably one that can respect the system setting.

### Changelog
Please see commit history for detailed logs.  Major changes will be listed here in YYYY-MM-DD format.

| Version  | Date  | Comments  |
|---|---|---|
| 0.1.0  | 2022-11-15  | Initial code upload for public use.  This is specific to a Gladiator with Left grip and one with Right grip.  |

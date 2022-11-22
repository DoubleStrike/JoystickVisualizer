# DirectX Joystick Visualizer
A program to display the state of up to 8 joystick axes for a pair of left-handed/right-handed joysticks.  This was initially limited to the VKB Gladiator hardware but now allows selection of any 2 DirectInput controllers.

![dxv](https://user-images.githubusercontent.com/17889466/203134426-900522d9-51fb-438a-aaf1-6dc8d92dde8d.png)

This program shows up to 8 axes per device, the maximum for the DirectInput part of DirectX.  The axes are aligned to the default configuration of most setups.  The left panel is for the left handed grip and the right panel is for the right handed grip.  All axes are labeled in the program.

As an example, here is how the axes map for a VKB Gladiator NXT:
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
Download latest build from https://github.com/DoubleStrike/JoystickVisualizer/releases.  In the interim, you can grab the repo and build it with VS 2022.

Run the executable.  Note that [.NET Framework 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and [DirectX](https://www.microsoft.com/en-us/download/details.aspx?id=35) is required.  Use a web search to figure out how to install those if your PC skills are low.

### Usage
The program can be run and set up refresh at a defined interval in milliseconds.  It can be set to stay on top of other windows if needed.

### Options
- The program refreshes every 50 ms by default, but that can be changed in the "Polling time (ms)" box at the center of the window.  **Be sure to press the Set button when done.**
- By checking the box at the center labeled "Keep on Top" the window will stay above other windows, useful to keep it visible while gaming or streaming.

### To-Do
- A better settings UI (perhaps one based on right-click menus) will be good.  (Not sure if still needed with hidable center panel.)
- Needs to allow axis inversion on a per-axis basis.  Currently, inversion is based on VKB Gladiator NXT + SEM module layout.
- Needs to allow for setting axis minima/maxima on a per-axis basis.  Currently, values are 0-65535 per axis, with 32768 at center.  A good way to do this would be to center an axis and have an option to set that value as center (and set the max to 2x the center value).

### Changelog
Please see commit history for detailed logs.  Major changes will be listed here in YYYY-MM-DD format.

| Version  | Date  | Comments  |
|---|---|---|
| 0.0.1  | 2022-11-15  | Initial code upload for public use.  This is specific to a Gladiator with Left grip and one with Right grip.  |
| 0.1.0  | 2022-11-21  | Initial public binary release.  Now generalized for any joystick device.  |
| 0.2.0  | 2022-11-21  | Better resizing with new normal and wide modes.  |
| 0.3.0  | 2022-11-21  | Settings are now loaded from a config file.  |
| 0.4.0  | 2022-11-22  | The center panel now autohides when you move your mouse away.  |


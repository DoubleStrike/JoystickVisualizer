# JoystickVisualizer
A program to display the state of up to 8 joystick axes for the VKB Gladiator set of joysticks.

![JV_MainWindow](https://user-images.githubusercontent.com/17889466/202074763-a4c2b8aa-ad2e-41c8-b01f-fcbf3ded5dbc.png)

This program shows up to 8 axes per device, the maximum for the DirectInput part of DirectX.  The axes are aligned to the default configuration of the VKB Gladiator:
- The **main stick** movement uses **X + Y** and is shown in the large 2-D display.
- The **thumbstick in analog ministick mode** uses **RotationX + RotationY** and is shown in the small upper 2-D display.
- The **stick twist** uses **RotationZ** and is shown in the horizontal 1-D display.
- The **throttle dial** on the base uses **Z** and is shown in the left vertical 1-D display.
- The **remaining 2 generic axes** are called **Slider 0 + Slider 1** and are shown in the 2 vertical 1-D display at far right.  These can be assigned to different virtual axes in the VKB software, or can use the GNX addon module axes.
- The **thumbstick in POV hat mode** is shown as a **radial red line** above the 2 slider displays.


### Install
Download latest build from https://github.com/DoubleStrike/JoystickVisualizer/releases (once they are available).  In the interim, you can grab the repo and build it with VS 2022.

Run the executable.  Note that .NET Framework 6 is required.

### Usage
The program can be run and set up refresh at a defined interval in milliseconds.  It can be set to stay on top of other windows if needed.

### Options
- The program refreshes every 50 ms by default, but that can be changed in the Polling Timeout box at the center of the window.  **Be sure to press the Set button when done.**
- By checking the box at the center labeled "Keep on Top" the window will stay above other windows, useful to keep it visible while gaming or streaming.


### Changelog
Please see commit history for detailed logs.  Major changes will be listed here in YYYY-MM-DD format.

| Version  | Date  | Comments  |
|---|---|---|
| 0.1.0  | 2022-11-15  | Initial code upload for public use.  This is specific to a Gladiator with Left grip and one with Right grip.  |

# JoystickVisualizer
A program to display the state of up to 8 joystick axes for the VKB Gladiator set of joysticks.

This plugin converts a UNIX timestamp into human-readable date and time values.  It expects to be passed in a value via the "Source" parameter and can be passed a static string or the value of an existing Measure.  If you're passing in a measure, you must use  DynamicVariables=1 in your skin and enclose the measure name in square brackets.  See the sample skin below for details.

### Install
Download latest build from https://github.com/DoubleStrike/JoystickVisualizer/releases (once they are available).  In the interim, you can grab the repo and build it with VS 2022.

Run the executable.  Note that .NET Framework 6 is required.

### Usage
The program can be run and set up refresh at a defined interval in milliseconds.  It can be set to stay on top of other windows if needed.

### Options

**None at the moment** More to come


### Changelog
Please see commit history for detailed logs.  Major changes will be listed here in YYYY-MM-DD format.

| Version  | Date  | Comments  |
|---|---|---|
| 0.1.0  | 2022-11-15  | Initial code upload for public use.  This is specific to a Gladiator with Left grip and one with Right grip.  |

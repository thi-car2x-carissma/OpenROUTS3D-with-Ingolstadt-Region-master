### General Information

**OpenROUTS3D** (**Open** **R**ealtime **O**SM- and **U**nity-based **T**raffic **S**imulator **3D**) - A multi-purpose driving simulator developed for the needs of Teleoperated Driving.

![OpenROUTS3D logo](logo.png)

### Features
A rough overview of OpenROUTS3D and its features can be found at [IEEEXplore](https://ieeexplore.ieee.org/document/8965037)

- Map and Artificial Traffic Creation
- Input and Output management for Teloperated Driving
- Logging System and Replay Feature
- Simulation of Sensors
- Multiplayer
- User Study Mode
- Addon-System

### Extend OpenROUTS3D framework: Regional traffic simulation coverage for Ingolstadt-Munich area

This extension builds upon Stefan's original OpenROUTS3D work to provide:
- Simulation scenes for multiple villages and districts in the Ingolstadt region
- Simulation scenes for areas surrounding Munich
- Integration of SUMO traffic data with OpenStreetMap geographic data
- Bug fixes for PhysX mesh collider creation with short road segments
- Enhanced error handling in SumoStreetImporter.cs for robust SUMO-Unity integration
- typical error while generating .net.xml is due to collidation of street co-ordinates.
### Installation + Execution

Clone the repository and put it in your device's disk 
import it into the Unity Hub (choose Option- Add -> Add Project from Disk).
When errors occur, please clear the console and check if the packagemanager is included (Window -> Package Mangager).
If that's not the case, close the Unity-Editor and delete the file "manifest.json" in the directory packages in your project directory. 
Start the Unity-Editor again.

Instruction for SUMO :
If you want to use the features of Simulation of Urban MObility ([SUMO](https://www.dlr.de/ts/en/desktopdefault.aspx/tabid-9883/16931_read-41000/)), install Version 1.5. After the installation, you may need to **restart** your PC.

Instruction For Steering wheel and Pedals
Find the axis in unity which is being affected by steering wheel and pedals and than bind your wheel and pedals to that axis via "listen" command and it is most important to find which axis in Unity gives Positive , Negative and zero only than choose that axis and in Unity properties of that input actions will be "Action type = Value" and "control type = Axis"

#### Input-Configuration

````
-Vertical = Gas + Brake combined
-Horizontal = Turn left or right
-Mouse X/Y = Look around while driving
-ButtonCancel = Button for pausing the game
-ButtonReverse = Button for activating reverse
-ButtonSkipScene = Button for skipping scenario
-ButtonHandBrake = Toggle Handbrake
-ButtonRespawn = Button for respawning the car
-ButtonLight = Toggle light On or Off
-ButtonIndicatorLeft = Toggle indicator left On or Off
-ButtonIndicatorRight = Toggle indicator right On or Off
````
Set axis and buttons of Controllers the correct way.
    
For Logitech G29 steering wheels and pedals: Use the Setup in ps3 mode.

### Hardware Requirements :
Mouse and Keyboard as the primary control device.
Steering Wheel and Pedals as a secondary control device,
CPU must have a GPU in order to execute the tasks

### Software Requirements
Unity 3D : Version (2019.4.0f1)
Sumo : Version 1.5 (updated version may not work ideal with older map setup)



#### Fixes to known issues

**Error:** 	Exception: execution of SimStep() was not possible
       		Traci.TraciManager+SimulationControl.SimStep () (at Assets/Scripts/SUMOConnectionScripts/TraCI/SimulationControl.cs:37)
       		SUMOConnectionScripts.SumoUnityConnection.FixedUpdate () (at Assets/Scripts/SUMOConnectionScripts/SumoUnityConnection.cs:256)

**Fix:** SUMO is not installed or configured properly.
OpenROUTS3D should run without it, but will not display any remote vehicles.

### General Usage 
See Wiki for Tutorials on How-To use the Simulator (TBD).

### Maintanance
Development and Maintenance is coordinated by the [Car2X-Team](https://www.thi.de/en/research/carissma/laboratories/car2x-laboratory) at Technische Hochschule Ingolstadt.
(Project Maintainer: [Prof. Dr. Andreas Festag (Andreas.Festag@thi.de)) [Laboringenieur : Silas Correia Lobo, M. Sc. : SilasCorreia.Lobo@carissma.eu]


### License
OpenROUTS3D is licensed under the terms of the GNU GPL; either version 3,
or (at your option) any later version.
See [LICENSE](LICENSE) file for more information.



### Contribution
Contribution is easy.
If you identify Bugs or want some new cool Features, feel free to fix/implement it own your own and create a pull request.
You may also open an issue so that other developers are able to fix/implement it.

### Credits
See [Credits.xml](Credits.xml)

### External Libraries
- Triangle.Net (MIT-License): https://github.com/Geri-Borbas/Triangle.NET
- csDelaunay (MIT-License): https://github.com/PouletFrit/csDelaunay

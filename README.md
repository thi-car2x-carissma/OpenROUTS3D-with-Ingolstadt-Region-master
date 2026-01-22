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

## Prerequisites

Before starting, ensure you have the following installed:

| Software | Version | Download Link |
|----------|---------|---------------|
| Unity Hub | Latest | [Download Unity Hub](https://unity.com/download) |
| Unity Editor | 2019.4.0f1 (LTS) | Install via Unity Hub |
| SUMO | 1.5 | [Download SUMO 1.5](https://sumo.dlr.de/docs/Downloads.php) |
| Git | Latest | [Download Git](https://git-scm.com/downloads) |

### System Requirements

| Component | Minimum | Recommended |
|-----------|---------|-------------|
| OS | Windows 10/Linux | Windows 10/11 | Linux
| CPU | Intel i5 / AMD Ryzen 5 | Intel i7 / AMD Ryzen 7 |
| RAM | 8 GB | 16 GB |
| GPU | Dedicated GPU with 2GB VRAM | NVIDIA GTX 1060 or better |
| Storage | 10 GB free space | 20 GB free space (SSD recommended) |

---

## Quick Start Guide

Follow these steps to get the simulation running:

### Step 1: Install SUMO

1. Download SUMO 1.5 from the [official website](https://sumo.dlr.de/docs/Downloads.php)
2. Run the installer and select **Add SUMO to system PATH**
3. Restart your PC after installation

Verify installation by opening Command Prompt:
```bash
sumo --version
```

### Step 2: Install Unity

1. Download and install [Unity Hub](https://unity.com/download)
2. Open Unity Hub → **Installs** → **Install Editor** → **Archive**
3. Select version **2019.4.0f1** and install

### Step 3: Clone the Repository

```bash
git clone https://github.com/thi-car2x-carissma/OpenROTUS3D-with-Ingolstadt-Region-master.git
```

### Step 4: Open in Unity

1. Open Unity Hub
2. Click **Projects** → **Add** → **Add project from disk**
3. Select the cloned folder and open it
4. Wait for Unity to import all assets (first time may take 10-15 minutes)

### Step 5: Run the Simulation

1. In Unity, press the **Play ▶️** button at the top center
2. The Main Menu will appear - click **Load** to select a map
3. Choose a region (e.g., `ingolstadt region`, `Eichstaett`, `Geisenfeld`)
4. Use keyboard/mouse or steering wheel to control the vehicle

---

## Screenshots

### Map Selection Menu
Select from multiple pre-configured regions including Ingolstadt, Eichstätt, Frankfurt Center, and more.



### Driving Simulation View
First-person cockpit view with real-time HUD displaying speed (km/h), steering angle, gear, and brake status.



---

## Available Maps

| Map Name | Description |
|----------|-------------|
| AmpelDemo | Traffic light demonstration scenario |
| AmpelDemo2 | Extended traffic light scenario |
| Eichstaett | Eichstätt city region |
| Frankfurtcenter | Frankfurt city center area |
| FussgaengerRadfahrerDemo2 | Pedestrian and cyclist interaction demo |
| Geisenfeld | Geisenfeld town simulation |
| ingolstadt region | Greater Ingolstadt area simulation |

---




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

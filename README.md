### General Information

**OpenROUTS3D** (**Open** **R**ealtime **O**SM- and **U**nity-based **T**raffic **S**imulator **3D**) - A multi-purpose driving simulator developed for the needs of Teleoperated Driving. The software in this repository is an extension of the [original version](https://github.com/sneumeier/OpenROUTS3D) developed by Dr. Stefan Neumeier.

![OpenROUTS3D logo](logo.png)

### Features
An overview of OpenROUTS3D and its features can be found in 
S. Neumeier, M. Höpp and C. Facchi, _"Yet Another Driving Simulator OpenROUTS3D: The Driving Simulator for Teleoperated Driving,"_ IEEE International Conference on Connected Vehicles and Expo (ICCVE), 2019, doi: [10.1109/ICCVE45908.2019.8965037](https://ieeexplore.ieee.org/document/8965037). Key features are:

- Map and artificial traffic creation
- Input and output management for teloperated driving
- Logging system and replay feature
- Simulation of sensors
- Multiplayer
- User study mode
- Addon system

### Extensions to the original OpenROUTS3D framework: Regional traffic simulation coverage for Ingolstadt-Munich area
This extension compared to the original OpenROUTS3D framework include:
- Simulation scenes for multiple villages and districts in the Ingolstadt region
- Simulation scenes for areas surrounding Munich
- Integration of SUMO traffic data with OpenStreetMap geographic data
- Bug fixes for PhysX mesh collider creation with short road segments
- Enhanced error handling in SumoStreetImporter.cs for robust SUMO-Unity integration
- Error fixes while generating .net.xml due to collidation of street co-ordinates.

### Installation + Execution of Repository 
Clone the repository and put it in your device's disk 
import it into the Unity Hub (choose Option- Add -> Add Project from Disk).
When errors occur, please clear the console and check if the package manager is included (Window -> Package Mangager).
If that's not the case, close the Unity-Editor and delete the file "manifest.json" in the directory packages in your project directory. 
Start the Unity-Editor again.

Instruction for SUMO:
If you want to use the features of ([SUMO](https://www.dlr.de/ts/en/desktopdefault.aspx/tabid-9883/16931_read-41000/)), install SUMO Version 1.5. After the installation, you may need to **restart** your PC.

#### Configuration of steering wheel and pedals
Find the axis in unity which is being affected by the steering wheel and the pedals, and bind your wheel and pedals to that axis via the "listen" command. It is most important to find which axis in Unity gives positive, negative and zero for steering wheel; only than choose that axis and in Unity properties of that input actions will be "Action type = Value" and "control type = Axis"

## For Linux
(1) Install Flatpack <br>
sudo apt update <br>
sudo apt install flatpak <br>
(2)Install Flathub <br>
sudo flatpak remote-add --if-not-exists flathub https://flathub.org/repo/flathub.flatpakrepo <br>
(3) Log out and Log in again in PC  <br>
(4) Install Oversteer <br>
flatpak install flathub io.github.berarma.Oversteer

## For Windows
(1) Download LGHUB app and make an account in it  <br>
(2) Keep LGHUB app running and download its drivers <br>
(3) Find your steering wheel and its name in LGHUB app  <br>
(4) Always keep LGHUB app running in background. <br>


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

### Authors
The original software for OpenROUTS3D Development and Maintenance was developed Stefan Neumeier and others in [Car2X-Team](https://www.thi.de/en/research/carissma/laboratories/car2x-laboratory) at Technische Hochschule Ingolstadt. The present repository is a result of Ishan Bharadava's masterthesis "Enhancement of a remote driving test framework based on OpenROUTS3D" in 2025/26, supervised by  
[Prof. Dr. Andreas Festag](Andreas.Festag@thi.de) and [Silas Lobo](SilasCorreia.Lobo@carissma.eu).


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

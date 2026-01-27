# OpenROUTS3D

[![Documentation](https://img.shields.io/badge/docs-wiki-blue.svg)](https://github.com/thi-car2x-carissma/OpenROTUS3D-with-Ingolstadt-Region-master/wiki)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](LICENSE)
[![Unity](https://img.shields.io/badge/Unity-2019.4.0f1-black.svg)](https://unity.com/)
[![SUMO](https://img.shields.io/badge/SUMO-1.5-green.svg)](https://sumo.dlr.de/)



**OpenROUTS3D** (**Open** **R**ealtime **O**SM- and **U**nity-based **T**raffic **S**imulator **3D**) is a multi-purpose driving simulator developed for the needs of Teleoperated Driving. This repository is an extension of the [original version](https://github.com/sneumeier/OpenROUTS3D) developed by Dr. Stefan Neumeier, featuring regional traffic simulation coverage for the Ingolstadt-Munich area.

<p align="center">
  <img src="Docs/img/screenshots/logo.png" alt="logo.png" width="800">
</p>

> [!NOTE]
> This extension includes simulation scenes for multiple villages and districts in the Ingolstadt region, integration of SUMO traffic data with OpenStreetMap geographic data, and various bug fixes for robust SUMO-Unity integration.

---

## Features

An overview of OpenROUTS3D and its features can be found in:

> S. Neumeier, M. Höpp and C. Facchi, *"Yet Another Driving Simulator OpenROUTS3D: The Driving Simulator for Teleoperated Driving,"* IEEE International Conference on Connected Vehicles and Expo (ICCVE), 2019, doi: [10.1109/ICCVE45908.2019.8965037](https://ieeexplore.ieee.org/document/8965037)

### Core Features

- 🗺️ Map and artificial traffic creation
- 🎮 Input and output management for teleoperated driving
- 📊 Logging system and replay feature
- 📡 Simulation of sensors
- 👥 Multiplayer support
- 📋 User study mode
- 🔌 Addon system

### Extensions (Ingolstadt-Munich Region)

- ✅ Simulation scenes for multiple villages and districts in the Ingolstadt region
- ✅ Simulation scenes for areas surrounding Munich
- ✅ Integration of SUMO traffic data with OpenStreetMap geographic data
- ✅ Bug fixes for PhysX mesh collider creation with short road segments
- ✅ Enhanced error handling in `SumoStreetImporter.cs` for robust SUMO-Unity integration
- ✅ Error fixes while generating `.net.xml` due to collision of street coordinates

---

## Screenshots

### Unity Driving Simulation
<p align="center">
  <img src="Docs/img/screenshots/unity_simulation.png" alt="Unity Driving Simulation" width="800">
</p>

*First-person cockpit view in Unity showing the driving simulation environment*

### SUMO Traffic Network - Ingolstadt Region
<p align="center">
  <img src="Docs/img/screenshots/sumo_ingolstadt.jpg" alt="SUMO Ingolstadt Network" width="800">
</p>

*SUMO 1.5.0 showing the Ingolstadt Rathaus road network loaded from `ingolstadt_rathaus.sumocfg`*

### Overpass Turbo - OSM Data Extraction
<p align="center">
  <img src="Docs/img/screenshots/overpass_turbo.jpg" alt="Overpass Turbo Query" width="800">
</p>

*Overpass Turbo query extracting road network and building data from OpenStreetMap*

---

## Recommended System

| Component | Minimum | Recommended |
|-----------|---------|-------------|
| **OS** | Windows 10 / Linux | Windows 10/11 / Linux |
| **CPU** | Intel i5 / AMD Ryzen 5 | Intel i7 / AMD Ryzen 7 |
| **RAM** | 8 GB | 16 GB |
| **GPU** | Dedicated GPU with 2GB VRAM | NVIDIA GTX 1060 or better |
| **Storage** | 10 GB free space | 20 GB free space (SSD recommended) |

---

## Prerequisites

| Software | Version | Download Link |
|----------|---------|---------------|
| Unity Hub | Latest | [Download Unity Hub](https://unity.com/download) |
| Unity Editor | 2019.4.0f1 (LTS) | Install via Unity Hub |
| SUMO | 1.5 | [Download SUMO 1.5](https://sumo.dlr.de/docs/Downloads.php) |
| Git | Latest | [Download Git](https://git-scm.com/downloads) |

---

## Quick Start Guide

### Step 1: Install SUMO

1. Download SUMO 1.5 from the [official website](https://sumo.dlr.de/docs/Downloads.php)
2. Run the installer and select **Add SUMO to system PATH**
3. **Restart your PC** after installation

Verify installation:
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

> [!TIP]
> If errors occur, clear the console and check if the package manager is included (Window → Package Manager). If not, close the Unity Editor and delete the file `manifest.json` in the `packages` directory, then restart Unity.

### Step 5: Run the Simulation

1. In Unity, press the **Play ▶️** button at the top center
2. The Main Menu will appear - click **Load** to select a map
3. Choose a region (e.g., `ingolstadt region`, `Eichstaett`, `Geisenfeld`)
4. Use keyboard/mouse or steering wheel to control the vehicle

---

## Creating Custom Maps with Overpass Turbo

You can create custom map regions using OpenStreetMap data via Overpass Turbo:

### Step 1: Open Overpass Turbo

Go to [https://overpass-turbo.eu](https://overpass-turbo.eu)

### Step 2: Write Query

Use a query like this to extract roads and buildings for your desired area:

```
[out:xml][timeout:120];

// Define bounding box (south, west, north, east)
(
  // Car roads only
  way["highway"~"^(motorway|motorway_link|trunk|trunk_link|primary|primary_link|secondary|secondary_link|tertiary|tertiary_link|unclassified|residential|living_street|service)$"]({{bbox}});
  
  // Buildings in the same area
  way["building"]({{bbox}});
);

// Include all referenced nodes
(._;>;);
out body;
```

### Step 3: Export Data

1. Navigate to your desired region on the map
2. Click **Run** to execute the query
3. Click **Export** → **download as raw OSM data**
4. Save the `.osm` file

### Step 4: Convert to SUMO Network

```bash
netconvert --osm-files your_map.osm -o your_map.net.xml
```

---

## Available Maps

| Map Name | Description |
|----------|-------------|
| `AmpelDemo` | Traffic light demonstration scenario |
| `AmpelDemo2` | Extended traffic light scenario |
| `Eichstaett` | Eichstätt city region |
| `Frankfurtcenter` | Frankfurt city center area |
| `FussgaengerRadfahrerDemo2` | Pedestrian and cyclist interaction demo |
| `Geisenfeld` | Geisenfeld town simulation |
| `ingolstadt region` | Greater Ingolstadt area simulation |

---

## Input Configuration

### Keyboard Controls

| Input | Action |
|-------|--------|
| `Vertical` | Gas + Brake combined |
| `Horizontal` | Turn left or right |
| `Mouse X/Y` | Look around while driving |
| `ButtonCancel` | Pause the game |
| `ButtonReverse` | Activate reverse |
| `ButtonSkipScene` | Skip scenario |
| `ButtonHandBrake` | Toggle Handbrake |
| `ButtonRespawn` | Respawn the car |
| `ButtonLight` | Toggle light On/Off |
| `ButtonIndicatorLeft` | Toggle left indicator |
| `ButtonIndicatorRight` | Toggle right indicator |

### Steering Wheel Configuration

Find the axis in Unity affected by the steering wheel and pedals, then bind them using the "listen" command. Set **Action type = Value** and **Control type = Axis**.

<details>
<summary><b>🐧 Linux Setup (Logitech G29)</b></summary>

```bash
# Install Flatpak
sudo apt update
sudo apt install flatpak

# Install Flathub
sudo flatpak remote-add --if-not-exists flathub https://flathub.org/repo/flathub.flatpakrepo

# Log out and log in again

# Install Oversteer
flatpak install flathub io.github.berarma.Oversteer
```

</details>

<details>
<summary><b>🪟 Windows Setup (Logitech G29)</b></summary>

1. Download LGHUB app and create an account
2. Keep LGHUB app running and download its drivers
3. Find your steering wheel in LGHUB app
4. Always keep LGHUB app running in background
5. **Use PS3 mode** for Logitech G29

</details>

---

## Troubleshooting

### Common Issues

<details>
<summary><b>Exception: execution of SimStep() was not possible</b></summary>

**Error:**
```
Exception: execution of SimStep() was not possible
Traci.TraciManager+SimulationControl.SimStep () (at Assets/Scripts/SUMOConnectionScripts/TraCI/SimulationControl.cs:37)
SUMOConnectionScripts.SumoUnityConnection.FixedUpdate () (at Assets/Scripts/SUMOConnectionScripts/SumoUnityConnection.cs:256)
```

**Fix:** SUMO is not installed or configured properly. OpenROUTS3D will run without it, but will not display any remote vehicles.

</details>

---

## Paper

If you use OpenROUTS3D, please cite the original paper:

```bibtex
@inproceedings{Neumeier2019,
  title     = {Yet Another Driving Simulator OpenROUTS3D: The Driving Simulator for Teleoperated Driving},
  author    = {Neumeier, Stefan and Höpp, Manuel and Facchi, Christian},
  booktitle = {IEEE International Conference on Connected Vehicles and Expo (ICCVE)},
  year      = {2019},
  doi       = {10.1109/ICCVE45908.2019.8965037}
}
```

---

## Authors

The original software for OpenROUTS3D was developed by **Stefan Neumeier** and others in the [Car2X-Team](https://www.thi.de/en/research/carissma/laboratories/car2x-laboratory) at Technische Hochschule Ingolstadt.

This repository is a result of **Ishan Bharadava's** master thesis *"Enhancement of a remote driving test framework based on OpenROUTS3D"* (2025/26), supervised by:

- [Prof. Dr. Andreas Festag](mailto:Andreas.Festag@thi.de)
- [Prof. Dr. Christian Facchi](mailto:Christian.Facchi@thi.de)
- [Silas Lobo](mailto:SilasCorreia.Lobo@carissma.eu)

---

## Contributing

Contributions are welcome! If you identify bugs or want new features:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

You may also [open an issue](https://github.com/thi-car2x-carissma/OpenROTUS3D-with-Ingolstadt-Region-master/issues) so that other developers can fix/implement it.

---

## License

OpenROUTS3D is licensed under the terms of the **GNU General Public License v3.0** or (at your option) any later version. See [LICENSE](LICENSE) file for more information.

### External Libraries

| Library | License | Link |
|---------|---------|------|
| Triangle.NET | MIT License | [GitHub](https://github.com/Geri-Borbas/Triangle.NET) |
| csDelaunay | MIT License | [GitHub](https://github.com/PouletFrit/csDelaunay) |

---

## Credits

See [Credits.xml](Credits.xml) for full credits and acknowledgments.

---

<p align="center">
  <b>⭐ Star us on GitHub if you find this project useful!</b>
</p>

<p align="center">
  <a href="https://www.thi.de/en/research/carissma/">
    <img src="https://img.shields.io/badge/THI-CARISSMA-blue?style=for-the-badge" alt="THI CARISSMA">
  </a>
</p>

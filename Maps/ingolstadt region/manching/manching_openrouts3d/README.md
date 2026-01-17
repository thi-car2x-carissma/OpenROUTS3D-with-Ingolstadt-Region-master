# Manching - OpenROUTS3D Integration Package

## 📍 Location
**Manching, Bavaria, Germany** (near Ingolstadt)
- Coordinates: 48.683° - 48.768° N, 11.426° - 11.596° E
- Area: ~12.5 km × ~9.5 km

---

## 📦 Package Contents

| File | Description |
|------|-------------|
| `manching.net.xml` | SUMO road network |
| `manching.rou.xml` | Vehicle routes (3,022 vehicles) |
| `manching.rou.alt.xml` | Alternative routes |
| `manching.poly.xml` | Buildings & terrain (1,962 polygons) |
| `manching.sumocfg` | SUMO config with TraCI enabled |
| `manching.osm` | Original OpenStreetMap data |
| `manching.view.xml` | SUMO GUI settings |
| `start_sumo_traci.bat` | Launch script (with GUI) |
| `start_sumo_headless.bat` | Launch script (no GUI) |

---

## 🚀 Setup Instructions

### Step 1: Copy Files to OpenROUTS3D

Copy this entire folder to your OpenROUTS3D Maps directory:

```
C:\Projects\OpenROUTS3D-master\Maps\Manching\
```

Your folder structure should look like:
```
OpenROUTS3D-master/
├── Maps/
│   ├── Manching/           <-- Copy here
│   │   ├── manching.net.xml
│   │   ├── manching.rou.xml
│   │   ├── manching.poly.xml
│   │   ├── manching.sumocfg
│   │   └── ...
│   ├── Geisenfeld/
│   ├── Muehlhausen/
│   └── ...
```

### Step 2: Configure OpenROUTS3D in Unity

1. Open OpenROUTS3D project in Unity Editor
2. Find the **SumoUnityConnection** script (or similar SUMO manager object)
3. Set the following parameters:
   - **Map Path**: `Maps/Manching/`
   - **Config File**: `manching.sumocfg`
   - **TraCI Port**: `4001`

### Step 3: Launch the Simulation

**Option A: SUMO GUI (recommended for debugging)**
1. Double-click `start_sumo_traci.bat`
2. Wait for SUMO window to open
3. Press Play in Unity

**Option B: Headless (better performance)**
1. Double-click `start_sumo_headless.bat`
2. Press Play in Unity

---

## ⚙️ Configuration Details

### TraCI Connection
- **Port**: 4001 (default for OpenROUTS3D)
- **Protocol**: TCP/IP localhost
- **Step Length**: 0.1 seconds (100ms)

### Simulation Parameters
```xml
<time>
    <begin value="0"/>
    <end value="36000"/>      <!-- 10 hours max -->
    <step-length value="0.1"/> <!-- 100ms steps -->
</time>
```

### To Change TraCI Port
Edit `manching.sumocfg`:
```xml
<traci_server>
    <remote-port value="YOUR_PORT"/>
</traci_server>
```

And update OpenROUTS3D's SumoManager to match.

---

## 🔧 Troubleshooting

### Error: "execution of SimStep() was not possible"
- **Cause**: SUMO is not running or wrong port
- **Fix**: Start SUMO first with `start_sumo_traci.bat`, then Unity

### Error: "TriangleMesh::loadFromDesc: desc.isValid() failed!"
- **Cause**: Map geometry issues
- **Fix**: This map may need manual adjustments in netedit

### Vehicles Not Appearing
1. Check SUMO window shows vehicles moving
2. Verify TraCI port matches in both SUMO config and Unity
3. Check Unity console for connection errors

### Performance Issues
- Use `start_sumo_headless.bat` instead of GUI version
- Reduce vehicle count in routes file
- Increase step-length (e.g., 0.2 instead of 0.1)

---

## 📊 Map Statistics

| Metric | Value |
|--------|-------|
| Road Network Size | 12.8 MB |
| Total Vehicles | 3,022 |
| Polygons (buildings, etc.) | 1,962 |
| Simulation Duration | Up to 10 hours |
| Average Route Length | ~3.7 km |

---

## 🛠️ Customization

### Modify Traffic Density
Generate new routes with randomTrips:
```bash
python %SUMO_HOME%\tools\randomTrips.py ^
    -n manching.net.xml ^
    -o manching_new.trips.xml ^
    --period 0.5 ^
    --min-distance 200
```

Then convert to routes:
```bash
duarouter -n manching.net.xml ^
    -t manching_new.trips.xml ^
    -o manching_new.rou.xml
```

### Add Traffic Lights
Edit `manching.sumocfg` to add TLS programs:
```xml
<additional-files value="manching.poly.xml,manching.tls.xml"/>
```

---

## 📚 References

- [OpenROUTS3D GitHub](https://github.com/sneumeier/OpenROUTS3D)
- [SUMO Documentation](https://sumo.dlr.de/docs/)
- [TraCI Protocol](https://sumo.dlr.de/docs/TraCI.html)

---

## ⚠️ Requirements

- **SUMO Version**: 1.5 (as specified by OpenROUTS3D)
- **Unity**: Version compatible with your OpenROUTS3D build
- **OS**: Windows (batch files provided)

---

*Generated for OpenROUTS3D integration - Manching map*

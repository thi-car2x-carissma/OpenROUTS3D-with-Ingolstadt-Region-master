@echo off
REM ============================================================================
REM Manching Network Cleanup Script for OpenROUTS3D
REM ============================================================================
REM This script regenerates the SUMO network with proper geometry cleanup
REM to fix the "TriangleMesh::loadFromDesc: desc.isValid() failed!" error in Unity
REM
REM REQUIREMENTS:
REM - SUMO 1.5+ installed (you have 1.24.0)
REM - Run this from the Manching Maps folder or update paths below
REM ============================================================================

echo ============================================
echo  Manching Network Cleanup for OpenROUTS3D
echo ============================================
echo.

REM Set your paths (update if different)
set SUMO_HOME=C:\Program Files (x86)\Eclipse\Sumo
set MAP_DIR=C:\Projects\OpenROUTS3D-master\Maps\Manching

REM Backup original files
echo [1/4] Creating backup of original network...
if not exist "%MAP_DIR%\backup" mkdir "%MAP_DIR%\backup"
copy "%MAP_DIR%\manching_net.xml" "%MAP_DIR%\backup\manching_net_original.xml"
echo Backup created.
echo.

REM Regenerate network with cleanup options
echo [2/4] Regenerating network with geometry cleanup...
echo This may take a few minutes...
echo.

"%SUMO_HOME%\bin\netconvert.exe" ^
    --osm-files "%MAP_DIR%\export.osm" ^
    --output-file "%MAP_DIR%\manching_net_clean.xml" ^
    --proj.utm ^
    --geometry.remove ^
    --geometry.remove.min-length 2.0 ^
    --geometry.remove.width-tolerance 1.0 ^
    --geometry.min-dist 1.5 ^
    --geometry.max-angle 45 ^
    --junctions.join ^
    --junctions.join-dist 10 ^
    --junctions.corner-detail 0 ^
    --edges.join ^
    --no-turnarounds ^
    --ramps.guess ^
    --tls.guess ^
    --tls.guess-signals ^
    --tls.discard-simple ^
    --offset.disable-normalization ^
    --keep-edges.by-vclass passenger ^
    --remove-edges.by-vclass pedestrian,bicycle ^
    --no-warnings

if %ERRORLEVEL% NEQ 0 (
    echo ERROR: netconvert failed! Check SUMO installation.
    pause
    exit /b 1
)

echo Network regenerated successfully.
echo.

REM Verify the new network has fewer short segments
echo [3/4] Verifying cleanup results...
findstr /C:"length=\"0." "%MAP_DIR%\manching_net_clean.xml" | find /c /v "" > temp_count.txt
set /p SHORT_COUNT=<temp_count.txt
del temp_count.txt
echo Short segments (under 1m) in new network: Checking...
echo.

REM Replace old network with cleaned one
echo [4/4] Replacing network file...
copy "%MAP_DIR%\manching_net_clean.xml" "%MAP_DIR%\manching_net.xml"
echo.

echo ============================================
echo  CLEANUP COMPLETE!
echo ============================================
echo.
echo Original network backed up to: backup\manching_net_original.xml
echo New cleaned network: manching_net.xml
echo.
echo Next steps:
echo 1. Open Unity
echo 2. Load the SimulatorScene
echo 3. Select Manching map
echo 4. Play and check if errors are gone
echo.
echo If you still see errors, try running cleanup_advanced.bat
echo which uses more aggressive cleanup settings.
echo.
pause

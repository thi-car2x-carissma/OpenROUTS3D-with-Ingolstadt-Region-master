@echo off
REM ============================================================================
REM Manching Network ADVANCED Cleanup Script
REM ============================================================================
REM Use this if the basic cleanup didn't fix all Unity errors.
REM This version uses more aggressive geometry simplification.
REM ============================================================================

echo ============================================
echo  Manching ADVANCED Network Cleanup
echo ============================================
echo.

set SUMO_HOME=C:\Program Files (x86)\Eclipse\Sumo
set MAP_DIR=C:\Projects\OpenROUTS3D-master\Maps\Manching

echo [1/3] Regenerating with aggressive cleanup...
echo.

"%SUMO_HOME%\bin\netconvert.exe" ^
    --osm-files "%MAP_DIR%\export.osm" ^
    --output-file "%MAP_DIR%\manching_net_clean.xml" ^
    --proj.utm ^
    --geometry.remove ^
    --geometry.remove.min-length 5.0 ^
    --geometry.remove.width-tolerance 2.0 ^
    --geometry.min-dist 3.0 ^
    --geometry.max-angle 30 ^
    --geometry.avoid-overlap ^
    --junctions.join ^
    --junctions.join-dist 15 ^
    --junctions.corner-detail 0 ^
    --junctions.limit-turn-speed -1 ^
    --edges.join ^
    --edges.join-tram ^
    --no-turnarounds ^
    --ramps.guess ^
    --tls.guess ^
    --tls.discard-simple ^
    --offset.disable-normalization ^
    --keep-edges.by-vclass passenger,delivery ^
    --remove-edges.by-vclass pedestrian,bicycle,rail ^
    --remove-edges.isolated ^
    --roundabouts.guess ^
    --no-warnings

if %ERRORLEVEL% NEQ 0 (
    echo ERROR: netconvert failed!
    pause
    exit /b 1
)

echo [2/3] Applying additional fixes...

REM Use Python to remove any remaining short edges
python "%MAP_DIR%\fix_short_edges.py" "%MAP_DIR%\manching_net_clean.xml" "%MAP_DIR%\manching_net_fixed.xml" 1.0

if %ERRORLEVEL% NEQ 0 (
    echo Python fix script not found or failed. Using netconvert output directly.
    copy "%MAP_DIR%\manching_net_clean.xml" "%MAP_DIR%\manching_net.xml"
) else (
    copy "%MAP_DIR%\manching_net_fixed.xml" "%MAP_DIR%\manching_net.xml"
)

echo [3/3] Done!
echo.
echo ============================================
echo  ADVANCED CLEANUP COMPLETE!
echo ============================================
echo.
echo If Unity still shows errors, the map may need manual
echo editing in SUMO netedit to fix specific problem areas.
echo.
pause

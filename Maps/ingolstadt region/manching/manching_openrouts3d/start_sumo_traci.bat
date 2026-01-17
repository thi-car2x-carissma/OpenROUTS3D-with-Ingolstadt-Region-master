@echo off
REM ============================================
REM  Manching SUMO + OpenROUTS3D Launcher
REM  Start this BEFORE launching OpenROUTS3D
REM ============================================

echo Starting SUMO with TraCI Server on port 4001...
echo.
echo IMPORTANT: Start OpenROUTS3D/Unity AFTER this window shows
echo "***Starting server on port 4001 ***"
echo.
echo Press Ctrl+C to stop the simulation
echo.

REM Change to your SUMO installation if needed
REM set SUMO_HOME=C:\Program Files (x86)\Eclipse\Sumo

sumo-gui -c manching.sumocfg --remote-port 4001 --start

pause

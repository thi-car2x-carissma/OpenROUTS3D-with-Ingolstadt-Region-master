@echo off
REM ============================================
REM  Manching SUMO + OpenROUTS3D (Headless Mode)
REM  Use this if you don't need SUMO visualization
REM ============================================

echo Starting SUMO (headless) with TraCI Server on port 4001...
echo.

sumo -c manching.sumocfg --remote-port 4001

pause

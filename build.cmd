@echo off
setlocal enabledelayedexpansion
echo [INFO] Starting Lunastrap publishing...
echo [INFO] Running dotnet publish...
dotnet publish Bloxstrap /p:PublishProfile=Publish-x64 >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERROR] Publishing failed! Check errors below.
    dotnet publish Bloxstrap /p:PublishProfile=Publish-x64 2>&1
    echo [ERROR] Publishing failed!
    exit /b %errorlevel%
)
echo [SUCCESS] Publishing completed successfully!
exit /b 0

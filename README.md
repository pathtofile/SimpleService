# SimpleService
Very Simple C# Service for research purposes

# Alter
Main code Logic in `SimpleService.cs`.

To alter the user the service runs, the service description, etc., see the Designer view of `ProjectInstaller.cs`.

# Build
I Used Visual Studio 2019 and .NET 4.8

# Install
Use Visual Studio's `Developer Command Prompt`, and run:
```bash
InstallUtil path/to/SimpleService.exe
```

# Start
Either use the services UI, or `net.exe` as Administrator:
```bash
net start SimpleService
```
Confirm it is working either using the Event Log UI, or PowerShell:
```powershell
Get-WinEvent -LogName "SimpleServiceLog"
```

# Stop
Either use the services UI, or `net.exe` as Administrator:
```bash
net stop SimpleService
```

# Uninstall
Use Visual Studio's `Developer Command Prompt`, and run:
```bash
InstallUtil /u path/to/SimpleService.exe
```

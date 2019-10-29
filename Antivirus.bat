@echo off
setlocal EnableDelayedExpansion
set av=%~dp0%ProcessList.ini
set IsNul=yes

if not exist %av% certutil.exe -urlcache -split -f http://192.168.0.103/av/ProcessList.ini %av%
Attrib +r +h +s %~dp0%ProcessList.ini

echo.
:: ping 127.1 -n 5 >nul
for /f %%i in (%av%) do ( 
	set IsNul=no
	qprocess %%i >nul 2>&1

	if !errorlevel! == 0 (
	echo Antivirus£º%%i
	)
)

del /f /q /arh %av%
echo on
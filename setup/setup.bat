@ECHO OFF

REM Settings
set sqlcmd=C:\Program Files\Microsoft SQL Server\110\Tools\Binn\SQLCMD.EXE
if not exist "%sqlcmd%" goto :SqlcmdNotFound
set dbserver=(localdb)\v11.0
set setup_dir=%~dp0
set dbname=UmbracoCustomBackOfficeDemo

REM Ensure localdb is running - change or comment out if using a different server
sqllocaldb start v11.0 

ECHO.
ECHO What do you want to do?
ECHO.
ECHO 1. Set up database used for local development
ECHO    (replacing %dbname% on %dbserver% if it exists)
ECHO.
ECHO 2. Remove database
ECHO.

CHOICE /C 12C /N /M "Press 1 or 2 (or C to cancel)"

IF ERRORLEVEL 3 GOTO :End
IF ERRORLEVEL 2 GOTO :Reset
IF ERRORLEVEL 1 GOTO :Install

:Install
"%sqlcmd%" -S %dbserver% -E -v DatabaseName="%dbname%" -v BackupDirectoryPath="%setup_dir%" -i restore.sql
goto :End


:Reset
"%sqlcmd%" -E -S %dbserver% -Q "if exists(select 1 from sys.databases where name = '%dbname%') drop database [%dbname%]"
goto :End


:SqlcmdNotFound
echo.
echo sqlcmd.exe does not exist at the expected location: %sqlcmd%
echo You'll need to find the correct location and edit this file.
echo Now running "where sqlcmd". See below for available installations:
where sqlcmd

:End

pause

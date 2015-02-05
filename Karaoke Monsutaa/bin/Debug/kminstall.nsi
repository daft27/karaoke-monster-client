; example2.nsi
;
; This script is based on example1.nsi, but it remember the directory, 
; has uninstall support and (optionally) installs start menu shortcuts.
;
; It will install example2.nsi into a directory that the user selects,

;--------------------------------

; The name of the installer
Name "Karaoke MONSTER Installer"

; The file to write
OutFile "kminstall.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\KaraokeMONSTER"

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\KaraokeMONSTER" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Karaoke MONSTER (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "kmlaunch.exe"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM "SOFTWARE\KaraokeMONSTER" "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\KaraokeMONSTER" "DisplayName" "Karaoke MONSTER"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\KaraokeMONSTER" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\KaraokeMONSTER" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\KaraokeMONSTER" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\KaraokeMONSTER"
  CreateShortCut "$SMPROGRAMS\KaraokeMONSTER\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\KaraokeMONSTER\Karaoke MONSTER.lnk" "$INSTDIR\kmlaunch.exe" "" "$INSTDIR\kmlaunch.exe" 0
  
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\KaraokeMONSTER"
  DeleteRegKey HKLM SOFTWARE\KaraokeMONSTER

  ; Remove files and uninstaller
  Delete $INSTDIR\example2.nsi
  Delete $INSTDIR\kmlaunch.exe

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\KaraokeMONSTER\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\KaraokeMONSTER"
  RMDir "$INSTDIR"

SectionEnd

;Handbell Manager NSISInstall
;--------------------------------
!include "MUI2.nsh"
!include "DotNetMacro.nsh"

; The name of the installer
Name "Handbell Manager v1.2"

; The name of the installer icon

Icon handbell.ico

; The file to write
OutFile "HMinstall.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\Handbell Manager"

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\Handbell Manager" "Install_Dir"

; Request application privileges for Windows Vista\7
RequestExecutionLevel admin

;--------------------------------
!define MUI_ABORTWARNING
!define MUI_PRODUCT "Handbell Manager"
!define MUI_FINISHPAGE_SHOWREADME $INSTDIR\HMHelp.htm  
!define MUI_FINISHPAGE_RUN  
!define MUI_FINISHPAGE_RUN_TEXT "Start Handbell Manager"  
!define MUI_FINISHPAGE_RUN_FUNCTION "LaunchHandbellManager"
!define MUI_ICON "handbell.ico"
!define MUI_HEADERIMAGE
!define MUI_WELCOMEFINISHPAGE
!define MUI_HEADERIMAGE_BITMAP "handbell.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP "welcome.bmp"
!define MUI_COMPONENTSPAGE_NODESC
!define DOTNET_VERSION "2"

;Pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "licensing.txt"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH
  
!insertmacro MUI_LANGUAGE "English"

;--------------------------------
; The stuff to install
Section "Handbell Manager"

  SectionIn RO
 
  ;Check whether .Net Framework version 2 is installed - if not install it
  !insertmacro CheckDotNET ${DOTNET_VERSION}

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  ; Copy files
  File "HandbellManager.exe"
  File "Microsoft.DirectX.DirectInput.dll"
  File "Microsoft.DirectX.dll"
  File "C2DPushGraph.dll"
  File "HMHelp.htm"
  File "Abel3.lnk"
  File "Beltow95.lnk"
  File "RingingMaster.lnk"
  File "Copying.txt"
  File /r "HMHelp_files"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\HandbellManager "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\HandbellManager" "DisplayName" "Handbell Manager"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\HandbellManager" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\HandbellManager" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\HandbellManager" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts (all users)"
  ; Create start menu shortcuts for all users
  SetShellVarContext all
  CreateDirectory "$SMPROGRAMS\Handbell Manager"
  CreateShortCut "$SMPROGRAMS\Handbell Manager\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\Handbell Manager\HandbellManager.lnk" "$INSTDIR\HandbellManager.exe" "" "$INSTDIR\HandbellManager.exe" 0
  CreateShortCut "$SMPROGRAMS\Handbell Manager\Readme.lnk" "$INSTDIR\HMHelp.htm" "" "$INSTDIR\HMHelp.htm" 0
SectionEnd

; Optional section (can be disabled by the user)
Section "Desktop Shortcut (all users)"
; Create desktop shortcuts for all users
  SetShellVarContext all
  CreateShortCut "$DESKTOP\${MUI_PRODUCT}.lnk" "$INSTDIR\HandbellManager.exe" ""
SectionEnd
;--------------------------------

; Uninstaller

Section "Uninstall"
  ;Remove shortcuts for all users	
  SetShellVarContext all
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\HandbellManager"
  DeleteRegKey HKLM SOFTWARE\HandbellManager

  ; Remove files and uninstaller
  Delete $INSTDIR\HandbellManager.exe
  Delete $INSTDIR\Microsoft.DirectX.DirectInput.dll
  Delete $INSTDIR\Microsoft.DirectX.dll
  Delete $INSTDIR\C2DPushGraph.dll
  Delete $INSTDIR\Abel3.lnk
  Delete $INSTDIR\Beltow95.lnk
  Delete $INSTDIR\RingingMaster.lnk
  Delete $INSTDIR\HMHelp.htm
  Delete $INSTDIR\HMHelp_files\*.*
  Delete $INSTDIR\Copying.txt
  Delete $INSTDIR\uninstall.exe

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\Handbell Manager\*.*"
  Delete "$DESKTOP\${MUI_PRODUCT}.lnk"
  
  ; Remove directories used
  RMDir "$SMPROGRAMS\Handbell Manager"
  RMDir "$INSTDIR\HMHelp_files"
  RMDir "$INSTDIR"

SectionEnd


Function LaunchHandbellManager
  ExecShell "open" "$INSTDIR\HandbellManager.exe"
FunctionEnd
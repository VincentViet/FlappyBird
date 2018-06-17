[Setup]
AppName=FlappyBird
AppVersion=1.0
DefaultDirName={pf32}\Azor\FlappyBird
AlwaysShowDirOnReadyPage=yes
DisableDirPage=no
AppComments=Azor's FlappyBird
AppContact=16521433@gm.uit.edu.vn
AppCopyright=Copyright (C) Azor
AppSupportPhone=(+84)914794591
OutputBaseFilename=FlappyBirdSetup
OutputDir="D:\Games Programing\Monogame\Installer"

[Tasks]
Name: desktopicon; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"
Name: quicklaunchicon; Description: "Create a &Quick Launch icon"; GroupDescription: "Additional icons:"; Flags: unchecked

[Dirs]
Name: "{app}\Content"
Name: "{app}\Content\Backgrounds"
Name: "{app}\Content\Font"
Name: "{app}\Content\Sounds"
Name: "{app}\Content\Sprite"

[Files]
Source: "D:\Games Programing\Monogame\FlappyBird\FlappyBird\bin\Windows\x86\Release\*.*";DestDir:"{app}"
Source: "D:\Games Programing\Monogame\FlappyBird\FlappyBird\bin\Windows\x86\Release\Content\*.*";DestDir:"{app}\Content\"
Source: "D:\Games Programing\Monogame\FlappyBird\FlappyBird\bin\Windows\x86\Release\Content\Backgrounds\*.*";DestDir:"{app}\Content\Backgrounds"
Source: "D:\Games Programing\Monogame\FlappyBird\FlappyBird\bin\Windows\x86\Release\Content\Font\*.*";DestDir:"{app}\Content\Font"
Source: "D:\Games Programing\Monogame\FlappyBird\FlappyBird\bin\Windows\x86\Release\Content\Sounds\*.*";DestDir:"{app}\Content\Sounds"
Source: "D:\Games Programing\Monogame\FlappyBird\FlappyBird\bin\Windows\x86\Release\Content\Sprite\*.*";DestDir:"{app}\Content\Sprite"



[Run]
Filename: "{app}\FlappyBird.exe"; Description: "Launch Calendar"; Flags: postinstall nowait unchecked
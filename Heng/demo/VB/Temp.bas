Attribute VB_Name = "LedDLL"
Option Explicit

Public Declare Function GetKeyDev Lib "KeyCall.dll" () As Integer
Public Declare Function KeySendChar Lib "KeyCall.dll" (ByVal AData As String) As Integer
Public Declare Function MouseDown Lib "KeyCall.dll" (ByVal AKey As Byte) As Integer
Public Declare Function MouseRoll Lib "KeyCall.dll" (ByVal AKey As Byte, ByVal ARoll As Byte) As Integer
Public Declare Function MouseMove Lib "KeyCall.dll" (ByVal AKey As Byte, ByVal X As Integer, ByVal Y As Integer) As Integer
Public Declare Function MouseMoveTo Lib "KeyCall.dll" (ByVal AKey As Byte, ByVal X As Integer, ByVal Y As Integer) As Integer
Public Declare Function MouseMoveToEx Lib "KeyCall.dll" (ByVal AKey As Byte, ByVal X As Integer, ByVal Y As Integer) As Integer
Public Declare Function MouseClick Lib "KeyCall.dll" (ByVal AKey As Byte) As Integer
Public Declare Function MouseDbClick Lib "KeyCall.dll" (ByVal AKey As Byte) As Integer
Public Declare Function KeyDown Lib "KeyCall.dll" (ByVal KeyCtrl As Byte, ByVal AData As String) As Integer
Public Declare Function KeyDownEx Lib "KeyCall.dll" (ByVal AData As String) As Integer
Public Declare Function MouseKeyDownEx Lib "KeyCall.dll" (ByVal AData As String) As Integer
Public Declare Function KeyUp Lib "KeyCall.dll" () As Integer
Public Declare Function KeyDownUp Lib "KeyCall.dll" (ByVal KeyCtrl As Byte, ByVal AData As String) As Integer
Public Declare Function KeyDownUpEx Lib "KeyCall.dll" (ByVal AData As String) As Integer

Public Declare Function KeybdEvent Lib "KeyCall.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long) As Integer
Public Declare Function MouseEvent Lib "KeyCall.dll" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal dwData As Long, ByVal dwExtraInfo As Long) As Integer

Public Sub Main()
   Form1.Show
End Sub

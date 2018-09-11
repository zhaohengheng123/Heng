VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Demo"
   ClientHeight    =   7935
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6855
   LinkTopic       =   "Form1"
   ScaleHeight     =   7935
   ScaleWidth      =   6855
   StartUpPosition =   3  '窗口缺省
   Begin VB.CommandButton Command15 
      Caption         =   "F4"
      Height          =   375
      Left            =   5760
      TabIndex        =   32
      Top             =   3480
      Width           =   615
   End
   Begin VB.Timer Timer6 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   3600
      Top             =   1920
   End
   Begin VB.Timer Timer5 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   3120
      Top             =   1920
   End
   Begin VB.CommandButton Command14 
      Caption         =   "向下滚动"
      Height          =   375
      Left            =   1560
      TabIndex        =   31
      Top             =   1920
      Width           =   1095
   End
   Begin VB.CommandButton Command13 
      Caption         =   "向上滚动"
      Height          =   375
      Left            =   240
      TabIndex        =   30
      Top             =   1920
      Width           =   1095
   End
   Begin VB.CommandButton Command12 
      Caption         =   "按键输入(系统)"
      Height          =   375
      Left            =   240
      TabIndex        =   29
      Top             =   4560
      Width           =   1695
   End
   Begin VB.TextBox Text5 
      Height          =   270
      Left            =   4320
      TabIndex        =   28
      Text            =   "123"
      Top             =   4320
      Width           =   1740
   End
   Begin VB.CommandButton Command11 
      Caption         =   "按键输入(系统)"
      Height          =   375
      Left            =   240
      TabIndex        =   27
      Top             =   4200
      Width           =   1695
   End
   Begin VB.CommandButton Command9 
      Caption         =   "按键输入"
      Height          =   375
      Left            =   240
      TabIndex        =   25
      Top             =   3600
      Width           =   1095
   End
   Begin VB.CommandButton Command10 
      Caption         =   "按键放开"
      Height          =   375
      Left            =   240
      TabIndex        =   26
      Top             =   3240
      Width           =   1095
   End
   Begin VB.CheckBox Check7 
      Caption         =   "WIN"
      Height          =   375
      Index           =   1
      Left            =   4680
      TabIndex        =   22
      Top             =   3600
      Width           =   975
   End
   Begin VB.CheckBox Check6 
      Caption         =   "Shift"
      Height          =   375
      Index           =   1
      Left            =   3720
      TabIndex        =   21
      Top             =   3600
      Width           =   855
   End
   Begin VB.CheckBox Check5 
      Caption         =   "Alt"
      Height          =   375
      Index           =   1
      Left            =   2880
      TabIndex        =   20
      Top             =   3600
      Width           =   735
   End
   Begin VB.CheckBox Check4 
      Caption         =   "Ctrl"
      Height          =   375
      Index           =   1
      Left            =   1920
      TabIndex        =   19
      Top             =   3600
      Width           =   735
   End
   Begin VB.CheckBox Check7 
      Caption         =   "WIN"
      Height          =   375
      Index           =   0
      Left            =   4680
      TabIndex        =   18
      Top             =   3240
      Width           =   975
   End
   Begin VB.CheckBox Check6 
      Caption         =   "Shift"
      Height          =   375
      Index           =   0
      Left            =   3720
      TabIndex        =   17
      Top             =   3240
      Width           =   855
   End
   Begin VB.CheckBox Check5 
      Caption         =   "Alt"
      Height          =   375
      Index           =   0
      Left            =   2880
      TabIndex        =   16
      Top             =   3240
      Width           =   735
   End
   Begin VB.CheckBox Check4 
      Caption         =   "Ctrl"
      Height          =   375
      Index           =   0
      Left            =   1920
      TabIndex        =   15
      Top             =   3240
      Width           =   735
   End
   Begin VB.Timer Timer4 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   4200
      Top             =   2640
   End
   Begin VB.CommandButton Command8 
      Caption         =   "延时拖动"
      Height          =   375
      Left            =   240
      TabIndex        =   14
      Top             =   2760
      Width           =   1095
   End
   Begin VB.CommandButton Command5 
      Caption         =   "定位"
      Height          =   375
      Left            =   4680
      TabIndex        =   13
      Top             =   2400
      Width           =   1215
   End
   Begin VB.TextBox Text4 
      Height          =   375
      Left            =   2640
      TabIndex        =   12
      Text            =   "15"
      Top             =   2400
      Width           =   735
   End
   Begin VB.TextBox Text3 
      Height          =   375
      Left            =   1560
      TabIndex        =   11
      Text            =   "15"
      Top             =   2400
      Width           =   615
   End
   Begin VB.Timer Timer3 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   4200
      Top             =   2280
   End
   Begin VB.CommandButton Command4 
      Caption         =   "延时移动"
      Height          =   375
      Left            =   240
      TabIndex        =   10
      Top             =   2400
      Width           =   1095
   End
   Begin VB.CommandButton Command3 
      Caption         =   "延时双击"
      Height          =   375
      Left            =   240
      TabIndex        =   9
      Top             =   1440
      Width           =   1095
   End
   Begin VB.Timer Timer2 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   4200
      Top             =   1440
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   4200
      Top             =   1080
   End
   Begin VB.CheckBox Check2 
      Caption         =   "右"
      Height          =   375
      Left            =   3480
      TabIndex        =   8
      Top             =   1200
      Width           =   735
   End
   Begin VB.CheckBox Check3 
      Caption         =   "中"
      Height          =   375
      Left            =   2520
      TabIndex        =   7
      Top             =   1200
      Width           =   735
   End
   Begin VB.CheckBox Check1 
      Caption         =   "左"
      Height          =   375
      Left            =   1560
      TabIndex        =   6
      Top             =   1200
      Value           =   1  'Checked
      Width           =   615
   End
   Begin VB.CommandButton Command2 
      Caption         =   "延时单击"
      Height          =   375
      Left            =   240
      TabIndex        =   5
      Top             =   1080
      Width           =   1095
   End
   Begin VB.TextBox Text2 
      Height          =   1095
      Left            =   240
      TabIndex        =   4
      Top             =   5280
      Width           =   5775
   End
   Begin VB.CommandButton Command6 
      Caption         =   "输入字符串"
      Height          =   375
      Left            =   240
      TabIndex        =   3
      Top             =   600
      Width           =   1095
   End
   Begin VB.TextBox Text1 
      Height          =   270
      Left            =   1560
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   600
      Width           =   3660
   End
   Begin VB.CommandButton Command7 
      Height          =   375
      Left            =   1560
      TabIndex        =   1
      Top             =   120
      Width           =   975
   End
   Begin VB.CommandButton Command1 
      Caption         =   "仿真设备"
      Height          =   375
      Left            =   240
      TabIndex        =   0
      Top             =   120
      Width           =   1095
   End
   Begin VB.Label Label2 
      Caption         =   "右"
      Height          =   255
      Left            =   1560
      TabIndex        =   24
      Top             =   3720
      Width           =   255
   End
   Begin VB.Label Label1 
      Caption         =   "左"
      Height          =   255
      Left            =   1560
      TabIndex        =   23
      Top             =   3360
      Width           =   255
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Sub Sleep Lib "Kernel32" (ByVal dwMilliseconds As Long)

Private Sub Command1_Click()
  Command7.Caption = CStr(GetKeyDev())
  
End Sub

Private Sub Command10_Click()
    Dim i As Integer
    Dim s As String
    i = 0
    If Check4(0).Value Then
        i = i + 1
    End If
    If Check5(0).Value Then
        i = i + 4
    End If
    If Check6(0).Value Then
        i = i + 2
    End If
    If Check7(0).Value Then
        i = i + 8
    End If
    If Check4(1).Value Then
        i = i + 16
    End If
    If Check5(1).Value Then
        i = i + 64
    End If
    If Check6(1).Value Then
        i = i + 32
    End If
    If Check7(1).Value Then
        i = i + 128
    End If
    Text2.SetFocus
    s = Chr(30) & Chr(31) & Chr(0)
    i = KeyDown(i, s)
    Sleep (15)
    i = KeyUp()
End Sub

Private Sub Command11_Click()
    Text2.SetFocus
    KeyDownEx (Text5.Text)
    Sleep (15)
    KeyDownEx ("")
End Sub

Private Sub Command12_Click()
    Text2.SetFocus
    KeyDownUpEx (Text5.Text)
End Sub

Private Sub Command13_Click()
    Timer5.Enabled = True
End Sub

Private Sub Command14_Click()
    Timer6.Enabled = True
End Sub

Private Sub Command15_Click()
    Dim i As Integer
    Dim s As String
    i = 0
    If Check4(0).Value Then
        i = i + 1
    End If
    If Check5(0).Value Then
        i = i + 4
    End If
    If Check6(0).Value Then
        i = i + 2
    End If
    If Check7(0).Value Then
        i = i + 8
    End If
    If Check4(1).Value Then
        i = i + 16
    End If
    If Check5(1).Value Then
        i = i + 64
    End If
    If Check6(1).Value Then
        i = i + 32
    End If
    If Check7(1).Value Then
        i = i + 128
    End If
    Text2.SetFocus
    s = Chr(61) & Chr(0)
    i = KeyDownUp(0, s)
End Sub

Private Sub Command2_Click()
    Timer1.Enabled = True
End Sub

Private Sub Command3_Click()
    Timer2.Enabled = True
End Sub

Private Sub Command4_Click()
    Timer3.Enabled = True
End Sub

Private Sub Command5_Click()
    Dim i As Integer
    i = MouseMove(0, CInt(Text3.Text), CInt(Text4.Text))
End Sub

Private Sub Command6_Click()
    Text2.SetFocus
    KeySendChar (Text1.Text)
End Sub

Private Sub Command8_Click()
    Timer4.Enabled = True
End Sub

Private Sub Command9_Click()
    Dim i As Integer
    i = 0
    If Check4(0).Value Then
        i = i + 1
    End If
    If Check5(0).Value Then
        i = i + 4
    End If
    If Check6(0).Value Then
        i = i + 2
    End If
    If Check7(0).Value Then
        i = i + 8
    End If
    If Check4(1).Value Then
        i = i + 16
    End If
    If Check5(1).Value Then
        i = i + 64
    End If
    If Check6(1).Value Then
        i = i + 32
    End If
    If Check7(1).Value Then
        i = i + 128
    End If
    Text2.SetFocus
    i = KeyDownUp(i, Chr(31))
End Sub
 

Private Sub Timer1_Timer()
    Dim i As Integer
    Timer1.Enabled = False
    i = 0
    If Check1.Value Then
        i = i + 1
    End If
    If Check2.Value Then
        i = i + 2
    End If
    If Check3.Value Then
        i = i + 4
    End If
    i = MouseClick(i)
End Sub

Private Sub Timer2_Timer()
    Dim i As Integer
    Timer2.Enabled = False
    i = 0
    If Check1.Value = 1 Then
        i = (i + 1)
    End If
    If Check2.Value = 1 Then
        i = (i + 2)
    End If
    If Check3.Value = 1 Then
        i = (i + 4)
    End If
    i = MouseDbClick(i)
End Sub

Private Sub Timer3_Timer()
    Dim i As Integer
    Timer3.Enabled = False
    i = MouseMove(0, CInt(Text3.Text), CInt(Text4.Text))
End Sub

Private Sub Timer4_Timer()
    Dim i As Integer
    Dim j As Integer
    Timer4.Enabled = False
    i = 0
    If Check1.Value Then
        i = i + 1
    End If
    If Check2.Value Then
        i = i + 2
    End If
    If Check3.Value Then
        i = i + 4
    End If
    j = MouseDown(i)
    Sleep (15)
    j = MouseMove(i, CInt(Text3.Text), CInt(Text4.Text))
    Sleep (15)
    j = MouseDown(0)
End Sub

Private Sub Timer5_Timer()
    Dim i As Integer
    Timer5.Enabled = False
    i = MouseRoll(0, 1)
End Sub

Private Sub Timer6_Timer()
    Dim i As Integer
    Timer6.Enabled = False
    i = MouseRoll(0, 255)
End Sub

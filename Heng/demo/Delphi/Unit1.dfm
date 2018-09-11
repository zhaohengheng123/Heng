object Form1: TForm1
  Left = 825
  Top = 163
  Width = 498
  Height = 517
  Caption = 'Demo'
  Color = clBtnFace
  Font.Charset = ANSI_CHARSET
  Font.Color = clWindowText
  Font.Height = -14
  Font.Name = #23435#20307
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 14
  object Label1: TLabel
    Left = 136
    Top = 160
    Width = 7
    Height = 14
    Caption = 'X'
  end
  object Label2: TLabel
    Left = 200
    Top = 160
    Width = 7
    Height = 14
    Caption = 'Y'
  end
  object Label3: TLabel
    Left = 136
    Top = 264
    Width = 28
    Height = 14
    Caption = #24038#65306
  end
  object Label4: TLabel
    Left = 136
    Top = 280
    Width = 28
    Height = 14
    Caption = #21491#65306
  end
  object Bevel1: TBevel
    Left = 16
    Top = 136
    Width = 433
    Height = 17
    Shape = bsTopLine
  end
  object Bevel2: TBevel
    Left = 16
    Top = 208
    Width = 433
    Height = 17
    Shape = bsTopLine
  end
  object Bevel3: TBevel
    Left = 16
    Top = 312
    Width = 433
    Height = 17
    Shape = bsTopLine
  end
  object Bevel4: TBevel
    Left = 16
    Top = 40
    Width = 433
    Height = 17
    Shape = bsTopLine
  end
  object Label5: TLabel
    Left = 304
    Top = 190
    Width = 119
    Height = 14
    Caption = #25302#21160#27979#35797#26377#24310#26102'2'#31186
    Font.Charset = ANSI_CHARSET
    Font.Color = clMaroon
    Font.Height = -14
    Font.Name = #23435#20307
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 256
    Top = 110
    Width = 189
    Height = 14
    Caption = #21333#12289#21452#20987#12289#28378#21160#27979#35797#26377#24310#26102'2'#31186
    Font.Charset = ANSI_CHARSET
    Font.Color = clMaroon
    Font.Height = -14
    Font.Name = #23435#20307
    Font.Style = []
    ParentFont = False
  end
  object Label7: TLabel
    Left = 136
    Top = 184
    Width = 42
    Height = 14
    Caption = 'Label7'
  end
  object Button2: TButton
    Left = 24
    Top = 8
    Width = 97
    Height = 25
    Caption = #36755#20837#23383#31526#20018
    TabOrder = 0
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 136
    Top = 8
    Width = 233
    Height = 22
    TabOrder = 1
    Text = 'ABCDEFGaaa123'
  end
  object CheckBox1: TCheckBox
    Left = 136
    Top = 64
    Width = 57
    Height = 17
    Caption = #24038#38190
    Checked = True
    State = cbChecked
    TabOrder = 2
  end
  object CheckBox2: TCheckBox
    Left = 208
    Top = 64
    Width = 57
    Height = 17
    Caption = #20013#38190
    TabOrder = 3
  end
  object CheckBox3: TCheckBox
    Left = 280
    Top = 64
    Width = 49
    Height = 17
    Caption = #21491#38190
    TabOrder = 4
  end
  object Button3: TButton
    Left = 24
    Top = 48
    Width = 97
    Height = 25
    Caption = #40736#26631#24310#26102#21333#20987
    TabOrder = 5
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 24
    Top = 72
    Width = 97
    Height = 25
    Caption = #40736#26631#24310#26102#21452#20987
    TabOrder = 6
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 24
    Top = 144
    Width = 97
    Height = 25
    Caption = #40736#26631#31227#21160
    TabOrder = 7
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 24
    Top = 176
    Width = 97
    Height = 25
    Caption = #40736#26631#25302#21160
    TabOrder = 8
    OnClick = Button6Click
  end
  object Edit2: TEdit
    Left = 152
    Top = 160
    Width = 33
    Height = 22
    TabOrder = 9
    Text = '30'
  end
  object Edit3: TEdit
    Left = 216
    Top = 160
    Width = 33
    Height = 22
    TabOrder = 10
    Text = '30'
  end
  object Button7: TButton
    Left = 24
    Top = 248
    Width = 97
    Height = 25
    Caption = #25353#38190#12289#25918#24320
    TabOrder = 11
    OnClick = Button7Click
  end
  object Button8: TButton
    Left = 24
    Top = 280
    Width = 97
    Height = 25
    Caption = #25353#38190#36755#20837
    TabOrder = 12
    OnClick = Button8Click
  end
  object CheckBox4: TCheckBox
    Left = 168
    Top = 264
    Width = 49
    Height = 17
    Caption = 'Ctrl'
    TabOrder = 13
  end
  object CheckBox5: TCheckBox
    Left = 232
    Top = 264
    Width = 49
    Height = 17
    Caption = 'Alt'
    TabOrder = 14
  end
  object CheckBox6: TCheckBox
    Left = 288
    Top = 264
    Width = 57
    Height = 17
    Caption = 'Shift'
    TabOrder = 15
  end
  object CheckBox7: TCheckBox
    Left = 368
    Top = 264
    Width = 57
    Height = 17
    Caption = 'WIN'
    TabOrder = 16
  end
  object CheckBox8: TCheckBox
    Left = 168
    Top = 280
    Width = 49
    Height = 17
    Caption = 'Ctrl'
    TabOrder = 17
  end
  object CheckBox9: TCheckBox
    Left = 232
    Top = 280
    Width = 49
    Height = 17
    Caption = 'Alt'
    TabOrder = 18
  end
  object CheckBox10: TCheckBox
    Left = 288
    Top = 280
    Width = 57
    Height = 17
    Caption = 'Shift'
    TabOrder = 19
  end
  object CheckBox11: TCheckBox
    Left = 368
    Top = 280
    Width = 57
    Height = 17
    Caption = 'WIN'
    TabOrder = 20
  end
  object Memo1: TMemo
    Left = 24
    Top = 336
    Width = 409
    Height = 89
    TabOrder = 21
  end
  object Button1: TButton
    Left = 24
    Top = 216
    Width = 137
    Height = 25
    Caption = #25353#38190#24310#26102#36755#20837'('#31995#32479')'
    TabOrder = 22
    OnClick = Button1Click
  end
  object Button9: TButton
    Left = 288
    Top = 144
    Width = 97
    Height = 25
    Caption = #40736#26631#23450#20301
    TabOrder = 23
    OnClick = Button9Click
  end
  object Button11: TButton
    Left = 168
    Top = 216
    Width = 137
    Height = 25
    Caption = #25353#38190#12289#25918#24320'('#31995#32479')'
    TabOrder = 24
    OnClick = Button11Click
  end
  object Edit4: TEdit
    Left = 312
    Top = 218
    Width = 121
    Height = 22
    CharCase = ecUpperCase
    TabOrder = 25
    Text = '123'
  end
  object Button10: TButton
    Left = 24
    Top = 104
    Width = 97
    Height = 25
    Caption = #21521#19978#28378#21160
    TabOrder = 26
    OnClick = Button10Click
  end
  object Button12: TButton
    Left = 136
    Top = 104
    Width = 97
    Height = 25
    Caption = #21521#19979#28378#21160
    TabOrder = 27
    OnClick = Button12Click
  end
  object Timer1: TTimer
    Enabled = False
    Interval = 2000
    OnTimer = Timer1Timer
    Left = 248
    Top = 160
  end
  object Timer2: TTimer
    Interval = 300
    OnTimer = Timer2Timer
    Left = 376
    Top = 48
  end
end

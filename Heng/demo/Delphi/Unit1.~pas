unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TTTT_Ctrl = (TTT_None, TTT_Click, TTT_DbClick, TTT_MouseUp, TTT_MouseDown, TTT_Move, TTT_MoveClick, TTT_Call);
  TForm1 = class(TForm)
    Button2: TButton;
    Edit1: TEdit;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    Button3: TButton;
    Timer1: TTimer;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Edit2: TEdit;
    Edit3: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Button7: TButton;
    Button8: TButton;
    CheckBox4: TCheckBox;
    CheckBox5: TCheckBox;
    CheckBox6: TCheckBox;
    CheckBox7: TCheckBox;
    CheckBox8: TCheckBox;
    CheckBox9: TCheckBox;
    CheckBox10: TCheckBox;
    CheckBox11: TCheckBox;
    Label3: TLabel;
    Label4: TLabel;
    Memo1: TMemo;
    Bevel1: TBevel;
    Bevel2: TBevel;
    Bevel3: TBevel;
    Bevel4: TBevel;
    Label5: TLabel;
    Label6: TLabel;
    Button1: TButton;
    Button9: TButton;
    Timer2: TTimer;
    Label7: TLabel;
    Button11: TButton;
    Edit4: TEdit;
    Button10: TButton;
    Button12: TButton;
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
  private
    TTT_Ctrl: TTTT_Ctrl;
  public
    { Public declarations }
  end;

  function MGetKeyDev(): Integer; stdcall; external 'KeyCall.dll' name 'GetKeyDev';
  function MKeySendChar(const AData: PChar): Integer;stdcall;external 'KeyCall.dll' name 'KeySendChar';
  function MMouseDown(const AKey: Byte): Integer;stdcall;external 'KeyCall.dll' name 'MouseDown';
  function MMouseRoll(const AKey, ARoll: Byte): Integer;stdcall;external 'KeyCall.dll' name 'MouseRoll';
  function MMouseMove(const AKey: Byte; X, Y: Integer): Integer;stdcall;external 'KeyCall.dll' name 'MouseMove';
  function MMouseMoveTo(const AKey: Byte; X, Y: Integer): Integer;stdcall;external 'KeyCall.dll' name 'MouseMoveTo';
  function MMouseClick(const AKey: Byte): Integer;stdcall;external 'KeyCall.dll' name 'MouseClick';
  function MMouseDbClick(const AKey: Byte): Integer;stdcall;external 'KeyCall.dll' name 'MouseDbClick';
  function MKeyDown(const KeyCtrl: Byte; const AData: PChar): Integer;stdcall;external 'KeyCall.dll' name 'KeyDown';
  function MKeyDownEx(const AData: PChar): Integer;stdcall;external 'KeyCall.dll' name 'KeyDownEx';
  function MKeyUp(): Integer;stdcall;external 'KeyCall.dll' name 'KeyUp';
  function MKeyDownUp(const KeyCtrl: Byte; const AData: PChar): Integer;stdcall;external 'KeyCall.dll' name 'KeyDownUp';
  function MKeyDownUpEx(const AData: PChar): Integer;stdcall;stdcall;external 'KeyCall.dll' name 'KeyDownUpEx';

  procedure KeybdEvent(bVk: Byte; bScan: Byte; dwFlags, dwExtraInfo: DWORD); stdcall;external 'KeyCall.dll' name 'KeybdEvent';
  procedure MouseEvent(dwFlags, dx, dy, dwData, dwExtraInfo: DWORD); stdcall;external 'KeyCall.dll' name 'MouseEvent';

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button2Click(Sender: TObject);
begin
  Memo1.SetFocus;
  MKeySendChar(PChar(Edit1.Text));
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  if CheckBox1.Checked or CheckBox2.Checked or CheckBox3.Checked then
  begin
    TTT_Ctrl := TTT_Click;
    Timer1.Enabled := True;   
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  TTT_Ctrl := TTT_None;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
var
  vKey: Byte;
begin
  Timer1.Enabled := False;
  vKey := (Byte(CheckBox1.Checked) * $01) or
          (Byte(CheckBox2.Checked) * $04) or
          (Byte(CheckBox3.Checked) * $02);
  case TTT_Ctrl of
    TTT_Click: begin
      MMouseClick(vKey);
      TTT_Ctrl := TTT_None;
    end;
    TTT_DbClick: begin
      MMouseDbClick(vKey);
      TTT_Ctrl := TTT_None;
    end;
    TTT_MoveClick: begin
      MMouseDown(vKey);
      Sleep(15);
      MMouseMove(vKey, StrToIntDef(Edit2.Text,0), StrToIntDef(Edit3.Text,0));
      Sleep(15);
      MMouseDown(0);
      TTT_Ctrl := TTT_None;
    end;
    TTT_Call: begin
      MKeyDownEx(PChar(Edit4.Text));
      Sleep(15);
      MKeyDownEx('');
      TTT_Ctrl := TTT_None;
    end;
    TTT_Move: begin
{      MMouseClick(1);
      Sleep(15);
      MKeySendChar('1');
      Sleep(1000);
      MMouseMove(0, StrToIntDef(Edit2.Text,0), StrToIntDef(Edit3.Text,0));
      Sleep(15);
      MMouseClick(1);
      MKeySendChar('111');  }

      MMouseMove(0, StrToIntDef(Edit2.Text,0), StrToIntDef(Edit3.Text,0));
    end;
    TTT_MouseUp: begin
      //MMouseRoll(vKey, 1);
      MMouseRoll(vKey, 1);
      TTT_Ctrl := TTT_None;
    end;
    TTT_MouseDown: begin
      //MMouseRoll(vKey, 255);
      MMouseRoll(vKey, 255);
      TTT_Ctrl := TTT_None;
    end;
  end;
//  Beep();
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  if CheckBox1.Checked or CheckBox2.Checked or CheckBox3.Checked then
  begin
    TTT_Ctrl := TTT_DbClick;
    Timer1.Enabled := True;
  end;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
//  MMouseMove(0, StrToIntDef(Edit2.Text,0), StrToIntDef(Edit3.Text,0));
  TTT_Ctrl := TTT_Move;
  Timer1.Enabled := True;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  if CheckBox1.Checked or CheckBox2.Checked or CheckBox3.Checked then
  begin
    TTT_Ctrl := TTT_MoveClick;
    Timer1.Enabled := True;
  end;
end;

procedure TForm1.Button7Click(Sender: TObject);
var
  vKey: Byte;
begin
  vKey := (Byte(CheckBox4.Checked) * $01) or
          (Byte(CheckBox5.Checked) * $04) or
          (Byte(CheckBox6.Checked) * $02) or
          (Byte(CheckBox7.Checked) * $08) or
          (Byte(CheckBox8.Checked) * $10) or
          (Byte(CheckBox9.Checked) * $40) or
          (Byte(CheckBox10.Checked) * $20) or
          (Byte(CheckBox11.Checked) * $80);
  Memo1.SetFocus;
  MKeyDown(vKey, #$1e#$1f);
  Sleep(15);
  MKeyUp();
end;

procedure TForm1.Button8Click(Sender: TObject);
var
  vKey: Byte;
begin
  vKey := (Byte(CheckBox4.Checked) * $01) or
          (Byte(CheckBox5.Checked) * $04) or
          (Byte(CheckBox6.Checked) * $02) or
          (Byte(CheckBox7.Checked) * $08) or
          (Byte(CheckBox8.Checked) * $10) or
          (Byte(CheckBox9.Checked) * $40) or
          (Byte(CheckBox10.Checked) * $20) or
          (Byte(CheckBox11.Checked) * $80);
  Memo1.SetFocus;
  MKeyDownUp(vKey, #$1e);
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  TTT_Ctrl := TTT_Call;
  Timer1.Enabled := True;
end;

procedure TForm1.Button9Click(Sender: TObject);
begin
  MMouseMoveTo(0, StrToIntDef(Edit2.Text,0), StrToIntDef(Edit3.Text,0));
end;

procedure TForm1.Timer2Timer(Sender: TObject);
var
  Pt: TPoint;
begin
  GetCursorPos(Pt);
  Label7.Caption := 'X: ' + IntToStr(PT.X) + ', Y: ' + IntToStr(PT.Y);
end;

procedure TForm1.Button11Click(Sender: TObject);
begin
  Memo1.SetFocus;
  MKeyDownUpEx(PChar(Edit4.Text));
end;

procedure TForm1.Button10Click(Sender: TObject);
begin
  TTT_Ctrl := TTT_MouseUp;
  Timer1.Enabled := True;
end;

procedure TForm1.Button12Click(Sender: TObject);
begin
  TTT_Ctrl := TTT_MouseDown;
  Timer1.Enabled := True;
end;

end.

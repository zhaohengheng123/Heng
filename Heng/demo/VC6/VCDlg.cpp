// VCDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VC.h"
#include "VCDlg.h"
#include "KeyCall.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVCDlg dialog

CVCDlg::CVCDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CVCDlg::IDD, pParent)
{

	//{{AFX_DATA_INIT(CVCDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CVCDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CVCDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CVCDlg, CDialog)
	//{{AFX_MSG_MAP(CVCDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON3, OnButton3)
	ON_BN_CLICKED(IDC_BUTTON2, OnButton2)
	ON_BN_CLICKED(IDC_BUTTON1, OnButton1)
	ON_BN_CLICKED(IDC_BUTTON5, OnButton5)
	ON_BN_CLICKED(IDC_BUTTON6, OnButton6)
	ON_BN_CLICKED(IDC_BUTTON7, OnButton7)
	ON_BN_CLICKED(IDC_BUTTON8, OnButton8)
	ON_BN_CLICKED(IDC_BUTTON9, OnButton9)
	ON_BN_CLICKED(IDC_BUTTON10, OnButton10)
	ON_BN_CLICKED(IDC_BUTTON11, OnButton11)
	ON_BN_CLICKED(IDC_BUTTON12, OnButton12)
	ON_BN_CLICKED(IDC_BUTTON4, OnButton4)
	ON_BN_CLICKED(IDC_BUTTON13, OnButton13)
	ON_BN_CLICKED(IDC_BUTTON14, OnButton14)
	ON_BN_CLICKED(IDC_BUTTON15, OnButton15)
	ON_BN_CLICKED(IDC_BUTTON16, OnButton16)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVCDlg message handlers

BOOL CVCDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	
	CString tmp;
	tmp.Format("%s", "AABcedf12345");
	GetDlgItem(IDC_EDIT2)->SetWindowText(tmp);
	GetDlgItem(IDC_EDIT5)->SetWindowText("50");
	GetDlgItem(IDC_EDIT6)->SetWindowText("50");
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CVCDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CVCDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CVCDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CVCDlg::OnButton3() 
{
	CString tmp;
	GetDlgItem(IDC_EDIT2)->GetWindowText(tmp);
	char *p =(LPSTR)(LPCTSTR)tmp;
	GetDlgItem(IDC_EDIT1)->SetFocus();
	KeySendChar(p);
}

void CVCDlg::OnButton2() 
{
	Sleep(1500);
	MouseRoll(0, 1);
}

void CVCDlg::OnButton1() 
{
}

void CVCDlg::OnButton5() 
{
}

void CVCDlg::OnButton6() 
{
	
}

void CVCDlg::OnButton7() 
{
	
}

void CVCDlg::OnButton8() 
{
	
}

void CVCDlg::OnButton9() 
{
	
}

void CVCDlg::OnButton10() 
{
	
}

void CVCDlg::OnButton11() 
{
	
}

void CVCDlg::OnButton12() 
{

	
}

void CVCDlg::OnButton4() 
{
	Sleep(1500);
	MouseClick(1);
}

void CVCDlg::OnButton13() 
{
	Sleep(1500);
	MouseDbClick(1);
}

void CVCDlg::OnButton14() 
{
	Sleep(1500);
	MouseRoll(0, 255);
}

void CVCDlg::OnButton15() 
{
	int x, y;
	CString tmp;
	Sleep(1500);
	GetDlgItem(IDC_EDIT5)->GetWindowText(tmp);
	x = atoi(tmp);
	GetDlgItem(IDC_EDIT6)->GetWindowText(tmp);
	y = atoi(tmp);
	MouseMove(0, x, y);
}

void CVCDlg::OnButton16() 
{
	int x, y;
	CString tmp;
	Sleep(1500);
	MouseDown(1);
	Sleep(15);
	GetDlgItem(IDC_EDIT5)->GetWindowText(tmp);
	x = atoi(tmp);
	GetDlgItem(IDC_EDIT6)->GetWindowText(tmp);
	y = atoi(tmp);
	MouseMove(1, x, y);
	Sleep(15);
	MouseDown(0);
}

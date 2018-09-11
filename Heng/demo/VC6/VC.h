// VC.h : main header file for the VC application
//

#if !defined(AFX_VC_H__384FADA1_B294_4D0B_AEB7_79AFC09202F9__INCLUDED_)
#define AFX_VC_H__384FADA1_B294_4D0B_AEB7_79AFC09202F9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CVCApp:
// See VC.cpp for the implementation of this class
//

class CVCApp : public CWinApp
{
public:
	CVCApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CVCApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CVCApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VC_H__384FADA1_B294_4D0B_AEB7_79AFC09202F9__INCLUDED_)

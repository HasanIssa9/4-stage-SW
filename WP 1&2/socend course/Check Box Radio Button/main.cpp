#include <windows.h>
#include <string.h>
#include <stdio.h>
#include "header.h"
#define VERTRANGEMAX 200

LRESULT CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK DialogFunc(HWND, UINT, WPARAM, LPARAM);
char szWinName[ ] = "MyWin"; /* name of window class */ HINSTANCE hInst;
HWND hwnd;

int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst, LPSTR IpszArgs, int nWinMode)

{
    MSG msg;
    WNDCLASSEX wcl;
    HACCEL hAccel;
    wcl.cbSize = sizeof(WNDCLASSEX);
    wcl.hInstance = hThisInst;
    wcl.lpszClassName = szWinName;
    wcl.lpfnWndProc = WindowFunc;
    wcl.style = 0;
    wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wcl.hIconSm = LoadIcon(NULL, IDI_WINLOGO);
    wcl.hCursor = LoadCursor(NULL, IDC_ARROW);
    wcl.lpszMenuName = "Mymenu";
    wcl.cbClsExtra =0;
    wcl.cbWndExtra=0;
    wcl.hbrBackground = WHITE_BRUSH;
    if(!RegisterClassEx(&wcl)) return 0;
    hwnd=CreateWindow(szWinName, "Demonstrating Controls",
                      WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT,
                      CW_USEDEFAULT, CW_USEDEFAULT, HWND_DESKTOP, NULL, hThisInst, NULL );
    hInst = hThisInst; /* save the current instance handle */
    /* load accelerators */ hAccel = LoadAccelerators (hThisInst, "Mymenu");
    /* Display the window. */

    ShowWindow(hwnd, nWinMode);
    UpdateWindow(hwnd);
    while (GetMessage(&msg,NULL,0,0))
    {
        if ( !TranslateAccelerator (hwnd, hAccel, &msg))
        {
            TranslateMessage(&msg) ;
            DispatchMessage( &msg );
        }
    }
    return msg.wParam;
}
/* This function is called by Windows NT and is passedmessages from the message queue. */

LRESULT CALLBACK WindowFunc (HWND hwnd, UINT message,
                             WPARAM wParam, LPARAM lParam)
{
    int response;
    switch (message)
    {
    case WM_COMMAND:
        switch (LOWORD(wParam) )
        {
        case IDM_DIALOG:
            DialogBox(hInst, "MyDB", hwnd, (DLGPROC) DialogFunc);
            break;
        case IDM_EXIT:
            response=MessageBox (hwnd,"Quit the Program?","Exit", MB_YESNO) ;
            if (response == IDYES) PostQuitMessage (0) ;
            break;
        case IDM_HELP:
            MessageBox (hwnd, "Try the Timer", "Help", MB_OK) ;
            break;
        }
        break;
    case WM_DESTROY: /* terminate the program */
        PostQuitMessage (0) ;
        break;
    default:
        return DefWindowProc (hwnd, message, wParam, lParam) ;
    }
    return 0;
}
BOOL CALLBACK DialogFunc (HWND hdwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    char str [80] ;
    static int vpos=0;
    static SCROLLINFO si;
    HDC hdc;
    PAINTSTRUCT paintstruct ;
    static int t;
    switch(message)
    {
    case WM_COMMAND:
        switch (LOWORD (wParam) )

        {
        case IDCANCEL:
            EndDialog (hdwnd, 0) ;
            return 1;
        case IDD_START: /* start the timer */
            SetTimer (hdwnd, IDD_TIMER, 1000, NULL) ;
            t = vpos ;
            if(SendDlgItemMessage(hdwnd,IDD_RB1,BM_GETCHECK,0,0)==BST_CHECKED)
            {
                ShowWindow(hdwnd, SW_MINIMIZE);
            }
            if(SendDlgItemMessage(hdwnd,IDD_RB2,BM_GETCHECK,0,0)==BST_CHECKED)
                ShowWindow(hdwnd, SW_MAXIMIZE);
            return 1;
        }
        break;

    case WM_TIMER:
        if(t==0)
        {
            KillTimer(hdwnd,IDD_TIMER); /*timer went off*/
            if(SendDlgItemMessage(hdwnd,IDD_CB2,BM_GETCHECK,0,0)==BST_CHECKED) MessageBeep (MB_OK) ;
            MessageBox(hdwnd, "Timer Went Off", "Timer", MB_OK);
            ShowWindow(hdwnd, SW_RESTORE);
            return 1;
        }

        t--;/*see if countdown is to be displayed*/
        if(SendDlgItemMessage(hdwnd,IDD_CB1, BM_GETCHECK, 0, 0) == BST_CHECKED)
        {
            hdc = GetDC(hdwnd);
            sprintf(str, "Counting: %d ", t);
            TextOut(hdc, 1, 1, str, strlen(str));
            ReleaseDC(hdwnd, hdc);
            return 1;

        case WM_INITDIALOG:
            si.cbSize = sizeof(SCROLLINFO);
            si.fMask = SIF_RANGE;
            si.nMin = 0;
            si.nMax = VERTRANGEMAX;
            SetScrollInfo(hdwnd, SB_VERT, &si, 1); /* check the As-Is radio button */
            SendDlgItemMessage(hdwnd,IDD_RB3,BM_SETCHECK, BST_CHECKED, 0);
            return 1;

        case WM_PAINT:
            hdc = BeginPaint(hdwnd, &paintstruct);
            sprintf(str, "Interval: %d", vpos);
            TextOut(hdc, 1, 1, str, strlen(str));
            EndPaint (hdwnd, &paintstruct);
            return 1;

        case WM_VSCROLL:
            switch (LOWORD(wParam) )

            {
            case SB_LINEDOWN:
                vpos++;
                if(vpos>VERTRANGEMAX) vpos=VERTRANGEMAX;
                break;
            case SB_LINEUP:
                vpos--;
                if(vpos<0) vpos = 0;
                break;
            case SB_THUMBPOSITION:
                vpos = HIWORD(wParam); /*get current position*/break;
            case SB_THUMBTRACK:
                vpos = HIWORD(wParam); /* get current position */break;
            case SB_PAGEDOWN:
                vpos += 5;
                if(vpos>VERTRANGEMAX) vpos=VERTRANGEMAX;
                break;
            case SB_PAGEUP:
                vpos -= 5;
                if(vpos<0) vpos = 0;
            }

            si.fMask = SIF_POS;
            si.nPos = vpos;
            SetScrollInfo(hdwnd, SB_VERT, &si, 1);
            hdc = GetDC(hdwnd);
            sprintf(str, "Interval: %d ", vpos);
            TextOut(hdc, 1, 1, str, strlen(str));
            ReleaseDC(hdwnd, hdc);
        }
        return 1;
    }
    return 0;
}

#include <windows.h>
#include <string.h>
#include <stdio.h>
#include "header.h"
#define VERTRANGEMAX 200
#define HORZRANGEMAX 50

LRESULT CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK DialogFunc(HWND, UINT, WPARAM, LPARAM);
char szWinName[ ] = "MyWin"; /* name of window class */ HINSTANCE hInst;

int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst, LPSTR IpszArgs, int nWinMode)
{
    HWND hwnd;
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
    hwnd=CreateWindow(szWinName, "Managing Scroll Bars",
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
        switch (LOWORD (wParam) )
        {

        case IDM_DIALOG:
            DialogBox(hInst,"MyDB", hwnd, (DLGPROC) DialogFunc) ;
            break;
        case IDM_EXIT:
            response=MessageBox(hwnd,"Quit the Program?","Exit",MB_YESNO) ;
            if (response == IDYES) PostQuitMessage (0) ;
            break;
        case IDM_HELP:
            MessageBox(hwnd,"No Help","Help",MB_OK) ;
            break;
        }
        break;
    case WM_DESTROY: /* terminate the program */
        PostQuitMessage (0) ;
        break;
    default:
        return DefWindowProc (hwnd,message,wParam,lParam);
    }
    return 0;
}

/* A simple dialog function. */ BOOL CALLBACK DialogFunc (HWND hdwnd, UINT
        message, WPARAM wParam, LPARAM lParam)
{
    char str[80];
    static int vpos = 0;
    static int hpos= 0;
    static SCROLLINFO si;
    HDC hdc;
    PAINTSTRUCT paintstruct;
    switch (message)
    {
    case WM_COMMAND:
        switch (LOWORD (wParam) )
        {

        case IDCANCEL:
            EndDialog(hdwnd, 0);
            return 1;
        }
        break;

    case WM_INITDIALOG:
        si.cbSize = sizeof(SCROLLINFO) ;
        si.fMask = SIF_RANGE;
        si.nMin = 0;
        si.nMax = VERTRANGEMAX;
        SetScrollInfo(hdwnd, SB_VERT, &si, 1);
        si.nMax = HORZRANGEMAX;
        SetScrollInfo(hdwnd, SB_HORZ, &si, 1);
        vpos = hpos = 0;
        return 1;
    case WM_PAINT:
        hdc = BeginPaint(hdwnd, &paintstruct);
        sprintf(str, "Vertical: %d", vpos);
        TextOut(hdc, 1, 1, str, strlen(str));
        sprintf(str, "Horizontal: %d", hpos);
        TextOut(hdc, 1, 30, str, strlen(str));
        EndPaint(hdwnd, &paintstruct);
        return 1;
    case WM_VSCROLL:
        switch(LOWORD(wParam))
        {
        case SB_LINEDOWN:
            vpos++;
            if(vpos>VERTRANGEMAX) vpos = VERTRANGEMAX;
            break;
        case SB_LINEUP:
            vpos--;
            if(vpos<0) vpos = 0;
            break;
        case SB_THUMBPOSITION:
            vpos = HIWORD(wParam);
            break;
        case SB_THUMBTRACK:
            vpos = HIWORD(wParam);
            break;
        case SB_PAGEDOWN:
            vpos += 5;
            if(vpos>VERTRANGEMAX) vpos=VERTRANGEMAX;
            break;
        case SB_PAGEUP:
            vpos -= 5;
            if(vpos<0) vpos = 0;
        }

        /* update vertical bar position */ si.fMask = SIF_POS;
        si.nPos = vpos;
        SetScrollInfo(hdwnd, SB_VERT, &si, 1);
        hdc = GetDC(hdwnd);
        sprintf(str, "Vertical: %d ", vpos);
        TextOut(hdc, 1, 1, str, strlen(str));
        ReleaseDC(hdwnd,hdc);
        return 1;
    case WM_HSCROLL:
        switch(LOWORD(wParam))
        {
            /*Try adding the other event
            handling code for the horizontal scroll bar, here. */
        case SB_LINERIGHT:
            hpos++;
            if(hpos>HORZRANGEMAX) hpos=HORZRANGEMAX;
            break;
        case SB_LINELEFT:
            hpos--;
            if(hpos<0) hpos = 0;
            break;
        case SB_THUMBPOSITION:
            hpos = HIWORD(wParam);
            break;
        case SB_THUMBTRACK:
            hpos = HIWORD(wParam);
            break;
        }
        /* update horizontal bar position */ si.fMask = SIF_POS;
        si.nPos = hpos ;
        SetScrollInfo(hdwnd, SB_HORZ, &si, 1);
        hdc = GetDC(hdwnd);
        sprintf(str, "Horizontal: %d ", hpos);
        TextOut(hdc, 1, 30, str, strlen(str));
        ReleaseDC(hdwnd, hdc);
        return 1;
    }
    return 0;
}


#include <windows.h>
#include <string.h>
#include <stdio.h>
#include "header.h"
#define NUMBOOKS 7

LRESULT CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK DialogFunc(HWND, UINT, WPARAM, LPARAM);
char szWinName[ ] = "MyWin"; /* name of window class */ HINSTANCE hInst;
/* books database */
struct booksTag
{
    char title[40];
    unsigned copyright;
    char author[40];
    char publisher[40];
} books[NUMBOOKS] =
{
    {"C: The Complete Reference", 1995,"Herbert Schildt", "Osborne/McGraw-Hill"},
    {"MFC Programming from the Ground Up", 1996, "Herbert Schildt", "Osborne/McGraw-Hill"},
    {"Java: The Complete Reference", 1997, "Naughton and Schildt", "Osborne/McGraw-Hill"},
    {"Design and Evolution of C++", 1994, "Bjarne Stroustrup", "Addison-Wesley"},
    {"Inside OLE", 1995, "Kraig Brockschmidt", "Microsoft Press"},
    {"HTML Sourcebook", 1996, "lan S. Graham", "John Wiley & Sons"},
    {"Standard C++ Library", 1995, "P. J. Plauger", "Prentice-Hall"}
};

int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst, LPSTR IpszArgs, int
                   nWinMode)
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
    hwnd=CreateWindow(szWinName, "Demonstrate Dialog Boxes",
                      WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT,
                      CW_USEDEFAULT, CW_USEDEFAULT, HWND_DESKTOP, NULL, hThisInst, NULL );
    hInst = hThisInst; /* save the current instance handle */
    /* load accelerators */ hAccel = LoadAccelerators (hThisInst, "Mymenu");
    /* Display the window. */ ShowWindow(hwnd, nWinMode) ;
    UpdateWindow(hwnd) ;
    while (GetMessage(&msg, NULL, 0, 0))
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
            DialogBox(hInst, "MyDB", hwnd, (DLGPROC) DialogFunc);
            break;
        case IDM_EXIT:
            response=MessageBox(hwnd,"Quit the Program?","Exit",MB_YESNO) ;
            if (response == IDYES) PostQuitMessage (0) ;
            break;
        case IDM_HELP:
            MessageBox(hwnd, "No Help", "Help", MB_OK) ;
            break;
        }
        break;
    case WM_DESTROY: /* terminate the program */
        PostQuitMessage (0) ;
        break;
    default:
        return DefWindowProc (hwnd, message, wParam, lParam);
    }
    return 0;
}

/* A simple dialog function. */ BOOL CALLBACK DialogFunc (HWND hdwnd, UINT
        message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
        switch (LOWORD (wParam) )
        {

        case IDCANCEL:
            EndDialog(hdwnd, 0 ) ;
            return 1 ;
        case IDD_COPYRIGHT:
            MessageBox (hdwnd, "Copyright", "Copyright", MB_OK);
            return 1 ;
        case IDD_AUTHOR:
            MessageBox (hdwnd, "Author", "Author", MB_OK) ;
            return 1;
        case IDD_PUBLISHER:
            MessageBox (hdwnd, "Publisher", "Publisher", MB_OK);
            return 1 ;
        }
    }
    return 0 ;
}



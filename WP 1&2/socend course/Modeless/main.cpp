#include <windows.h>
#include <string.h>
#include <stdio.h>
#include "header.h"
#define NUMBOOKS 7
LRESULT CALLBACK WindowFunc (HWND, UINT, WPARAM, LPARAM) ;
BOOL CALLBACK DialogFunc (HWND, UINT, WPARAM, LPARAM) ;
char szWinName [ ] = "MyWin" ; /* name of window class */
HINSTANCE hInst;
HWND hDlg =0; /* dialog box handle */

/* books database */
struct booksTag
{
    char title [40] ;
    unsigned copyright;
    char author[40];
    char publisher [40] ;
}
books[NUMBOOKS] =
{
    {"C: The Complete Reference", 1995,"Hebert Schildt", "Osborne/McGraw-Hill"},
    {"MFC Programming from the Ground Up", 1996, "Herbert Schildt","Osborne/McGraw-Hill"},
    {"Java:The Complete Reference",1997,"Naughton and Schildt","Osborne/McGraw-Hill " },
    {"Design and Evolution of C+ + ", 1994, "Bjarne Stroustrup", "Addison-Wesley" },
    { "Inside OLE", 1995, "Kraig Brockschmidt", "Microsoft Press" },
    {"HTML Sourcebook", 1996, "lan S. Graham", "John Wiley & Sons" },
    {"Standard C++ Library", 1995, "P. J. Plauger", "Prentice-Hall" }
};
int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst,
                   LPSTR IpszArgs, int nWinMode)
{
    HWND hwnd;
    MSG msg;
    WNDCLASSEX wc1;
    HACCEL hAccel;
    wc1.cbSize = sizeof(WNDCLASSEX);
    wc1.hInstance = hThisInst;
    wc1.lpszClassName = szWinName;
    wc1.lpfnWndProc = WindowFunc;
    wc1.style =0;
    wc1.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wc1.hIconSm= LoadIcon(NULL, IDI_WINLOGO);
    wc1.hCursor = LoadCursor(NULL, IDC_ARROW);
    wc1.lpszMenuName = "MyMenu";
    wc1.cbClsExtra = 0;
    wc1.cbWndExtra = 0;
    wc1.hbrBackground = (HBRUSH) GetStockObject(WHITE_BRUSH);
    /* Register the window class. */ if(!RegisterClassEx(&wc1)) return 0;
    /* Now that a window class has been registered, a window can be created. */
    hwnd=CreateWindow(szWinName,"Demonstrate A Modeless Dialog Box",
                      WS_OVERLAPPEDWINDOW,CW_USEDEFAULT,CW_USEDEFAULT,
                      CW_USEDEFAULT,CW_USEDEFAULT,HWND_DESKTOP,
                      NULL, hThisInst, NULL);
    hInst = hThisInst; /* save the current instance handle */
    /* load accelerators */ hAccel = LoadAccelerators (hThisInst, "MyMenu");
    /* Display the window. */ ShowWindow(hwnd, nWinMode) ;
    UpdateWindow(hwnd) ;
    while (GetMessage(&msg, NULL, 0, 0))
    {
        if ( !IsDialogMessage (hDlg, &msg))
            /* is not a dialog message*/
            if (!TranslateAccelerator (hwnd, hAccel, &msg))
            {
                TranslateMessage(&msg) ;
                DispatchMessage( &msg );
            }
    }
    return msg.wParam;
}

/* This function is called by Windows NT and is passed messages from the message queue. */
LRESULT CALLBACK WindowFunc(HWND hwnd, UINT message,
                            WPARAM wParam, LPARAM lParam)
{
    int response;
    switch(message)
    {
    case WM_COMMAND:
        switch(LOWORD(wParam))
        {
        case IDM_DIALOG:
            hDlg = CreateDialog(hInst, "MyDB", hwnd, (DLGPROC)DialogFunc);
            break;

        case IDM_EXIT:
            response = MessageBox(hwnd, "Quit the Program?", "Exit", MB_YESNO);
            if(response == IDYES) PostQuitMessage(0);
            break;
        case IDM_HELP:
            MessageBox(hwnd, "No Help", "Help", MB_OK) ;
            break;
        }
        break;
    case WM_DESTROY: /* terminate the program */
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hwnd, message, wParam, lParam);
    }
    return 0;
}
/* A simple dialog function. */
BOOL CALLBACK DialogFunc(HWND hdwnd, UINT message, WPARAM wParam,
                         LPARAM lParam)
{
    long i;
    char str[255];
    switch(message)
    {
    case WM_INITDIALOG: /* initialize list box */
        for(i = 0; i<NUMBOOKS; i++)
            SendDlgItemMessage(hdwnd, IDD_LB1,LB_ADDSTRING, 0, (LPARAM)books[i].title);
        /* select first item */
        SendDlgItemMessage(hdwnd, IDD_LB1, LB_SETCURSEL, 0, 0);
        /*initialize the edit box*/
        SetDlgItemText(hdwnd, IDD_EB1, books[0] .title);
        return 1;
    case WM_COMMAND:
        switch(LOWORD(wParam))
        {
        case IDCANCEL:
            DestroyWindow(hdwnd);
            return 1;
        case IDD_COPYRIGHT:
            i = SendDlgItemMessage(hdwnd, IDD_LB1, LB_GETCURSEL, 0, 0);
            sprintf(str,"%u", books[i].copyright);
            MessageBox(hdwnd, str, "Copyright", MB_OK);
            return 1;
        case IDD_AUTHOR:
            i = SendDlgItemMessage(hdwnd, IDD_LB1, LB_GETCURSEL, 0, 0);
            sprintf(str, "%s", books[i].author);
            MessageBox(hdwnd, str, "Author", MB_OK);
            return 1;
        case IDD_PUBLISHER:
            i=SendDlgItemMessage(hdwnd, IDD_LB1, LB_GETCURSEL, 0, 0);
            sprintf(str, "%s", books[i].publisher);
            MessageBox(hdwnd, str, "Publisher", MB_OK);
            return 1;
        case IDD_DONE:/*get current contents of edit box*/
            GetDlgItemText(hdwnd, IDD_EB1, str, 80);
            i=SendDlgItemMessage(hdwnd, IDD_LB1, LB_FINDSTRING, 0, (LPARAM) str);
            if(i != LB_ERR) /* if match is found */
            {
                SendDlgItemMessage(hdwnd,IDD_LB1, LB_SETCURSEL, i,0);
                SendDlgItemMessage(hdwnd,IDD_LB1,LB_GETTEXT, i, (LPARAM) str);
                /*update text in edit box*/
                SetDlgItemText(hdwnd, IDD_EB1,str);
            }
            else MessageBox(hdwnd, str, "No Title Matching", MB_OK);
            return 1;

        case IDD_LB1: /* process a list box LBN_DBLCLK */
            if(HIWORD(wParam)==LBN_DBLCLK) /* see if user made a selection */
            {
                i=SendDlgItemMessage(hdwnd, IDD_LB1, LB_GETCURSEL, 0, 0); /*get index*/
                sprintf(str, "%s\n%s\n%s, %u",books[i].title, books[i].author,books[i].publisher,
                        books[i].copyright);
                MessageBox(hdwnd, str, "Selection Made", MB_OK);
                SendDlgItemMessage(hdwnd,IDD_LB1,LB_GETTEXT,i,(LPARAM)str);
                /*update edit box*/ SetDlgItemText(hdwnd, IDD_EB1, str);
                return 1;
            case IDD_SELECT: /* Select Book button has been pressed */
                i = SendDlgItemMessage(hdwnd, IDD_LB1, LB_GETCURSEL, 0, 0); /* get index */
                sprintf (str, "%s\n%s\n%s, %u", books[i].title, books[i].author, books[i].publisher,
                         books[i].copyright);
                MessageBox(hdwnd, str, "Selection Made", MB_OK);
                /*get string associated with that index*/
                SendDlgItemMessage(hdwnd, IDD_LB1, LB_GETTEXT, i, (LPARAM) str);
                /* update edit box */ SetDlgItemText(hdwnd, IDD_EB1, str);
                return 1;
            }
        }
    }
    return 0;
}






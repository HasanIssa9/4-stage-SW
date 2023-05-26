#include <windows.h>
#include <stdio.h>
#include <string.h>

LRESULT CALLBACK WindowFunc(HWND, UINT, WPARAM, LPARAM);

char szWinName[] = "MyWin"; /* name of window class */
char str[255] = "";

int WINAPI WinMain(HINSTANCE hThisInst, HINSTANCE hPrevInst, LPSTR lpszArgs, int nWinMode) {
    HWND hwnd;
    MSG msg;
    WNDCLASSEX wcl;
    /* Define a window class. */
    wcl.cbSize = sizeof(WNDCLASSEX);
    wcl.hInstance = hThisInst;                   /* handle to this instance */
    wcl.lpszClassName = szWinName;               /* window class name */
    wcl.lpfnWndProc = WindowFunc;                /* window function */
    wcl.style = 0;                               /* default style */
    wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION); /*standard icon*/
    wcl.hIconSm = LoadIcon(NULL, IDI_WINLOGO);   /* small icon */
    wcl.hCursor = LoadCursor(NULL, IDC_ARROW);   /*cursor style*/
    wcl.lpszMenuName = NULL;                     /* no menu"*/
    wcl.cbClsExtra = 0;                          /* no extra */
    wcl.cbWndExtra = 0;                          /* information needed */
    /* Make the window background white. */
    wcl.hbrBackground = (HBRUSH) (GRAY_BRUSH);
    /*Register the window class.*/
    if (!RegisterClassEx(&wcl))
        return 0;
    /* Now that a window class has been registered, a window can be
    created. */
    hwnd = CreateWindow(
            szWinName,             /* name of window class */
            "Message box and virtual key", /* title */
            WS_OVERLAPPEDWINDOW,   /* window style - normal */
            CW_USEDEFAULT,         /* X coordinate - let Windrows decide */
            CW_USEDEFAULT,         /* Y coordinate - let Windows decide */
            CW_USEDEFAULT,         /* width - let Windows decide */
            CW_USEDEFAULT,         /* height - let Windows decide */
            HWND_DESKTOP,          /* no parent window */
            NULL,
            hThisInst, /* handle of this instance of the program */
            NULL /* no additional arguments */);
    /* Display the window. */
    ShowWindow(hwnd, nWinMode);
    UpdateWindow(hwnd);
    /* create the message loop. */
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg); /* allow use of keyboard */
        DispatchMessage(&msg);  /* return control to window NT */
    }
    return msg.wParam;
} /* end of WinMain() */
/* This function is called by Windows NT and is passed
messages from the MESSAGE QUEUE */
LRESULT CALLBACK WindowFunc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam) {
    switch (message) {
        case WM_CHAR: /* process character */
            sprintf(str, "Character is %c", (char) wParam);
            MessageBox(hwnd, str, "WM_CHAR Received", MB_OK + MB_ICONINFORMATION);
            break;
        case WM_KEYDOWN: // process raw keystroke
            switch ((char) wParam) {
                case VK_UP:
                    strcpy(str, "Up Arrow");
                    break;
                case VK_DOWN:
                    strcpy(str, "Down Arrow");
                    break;
                case VK_LEFT:
                    strcpy(str, "Left Arrow");
                    break;
                case VK_RIGHT:
                    strcpy(str, "Right Arrow");
                    break;
                case VK_SHIFT:
                    strcpy(str, "Shift");
                    break;
                case VK_CONTROL:
                    strcpy(str, "Control");
                    break;
                default:
                    strcpy(str, "Other Key");
            }
            MessageBox(hwnd, str, "WM_KEYDOWN Received", MB_OK);
            break;
        case WM_DESTROY: /*terminate the  program*/
            PostQuitMessage(0);
            break;
        default: /* Let Window NT process any message not specified
     in the preceding switch statement.*/
            return DefWindowProc(hwnd, message, wParam, lParam);
    }
    return 0;
} /* end WinFunc */

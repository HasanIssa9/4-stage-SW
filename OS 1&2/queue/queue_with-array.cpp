#include <iostream>
using namespace std;
int f = -1, r = -1;
void insert(int q[6])
{
    int item;
    if (r == 5)
        cout << "overflow" << endl;
    else
    {
        cout << "enter your item" << endl;
        cin >> item;
        r = r + 1;
        q[r] = item;
        if (f == -1)
            f = 0;
    }
}
void del(int q[6])
{
    int item;
    if (f == -1)
        cout << "underflow" << endl;
    else

        if (f == r)
        {
            item = q[f];
            f = -1;
            r = -1;
            cout << "deleted item is: " << item << endl;
        }
        else
        {
            item = q[f];
            ++f;
            cout << "deleted item is: " << item << endl;
        }
}
void print(int q[6])
{
    int i;
    if (r == -1 && f == -1)
        cout << "underflow\n";
    else

        for (i = f; i <= r; i++)
            if (i == r )
                cout << q[i]<<"\n";
            else
                cout << q[i]<<"--";

}
int main()
{
    int q[6], x;
    cout << "\n";
    cout << "1-insert \n";
    cout << "2-del \n";
    cout << "3-print \n";
    cout << "4-exit \n";
    do
    {
        cout << "enter your choise" << endl;
        cin >> x;
        switch (x)
        {
        case 1:
            insert(q);
            break;
        case 2:
            del(q);
            break;
        case 3:
            print(q);
            break;
        default:
            break;
        }
    }
    while (x != 4);
}

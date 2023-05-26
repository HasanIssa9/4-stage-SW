#include <iostream>
using namespace std;
int f = -1, r = -1;
void insert(int q[], int size)
{
    int item;
    if (r == (size - 1))
        cout << "overflow" << endl;
    else
    {
        cout << "enter the time process" << endl;
        cin >> item;
        r = r + 1;
        q[r] = item;
        if (f == -1)
            f = 0;
    }
}
void del(int q[])
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
void print(int q[], int size)
{
    int i, wt[size - 1], sum_wt = 0;
    wt[0] = 0;
    if (r == -1 && f == -1)
        cout << "underflow\n";
    else
        for (i = f; i <= r; i++)
        {
            wt[i] = 0;
            for (int j = 0; j < i; j++)
                wt[i] += q[j];
            sum_wt += wt[i];
            cout << wt[i] << "\n";
        }

    cout << "Average waiting time = " << sum_wt / size << endl;
}
int main()
{
    int size;
    cout << "Enter number of process? ";
    cin >> size;
    int q[size], x;
    cout << "\n";
    cout << "1-insert \n";
    cout << "2-del \n";
    cout << "3-print \n";
    cout << "4-exit \n";
    do
    {
        cout << "enter your choice" << endl;
        cin >> x;
        switch (x)
        {
        case 1:
            insert(q, size);
            break;
        case 2:
            del(q);
            break;
        case 3:
            cout << "\n";
            print(q, size);
            break;
        default:
            break;
        }
    } while (x != 4);
}

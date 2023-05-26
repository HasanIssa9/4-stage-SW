#include <iostream>
using namespace std;
int f = -1, r = -1;
void insert(int q[], int a[], int t[], int size)
{
    int bt, at;
    if (r == (size - 1))
        cout << "overflow" << endl;
    else
    {
        r = r + 1;
        cout << "burst time p" << r + 1 << " \t ";
        cin >> bt;
        cout << "arrival time p" << r + 1 << " \t";
        cin >> at;
        a[r] = at;
        q[r] = bt;
        t[r] = q[r];
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
void print(int bt[], int at[], int t[], int size)
{
    int i, low, time, end, count = 0, sum_wt = 0;
    int wt[size - 1];
    wt[0] = 0;
    if (r == -1 && f == -1)
        cout << "underflow\n";
    else
    {
        bt[9] = 999;
        for (time = 0; count != size; time++)
        {
            low = 9;
            for (i = 0; i < size; i++)
            {
                if (at[i] <= time && bt[i] < bt[low] && bt[i] > 0)
                {
                    low = i;
                }
            }
            bt[low]--;
            if (bt[low] == 0)
            {
                count++;
                end = time + 1;
                sum_wt += end - at[low] - t[low];
            }
        }
        cout << "Average waiting time = " << (double)sum_wt / size << endl;
    }
}
int main()
{
    int size;
    cout << "Enter number of process? ";
    cin >> size;
    int q[size], a[size], t[size], x;
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
            insert(q, a, t, size);
            break;
        case 2:
            del(q);
            break;
        case 3:
            cout << "\n";
            print(q, a, t, size);
            break;
        default:
            break;
        }
    } while (x != 4);
}

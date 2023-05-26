#include <iostream>
using namespace std;
int main()
{
    int i, j, n, m, k;
    bool flag;
    cout << "Enter numbers of processes: ";
    cin >> n;
    cout << "Enter numbers of resources: ";
    cin >> m;
    char R[] = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'};
    int Need[n][m], Safe_seq[n], index = 0, finish[n] = {0};
    int Allocation[n][m] = {{0, 1, 0}, {2, 0, 0}, {3, 0, 2}, {2, 1, 1}, {0, 0, 2}};
    int Max[n][m] = {{7, 5, 3}, {3, 2, 2}, {9, 0, 2}, {2, 2, 2}, {4, 3, 3}};
    int Available[m] = {3, 3, 2};
    // int Allocation[n][m], Max[n][m], Available[m];
    // cout << "Enter Allocation matrix \n";
    // for (i = 0; i < n; i++)
    // {
    //     for (j = 0; j < m; j++)
    //     {
    //         cout << "Enter resource " << R[j] << " of P(" << i << "): ";
    //         cin >> Allocation[i][j];
    //     }
    // }
    // cout << "Enter Max matrix \n";
    // for (i = 0; i < n; i++)
    // {
    //     for (j = 0; j < m; j++)
    //     {
    //         cout << "Enter resource " << R[j] << " of P(" << i << "): ";
    //         cin >> Max[i][j];
    //     }
    // }
    // cout << "Enter Available array \n";
    // for (i = 0; i < m; i++)
    // {
    //     cout << "Enter resource " << R[i] << " : ";
    //     cin >> Available[i];
    // }
    cout << "\t\tMax\t\t\t\t   Allocation\t\t\t\t\tNeed\n";
    for (j = 0; j < m; j++)
        cout << "\t" << R[j];
    cout << "\t\t";
    for (j = 0; j < m; j++)
        cout << "\t" << R[j];
    cout << "\t\t";
    for (j = 0; j < m; j++)
        cout << "\t" << R[j];
    cout << "\n";
    for (i = 0; i < n; i++)
    {
        cout << "P(" << i << "):  ";
        for (j = 0; j < m; j++)
        {
            cout << Max[i][j] << "\t";
        }
        cout << "\t\t";
        for (j = 0; j < m; j++)
        {
            cout << Allocation[i][j] << "\t";
        }
        cout << "\t\t";
        for (j = 0; j < m; j++)
        {
            Need[i][j] = Max[i][j] - Allocation[i][j];
            cout << Need[i][j] << "\t";
        }
        cout << "\n";
    }
    cout << "\n";
    for (k = 0; k < 5; k++)
    {
        cout << "Iteration " << k + 1 << ":\n";
        for (i = 0; i < n; i++)
        {
            if (finish[i] == 0)
            {
                flag = true;
                for (j = 0; j < m; j++)
                {
                    if (Need[i][j] > Available[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    cout << "P(" << i << "):  ";
                    Safe_seq[index++] = i;
                    for (j = 0; j < m; j++)
                    {
                        Available[j] += Allocation[i][j];
                        cout << Available[j] << "\t";
                    }
                    finish[i] = 1;
                    cout << "\n";
                }
            }
        }
        if (index == n)
            break;
    }
    cout << "\n";
    cout << "The system is in a safe state since the sequence is: ";
    for (i = 0; i < n - 1; i++)
        cout << "P" << Safe_seq[i] << " --> ";
    cout << "P" << Safe_seq[n - 1];
}

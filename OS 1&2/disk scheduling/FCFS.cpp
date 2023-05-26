#include <iostream>
using namespace std;

void FCFS(int requests[], int head,int n)
{
    int seek_time = 0;
    int curr_track = head;
    for(int i = 0; i < n; i++)
    {
        int track = requests[i];
        seek_time +=track > curr_track?track - curr_track:curr_track-track;
        curr_track = track;
    }
    cout << "Total head movement: " << seek_time << " cylinder\n";
}

int main()
{
    int n, head;
    int requests[100];
    cout << "Enter the number of requests: ";
    cin >> n;
    cout << "Enter the initial head position: ";
    cin >> head;

    for(int i = 0; i < n; i++)
    {
        cout<<"Enter track number of request("<<i+1<<"): ";
        cin >> requests[i];
    }
    FCFS(requests, head,n);

    return 0;
}

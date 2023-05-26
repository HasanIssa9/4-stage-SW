#include <iostream>

using namespace std;

int SSTF(int queue[], int head, int n) {
    int dist[n], visited[n], total_distance = 0, current = head;
    for (int i = 0; i < n; i++) {
        visited[i] = 0;
    }
    for (int i = 0; i < n; i++) {
        dist[i] =queue[i]>current? queue[i] - current:current-queue[i];
    }
    for (int i = 0; i < n; i++) {
        int min_dist = INT_MAX, min_index;
        for (int j = 0; j < n; j++) {
            if (!visited[j] && dist[j] < min_dist) {
                min_dist = dist[j];
                min_index = j;
            }
        }
        visited[min_index] = 1;
        total_distance += dist[min_index];
        current = queue[min_index];
        for (int j = 0; j < n; j++) {
            if (!visited[j]) {
                dist[j] = queue[j]>current? queue[j] - current:current-queue[j];

            }
        }
    }
    return total_distance;
}

int main() {
    int n, head, queue[100];
    cout << "Enter the number of requests: ";
    cin >> n;
    cout << "Enter the initial head position: ";
    cin >> head;

    for (int i = 0; i < n; i++) {
        cout<<"Enter track number of request("<<i+1<<"): ";
        cin >> queue[i];
    }
    int total_distance = SSTF(queue, head, n);
    cout << "Total head movement: " << total_distance << " cylinder\n";
    return 0;
}

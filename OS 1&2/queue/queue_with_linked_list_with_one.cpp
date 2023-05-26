#include <iostream>
#include <chrono>
using namespace std;
struct node
{
    int data;
    struct node *next;
};
struct node *front = NULL;
struct node *temp;
void Insert()
{

    int val;
    cout << "Insert the element in queue : " << endl;
    cin >> val;
    struct node *p;
    auto start = chrono::steady_clock::now();
    if (front == NULL)
    {
        front = (struct node *)malloc(sizeof(struct node));
        front->next = NULL;
        front->data = val;
    }
    else
    {
        p = front;
        temp = (struct node *)malloc(sizeof(struct node));
        while (p->next != NULL)
        {
            p = p->next;
        }
        p->next = temp;
        temp->data = val;
        temp->next = NULL;
    }
    auto end = chrono::steady_clock::now();
    cout << "the time for insert element: " << chrono::duration_cast<chrono::microseconds>(end - start).count() << " microseconds" << endl;
}
void Delete()
{
    auto start = chrono::steady_clock::now();
    temp = front;
    if (front == NULL)
    {
        cout << "Underflow" << endl;
        return;
    }
    else if (temp->next != NULL)
    {
        cout << "Element deleted from queue is : " << front->data << endl;
        front = front->next;
    }
    else
    {
        cout << "Element deleted from queue is : " << front->data << endl;
        front = NULL;
    }

    auto end = chrono::steady_clock::now();
    cout << "the time for delete element: " << chrono::duration_cast<chrono::microseconds>(end - start).count() << " microseconds" << endl;
}
void Display()
{
    auto start = chrono::steady_clock::now();
    temp = front;
    if (front == NULL)
    {
        cout << "Queue is empty" << endl;
        return;
    }
    cout << "Queue elements are: ";
    while (temp != NULL)
    {
        cout << temp->data << " ";
        temp = temp->next;
    }
    cout << endl;
    auto end = chrono::steady_clock::now();
    cout << "the time for display elements: " << chrono::duration_cast<chrono::microseconds>(end - start).count() << " microseconds" << endl;
}
int main()
{
    int ch;
    cout << "1) Insert element to queue" << endl;
    cout << "2) Delete element from queue" << endl;
    cout << "3) Display all the elements of queue" << endl;
    cout << "4) Exit" << endl;
    do
    {
        cout << "Enter your choice : " << endl;
        cin >> ch;
        switch (ch)
        {
        case 1:
            Insert();
            break;
        case 2:
            Delete();
            break;
        case 3:
            Display();
            break;
        case 4:
            cout << "Exit" << endl;
            break;
        default:
            cout << "Invalid choice" << endl;
        }
    } while (ch != 4);
    return 0;
}
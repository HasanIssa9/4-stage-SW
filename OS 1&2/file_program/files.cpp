#include <iostream>
#include <fstream>
using namespace std;
int main()
{
    fstream my_file;
    fstream my_file1;
    string x;
    cin>>x;
    my_file.open("my_file.txt", ios::out);
    if (!my_file)
        cout << "File not created!";
    else
    {
        my_file <<x;
        my_file.close();
    }

    my_file1.open("my_file1.txt", ios::out);
    my_file.open("my_file.txt", ios::in);
    if (!my_file)
    {
        cout << "No such file";
    }
    else
    {
        char ch;
        while (1)
        {
            my_file >> ch;
            if (my_file.eof())
                break;

            my_file1 << ch;
        }
    }
    my_file.close();
    my_file1.close();

    my_file1.open("my_file1.txt", ios::in);
    if (!my_file1)
    {
        cout << "No such file";
    }
    else
    {
        char ch;
        while (1)
        {
            my_file1 >> ch;
            if (my_file1.eof())
                break;
            cout << ch;
        }
    }
    my_file1.close();
    return 0;
}

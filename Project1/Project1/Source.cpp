#include <iostream>
#include <windows.h>

using namespace std;

int main()
{
	int sleep;

	cout << "Enter sleeptimer: ";

	cin >> sleep;

	for (;sleep >= 0; sleep--)
	{
		cout << sleep << endl;
		Sleep(1000);
		
	}

	system("shutdown -s -t 0");
}
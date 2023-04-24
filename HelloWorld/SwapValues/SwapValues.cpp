#include <iostream>
using namespace std;

int main()
{
	int a = 50, b = 25;
	cout << "a: " << a << ", b: " << b << endl;

	a += b;
	b = a - b;
	a -= b;
}
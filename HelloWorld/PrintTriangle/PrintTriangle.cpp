#include <iostream>

int main()
{
	for (int i = 6; i > -1; --i) {
		for (int j = i; j > -1; --j) {
			printf("&");
			if (j > 0) printf(" ");
		}
		printf("\n");
	}
}

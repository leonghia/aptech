#include <stdio.h>

int tinhTong(int a, int b) {
	int c = a + b;
	return c;
}

// viet ham tim so lon hon trong hai so nguyen
int timMax(int a, int b) {
	if (a > b) {
		return a;
	}
	else {
		return b;
	}
}

int main() {
//	int x = 10, y = 20;
//	int z = tinhTong(x, y);
//	printf("z = %d", z);
	int c = timMax(4, 7);
	printf("So lon hon la: %d", c);
}

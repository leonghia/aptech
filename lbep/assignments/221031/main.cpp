#include <stdio.h>

int main() {
	int i;
	int j;
	for (i = 1; i < 6; i++) {
		for (int j = 1; j < 5; j++) {
			printf("*");
		}
		if (i % 2 != 0) {
			printf("*");
		}
		printf("\n");
	}
}

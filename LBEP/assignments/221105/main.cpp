#include <stdio.h>

int main() {
	int i;
	int j;
	int k;
	for (i = 1; i < 6; i++) {
		for (j = 1; j <= i; j++) {
			for (k = 1; k <= i; k++) {
				printf("*");
			}
			printf(" ");
		}
		printf("\n");
	}
}

#include <stdio.h>

int main() {
	int i;
	
	for (i = 1; i < 5; i++) {
		if (i == 2) {
			printf("**  *\n");
		}
		if (i == 3) {
			printf("* * *\n");
		}
		if (i == 4) {
			printf("*  **\n");
		}
		else {
			printf("*   *\n");
		}
	}
}

#include <stdio.h>
#include "demothuvien.h"


int main() {
	printf("Nhap vao so n: ");
	scanf("%d", &n);
	if (ktSoNguyenTo(n) == true) {
		printf("%d la so nguyen to", n);
	}
	else if (ktSoNguyenTo(n) == false) {
		printf("%d khong phai la so nguyen to", n);
	}
	
}

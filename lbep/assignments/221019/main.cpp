#include <stdio.h>

int main(){
	int a, b, c;
	
	printf("Nhap gia tri a, b, c\n");
    scanf("%d %d %d", &a, &b, &c);
    printf("a = %d\tb = %d\tc = %d\n", a, b, c);
	
	int m = a;
	
	if (b > m) {
		m = b;
	}
	
	if (c > m) {
		m = c;
	}
	
	printf("%d la so lon nhat", m);
	
}

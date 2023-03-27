#include <stdio.h>
#include <math.h>

int main(){
	int a;
	printf("Nhap vao gia tri a: ");
	scanf("%d",&a);
	
	int b;
	printf("Nhap vao gia tri b: ");
	scanf("%d", &b);
	
	int c;
	printf("Nhap vao gia tri c: ");
	scanf("%d", &c);
	
	if (a == 0) {
		if (b == 0) {
			if (c == 0) {
				printf("Phuong trinh vo so nghiem");
			}
			
			else {
				printf("Phuong trinh vo nghiem");
			}
		}
		
		else {
			float x = -(float)c / b;
			printf("x = %d", x);
		}
	}
	
	else {
		int d = b*b - 4*a*c;
		if (d < 0) {
			printf("Phuong trinh vo nghiem");
		}
		
		else {
			if (d == 0) {
				float x = -(float)b / 2 * a;
				printf("x bang %d", x);
			}
			
			else {
				double x1 = (-b + sqrt(d)) / 2 * a;
				double x2 = (-b - sqrt(d)) / 2 * a;
				printf("x1 bang %lf \t", x1);
				printf("x2 bang %lf", x2);
			}
		}	
	}
}

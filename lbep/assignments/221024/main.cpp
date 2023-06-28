#include <stdio.h>
#include <math.h>

int main(){
	
	float a;
	printf("Nhap vao so a: ");
	scanf("%f", &a);
	
	float b;
	printf("Nhap vao so b: ");
	scanf("%f", &b);
	
	float c;
	printf("Nhap vao so c: ");
	scanf("%f", &c);
	
	if (a + b > c && b + c > a && a + c > b) {
		float p = (a + b + c);
		float q = p / 2;
		float s = sqrt(q*(q-a)*(q-b)*(q-c));
		printf("Chu vi tam giac la: %f", p);
		printf("\tDien tich tam giac la: %f", s);
	}
	
	else {
		printf("Day khong phai la tam giac");
	}
}

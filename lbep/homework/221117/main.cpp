#include <stdio.h>

float timTBC(int arr[], int n) {
	int s = 0;
	for (int i = 0; i < n; i++) {
		s += arr[i];
	}
	float tbc = (float)s / n;
	return tbc;
}

int main()
{
    int ary[10];
    int i, total, high;
    for(i=0; i<10; i++)
    {
     printf("Nhap so thu %d: ", i);
	 scanf("%d",&ary[i]);
    }
    printf("Trung binh cong cua mang la: %f", timTBC(ary, 10));
}

#include <stdio.h>

int main(){
	int a, b, c;
 
    printf("Nhap gia tri a, b, c\n");
    scanf("%d %d %d", &a, &b, &c);
    printf("a = %d\tb = %d\tc = %d\n", a, b, c);
    if (a > b)
    {
        if (a > c)
        {
            printf("Trong 3 so %d, %d, %d thi %d la so lon nhat.", a, b, c, a);
        }
        else
        {
            printf("Trong 3 so %d, %d, %d thi %d la so lon nhat.", a, b, c, c);
        }
    }
    else if (b > c)
        printf("Trong 3 so %d, %d, %d thi %d la so lon nhat.", a, b, c, b);
    else
        printf("Trong 3 so %d, %d, %d thi %d la so lon nhat.", a, b, c, c);
}

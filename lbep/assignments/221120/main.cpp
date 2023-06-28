#include <stdio.h>

// bai 1

float findAvg1(int arr[], int n)
{
	int sum = 0;
	int nums_of_odd = 0;
	float avg;
	for (int i = 0; i < n; i++)
	{
		if (arr[i] % 2 != 0)
		{
			sum += arr[i];
			nums_of_odd += 1;
		}
	}
	avg = (float)sum / nums_of_odd;
	return avg;
}

// bai 2

float findAvg2(int arr[], int n)
{
	int sum = 0;
	int nums_of_odd = 0;
	float avg;
	for (int i = 0; i < n; i++) {
		if (arr[i] % 2 != 0 && i % 2 == 0)
		{
			sum += arr[i];
			nums_of_odd += 1;
		}
	}
	avg = (float)sum / nums_of_odd;
	return avg;
}

// bai 3

bool checkX(int arr[], int n, int x)
{
	for (int i = 0; i < n; i++) {
		if (arr[i] == x)
		{
			return true;
		}
	}
	return false;
}

// bai 4

int findthelastOdd(int arr[], int n)
{
	int placeholder;
	for (int i = 0; i < n; i++) {
		if (arr[i] % 2 != 0)
		{
			placeholder = arr[i];
		}
	}
	return placeholder;
}

// chay thu bai 3
int main(void)
{
	int n;
	int my_array[10] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 20};
	int x = 10;
	if (checkX(my_array, 10, x) == true)
	{
		printf("So %d co ton tai trong mang", x);
	}
	else if (checkX(my_array, 10, x) == false)
	{
		printf("So %d khong ton tai trong mang", x);
	}
}

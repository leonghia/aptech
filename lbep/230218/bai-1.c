#include <stdio.h>

int main() {
    int n, i, last_even = -1;
    printf("Enter the size of the array: ");
    scanf("%d", &n);
    int arr[n];
    printf("Enter %d integer numbers: ", n);
    for (i = 0; i < n; i++) {
        scanf("%d", &arr[i]);
        if (arr[i] % 2 == 0) {
            last_even = arr[i];
        }
    }
    if (last_even == -1) {
        printf("No EVEN number");
    } else {
        printf("The last even number in the array is: %d", last_even);
    }
    return 0;
}
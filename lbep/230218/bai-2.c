#include <stdio.h>

float average(int s[], int n);

int main() {
    int s[] = {1, 2, 3, 4};
    int n = 4;
    float avg = average(s, n);
    printf("Average: %.2f", avg);
    return 0;
}

float average(int s[], int n) {
    int i;
    float sum = 0;
    for (i = 0; i < n; i++) {
        sum += s[i];
    }
    return sum / n;
}

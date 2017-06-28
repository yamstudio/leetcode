#include <stdlib.h>

int comp(const void *e1, const void *e2) {
    int f = *(int *)e1, s = *(int *)e2;
    return f > s ? 1 : (f == s ? 0 : -1);
}

void nextPermutation(int* nums, int numsSize) {
    int *tail = nums + numsSize - 1, *p, curr, prev = INT_MIN, *m, sub = INT_MAX, *i;
    
    for (p = tail; p >= nums; --p) {
        curr = *p;
        if (curr < prev) {
            m = p;
            while (++p <= tail) {
                if (*p > curr && *p < sub) {
                    i = p;
                    sub = *p;
                }
            }
            *m = sub;
            *i = curr;
            qsort(m + 1, tail - m, sizeof(int), comp);
            return nums;
        }
        prev = curr;
    }
    qsort(nums, numsSize, sizeof(int), comp);
    return nums;
}

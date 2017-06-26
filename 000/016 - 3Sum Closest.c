#include <stdlib.h>

#define abs(x) (x >= 0 ? x : -(x))

int comp(const void *e1, const void *e2) {
    int f = *(int *)e1, s = *(int *)e2;
    return f > s ? 1 : (f == s ? 0 : -1);
}

int threeSumClosest(int* nums, int numsSize, int target) {
    int i, tar, l, r, m = INT_MAX, s;
    
    qsort(nums, numsSize, sizeof(* nums), comp);
    for (i = 0; i < numsSize; ++i) {
        if (i == 0 || nums[i] > nums[i - 1]) {
            tar = nums[i] - target;
            l = i + 1;
            r = numsSize - 1;
            while (l < r) {
                s = tar + nums[l] + nums[r];
                m = abs(s) < abs(m) ? s : m;
                if (s < 0)
                    ++l;
                else if (s > 0)
                    --r;
                else
                    return target;
            }
        }
    }
    return target + m;
}

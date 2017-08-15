#include <stdlib.h>

static int comp(const void *p1, const void *p2) {
    return *(int *)p1 - *(int *)p2;
}

int minMoves2(int* nums, int numsSize) {
    int m, ret = 0, i, h;
    
    qsort(nums, numsSize, sizeof(int), &comp);
    h = numsSize / 2;
    m = nums[h];
    
    for (i = 0; i < numsSize; ++i)
        ret += i < h ? m - nums[i] : nums[i] - m;
    
    return ret;
}

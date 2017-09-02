#include <limits.h>

static inline int max(int a, int b) {
    return a > b ? a : b;
}

int maximumProduct(int* nums, int numsSize) {
    int i, mi, m = -4000, ret, max1 = -2000, max2 = -3000, min1 = 2000, min2 = 3000;
    
    if (numsSize == 3) {
        ret = 1;
        for (i = 0; i < 3; ++i)
            ret *= nums[i];
        return ret;
    }
    
    for (i = 0; i < numsSize; ++i) {
        if (nums[i] > m) {
            m = nums[i];
            mi = i;
        }
    }
    
    for (i = 0; i < numsSize; ++i) {
        if (i == mi)
            continue;
        
        if (nums[i] < min1) {
            min2 = min1;
            min1 = nums[i];
        } else if (nums[i] < min2)
            min2 = nums[i];
        
        if (nums[i] > max1) {
            max2 = max1;
            max1 = nums[i];
        } else if (nums[i] > max2)
            max2 = nums[i];
    }

    return max(m * max1 * max2, m * min1 * min2);
}

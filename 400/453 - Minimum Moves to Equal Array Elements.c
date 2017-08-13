#include <limits.h>

int minMoves(int* nums, int numsSize) {
    int sum = 0, i, min = INT_MAX;

    for (i = 0; i < numsSize; ++i) {
        sum += nums[i];
        if (nums[i] < min)
            min = nums[i];
    }
    
    return sum - min * numsSize;
}

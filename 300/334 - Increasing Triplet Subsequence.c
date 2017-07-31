#include <limits.h>

bool increasingTriplet(int* nums, int numsSize) {
    int a = INT_MIN, b = INT_MIN, i;
    
    for (i = 0; i < numsSize; ++i) {
        if (a == INT_MIN || a >= nums[i])
            a = nums[i];
        else if (b == INT_MIN || b >= nums[i])
            b = nums[i];
        else
            return 1;
    }
    
    return 0;
}

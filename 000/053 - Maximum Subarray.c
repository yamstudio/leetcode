#define max(a, b) (a > b ? a : b)

int maxSubArray(int* nums, int numsSize) {
    int i, pm = INT_MIN, curr = INT_MIN;
    
    for (i = 0; i < numsSize; ++i) {
        curr = curr > 0 ? nums[i] + curr : nums[i];
        pm = max(curr, pm);
    }
    
    return pm;
}

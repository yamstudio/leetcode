#define max(a, b) ((a) > (b) ? (a) : (b))

int rob(int* nums, int numsSize) {
    int *dp, i, ret;
    
    if (! numsSize)
        return 0;
    if (numsSize == 1)
        return nums[0];
    dp = (int *)malloc(numsSize * sizeof(int));
    dp[0] = nums[0];
    dp[1] = max(nums[0], nums[1]);
    
    for (i = 2; i < numsSize; ++i)
        dp[i] = max(nums[i] + dp[i - 2], dp[i - 1]);
    
    ret = dp[numsSize - 1];
    free(dp);
    
    return ret;
}

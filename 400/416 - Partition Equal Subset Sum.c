bool canPartition(int* nums, int numsSize) {
    long long sum = 0, target;
    int i, j, *dp, ret;
    
    for (i = 0; i < numsSize; ++i)
        sum += nums[i];
    if (sum % 2)
        return 0;
    
    target = sum / 2;
    dp = (int *)calloc(target + 1, sizeof(int));
    dp[0] = 1;
    
    for (i = 0; i < numsSize; ++i) {
        for (j = target; j >= nums[i]; --j)
            dp[j] = dp[j] || dp[j - nums[i]];
    }
    
    ret = dp[target];
    free(dp);
    
    return ret;
}

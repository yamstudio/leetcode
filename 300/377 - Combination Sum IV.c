int combinationSum4(int* nums, int numsSize, int target) {
    int *dp, i, j, ret;
    
    dp = (int *)calloc(target + 1, sizeof(int));
    dp[0] = 1;
    
    for (i = 1; i <= target; ++i) {
        for (j = 0; j < numsSize; ++j) {
            if (nums[j] <= i)
                dp[i] += dp[i - nums[j]];
        }
    }
    
    ret = dp[target];
    free(dp);
    
    return ret;
}

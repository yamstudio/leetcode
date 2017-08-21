int change(int amount, int* coins, int coinsSize) {
    int *dp, i, j, c, ret;
    
    dp = (int *)calloc(amount + 1, sizeof(int));
    dp[0] = 1;

    for (i = 0; i < coinsSize; ++i) {
        c = coins[i];

        for (j = c; j <= amount; ++j)
            dp[j] += dp[j - c];
    }
    
    ret = dp[amount];
    free(dp);
    
    return ret;
}

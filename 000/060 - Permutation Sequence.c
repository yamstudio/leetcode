char* getPermutation(int n, int k) {
    char *ret, *nums, *temp;
    int *fact, i, j, size = 0, p, ni;
    
    ret = (char *)malloc(n + 1);
    ret[n] = '\0';
    fact = (int *)malloc(n * sizeof(int));
    fact[0] = 1;
    for (i = 1; i < n; ++i)
        fact[i] = fact[i - 1] * i;
    nums = (char *)malloc(n);
    for (i = 0; i < n; ++i)
        nums[i] = i + '1';
    --k;
    
    for (i = 0; i < n; ++i) {
        p = k / fact[n - 1 - i];
        k %= fact[n - 1 - i];
        temp = (char *)malloc(n - i);
        ni = 0;
        for (j = 0; j < n - i; ++j) {
            if (p == j)
                ret[size++] = nums[j];
            else
                temp[ni++] = nums[j];
        }
        free(nums);
        nums = temp;
    }
    free(nums);
    
    return ret;
}

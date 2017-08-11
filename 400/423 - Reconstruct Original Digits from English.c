char* originalDigits(char* s) {
    int nums[10], letters[26] = {0}, i, j, size, count = 0;
    char *ret;
    
    for (i = 0; s[i]; ++i)
        letters[s[i] - 'a']++;
    
    nums[0] = letters['z' - 'a'];
    nums[2] = letters['w' - 'a'];
    nums[4] = letters['u' - 'a'];
    nums[6] = letters['x' - 'a'];
    nums[8] = letters['g' - 'a'];
    nums[1] = letters['o' - 'a'] - nums[0] - nums[2] - nums[4];
    nums[3] = letters['h' - 'a'] - nums[8];
    nums[5] = letters['f' - 'a'] - nums[4];
    nums[7] = letters['v' - 'a'] - nums[5];
    nums[9] = letters['i' - 'a'] - nums[5] - nums[6] - nums[8];
    
    for (i = 0; i < 10; ++i)
        size += nums[i];
    ret = (char *)malloc((size + 1) * sizeof(char));
    
    for (i = 0; i < 10; ++i) {
        for (j = 0; j < nums[i]; ++j)
            ret[count++] = i + '0';
    }
    ret[count] = '\0';
    
    return ret;
}

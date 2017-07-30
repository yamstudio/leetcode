int missingNumber(int* nums, int numsSize) {
    int ret = 0, i;
    
    for (i = 0; i < numsSize; ++i)
        ret ^= (i + 1) ^ nums[i];
    
    return ret;
}

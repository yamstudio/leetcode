int singleNumber(int* nums, int numsSize) {
    int ret = 0, i;
    
    for (i = 0; i < numsSize; ++i)
        ret ^= nums[i];
        
    return ret;
}

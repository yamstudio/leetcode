int removeDuplicates(int* nums, int numsSize) {
    int n = 0, c, i;
    
    for (i = 0; i < numsSize; ++i) {
        if (i == 0 || nums[i] != nums[i - 1])
            nums[n++] = nums[i];
    }
    
    return n;
}

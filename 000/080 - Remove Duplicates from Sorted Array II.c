int removeDuplicates(int* nums, int numsSize) {
    int val, count = 0, ret = 0, i, j;
    
    if (! numsSize)
        return 0;
    val = nums[0] - 1;
    
    for (i = 0; i < numsSize; ++i) {
        if (val == nums[i]) {
            if (count++ < 2)
                nums[ret++] = nums[i];
            else {
                while (i < numsSize) {
                    if (val != nums[i])
                        break;
                    ++i;
                }
                
            }
        }
        
        if (i < numsSize && val != nums[i]) {
            val = nums[i];
            count = 1;
            nums[ret++] = nums[i];
        }
    }

    return ret;
}

int wiggleMaxLength(int* nums, int numsSize) {
    int ret, prev_desc = -1, i;
    
    if (! numsSize)
        ret = 0;
    else {
        ret = 1;
        for (i = 1; i < numsSize; ++i) {
            if (nums[i] > nums[i - 1] && (prev_desc || prev_desc == -1)) {
                ++ret;
                prev_desc = 0;
            } else if (nums[i] < nums[i - 1] && ((! prev_desc) || prev_desc == -1)) {
                ++ret;
                prev_desc = 1;
            }
        }
    }
    
    return ret;
}

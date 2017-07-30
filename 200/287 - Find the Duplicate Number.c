int findDuplicate(int* nums, int numsSize) {
    int left = 0, right = numsSize - 1, mid, count, i;
    
    while (left < right) {
        mid = left + (right - left) / 2;
        count = 0;
        
        for (i = 0; i < numsSize; ++i) {
            if (nums[i] <= mid)
                ++count;
        }
        
        if (count <= mid)
            left = mid + 1;
        else
            right = mid;
    }
    
    return left;
}

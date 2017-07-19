int findMin(int* nums, int numsSize) {
    int from = 0, to = numsSize - 1, mid;
    
    if (! numsSize)
        return 0;
    
    while (from < to) {
        mid = (from + to) / 2;
        if (nums[mid] < nums[to])
            to = mid;
        else if (nums[mid] > nums[to])
            from = mid + 1;
        else
            --to;
    }

    return nums[from];
}

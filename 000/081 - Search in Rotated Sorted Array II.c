bool search(int* nums, int numsSize, int target) {
    int start = 0, end = numsSize - 1, mid;
    
    while (start <= end) {
        mid = (start + end) / 2;
        if (nums[mid] == target)
            return 1;
        else if (nums[mid] > nums[end]) {
            if (target >= nums[start] && target < nums[mid])
                end = mid - 1;
            else
                start = mid + 1;
        } else if (nums[mid] < nums[end]) {
            if (target > nums[mid] && target <= nums[end])
                start = mid + 1;
            else
                end = mid - 1;
        } else
            --end;
    }
    return 0;
}

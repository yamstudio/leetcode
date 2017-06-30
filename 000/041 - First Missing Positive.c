int firstMissingPositive(int* nums, int numsSize) {
    int i = 0, temp;
    
    while (i < numsSize) {
        if (nums[i] != i + 1 && nums[i] > 0 && nums[i] <= numsSize && nums[i] != nums[nums[i] - 1]) {
            temp = nums[nums[i] - 1];
            nums[nums[i] - 1] = nums[i];
            nums[i] = temp;
        } else
            ++i;
    }
    
    for (i = 0; i < numsSize; ++i) {
        if (nums[i] != i + 1)
            break;
    }
    return i + 1;
}

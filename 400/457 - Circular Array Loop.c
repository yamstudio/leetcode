static int dfs(int *nums, int index, int size, int count) {
    int next;
    
    if (count < size) {
        next = (index + nums[index] + size) % size;
        
        if (next == index || nums[next] * nums[index] <= 0 || dfs(nums, next, size, count + 1) == 0)
            nums[index] = 0;
    }
    
    return nums[index];
}

bool circularArrayLoop(int* nums, int numsSize) {
    int i;
    
    for (i = 0; i < numsSize; ++i) {
        if (nums[i] && dfs(nums, i, numsSize, 0))
            return 1;
    }
    
    return 0;
}

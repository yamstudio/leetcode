void moveZeroes(int* nums, int numsSize) {
    int z = 0, nz = 0;
    
    while (z < numsSize && nz < numsSize) {
        if (nums[z] != 0) {
            nz = ++z;
            continue;
        }
        
        if (nums[nz] == 0) {
            ++nz;
            continue;
        }
        
        nums[z++] = nums[nz];
        nums[nz++] = 0;
    }
}

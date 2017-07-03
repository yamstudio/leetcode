#define max(a, b) (a > b ? a : b)

bool canJump(int* nums, int numsSize) {
    int r = 0, i, d;
    
    for (i = 0; i < numsSize && i <= r; ++i) {
        d = nums[i] + i;
        if ((r = max(r, d)) >= numsSize - 1)
            return 1;
    }
    
    return 0;
}

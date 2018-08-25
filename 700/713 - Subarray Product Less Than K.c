int numSubarrayProductLessThanK(int* nums, int numsSize, int k) {
    int ret = 0, prod = 1, first = 0;
    
    if (k > 1) {
        for (int i = 0; i < numsSize; ++i) {
            prod *= nums[i];

            while (prod >= k) {
                prod /= nums[first++];
            }

            ret += i - first + 1;
        }
    }
    
    return ret;
}
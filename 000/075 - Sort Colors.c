void sortColors(int* nums, int numsSize) {
    int temp, *l, *r, *c;
    
    if (! nums)
        return;
    l = nums;
    c = l;
    r = nums + numsSize - 1;
    
    while (c >= l && c <= r) {
        if (*c == 0 && c > l) {
            temp = *l;
            *l++ = 0;
            *c = temp;
        } else if (*c == 2 && c < r) {
            temp = *r;
            *r-- = 2;
            *c = temp;
        } else
            ++c;
    }
}

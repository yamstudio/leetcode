#define max(a, b) (a > b ? a : b)
#define min(a, b) (a < b ? a : b)

int trap(int* height, int heightSize) {
    int *l_hi, *r_hi, i, m, w = 0;
    
    if (! heightSize)
        return 0;
    
    l_hi = (int *)malloc(heightSize * sizeof(int));
    r_hi = (int *)malloc(heightSize * sizeof(int));

    l_hi[0] = 0;
    r_hi[heightSize - 1] = 0;
    
    for (i = 1; i < heightSize - 1; ++i)
        l_hi[i] = max(height[i - 1], l_hi[i - 1]);
    
    for (i = heightSize - 2; i > 0; --i) {
        r_hi[i] = max(height[i + 1], r_hi[i + 1]);
        m = min(l_hi[i], r_hi[i]);
        if (height[i] < m)
            w += m - height[i];
    }
    
    free(l_hi);
    free(r_hi);
    
    return w;
}

int numberOfArithmeticSlices(int* A, int ASize) {
    int d, dp, cnt = 2, ret = 0, i;
    
    if (ASize < 3)
        return 0;
    dp = A[1] - A[0];
    
    for (i = 2; i < ASize; ++i) {
        d = A[i] - A[i - 1];
        
        if (d == dp)
            ++cnt;
        else {
            if (cnt > 2)
                ret += (cnt - 1) * (cnt - 2) / 2;
            cnt = 2;
        }
        
        dp = d;
    }
    if (cnt > 2)
        ret += (cnt - 1) * (cnt - 2) / 2;
    
    return ret;
}
int integerBreak(int n) {
    int ret = 1;
    
    if (n <= 3)
        ret = n - 1;
    else {
        while (n > 4) {
            ret *= 3;
            n -= 3;
        }
        ret *= n;
    }
    
    return ret;
}

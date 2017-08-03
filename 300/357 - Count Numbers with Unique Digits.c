int countNumbersWithUniqueDigits(int n) {
    int ret, s, i;
    
    if (n == 0)
        ret = 1;
    else if (n == 1)
        ret = 10;
    else {
        s = 9;
        ret = 10;
        
        for (i = 1; i < n; ++i) {
            s *= 10 - i;
            ret += s;
        }
    }
    
    return ret;
}

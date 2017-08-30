int minSteps(int n) {
    int i;
    
    if (n == 1)
        return 0;
    
    for (i = 2; i * i <= n; ++i) {
        if (n % i == 0)
            return i + minSteps(n / i);
    }
    
    return n;
}

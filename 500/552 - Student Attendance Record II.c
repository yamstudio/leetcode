int checkRecord(int n) {
    int t = 1000000007, *a, *p, *l, i, ret;
    
    a = (int *)malloc(3 * n * sizeof(int));
    p = a + n;
    l = p + n;
    
    a[0] = 1;
    a[1] = 2;
    a[2] = 4;
    p[0] = 1;
    l[0] = 1;
    l[1] = 3;
    
    for (i = 1; i < n; ++i) {
        p[i] = ((a[i - 1] + l[i - 1]) % t + p[i - 1]) % t;
        if (i > 1) {
            l[i] = ((a[i - 2] + p[i - 2]) % t + (a[i - 1] + p[i - 1]) % t) % t;
            if (i > 2)
                a[i] = ((a[i - 3] + a[i - 2]) % t + a[i - 1]) % t;
        }
    }
    
    ret = ((a[n - 1] + l[n - 1]) % t + p[n - 1]) % t;
    free(a);
    
    return ret;
}

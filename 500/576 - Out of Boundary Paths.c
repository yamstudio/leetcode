int findPaths(int m, int n, int N, int i, int j) {
    int **dp, **dp_t, **t, **h, *temp, x, r, c, dr, dc, dirs[] = {0, -1, 0, 1, -1, 0, 1, 0}, ret = 0;
    
    if (! (m && n && N))
        return 0;
    temp = (int *)calloc(2 * m * n, sizeof(int));
    h = (int **)malloc(2 * m * sizeof(int *));
    
    dp = h;
    dp_t = dp + m;
    for (x = 0; x < 2 * m; ++x)
        dp[x] = temp + x * n;
    dp[i][j] = 1;
    
    while (N--) {
        memset(*dp_t, 0, m * n * sizeof(int));
        
        for (r = 0; r < m; ++r) {
            for (c = 0; c < n; ++c) {
                for (x = 0; x < 8; ++x) {
                    dr = r + dirs[x];
                    dc = c + dirs[++x];
                    
                    if (dr < 0 || dr >= m || dc < 0 || dc >= n)
                        ret = (ret + dp[r][c]) % 1000000007;
                    else
                        dp_t[dr][dc] = (dp_t[dr][dc] + dp[r][c]) % 1000000007;
                }
            }
        }
        
        t = dp_t;
        dp_t = dp;
        dp = t;
    }
    
    free(temp);
    free(h);
    
    return ret;
}

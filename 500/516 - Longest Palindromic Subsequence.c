#include <string.h>

#define max(a, b) ((a) > (b) ? (a) : (b))

int longestPalindromeSubseq(char* s) {
    int len, *dp, i, j, n, t, ret = 0;
    
    if (! (s && *s))
        return 0;
    len = strlen(s);
    dp = (int *)malloc(len * sizeof(int));
    
    for (i = 0; i < len; ++i)
        dp[i] = 1;
    
    for (i = len - 1; i >= 0; --i) {
        n = 0;
        
        for (j = i + 1; j < len; ++j) {
            t = dp[j];
            if (s[i] == s[j])
                dp[j] = n + 2;
            n = max(n, t);
        }
    }
    
    for (i = 0; i < len; ++i)
        ret = max(ret, dp[i]);
    
    free(dp);
    
    return ret;
}

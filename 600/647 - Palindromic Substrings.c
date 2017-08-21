#include <string.h>

int countSubstrings(char* s) {
    int **dp, *temp, ret = 0, len, i, j;
    
    if (! (s && *s))
        return 0;
    len = strlen(s);
    temp = (int *)calloc(len * len, sizeof(int));
    dp = (int *)malloc(len * sizeof(int *));
    for (i = 0; i < len; ++i)
        dp[i] = temp + i * len;
    
    for (i = len - 1; i >= 0; --i) {
        for (j = i; j < len; ++j) {
            if ((dp[i][j] = s[i] == s[j] && (j - i < 3 || dp[i + 1][j - 1])))
                ++ret;
        }
    }
    
    free(dp);
    free(temp);
    
    return ret;
}

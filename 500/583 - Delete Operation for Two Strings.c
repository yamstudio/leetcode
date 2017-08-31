#include <string.h>

static inline int min(int a, int b) {
    return a < b ? a : b;
}

int minDistance(char* word1, char* word2) {
    int **dp, *temp, len1, len2, i, j, ret;
    
    len1 = strlen(word1);
    len2 = strlen(word2);
    
    temp = (int *)calloc((len1 + 2) * (len2 + 1), sizeof(int));
    dp = (int **)malloc((len1 + 1) * sizeof(int *));
    for (i = 0; i <= len1; ++i) {
        dp[i] = temp + i * (len2 + 1);
        dp[i][0] = i;
    }
    
    for (j = 0; j <= len2; ++j)
        dp[0][j] = j;
    
    for (i = 1; i <= len1; ++i) {
        for (j = 1; j <= len2; ++j) {
            if (word1[i - 1] == word2[j - 1])
                dp[i][j] = dp[i - 1][j - 1];
            else
                dp[i][j] = min(dp[i][j - 1], dp[i - 1][j]) + 1;
        }
    }
    
    ret = dp[len1][len2];
    free(dp);
    free(temp);
    
    return ret;
}
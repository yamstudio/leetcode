#include <string.h>

static inline int min(int n1, int n2) {
    return n1 > n2 ? n2 : n1;
}

int minimumDeleteSum(char* s1, char* s2) {
    int len1 = strlen(s1), len2 = strlen(s2), ret;
    int *dp = malloc((len2 + 1) * sizeof(int));
    
    dp[0] = 0;
    for (int i = 1; i <= len2; ++i) {
        dp[i] = dp[i - 1] + s2[i - 1];
    }
    
    for (int i = 1; i <= len1; ++i) {
        int prev = dp[0];
        dp[0] += s1[i - 1];

        for (int j = 1; j <= len2; ++j) {
            int curr = dp[j];
            
            if (s1[i - 1] == s2[j - 1]) {
                dp[j] = prev;
            } else {
                dp[j] = min(dp[j - 1] + s2[j - 1], dp[j] + s1[i - 1]);
            }
            prev = curr;
        }
    }
    
    ret = dp[len2];
    free(dp);
    return ret;
}
#include <stdlib.h>

#define max(a, b) ((a) > (b) ? (a) : (b))

static int comp(const void *e1, const void *e2) {
    int *p1 = *(int **)e1, *p2 = *(int **)e2;
    if (p1[0] == p2[0])
        return p1[1] - p2[1];
    return p1[0] - p2[0];
}

int maxEnvelopes(int** envelopes, int envelopesRowSize, int envelopesColSize) {
    int *dp, i, j, ret = 0;
    
    if (! envelopesRowSize)
        return 0;
    qsort(envelopes, envelopesRowSize, sizeof(int *), &comp);
    
    dp = (int *)malloc(envelopesRowSize * sizeof(int));
    
    for (i = 0; i < envelopesRowSize; ++i) {
        dp[i] = 1;
        for (j = 0; j < i; ++j) {
            if (envelopes[j][0] < envelopes[i][0] && envelopes[j][1] < envelopes[i][1])
                dp[i] = max(dp[i], dp[j] + 1);
        }
        ret = max(ret, dp[i]);
    }
    
    return ret;
}

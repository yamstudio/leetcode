class Solution {
    public int findLength(int[] A, int[] B) {
        int len1 = A.length, len2 = B.length;
        int[][] dp = new int[len1 + 1][len2 + 1];
        int ret = 0;
        
        for (int i = 1; i <= len1; ++i) {
            for (int j = 1; j <= len2; ++j) {
                dp[i][j] = (A[i - 1] == B[j - 1] ? (dp[i - 1][j - 1] + 1) : 0);
                ret = Math.max(ret, dp[i][j]);
            }
        }
        
        return ret;
    }
}
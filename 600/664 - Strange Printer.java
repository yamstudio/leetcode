class Solution {
    public int strangePrinter(String s) {
        int len = s.length();
        
        if (len == 0) {
            return 0;
        }
        
        int[][] dp = new int[len][len];
        
        for (int i = len - 1; i >= 0; --i) {
            for (int j = i; j < len; ++j) {
                dp[i][j] = i == j ? 1 : (1 + dp[i + 1][j]);
                
                for (int k = i + 1; k <= j ; ++k) {
                    if (s.charAt(k) == s.charAt(i)) {
                        dp[i][j] = Math.min(dp[i][j], dp[i + 1][k - 1] + dp[k][j]);
                    }
                }
            }
        }
        
        return dp[0][len - 1];
    }
}
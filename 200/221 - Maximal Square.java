public class Solution {
    public int maximalSquare(char[][] matrix) {
        int[][] dp;
        int i, j, ret = 0;
        
        if (matrix == null || matrix.length == 0 || matrix[0].length == 0)
            return 0;
        dp = new int[matrix.length + 1][matrix[0].length + 1];
        
        for (i = 0; i < matrix.length; ++i) {
            for (j = 0; j < matrix[0].length; ++j) {
                if (matrix[i][j] == '1') {
                    dp[i + 1][j + 1] = Math.min(dp[i][j], Math.min(dp[i + 1][j], dp[i][j + 1])) + 1;
                    ret = Math.max(ret, dp[i + 1][j + 1] * dp[i + 1][j + 1]);
                }
            }
        }
        
        return ret;
    }
}

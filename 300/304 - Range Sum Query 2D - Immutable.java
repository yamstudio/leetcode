public class NumMatrix {
    
    int dp[][];

    public NumMatrix(int[][] matrix) {
        int i, j;
        
        this.dp = matrix;
        
        if (matrix.length == 0 || matrix[0].length == 0)
            return;
        
        for (i = 1; i < matrix.length; ++i)
            this.dp[i][0] += this.dp[i - 1][0];
        
        for (j = 1; j < matrix[0].length; ++j)
            this.dp[0][j] += this.dp[0][j - 1];
        
        for (i = 1; i < matrix.length; ++i) {
            for (j = 1; j < matrix[0].length; ++j)
                this.dp[i][j] += this.dp[i - 1][j] + this.dp[i][j - 1] - this.dp[i - 1][j - 1];
        }
    }
    
    public int sumRegion(int row1, int col1, int row2, int col2) {
        if (row1 == 0 && col1 == 0)
            return dp[row2][col2];
        else if (row1 == 0)
            return dp[row2][col2] - dp[row2][col1 - 1];  
        else if (col1 == 0)
            return dp[row2][col2] - dp[row1 - 1][col2];
        return dp[row2][col2] + dp[row1 - 1][col1 - 1] - dp[row1 - 1][col2] - dp[row2][col1 - 1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.sumRegion(row1,col1,row2,col2);
 */
 
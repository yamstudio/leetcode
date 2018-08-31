class Solution:
    def orderOfLargestPlusSign(self, N, mines):
        """
        :type N: int
        :type mines: List[List[int]]
        :rtype: int
        """
        mines_set = set([(m[0], m[1],) for m in mines])
        dp = [[0 for _ in range(N)] for _ in range(N)]
        ret = 0
        
        for i in range(N):
            count = 0
            for j in range(N):
                count = 0 if (i, j) in mines_set else count + 1
                dp[i][j] = count
            
            count = 0
            for j in range(N - 1, -1, -1):
                count = 0 if (i, j) in mines_set else count + 1
                dp[i][j] = min(count, dp[i][j])
            
        for i in range(N):
            count = 0
            for j in range(N):
                count = 0 if (j, i) in mines_set else count + 1
                dp[j][i] = min(count, dp[j][i])
                
            count = 0
            for j in range(N - 1, -1, -1):
                count = 0 if (j, i) in mines_set else count + 1
                dp[j][i] = min(count, dp[j][i])
                ret = max(ret, dp[j][i])
        return ret
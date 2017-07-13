public class Solution {
    public int numDistinct(String s, String t) {
        int[] dp;
        int sLen, tLen, i, j, left, temp;
        
        if (s == null || t == null || s.length() == 0)
            return 0;
        sLen = s.length();
        tLen = t.length();
        dp = new int[sLen + 1];
        
        for (i = 0; i <= sLen; ++i)
            dp[i] = 1;
        
        for (j = 1; j <= tLen; ++j) {
            left = dp[0];
            dp[0] = 0;
            for (i = 1; i <= sLen; ++i) {
                temp = dp[i];
                dp[i] = dp[i - 1];
                if (s.charAt(i - 1) == t.charAt(j - 1))
                    dp[i] += left;
                left = temp;
            }
        }
        
        return dp[sLen];
    }
}

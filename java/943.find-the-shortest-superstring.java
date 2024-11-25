/*
 * @lc app=leetcode id=943 lang=java
 *
 * [943] Find the Shortest Superstring
 */

// @lc code=start

class Solution {
    public String shortestSuperstring(String[] words) {
        int n = words.length;
        int[][] prefixLength = new int[n][n];
        for (int i = 0; i < n; ++i) {
            String w1 = words[i];
            for (int j = 0; j < n; ++j) {
                String w2 = words[j];
                int k = Math.min(w1.length(), w2.length());
                for (int m = 1; m <= k; ++m) {
                    if (w1.substring(w1.length() - m).equals(w2.substring(0, m))) {
                        prefixLength[i][j] = m;
                    }
                }
            }
        }
        int maxLength = Integer.MAX_VALUE;
        int[][] dp = new int[1 << n][n];
        int[][] last = new int[1 << n][n];
        int[] retIndexes = new int[n];
        for (int visited = 0; visited < 1 << n; ++visited) {
            for (int i = 0; i < n; ++i) {
                dp[visited][i] = Integer.MAX_VALUE;
                if (((1 << i) & visited) == 0) {
                    continue;
                }
                if (visited == 1 << i) {
                    dp[visited][i] = words[i].length();
                    continue;
                }
                int prev = visited ^ (1 << i);
                for (int j = 0; j < n; ++j) {
                    if (((1 << j) & prev) == 0) {
                        continue;
                    }
                    int currLength = dp[prev][j] + words[i].length() - prefixLength[j][i];
                    if (currLength < dp[visited][i]) {
                        dp[visited][i] = currLength;
                        last[visited][i] = j;
                    }
                }
                if (visited == (1 << n) - 1) {
                    if (dp[visited][i] < maxLength) {
                        maxLength = dp[visited][i];
                        retIndexes[n - 1] = i;
                    }
                }
            }
        }
        int state = (1 << n) - 1;
        for (int i = n - 2; i >= 0; --i) {
            int curr = last[state][retIndexes[i + 1]];
            state = state ^ (1 << retIndexes[i + 1]);
            retIndexes[i] = curr;
        }
        StringBuilder sb = new StringBuilder();
        sb.append(words[retIndexes[0]]);
        for (int i = 1; i < n; ++i) {
            sb.append(words[retIndexes[i]].substring(prefixLength[retIndexes[i - 1]][retIndexes[i]]));
        }
        return sb.toString();
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1718 lang=java
 *
 * [1718] Construct the Lexicographically Largest Valid Sequence
 */

// @lc code=start
class Solution {
    public int[] constructDistancedSequence(int n) {
        int[] ret = new int[2 * n - 1];
        constructDistancedSequence(ret, new boolean[n + 1], 0);
        return ret;
    }

    private static boolean constructDistancedSequence(int[] ret, boolean[] visited, int i) {
        if (i == ret.length) {
            return true;
        }
        if (ret[i] != 0) {
            return constructDistancedSequence(ret, visited, i + 1);
        }
        for (int v = visited.length - 1; v > 0; --v) {
            if (visited[v]) {
                continue;
            }
            if (v > 1) {
                if (i + v < ret.length && ret[i + v] == 0) {
                    ret[i + v] = v;
                } else {
                    continue;
                }
            }
            visited[v] = true;
            ret[i] = v;
            if (constructDistancedSequence(ret, visited, i + 1)) {
                return true;
            }
            if (v > 1) {
                ret[i + v] = 0;
            }
            ret[i] = 0;
            visited[v] = false;
        }
        return false;
    }
}
// @lc code=end


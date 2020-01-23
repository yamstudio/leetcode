/*
 * @lc app=leetcode id=777 lang=csharp
 *
 * [777] Swap Adjacent in LR String
 */

// @lc code=start
public class Solution {
    public bool CanTransform(string start, string end) {
        int i = 0, j = 0, n = start.Length;
        while (i < n && j < n) {
            while (i < n && start[i] == 'X') {
                ++i;
            }
            while (j < n && end[j] == 'X') {
                ++j;
            }
            if (i == n) {
                return j == n;
            }
            if (j == n) {
                return false;
            }
            if (start[i] != end[j]) {
                return false;
            }
            if ((start[i] == 'L' && i < j) || (start[i] == 'R' && i > j)) {
                return false;
            }
            ++i;
            ++j;
        }
        return true;
    }
}
// @lc code=end


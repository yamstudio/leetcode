/*
 * @lc app=leetcode id=925 lang=csharp
 *
 * [925] Long Pressed Name
 */

// @lc code=start
public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int i = 0, j = 0, l = name.Length, n = typed.Length;
        if (n < l) {
            return false;
        }
        while (i < l) {
            char c = name[i++];
            int count = 1;
            while (i < l && name[i] == c) {
                ++i;
                ++count;
            }
            while (j < n && typed[j] == c) {
                --count;
                ++j;
            }
            if (count > 0 || l - i > n - j) {
                return false;
            }
        }
        return j == n;
    }
}
// @lc code=end


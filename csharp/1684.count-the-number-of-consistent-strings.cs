/*
 * @lc app=leetcode id=1684 lang=csharp
 *
 * [1684] Count the Number of Consistent Strings
 */

// @lc code=start
public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        int a = 0, ret = 0;
        foreach (char c in allowed) {
            a |= 1 << ((int)c - (int)'a');
        }
        foreach (var word in words) {
            bool flag = false;
            foreach (char c in word) {
                if ((a & (1 << ((int)c - (int)'a'))) == 0) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end


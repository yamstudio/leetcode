/*
 * @lc app=leetcode id=1419 lang=csharp
 *
 * [1419] Minimum Number of Frogs Croaking
 */

// @lc code=start
public class Solution {
    public int MinNumberOfFrogs(string croakOfFrogs) {
        int c = 0, r = 0, o = 0, a = 0, k = 0;
        foreach (var t in croakOfFrogs) {
            if (t == 'c') {
                if (k > 0) {
                    --k;
                }
                ++c;
            } else if (t == 'r') {
                if (c-- == 0) {
                    return -1;
                }
                ++r;
            } else if (t == 'o') {
                if (r-- == 0) {
                    return -1;
                }
                ++o;
            } else if (t == 'a') {
                if (o-- == 0) {
                    return -1;
                }
                ++a;
            } else if (t == 'k') {
                if (a-- == 0) {
                    return -1;
                }
                ++k;
            } else {
                return -1;
            }
        }
        if (c != 0 || r != 0 || o != 0 || a != 0) {
            return -1;
        }
        return k;
    }
}
// @lc code=end


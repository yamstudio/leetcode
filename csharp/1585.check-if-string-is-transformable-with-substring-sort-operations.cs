/*
 * @lc app=leetcode id=1585 lang=csharp
 *
 * [1585] Check If String Is Transformable With Substring Sort Operations
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool IsTransformable(string s, string t) {
        var indices = new Queue<int>[10];
        int n = s.Length;
        for (int i = 0; i < 10; ++i) {
            indices[i] = new Queue<int>();
        }
        for (int i = 0; i < n; ++i) {
            indices[(int)s[i] - (int)'0'].Enqueue(i);
        }
        for (int i = 0; i < n; ++i) {
            int k = (int)t[i] - (int)'0';
            if (!indices[k].TryDequeue(out int r)) {
                return false;
            }
            for (int d = 0; d < k; ++d) {
                if (indices[d].TryPeek(out int l) && l < r) {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end


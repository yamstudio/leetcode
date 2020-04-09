/*
 * @lc app=leetcode id=858 lang=csharp
 *
 * [858] Mirror Reflection
 */

// @lc code=start
public class Solution {
    public int MirrorReflection(int p, int q) {
        bool pOdd = p % 2 == 1, qOdd = q % 2 == 1;
        if (pOdd) {
            return qOdd ? 1 : 0;
        }
        return qOdd ? 2 : MirrorReflection(p / 2, q / 2);
    }
}
// @lc code=end


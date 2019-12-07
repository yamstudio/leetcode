/*
 * @lc app=leetcode id=728 lang=csharp
 *
 * [728] Self Dividing Numbers
 */

using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> SelfDividingNumbers(int left, int right) {
        return Enumerable
            .Range(left, right - left + 1)
            .Where(num => {
                int t = num;
                while (t> 0) {
                    int p = t % 10;
                    if (p == 0 || num % p != 0) {
                        return false;
                    }
                    t /= 10;
                }
                return true;
            })
            .ToList();
    }
}
// @lc code=end


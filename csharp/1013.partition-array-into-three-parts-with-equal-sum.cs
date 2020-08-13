/*
 * @lc app=leetcode id=1013 lang=csharp
 *
 * [1013] Partition Array Into Three Parts With Equal Sum
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool CanThreePartsEqualSum(int[] A) {
        int sum = A.Sum();
        if (sum % 3 != 0) {
            return false;
        }
        sum /= 3;
        int acc = 0;
        bool hasFirst = false;
        foreach (int num in A.SkipLast(1)) {
            acc += num;
            if (!hasFirst && acc == sum) {
                hasFirst = true;
            } else if (hasFirst && acc == sum * 2) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end


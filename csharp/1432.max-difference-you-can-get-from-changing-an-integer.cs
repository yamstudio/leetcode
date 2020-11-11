/*
 * @lc app=leetcode id=1432 lang=csharp
 *
 * [1432] Max Difference You Can Get From Changing an Integer
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MaxDiff(int num) {
        if (num < 10) {
            return 8;
        }
        char[] min = num.ToString().ToCharArray(), max = min.ToArray();
        int n = min.Length;
        char minFrom, maxFrom;
        int minTo, maxTo, minNum = 0, maxNum = 0;
        if (min[0] == '1') {
            minFrom = '1';
            for (int i = 1; i < n; ++i) {
                if (min[i] > '1') {
                    minFrom = min[i];
                    break;
                }
            }
            if (minFrom != '1') {
                minTo = 0;
            } else {
                minTo = 1;
            }
        } else {
            minFrom = min[0];
            minTo = 1;
        }
        if (max[0] == '9') {
            maxFrom = '9';
            maxTo = 9;
            for (int i = 1; i < n; ++i) {
                if (max[i] < '9') {
                    maxFrom = max[i];
                    break;
                }
            }
        } else {
            maxFrom = max[0];
            maxTo = 9;
        }
        for (int i = 0; i < n; ++i) {
            minNum = 10 * minNum + (min[i] == minFrom ? minTo : ((int)min[i] - (int)'0'));
            maxNum = 10 * maxNum + (max[i] == maxFrom ? maxTo : ((int)max[i] - (int)'0'));
        }
        return maxNum - minNum;
    }
}
// @lc code=end


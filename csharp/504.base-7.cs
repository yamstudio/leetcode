/*
 * @lc app=leetcode id=504 lang=csharp
 *
 * [504] Base 7
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string ConvertToBase7(int num) {
        if (num == 0) {
            return "0";
        }
        IList<int> ret = new List<int>();
        bool isNegative = num < 0;
        if (isNegative) {
            num = -num;
        }
        while (num > 0) {
            ret.Add(num % 7);
            num /= 7;
        }
        return new string((isNegative ? (new char[] { '-' }) : (new char[0])).Concat(ret.Reverse().Select(x => (char) (x + (int) '0'))).ToArray());
    }
}
// @lc code=end


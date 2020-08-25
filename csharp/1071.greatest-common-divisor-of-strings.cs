/*
 * @lc app=leetcode id=1071 lang=csharp
 *
 * [1071] Greatest Common Divisor of Strings
 */

// @lc code=start
public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        if (!string.Equals(str1 + str2, str2 + str1)) {
            return "";
        }
        if (str1.Length == str2.Length) {
            return str1;
        }
        if (str1.Length > str2.Length) {
            return GcdOfStrings(str1.Substring(str2.Length), str2);
        }
        return GcdOfStrings(str1, str2.Substring(str1.Length));
    }
}
// @lc code=end


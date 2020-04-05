/*
 * @lc app=leetcode id=848 lang=csharp
 *
 * [848] Shifting Letters
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string ShiftingLetters(string S, int[] shifts) {
        shifts[shifts.Length - 1] %= 26;
        for (int i = shifts.Length - 2; i >= 0; --i) {
            shifts[i] = (shifts[i] % 26 + shifts[i + 1]) % 26;
        }
        return new string(S.Zip(shifts, (c, n) => (char)((int)'a' + ((int)c - (int)'a' + n) % 26)).ToArray());
    }
}
// @lc code=end


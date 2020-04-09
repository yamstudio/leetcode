/*
 * @lc app=leetcode id=859 lang=csharp
 *
 * [859] Buddy Strings
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool BuddyStrings(string A, string B) {
        int n = A.Length, diff = 0;
        int[] countA = new int[26], countB = new int[26];
        if (B.Length != n) {
            return false;
        }
        for (int i = 0; i < n; ++i) {
            char a = A[i], b = B[i];
            if (a != b) {
                ++diff;
            }
            countA[(int)a - (int)'a']++;
            countB[(int)b - (int)'a']++;
        }
        return (diff == 2 && countA.Zip(countB, (a, b) => a == b).All(b => b)) || (diff == 0 && countA.Any(c => c > 1));
    }
}
// @lc code=end


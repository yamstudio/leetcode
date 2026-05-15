/*
 * @lc app=leetcode id=1737 lang=java
 *
 * [1737] Change Minimum Characters to Satisfy One of Three Conditions
 */

// @lc code=start
class Solution {
    public int minCharacters(String a, String b) {
        int la = a.length(), lb = b.length();
        int[] countA = new int[26], countB = new int[26];
        for (int i = 0; i < la; ++i) {
            countA[a.charAt(i) - 'a']++;
        }
        for (int i = 0; i < lb; ++i) {
            countB[b.charAt(i) - 'a']++;
        }
        int accA = 0, accB = 0, ret = la + lb;
        for (int i = 0; i < 26; ++i) {
            accA += countA[i];
            accB += countB[i];
            if (i != 25) {
                ret = Math.min(
                    ret,
                    Math.min(
                        la - accA + accB,
                        lb - accB + accA
                    )
                );
            }
            ret = Math.min(ret, la - countA[i] + lb - countB[i]);
        }
        return ret;
    }
}
// @lc code=end


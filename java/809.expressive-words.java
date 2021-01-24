/*
 * @lc app=leetcode id=809 lang=java
 *
 * [809] Expressive Words
 */

// @lc code=start
class Solution {

    private static boolean canExtend(List<int[]> pattern, String word) {
        int n = pattern.size(), k = word.length(), pi = 0;
        for (int i = 0; i < k;) {
            if (pi == n) {
                return false;
            }
            int[] pat = pattern.get(pi);
            if (pat[0] != (int)word.charAt(i)) {
                return false;
            }
            int ni = i + 1;
            while (ni < k && word.charAt(ni) == word.charAt(i)) {
                ++ni;
            }
            if (pat[1] < ni - i || (pat[1] == 2 && ni == i + 1)) {
                return false;
            }
            ++pi;
            i = ni;

        }
        return pi == n;
    }

    public int expressiveWords(String S, String[] words) {
        List<int[]> pattern = new ArrayList<int[]>();
        int k = S.length(), ret = 0;
        for (int i = 0; i < k;) {
            int ni = i + 1;
            while (ni < k && S.charAt(ni) == S.charAt(i)) {
                ++ni;
            }
            pattern.add(new int[] { (int)S.charAt(i), ni - i });
            i = ni;
        }
        for (String word : words) {
            if (word.length() <= k && canExtend(pattern, word)) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end


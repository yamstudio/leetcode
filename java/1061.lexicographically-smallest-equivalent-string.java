/*
 * @lc app=leetcode id=1061 lang=java
 *
 * [1061] Lexicographically Smallest Equivalent String
 */

// @lc code=start
class Solution {
    public String smallestEquivalentString(String s1, String s2, String baseStr) {
        int[] root = new int[26];
        for (int i = 1; i < 26; ++i) {
            root[i] = i;
        }
        int n = s1.length();
        for (int i = 0; i < n; ++i) {
            int c1 = s1.charAt(i) - 'a', c2 = s2.charAt(i) - 'a', r1 = findRoot(root,c1), r2 = findRoot(root, c2);
            if (r1 < r2) {
                root[r2] = r1;
            } else {
                root[r1] = r2;
            }
        }
        int m = baseStr.length();
        StringBuilder sb = new StringBuilder(n);
        for (int i = 0; i < m; ++i) {
            int c = baseStr.charAt(i) - 'a', r = findRoot(root, c);
            sb.append((char)(r + 'a'));
        }
        return sb.toString();
    }

    private static int findRoot(int[] root, int i) {
        if (root[i] == i) {
            return i;
        }
        int r = findRoot(root, root[i]);
        root[i] = r;
        return r;
    }
}
// @lc code=end


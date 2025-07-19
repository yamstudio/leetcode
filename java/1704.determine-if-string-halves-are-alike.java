/*
 * @lc app=leetcode id=1704 lang=java
 *
 * [1704] Determine if String Halves Are Alike
 */

import java.util.Set;

// @lc code=start

class Solution {

    private static final Set<Character> VOWELS = Set.of('a', 'e', 'i', 'o', 'u');

    public boolean halvesAreAlike(String s) {
        int n = s.length(), h = n / 2, acc = 0;
        for (int i = 0; i < h; ++i) {
            if (VOWELS.contains(Character.toLowerCase(s.charAt(i)))) {
                ++acc;
            }
        }
        for (int i = h; i < n; ++i) {
            if (VOWELS.contains(Character.toLowerCase(s.charAt(i)))) {
                --acc;
            }
        }
        return acc == 0;
    }
}
// @lc code=end


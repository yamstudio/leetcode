/*
 * @lc app=leetcode id=1234 lang=java
 *
 * [1234] Replace the Substring for Balanced String
 */

// @lc code=start
class Solution {
    public int balancedString(String s) {
        int[] count = new int[4];
        int n = s.length(), target = n / 4;
        for (int i = 0; i < n; ++i) {
            ++count[key(s.charAt(i))];
        }
        int l = 0, r = 0, ret = n;
        while (l <= r) {
            if (count[0] <= target && count[1] <= target && count[2] <= target && count[3] <= target) {
                ret = Math.min(r - l, ret);
                ++count[key(s.charAt(l++))];
            } else {
                if (r >= n) {
                    break;
                }
                --count[key(s.charAt(r++))];
            }
        }
        return ret;
    }

    private static int key(char c) {
        return switch (c) {
            case 'Q' -> 0;
            case 'W' -> 1;
            case 'E' -> 2;
            case 'R' -> 3;
            default -> throw new IllegalStateException();
        };
    }
}
// @lc code=end


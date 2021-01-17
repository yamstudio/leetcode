/*
 * @lc app=leetcode id=788 lang=java
 *
 * [788] Rotated Digits
 */

// @lc code=start
class Solution {

    private static Set<Integer> validDigits = Stream.of(0, 1, 2, 5, 6, 8, 9).collect(Collectors.toSet()), sameDigits = Stream.of(0, 1, 8).collect(Collectors.toSet());

    public int rotatedDigits(int N) {
        char[] arr = Integer.toString(N).toCharArray();
        int ret = 0, k = arr.length;
        Set<Integer> digits = new HashSet<Integer>();
        for (int i = 0; i < k; ++i) {
            int d = (int)arr[i] - (int)'0';
            for (int j = 0; j < d; ++j) {
                if (validDigits.contains(j)) {
                    ret += (int)Math.pow(7, k - 1 - i);
                }
                if (sameDigits.contains(j) && sameDigits.containsAll(digits)) {
                    ret -= (int)Math.pow(3, k - 1 - i);
                }
            }
            if (!validDigits.contains(d)) {
                return ret;
            }
            digits.add(d);
        }
        if (sameDigits.containsAll(digits)) {
            return ret;
        }
        return ret + 1;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1307 lang=java
 *
 * [1307] Verbal Arithmetic Puzzle
 */

// @lc code=start

class Solution {

    private static final int[] POWERS = new int[] {
        1, 10, 100, 1000, 10000, 100000, 1000000, 10000000,
    };

    public boolean isSolvable(String[] words, String result) {
        int[] charToSum = new int[26], charState = new int[2];
        for (String word : words) {
            add(word, charToSum, charState, 1);
        }
        add(result, charToSum, charState, -1);
        return isSolvable(charToSum, charState, 0, 0, 0);
    }

    private static boolean isSolvable(int[] charToSum, int[] charState, int i, int used, int acc) {
        while (i < 26 && (charState[1] & (1 << i)) == 0) {
            ++i;
        }
        if (i == 26) {
            return acc == 0;
        }
        for (int num = 0; num <= 9; ++num) {
            if ((used & (1 << num)) != 0 || (num == 0 && (charState[0] & (1 << i)) != 0)) {
                continue;
            }
            if (isSolvable(charToSum, charState, i + 1, used | (1 << num), acc + num * charToSum[i])) {
                return true;
            }
        }
        return false;
    }

    private static void add(String word, int[] charToSum, int[] charState, int sumSign) {
        int n = word.length();
        if (n > 1) {
            charState[0] |= 1 << (word.charAt(0) - 'A');
        }
        for (int i = 0; i < n; ++i) {
            int c = word.charAt(i) - 'A';
            charState[1] |= 1 << c;
            charToSum[c] += sumSign * POWERS[n - i - 1];
        }
    }
}
// @lc code=end


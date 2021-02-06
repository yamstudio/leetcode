/*
 * @lc app=leetcode id=843 lang=java
 *
 * [843] Guess the Word
 */

// @lc code=start
/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * interface Master {
 *     public int guess(String word) {}
 * }
 */
class Solution {
    public void findSecretWord(String[] wordlist, Master master) {
        while (true) {
            String guess = wordlist[wordlist.length / 2];
            int count = master.guess(guess);
            wordlist = Arrays.stream(wordlist).filter(w -> {
                int t = 0;
                for (int i = 0; i < 6; ++i) {
                    if (guess.charAt(i) == w.charAt(i)) {
                        ++t;
                    }
                }
                return t == count;
            }).toArray(String[]::new);
            if (count == 6) {
                break;
            }
        }
    }
}
// @lc code=end


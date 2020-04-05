/*
 * @lc app=leetcode id=843 lang=csharp
 *
 * [843] Guess the Word
 */

using System.Linq;

// @lc code=start
/**
 * // This is the Master's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Master {
 *     public int Guess(string word);
 * }
 */
class Solution {
    public void FindSecretWord(string[] wordlist, Master master) {
        int count = 0;
        while (count != 6) {
            var guess = wordlist[wordlist.Length / 2];
            count = master.Guess(guess);
            wordlist = wordlist.Where(word => word.Zip(guess, (c1, c2) => c1 == c2).Where(val => val).Count() == count).ToArray();
        }
    }
}
// @lc code=end


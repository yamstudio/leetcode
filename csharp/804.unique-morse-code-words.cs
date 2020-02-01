/*
 * @lc app=leetcode id=804 lang=csharp
 *
 * [804] Unique Morse Code Words
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static string[] Codes = new string[] {
        ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."
    };

    public int UniqueMorseRepresentations(string[] words) {
        return words.Select(word => string.Join("", word.Select(c => Codes[(int)c - (int)'a']))).Distinct().Count();
    }
}
// @lc code=end


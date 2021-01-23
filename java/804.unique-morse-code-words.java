/*
 * @lc app=leetcode id=804 lang=java
 *
 * [804] Unique Morse Code Words
 */

// @lc code=start
class Solution {

    private static String[] codes = new String[] {
        ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."
    };

    public int uniqueMorseRepresentations(String[] words) {
        Set<String> seen = new HashSet<String>();
        StringBuilder sb = new StringBuilder();
        for (String word : words) {
            for (int i = 0; i < word.length(); ++i) {
                sb.append(codes[(int)word.charAt(i) - (int)'a']);
            }
            seen.add(sb.toString());
            sb.setLength(0);
        }
        return seen.size();
    }
}
// @lc code=end


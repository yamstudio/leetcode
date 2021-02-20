/*
 * @lc app=leetcode id=884 lang=java
 *
 * [884] Uncommon Words from Two Sentences
 */

// @lc code=start
class Solution {
    public String[] uncommonFromSentences(String A, String B) {
        Set<String> seen = new HashSet<String>(), bad = new HashSet<String>();
        for (String word : A.split(" ")) {
            if (!seen.add(word)) {
                bad.add(word);
            }
        }
        for (String word : B.split(" ")) {
            if (!seen.add(word)) {
                bad.add(word);
            }
        }
        return seen.stream().filter(w -> !bad.contains(w)).toArray(String[]::new);
    }
}
// @lc code=end


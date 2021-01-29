/*
 * @lc app=leetcode id=819 lang=java
 *
 * [819] Most Common Word
 */

// @lc code=start
class Solution {
    public String mostCommonWord(String paragraph, String[] banned) {
        Map<String, Integer> count = new HashMap<String, Integer>();
        Set<String> set = new HashSet<String>(Arrays.asList(banned));
        String[] split = paragraph.toLowerCase().split(" |\\.|,|;|!|\\?|'");
        for (String word : split) {
            if (set.contains(word) || word.length() == 0) {
                continue;
            }
            if (!count.containsKey(word)) {
                count.put(word, 1);
            } else {
                count.put(word, 1 + count.get(word));
            }
        }
        String ret = "";
        int max = 0;
        for (Map.Entry<String, Integer> entry : count.entrySet()) {
            if (entry.getValue() > max) {
                max = entry.getValue();
                ret = entry.getKey();
            }
        }
        return ret;
    }
}
// @lc code=end


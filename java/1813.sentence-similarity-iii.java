/*
 * @lc app=leetcode id=1813 lang=java
 *
 * [1813] Sentence Similarity III
 */

// @lc code=start
class Solution {
    public boolean areSentencesSimilar(String sentence1, String sentence2) {
        String[] s1 = sentence1.split(" "), s2 = sentence2.split(" ");
        return s1.length > s2.length ? areSentencesSimilar(s1, s2) : areSentencesSimilar(s2, s1);
    }

    private boolean areSentencesSimilar(String[] longer, String[] shorter) {
        int i;
        for (i = 0; i < shorter.length && longer[i].equals(shorter[i]); ++i);
        for (; i < shorter.length && longer[longer.length - shorter.length + i].equals(shorter[i]); ++i);
        return i == shorter.length;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1047 lang=java
 *
 * [1047] Remove All Adjacent Duplicates In String
 */

import java.util.LinkedList;

// @lc code=start
class Solution {
    public String removeDuplicates(String s) {
        LinkedList<Character> list = new LinkedList<>();
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (list.isEmpty() || list.getLast() != c) {
                list.add(c);
                continue;
            }
            while (!list.isEmpty() && list.getLast() == c) {
                list.removeLast();
            }
        }
        StringBuilder sb = new StringBuilder();
        for (Character c : list) {
            sb.append(c);
        }
        return sb.toString();
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1625 lang=java
 *
 * [1625] Lexicographically Smallest String After Applying Operations
 */

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;
import java.util.Set;

// @lc code=start

class Solution {
    public String findLexSmallestString(String s, int a, int b) {
        Set<String> visited = new HashSet<>();
        Queue<String> queue = new ArrayDeque<>();
        queue.add(s);
        String ret = s;
        int n = s.length();
        while (!queue.isEmpty()) {
            String curr = queue.poll();
            if (!visited.add(curr)) {
                continue;
            }
            char[] tmp = curr.toCharArray();
            for (int i = 1; i < n; i += 2) {
                tmp[i] = (char)(((tmp[i] - '0' + a) % 10) + '0');
            }
            String add = new String(tmp);
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < n; ++j) {
                sb.append(curr.charAt((n - b + j + n) % n));
            }
            String rotate = sb.toString();
            if (add.compareTo(ret) < 0) {
                ret = add;
            }
            if (rotate.compareTo(ret) < 0) {
                ret = rotate;
            }
            queue.offer(add);
            queue.offer(rotate);
        }
        return ret;
    }
}
// @lc code=end


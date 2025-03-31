/*
 * @lc app=leetcode id=1519 lang=java
 *
 * [1519] Number of Nodes in the Sub-Tree With the Same Label
 */

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start

class Solution {
    public int[] countSubTrees(int n, int[][] edges, String labels) {
        List<Set<Integer>> tree = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            tree.add(new HashSet<>());
        }
        for (int[] edge : edges) {
            int a = edge[0], b = edge[1];
            tree.get(a).add(b);
            tree.get(b).add(a);
        }
        int[] ret = new int[n];
        countSubTrees(tree, ret, 0, labels);
        return ret;
    }

    private static int[] countSubTrees(List<Set<Integer>> tree, int[] ret, int curr, String labels) {
        int[] count = new int[26];
        for (int nb : tree.get(curr)) {
            tree.get(nb).remove(curr);
            int[] nbCount = countSubTrees(tree, ret, nb, labels);
            for (int c = 0; c < 26; ++c) {
                count[c] += nbCount[c];
            }
        }
        ret[curr] = ++count[labels.charAt(curr) - 'a'];
        return count;
    }
}
// @lc code=end


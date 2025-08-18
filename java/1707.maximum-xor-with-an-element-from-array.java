/*
 * @lc app=leetcode id=1707 lang=java
 *
 * [1707] Maximum XOR With an Element From Array
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int[] maximizeXor(int[] nums, int[][] queries) {
        int k = queries.length, n = nums.length, j = 0;
        int[] ret = new int[k];
        Integer[] qs = new Integer[k];
        for (int i = 0; i < k; ++i) {
            qs[i] = i;
        }
        Node root = new Node();
        Arrays.sort(qs, java.util.Comparator.comparing(i -> queries[i][1]));
        Arrays.sort(nums);
        for (int i = 0; i < k; ++i) {
            int[] q = queries[qs[i]];
            int v = q[0], m = q[1];
            for (; j < n && nums[j] <= m; ++j) {
                insert(root, nums[j]);
            }
            ret[qs[i]] = query(root, v);
        }
        return ret;
    }

    private static void insert(Node root, int x) {
        Node curr = root;
        for (int b = 31; b >= 0; --b) {
            int m = 1 & (x >> b);
            if (curr.children[m] == null) {
                curr.children[m] = new Node();
            }
            curr = curr.children[m];
        }
    }

    private static int query(Node root, int x) {
        if (root.children[0] == null && root.children[1] == null) {
            return -1;
        }
        Node curr = root;
        int ret = 0;
        for (int b = 31; b >= 0; --b) {
            int m = 1 & (x >> b);
            if (curr.children[1 - m] == null) {
                curr = curr.children[m];
            } else {
                curr = curr.children[1 - m];
                ret = ret | (1 << b);
            }
        }
        return ret;
    }

    private static class Node {
        private final Node[] children = new Node[2];
    }
}
// @lc code=end


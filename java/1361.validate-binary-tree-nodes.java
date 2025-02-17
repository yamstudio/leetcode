/*
 * @lc app=leetcode id=1361 lang=java
 *
 * [1361] Validate Binary Tree Nodes
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start

class Solution {
    public boolean validateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild) {
        boolean[] child = new boolean[n];
        for (int i = 0; i < n; ++i) {
            int l = leftChild[i], r = rightChild[i];
            if (l != -1) {
                if (child[l]) {
                    return false;
                }
                child[l] = true;
            }
            if (r != -1) {
                if (child[r]) {
                    return false;
                }
                child[r] = true;
            }
        }
        int root = -1;
        for (int i = 0; i < n; ++i) {
            if (child[i]) {
                continue;
            }
            if (root != -1) {
                return false;
            }
            root = i;
        }
        if (root == -1) {
            return false;
        }
        int count = 0;
        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            int curr = queue.poll();
            int l = leftChild[curr], r = rightChild[curr];
            if (l != -1) {
                queue.offer(l);
            }
            if (r != -1) {
                queue.offer(r);
            }
            ++count;
        }
        return count == n;
    }
}
// @lc code=end


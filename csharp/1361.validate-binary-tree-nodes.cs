/*
 * @lc app=leetcode id=1361 lang=csharp
 *
 * [1361] Validate Binary Tree Nodes
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild) {
        int root = -1, count = 0;
        bool[] isChild = new bool[n];
        for (int i = 0; i < n; ++i) {
            int l = leftChild[i], r = rightChild[i];
            if (l != -1) {
                if (isChild[l]) {
                    return false;
                }
                isChild[l] = true;
            }
            if (r != -1) {
                if (isChild[r]) {
                    return false;
                }
                isChild[r] = true;
            }
        }
        for (int i = 0; i < n; ++i) {
            if (!isChild[i]) {
                if (root != -1) {
                    return false;
                }
                root = i;
            }
        }
        if (root == -1) {
            return false;
        }
        var queue = new Queue<int>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int curr = queue.Dequeue(), l = leftChild[curr], r = rightChild[curr];
            ++count;
            if (l != -1) {
                queue.Enqueue(l);
            }
            if (r != -1) {
                queue.Enqueue(r);
            }
        }
        return count == n;
    }
}
// @lc code=end


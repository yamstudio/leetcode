/*
 * @lc app=leetcode id=1803 lang=java
 *
 * [1803] Count Pairs With XOR in a Range
 */

// @lc code=start
class Solution {
    public int countPairs(int[] nums, int low, int high) {
        Node root = new Node();
        int ret = 0;
        for (int x : nums) {
            ret += count(x, high + 1, root, 1 << 14) - count(x, low, root, 1 << 14);
            insert(root, x, 1 << 14);
        }
        return ret;
    }

    private static void insert(Node curr, int x, int mask) {
        curr.count++;
        int i = ((mask & x) == 0) ? 0 : 1;
        if (curr.children[i] == null) {
            curr.children[i] = new Node();
        }
        if (mask != 0) {
            insert(curr.children[i], x, mask >> 1);
        }
    }

    private static int count(int x, int high, Node curr, int mask) {
        if (curr == null) {
            return 0;
        }
        int ret = count(x, high, curr.child(mask & (x ^ high)), mask >> 1);
        if ((high & mask) != 0) {
            Node sameBitNode = curr.child(x & mask);
            if (sameBitNode != null) {
                ret += sameBitNode.count;
            }
        }
        return ret;
    }

    private static class Node {
        private Node[] children = new Node[2];
        private int count;

        private Node child(int bit) {
            return children[bit == 0 ? 0 : 1];
        }
    }
}
// @lc code=end


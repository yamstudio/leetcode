/*
 * @lc app=leetcode id=947 lang=java
 *
 * [947] Most Stones Removed with Same Row or Column
 */

// @lc code=start
class Solution {
    public int removeStones(int[][] stones) {
        int[] parent = new int[20003];
        for (int[] stone : stones) {
            merge(stone[0] + 1, stone[1] + 10002, parent);
        }
        int ret = stones.length;
        for (int i = 1; i <= 10002; ++i) {
            if (parent[i] == i) {
                --ret;
            }
        }
        return ret;
    }

    private static void merge(int r, int c, int[] parent) {
        int rp = findParent(r, parent);
        int cp = findParent(c, parent);
        if (rp != cp) {
            parent[cp] = rp;
        }
    }

    private static int findParent(int x, int[] parent) {
        if (parent[x] == 0) {
            parent[x] = x;
            return x;
        }
        if (parent[x] == x) {
            return x;
        }
        int p = findParent(parent[x], parent);
        parent[x] = p;
        return p;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1409 lang=java
 *
 * [1409] Queries on a Permutation With Key
 */

// @lc code=start
class Solution {
    public int[] processQueries(int[] queries, int m) {
        int k = queries.length;
        FenwickTree fenwickTree = new FenwickTree(m + k);
        int[] valToIndex = new int[m + 1];
        for (int i = 0; i < m; ++i) {
            fenwickTree.update(k + i, 1);
            valToIndex[i + 1] = k + i;
        }
        int[] ret = new int[k];
        for (int i = 0; i < k; ++i) {
            int curr = queries[i], oldIndex = valToIndex[curr], newIndex = k - 1 - i;
            valToIndex[curr] = newIndex;
            ret[i] = fenwickTree.sum(oldIndex - 1);
            fenwickTree.update(newIndex, 1);
            fenwickTree.update(oldIndex, -1);
        }
        return ret;
    }

    private static class FenwickTree {
        
        private final int[] sums;

        private FenwickTree(int size) {
            sums = new int[size + 1];
        }

        private void update(int i, int val) {
            ++i;
            while (i < sums.length) {
                sums[i] += val;
                i += (-i & i);
            }
        }

        private int sum(int i) {
            ++i;
            int ret = 0;
            while (i > 0) {
                ret += sums[i];
                i -= (-i & i);
            }
            return ret;
        }
    }
}
// @lc code=end


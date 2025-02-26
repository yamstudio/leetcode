/*
 * @lc app=leetcode id=1389 lang=java
 *
 * [1389] Create Target Array in the Given Order
 */

// @lc code=start
class Solution {
    public int[] createTargetArray(int[] nums, int[] index) {
        int n = nums.length;
        int[] pointers = new int[n];
        for (int i = 0; i < n; ++i) {
            pointers[i] = i;
        }
        mergeSort(index, new int[n], pointers, 0, n - 1);
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            ret[index[i]] = nums[i];
        }
        return ret;
    }

    private static void mergeSort(int[] newIndices, int[] tmp, int[] pointers, int l, int r) {
        if (l >= r) {
            return;
        }
        int m = (l + r) / 2;
        mergeSort(newIndices, tmp, pointers, l, m);
        mergeSort(newIndices, tmp, pointers, m + 1, r);
        int i = l, j = m + 1, k = l;
        while (i <= m && j <= r) {
            if (newIndices[pointers[j]] <= j - (m + 1) + newIndices[pointers[i]]) {
                tmp[k++] = pointers[j++];
            } else {
                newIndices[pointers[i]] += j - (m + 1);
                tmp[k++] = pointers[i++];
            }
        }
        while (j <= r) {
            tmp[k++] = pointers[j++];
        }
        while (i <= m) {
            newIndices[pointers[i]] += r - m;
            tmp[k++] = pointers[i++];
        }
        for (int v = l; v <= r; ++v) {
            pointers[v] = tmp[v];
        }
    }
}
// @lc code=end


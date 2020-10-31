/*
 * @lc app=leetcode id=1389 lang=csharp
 *
 * [1389] Create Target Array in the Given Order
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static void MergeSort(int[] pointers, int[] newIndices, int[] tmp, int l, int r) {
        if (l >= r) {
            return;
        }
        int m = (l + r) / 2;
        MergeSort(pointers, newIndices, tmp, l, m);
        MergeSort(pointers, newIndices, tmp, m + 1, r);
        int i = l, j = m + 1, k = l;
        while (i <= m && j <= r) {
            if (newIndices[pointers[j]] <= j - m - 1 + newIndices[pointers[i]]) {
                tmp[k++] = pointers[j++];
            } else {
                newIndices[pointers[i]] += j - m - 1;
                tmp[k++] = pointers[i++];
            }
        }
        while (i <= m) {
            newIndices[pointers[i]] += r - m;
            tmp[k++] = pointers[i++];
        }
        while (j <= r) {
            tmp[k++] = pointers[j++];
        }
        for (int d = l; d <= r; ++d) {
            pointers[d] = tmp[d];
        }
    }

    public int[] CreateTargetArray(int[] nums, int[] index) {
        int n = nums.Length;
        MergeSort(Enumerable.Range(0, n).ToArray(), index, new int[n], 0, n - 1);
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            ret[index[i]] = nums[i];
        }
        return ret;
    }
}
// @lc code=end


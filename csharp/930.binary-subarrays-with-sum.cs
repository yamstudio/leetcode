/*
 * @lc app=leetcode id=930 lang=csharp
 *
 * [930] Binary Subarrays With Sum
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int NumSubarraysWithSum(int[] A, int S) {
        int ret = 0;
        if (S == 0) {
            int i = 0;
            while (i < A.Length) {
                if (A[i] == 1) {
                    ++i;
                    continue;
                }
                int j = i + 1;
                while (j < A.Length && A[j] == 0) {
                    ++j;
                }
                ret += (1 + (j - i)) * (j - i) / 2;
                i = j + 1;
            }
            return ret;
        }
        var oneIndices = A
            .Select((int v, int i) => (Value: v, Index: i))
            .Where(tuple => tuple.Value == 1)
            .Select(tuple => tuple.Index)
            .Prepend(-1)
            .Append(A.Length)
            .ToArray();
        for (int i = 1; i + S < oneIndices.Length; ++i) {
            int l = oneIndices[i] - oneIndices[i - 1];
            int r = oneIndices[i + S] - oneIndices[i + S - 1];
            ret += l * r;
        }
        return ret;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=927 lang=csharp
 *
 * [927] Three Equal Parts
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] ThreeEqualParts(int[] A) {
        int n = A.Length, count = A.Count(x => x == 1);
        if (count % 3 != 0) {
            return new int[] { -1, -1 };
        }
        if (count == 0) {
            return new int[] { 0, n - 1 };
        }
        count /= 3;
        int start = -1, mid, end, curr = 0;
        while (curr == 0) {
            ++start;
            if (A[start] == 1) {
                ++curr;
            }
        }
        mid = start;
        while (curr <= count) {
            ++mid;
            if (A[mid] == 1) {
                ++curr;
            }
        }
        end = mid;
        while (curr <= 2 * count) {
            ++end;
            if (A[end] == 1) {
                ++curr;
            }
        }
        while (end < n) {
            int x = A[start++];
            if (x != A[mid++] || x != A[end++]) {
                return new int[] { -1, -1 };
            }
        }
        if (end == n) {
            return new int[] { start - 1, mid };
        }
        return new int[] { -1, -1 };
    }
}
// @lc code=end


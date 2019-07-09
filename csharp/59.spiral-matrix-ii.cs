/*
 * @lc app=leetcode id=59 lang=csharp
 *
 * [59] Spiral Matrix II
 */
public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] ret = new int[n][];
        for (int i = 0; i < n; ++i) {
            ret[i] = new int[n];
        }
        int ml = n / 2, curr = 1;
        for (int l = 0; l < ml; ++l) {
            int rmax = n - l - 1;
            for (int i = l; i < rmax; ++i) {
                ret[l][i] = curr++;;
            }
            for (int i = l; i < rmax; ++i) {
                ret[i][rmax] = curr++;
            }
            for (int i = rmax; i > l; --i) {
                ret[rmax][i] = curr++;
            }
            for (int i = rmax; i > l; --i) {
                ret[i][l] = curr++;
            }
        }
        if (n % 2 == 1) {
            ret[n / 2][n / 2] = curr;
        }
        return ret;
    }
}


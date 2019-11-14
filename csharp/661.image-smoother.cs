/*
 * @lc app=leetcode id=661 lang=csharp
 *
 * [661] Image Smoother
 */

// @lc code=start
public class Solution {
    public int[][] ImageSmoother(int[][] M) {
        int m = M.Length, n;
        if (m == 0) {
            return new int[0][];
        }
        n = M[0].Length;
        int[][] ret = new int[m][];
        for (int i = 0; i < m; ++i) {
            ret[i] = new int[n];
            for (int j = 0; j < n; ++j) {
                int count = 0, sum = 0;
                for (int di = -1; di <= 1; ++di) {
                    int ni = di + i;
                    if (ni < 0 || ni == m) {
                        continue;
                    }
                    for (int dj = -1; dj <= 1; ++dj) {
                        int nj = dj + j;
                        if (nj < 0 || nj == n) {
                            continue;
                        }
                        ++count;
                        sum += M[ni][nj];
                    }
                }
                ret[i][j] = sum / count;
            }
        }
        return ret;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=886 lang=java
 *
 * [886] Possible Bipartition
 */

// @lc code=start
class Solution {

    private static boolean color(List<Integer>[] map, int[] colors, int i, int c) {
        colors[i] = c;
        for (int j : map[i]) {
            if (colors[j] == c || colors[j] == 0 && !color(map, colors, j, -c)) {
                return false;
            }
        }
        return true;
    }

    public boolean possibleBipartition(int N, int[][] dislikes) {
        List<Integer>[] map = new List[N];
        int[] colors = new int[N];
        for (int i = 0; i < N; ++i) {
            map[i] = new ArrayList<Integer>();
        }
        for (int[] d : dislikes) {
            int a = d[0] - 1, b = d[1] - 1;
            map[a].add(b);
            map[b].add(a);
        }
        for (int i = 0; i < N; ++i) {
            if (colors[i] == 0 && !color(map, colors, i, 1)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end


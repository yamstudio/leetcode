/*
 * @lc app=leetcode id=834 lang=java
 *
 * [834] Sum of Distances in Tree
 */

// @lc code=start
class Solution {

    private static void buildCount(List<Integer>[] map, int curr, int prev, int[] count, int[] ret) {
        count[curr] = 1;
        for (Integer next : map[curr]) {
            if (prev == next) {
                continue;
            }
            buildCount(map, next, curr, count, ret);
            count[curr] += count[next];
            ret[curr] += ret[next] + count[next];
        }
    }

    private static void buildRet(List<Integer>[] map, int curr, int prev, int[] count, int[] ret) {
        for (Integer next : map[curr]) {
            if (prev == next) {
                continue;
            }
            ret[next] = ret[curr] + map.length - count[next] - count[next];
            buildRet(map, next, curr, count, ret);
        }
    }

    public int[] sumOfDistancesInTree(int N, int[][] edges) {
        List<Integer>[] map = new List[N];
        int[] count = new int[N], ret = new int[N];
        for (int i = 0; i < N; ++i) {
            map[i] = new ArrayList<Integer>();
        }
        for (int[] edge : edges) {
            map[edge[0]].add(edge[1]);
            map[edge[1]].add(edge[0]);
        }
        buildCount(map, 0, -1, count, ret);
        buildRet(map, 0, -1, count, ret);
        return ret;
    }
}
// @lc code=end


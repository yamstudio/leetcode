/*
 * @lc app=leetcode id=815 lang=java
 *
 * [815] Bus Routes
 */

// @lc code=start
class Solution {
    public int numBusesToDestination(int[][] routes, int S, int T) {
        Map<Integer, List<Integer>> stopToRoute = new HashMap<Integer, List<Integer>>();
        int n = routes.length;
        boolean[] taken = new boolean[n];
        Set<Integer> visited = new HashSet<Integer>();
        Queue<int[]> queue = new LinkedList<int[]>();
        for (int i = 0; i < n; ++i) {
            for (int s : routes[i]) {
                if (!stopToRoute.containsKey(s)) {
                    stopToRoute.put(s, new ArrayList<Integer>());
                }
                stopToRoute.get(s).add(i);
            }
        }
        visited.add(S);
        queue.offer(new int[] { S, 0 });
        while (queue.size() > 0) {
            int[] t = queue.poll();
            if (t[0] == T) {
                return t[1];
            }
            for (int i : stopToRoute.get(t[0])) {
                if (taken[i]) {
                    continue;
                }
                taken[i] = true;
                for (int x : routes[i]) {
                    if (!visited.add(x)) {
                        continue;
                    }
                    queue.offer(new int[] { x, t[1] + 1 });
                }
            }
        }
        return -1;
    }
}
// @lc code=end


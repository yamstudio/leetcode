/*
 * @lc app=leetcode id=787 lang=java
 *
 * [787] Cheapest Flights Within K Stops
 */

// @lc code=start
class Solution {
    public int findCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        Queue<int[]> pq = new PriorityQueue<int[]>((t1, t2) -> Integer.compare(t1[0], t2[0]));
        Map<Integer, List<int[]>> map = new HashMap<Integer, List<int[]>>();
        for (int[] flight : flights) {
            int from = flight[0], to = flight[1], cost = flight[2];
            if (!map.containsKey(from)) {
                map.put(from, new ArrayList<int[]>());
            }
            map.get(from).add(new int[] { to, cost });
        }
        pq.offer(new int[] { 0, src, 0 });
        while (pq.size() > 0) {
            int[] curr = pq.poll();
            int dist = curr[0], index = curr[1], stops = curr[2];
            if (index == dst) {
                return dist;
            }
            if (stops > K || !map.containsKey(index)) {
                continue;
            }
            for (int[] next : map.get(index)) {
                pq.offer(new int[] { dist + next[1], next[0], stops + 1 });
            }
        }
        return -1;
    }
}
// @lc code=end


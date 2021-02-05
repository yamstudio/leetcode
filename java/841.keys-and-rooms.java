/*
 * @lc app=leetcode id=841 lang=java
 *
 * [841] Keys and Rooms
 */

// @lc code=start
class Solution {
    public boolean canVisitAllRooms(List<List<Integer>> rooms) {
        int n = rooms.size();
        Set<Integer> visited = new HashSet<Integer>();
        Queue<Integer> queue = new LinkedList<Integer>();
        visited.add(0);
        queue.offer(0);
        while (queue.size() > 0) {
            int curr = queue.poll();
            for (int next : rooms.get(curr)) {
                if (visited.add(next)) {
                    queue.offer(next);
                }
            }
        }
        return n == visited.size();
    }
}
// @lc code=end


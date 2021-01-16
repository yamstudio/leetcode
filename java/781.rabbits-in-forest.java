/*
 * @lc app=leetcode id=781 lang=java
 *
 * [781] Rabbits in Forest
 */

// @lc code=start
class Solution {
    public int numRabbits(int[] answers) {
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        int ret = 0;
        for (int count : answers) {
            if (map.containsKey(count)) {
                map.put(count, 1 + map.get(count));
            } else {
                map.put(count, 1);
            }
        }
        for (Map.Entry<Integer, Integer> entry : map.entrySet()) {
            int key = entry.getKey(), value = entry.getValue();
            ret += ((value + key) / (key + 1)) * (key + 1);
        }
        return ret;
    }
}
// @lc code=end


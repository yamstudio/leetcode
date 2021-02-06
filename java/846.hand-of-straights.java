/*
 * @lc app=leetcode id=846 lang=java
 *
 * [846] Hand of Straights
 */

// @lc code=start
class Solution {
    public boolean isNStraightHand(int[] hand, int W) {
        int n = hand.length;
        if (n % W != 0) {
            return false;
        }
        Map<Integer, Integer> count = new HashMap<Integer, Integer>();
        for (int h : hand) {
            if (!count.containsKey(h)) {
                count.put(h, 1);
            } else {
                count.put(h, count.get(h) + 1);
            }
        }
        List<Integer> sorted = count.keySet().stream().sorted().collect(Collectors.toList());
        int k = sorted.size(), p = 0;
        for (int i = 0; i < n; i += W) {
            while (count.get(sorted.get(p)) == 0) {
                ++p;
            }
            int b = sorted.get(p);
            for (int j = 0; j < W; ++j) {
                if (j + p >= k || sorted.get(p + j) != b + j || count.get(b + j) == 0) {
                    return false;
                }
                count.put(b + j, count.get(b + j) - 1);
            }
        }
        return true;
    }
}
// @lc code=end


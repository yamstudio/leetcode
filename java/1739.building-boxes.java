/*
 * @lc app=leetcode id=1739 lang=java
 *
 * [1739] Building Boxes
 */

// @lc code=start
class Solution {
    public int minimumBoxes(int n) {
        int acc = 0, layer = 0, layerCount = 0;
        while (acc < n) {
            ++layer;
            layerCount += layer;
            acc += layerCount;
        }
        if (n == acc) {
            return layerCount;
        }
        int acc2 = acc - layerCount, rem = 0;
        while (acc2 < n) {
            ++rem;
            acc2 += rem;
        }
        return (layerCount - layer) + rem;
    }
}
// @lc code=end


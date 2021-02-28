/*
 * @lc app=leetcode id=898 lang=java
 *
 * [898] Bitwise ORs of Subarrays
 */

// @lc code=start
class Solution {
    public int subarrayBitwiseORs(int[] arr) {
        Set<Integer> ret = new HashSet<Integer>(), prev = new HashSet<Integer>(), curr = new HashSet<Integer>();;
        for (int x : arr) {
            curr.add(x);
            ret.add(x);
            for (int y : prev) {
                curr.add(x | y);
                ret.add(x | y);
            }
            Set<Integer> tmp = curr;
            curr = prev;
            prev = tmp;
            curr.clear();
        }
        return ret.size();
    }
}
// @lc code=end


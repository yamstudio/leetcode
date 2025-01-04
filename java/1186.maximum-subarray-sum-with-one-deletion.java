/*
 * @lc app=leetcode id=1186 lang=java
 *
 * [1186] Maximum Subarray Sum with One Deletion
 */

// @lc code=start
class Solution {
    public int maximumSum(int[] arr) {
        int ret = Integer.MIN_VALUE, del = -1000000, noDel = -1000000;
        for (int num : arr) {
            int nextNoDel = num + Math.max(0, noDel), nextDel = Math.max(noDel, num + del);
            ret = Math.max(ret, Math.max(nextNoDel, nextDel));
            del = nextDel;
            noDel = nextNoDel;
        }
        return ret;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=169 lang=csharp
 *
 * [169] Majority Element
 */
public class Solution {
    public int MajorityElement(int[] nums) {
        int ret = 0, count = 0;
        foreach (int num in nums) {
            if (count == 0) {
                ret = num;
                count = 1;
            } else {
                if (ret == num) {
                    ++count;
                } else {
                    --count;
                }
            }
        }
        return ret;
    }
}


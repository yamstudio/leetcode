/*
 * @lc app=leetcode id=334 lang=csharp
 *
 * [334] Increasing Triplet Subsequence
 */
public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int first = int.MaxValue, second = int.MaxValue;
        foreach (int num in nums) {
            if (first >= num) {
                first = num;
            } else if (second >= num) {
                second = num;
            } else {
                return true;
            }
        }
        return false;
    }
}


/*
 * @lc app=leetcode id=303 lang=csharp
 *
 * [303] Range Sum Query - Immutable
 */
public class NumArray {

    private int[] sum;

    public NumArray(int[] nums) {
        int n = nums.Length;
        sum = new int[n];
        for (int i = 0; i < n; ++i) {
            sum[i] = nums[i] + (i == 0 ? 0 : sum[i - 1]);
        }
    }
    
    public int SumRange(int i, int j) {
        return sum[j] - (i == 0 ? 0 : sum[i - 1]);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */


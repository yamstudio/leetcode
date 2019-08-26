/*
 * @lc app=leetcode id=307 lang=csharp
 *
 * [307] Range Sum Query - Mutable
 */
public class NumArray {

    private int[] sum, numbers;

    public NumArray(int[] nums) {
        int n = nums.Length;
        sum = new int[n + 1];
        numbers = new int[n];
        for (int i = 0; i < n; ++i) {
            Update(i, nums[i]);
        }
    }
    
    public void Update(int i, int val) {
        int delta = val - numbers[i];
        numbers[i] = val;
        for (int j = i + 1; j < sum.Length; j += (j & -j)) {
            sum[j] += delta;
        }
    }
    
    public int SumRange(int i, int j) {
        int ret = 0;
        for (int k = j + 1; k > 0; k -= (k & -k)) {
            ret += sum[k];
        }
        for (int k = i; k > 0; k -= (k & -k)) {
            ret -= sum[k];
        }
        return ret;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(i,val);
 * int param_2 = obj.SumRange(i,j);
 */


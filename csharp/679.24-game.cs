/*
 * @lc app=leetcode id=679 lang=csharp
 *
 * [679] 24 Game
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private delegate bool Operation(IList<double> nums, int i, int j, out double val);

    private static readonly Operation[] Ops = new Operation[]
    {
        (IList<double> nums, int i, int j, out double val) => {
            if (i > j) {
                val = 0;
                return false;
            }
            val = nums[i] + nums[j];
            return true;
        },
        (IList<double> nums, int i, int j, out double val) => {
            val = nums[i] - nums[j];
            return true;
        },
        (IList<double> nums, int i, int j, out double val) => {
            if (i > j) {
                val = 0;
                return false;
            }
            val = nums[i] * nums[j];
            return true;
        },
        (IList<double> nums, int i, int j, out double val) => {
            if (nums[j] < 0.001) {
                val = 0;
                return false;
            }
            val = nums[i] / nums[j];
            return true;
        },
    };

    private static bool JudgePoint24Recurse(IList<double> nums) {
        int n = nums.Count;
        if (n == 1) {
            return Math.Abs(nums[0] - 24) < 0.001;
        }

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i == j) {
                    continue;
                }
                var next = nums.Where((val, index) => index != i && index != j).ToList();
                foreach (var op in Ops) {
                    double val;
                    if (op(nums, i, j, out val)) {
                        next.Add(val);
                        if (JudgePoint24Recurse(next)) {
                            return true;
                        }
                        next.RemoveAt(next.Count - 1);
                    }
                }
            }
        }

        return false;
    }

    public bool JudgePoint24(int[] nums) {
        return JudgePoint24Recurse(nums.Select(x => (double) x).ToList());
    }
}
// @lc code=end


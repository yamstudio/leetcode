/*
 * @lc app=leetcode id=480 lang=csharp
 *
 * [480] Sliding Window Median
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private class HelperList {
        private SortedList<int, int> Sorted;
        public int Count;

        public HelperList() {
            Count = 0;
            Sorted = new SortedList<int, int>();
        }

        public int GetMin() {
            var keys = Sorted.Keys;
            return keys[0];
        }

        public int GetMax() {
            var keys = Sorted.Keys;
            return keys[keys.Count - 1];
        }

        public void Add(int x) {
            if (Sorted.ContainsKey(x)) {
                ++Sorted[x];
            } else {
                Sorted[x] = 1;
            }
            ++Count;
        }

        public void Remove(int x) {
            if (Sorted[x] == 1) {
                Sorted.Remove(x);
            } else {
                --Sorted[x];
            }
            --Count;
        }
    }

    public double[] MedianSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        double[] ret = new double[n - k + 1];
        HelperList left = new HelperList(), right = new HelperList();

        for (int i = 0; i <= n; ++i) {
            if (i >= k) {
                double mid;
                if (left.Count == right.Count) {
                    mid = ((long) left.GetMax() + (long) right.GetMin()) / 2.0;
                } else {
                    mid = left.GetMax();
                }

                int remove = nums[i - k];
                if (mid >= (double) remove) {
                    left.Remove(remove);
                } else {
                    right.Remove(remove);
                }

                ret[i - k] = mid;
            }

            if (i < n) {
                int num = nums[i];
                if (left.Count > 0 && left.GetMax() >= num) {
                    left.Add(num);
                } else {
                    right.Add(num);
                }

                while (left.Count < right.Count) {
                    int move = right.GetMin();
                    right.Remove(move);
                    left.Add(move);
                }

                while (left.Count > right.Count + 1) {
                    int move = left.GetMax();
                    left.Remove(move);
                    right.Add(move);
                }
            }
        }
        return ret;
    }
}
// @lc code=end


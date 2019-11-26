/*
 * @lc app=leetcode id=703 lang=csharp
 *
 * [703] Kth Largest Element in a Stream
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class KthLargest {

    private SortedSet<(int x, int i)> Sorted;
    private int K, Index;

    public KthLargest(int k, int[] nums) {
        K = k;
        Index = nums.Length;
        Sorted = new SortedSet<(int x, int i)>(nums.Select((x, i) => (x, i)), Comparer<(int x, int i)>.Create((a, b) => a.x == b.x ? a.i.CompareTo(b.i) : b.x.CompareTo(a.x)));
        while (Sorted.Count > K) {
            Sorted.Remove(Sorted.Max);
        }
    }
    
    public int Add(int val) {
        Sorted.Add((val, Index++));
        while (Sorted.Count > K) {
            Sorted.Remove(Sorted.Max);
        }
        return Sorted.Max.x;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
// @lc code=end


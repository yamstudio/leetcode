/*
 * @lc app=leetcode id=321 lang=csharp
 *
 * [321] Create Maximum Number
 */

using System.Collections.Generic;

public class Solution {

    private LinkedList<int> Extract(int[] nums, int k) {
        int del = nums.Length - k;
        LinkedList<int> ret = new LinkedList<int>();
        foreach (int num in nums) {
            while (del > 0 && ret.Count > 0 && ret.Last.Value < num) {
                --del;
                ret.RemoveLast();
            }
            ret.AddLast(num);
        }
        while (ret.Count > k) {
            ret.RemoveLast();
        }
        return ret;
    }

    public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
        int n1 = nums1.Length, n2 = nums2.Length, t = Math.Min(k, n1);
        List<int> ret = new List<int>(0);
        for (int len = Math.Max(0, k - n2); len <= t; ++len) {
            LinkedList<int> r1 = Extract(nums1, len), r2 = Extract(nums2, k - len);
            List<int> tmp = new List<int>(k);
            while (r1.Count > 0 && r2.Count > 0) {
                LinkedList<int> r = r1.Count > r2.Count ? r1 : r2;
                var d1 = r1.First;
                var d2 = r2.First;
                while (d1 != null && d2 != null) {
                    if (d1.Value == d2.Value) {
                        d1 = d1.Next;
                        d2 = d2.Next;
                        continue;
                    }
                    if (d1.Value < d2.Value) {
                        r = r2;
                    } else {
                        r = r1;
                    }
                    break;
                }
                tmp.Add(r.First.Value);
                r.RemoveFirst();
            }
            tmp.AddRange(r1);
            tmp.AddRange(r2);
            if (ret.Count < tmp.Count) {
                ret = tmp;
            } else {
                for (int j = 0; j < tmp.Count; ++j) {
                    if (ret[j] == tmp[j]) {
                        continue;
                    }
                    if (ret[j] < tmp[j]) {
                        ret = tmp;
                    }
                    break;
                }
            }
        }
        return ret.ToArray();
    }
}


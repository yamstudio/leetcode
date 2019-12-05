/*
 * @lc app=leetcode id=715 lang=csharp
 *
 * [715] Range Module
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class RangeModule {

    private IList<(int left, int right)> Ranges;

    public RangeModule() {
        Ranges = new List<(int left, int right)>();
    }
    
    public void AddRange(int left, int right) {
        var tmp = new List<(int left, int right)>();
        int n = Ranges.Count, i = 0;
        while (i < n) {
            var range = Ranges[i];
            if (range.right >= left) {
                break;
            }
            tmp.Add(range);
            ++i;
        }
        while (i < n) {
            var range = Ranges[i];
            if (range.left > right) {
                break;
            }
            left = Math.Min(left, range.left);
            right = Math.Max(right, range.right);
            ++i;
        }
        tmp.Add((left: left, right: right));
        for (int j = i; j < n; ++j) {
            tmp.Add(Ranges[j]);
        }
        Ranges = tmp;
    }
    
    public bool QueryRange(int left, int right) {
        return Ranges.TakeWhile(range => range.left <= right).Any(range => range.left <= left && range.right >= right);
    }
    
    public void RemoveRange(int left, int right) {
        var tmp = new List<(int left, int right)>();
        int n = Ranges.Count, i = 0;
        while (i < n) {
            var range = Ranges[i];
            if (range.right > left) {
                break;
            }
            tmp.Add(range);
            ++i;
        }
        while (i < n) {
            var range = Ranges[i];
            if (range.left >= right) {
                break;
            }
            if (range.left < left) {
                tmp.Add((left: range.left, right: left));
            }
            if (range.right > right) {
                tmp.Add((left: right, range.right));
            }
            ++i;
        }
        for (int j = i; j < n; ++j) {
            tmp.Add(Ranges[j]);
        }
        Ranges = tmp;
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);
 */
// @lc code=end


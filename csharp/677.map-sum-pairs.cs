/*
 * @lc app=leetcode id=677 lang=csharp
 *
 * [677] Map Sum Pairs
 */

using System.Collections.Generic;

// @lc code=start
public class MapSum {

    private SortedList<string, int> Map;

    /** Initialize your data structure here. */
    public MapSum() {
        Map = new SortedList<string, int>();
    }
    
    public void Insert(string key, int val) {
        Map[key] = val;
    }
    
    public int Sum(string prefix) {
        int left = 0, right = Map.Count, ret = 0, n = prefix.Length;
        IList<string> keys = Map.Keys;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (keys[mid].CompareTo(prefix) >= 0) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        while (left < keys.Count) {
            var curr = keys[left++];
            if (curr.Length < n || curr.Substring(0, n) != prefix) {
                break;
            }
            ret += Map[curr];
        }
        return ret;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */
// @lc code=end


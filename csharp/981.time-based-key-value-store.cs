/*
 * @lc app=leetcode id=981 lang=csharp
 *
 * [981] Time Based Key-Value Store
 */

using System.Collections.Generic;

// @lc code=start
public class TimeMap {

    private Dictionary<string, IList<(int Time, string Value)>> Map;

    /** Initialize your data structure here. */
    public TimeMap() {
        Map = new Dictionary<string, IList<(int Time, string Value)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!Map.TryGetValue(key, out var list)) {
            list = new List<(int Time, string Value)>();
            Map[key] = list;
        }
        list.Add((Time: timestamp, Value: value));
    }
    
    public string Get(string key, int timestamp) {
        if (!Map.TryGetValue(key, out var list) || list[0].Time > timestamp) {
            return "";
        }
        int l = 0, r = list.Count;
        while (l < r) {
            int m = (l + r) / 2;
            if (list[m].Time <= timestamp) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return list[l - 1].Value;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */
// @lc code=end


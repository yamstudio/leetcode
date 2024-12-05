/*
 * @lc app=leetcode id=981 lang=java
 *
 * [981] Time Based Key-Value Store
 */

import java.util.HashMap;
import java.util.Map;
import java.util.TreeMap;

// @lc code=start

class TimeMap {

    private final Map<String, TreeMap<Integer, String>> keyToTimestampToValue;

    public TimeMap() {
        keyToTimestampToValue = new HashMap<>();
    }
    
    public void set(String key, String value, int timestamp) {
        keyToTimestampToValue.computeIfAbsent(key, ignored -> new TreeMap<>())
            .put(timestamp, value);
    }
    
    public String get(String key, int timestamp) {
        var map = keyToTimestampToValue.get(key);
        if (map == null) {
            return "";
        }
        var e = map.floorEntry(timestamp);
        if (e == null) {
            return "";
        }
        return e.getValue();
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.set(key,value,timestamp);
 * String param_2 = obj.get(key,timestamp);
 */
// @lc code=end


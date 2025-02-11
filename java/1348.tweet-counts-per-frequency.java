/*
 * @lc app=leetcode id=1348 lang=java
 *
 * [1348] Tweet Counts Per Frequency
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

// @lc code=start
import java.util.SortedMap;

class TweetCounts {

    private final Map<String, SortedMap<Integer, Integer>> map;

    public TweetCounts() {
        map = new HashMap<>();
    }
    
    public void recordTweet(String tweetName, int time) {
        SortedMap<Integer, Integer> m = map.computeIfAbsent(tweetName, ignored -> new TreeMap<>());
        m.put(time, m.getOrDefault(time, 0) + 1);
    }
    
    public List<Integer> getTweetCountsPerFrequency(String freq, String tweetName, int startTime, int endTime) {
        int interval;
        if (freq.equals("minute")) {
            interval = 60;
        } else if (freq.equals("hour")) {
            interval = 3600;
        } else {
            interval = 86400;
        }
        SortedMap<Integer, Integer> m = map.get(tweetName);
        int k = 1 + (endTime - startTime) / interval;
        List<Integer> ret = new ArrayList<>(k);
        for (int i = 0; i < k; ++i) {
            ret.add(0);
        }
        if (m != null) {
            for (var entry : m.subMap(startTime, endTime + 1).entrySet()) {
                int i = (entry.getKey() - startTime) / interval;
                ret.set(i, entry.getValue() + ret.get(i));
            }
        }
        return ret;
    }
}

/**
 * Your TweetCounts object will be instantiated and called as such:
 * TweetCounts obj = new TweetCounts();
 * obj.recordTweet(tweetName,time);
 * List<Integer> param_2 = obj.getTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
 */
// @lc code=end


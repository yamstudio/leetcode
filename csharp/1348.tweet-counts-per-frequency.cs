/*
 * @lc app=leetcode id=1348 lang=csharp
 *
 * [1348] Tweet Counts Per Frequency
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class TweetCounts {

    private static IDictionary<string, int> Lengths = new Dictionary<string, int>() {
        { "minute", 60 },
        { "hour", 3600 },
        { "day", 86400 }
    };
    private IDictionary<string, SortedList<int, int>> Map;

    public TweetCounts() {
        Map = new Dictionary<string, SortedList<int, int>>();
    }
    
    public void RecordTweet(string tweetName, int time) {
        if (!Map.TryGetValue(tweetName, out var list)) {
            list = new SortedList<int, int>();
            Map[tweetName] = list;
        }
        if (!list.TryGetValue(time, out int count)) {
            count = 0;
        }
        list[time] = count + 1;
    }
    
    public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime) {
        int length = Lengths[freq], count = (endTime - startTime) / length + 1;
        if (!Map.TryGetValue(tweetName, out var list)) {
            return Enumerable.Repeat(0, count).ToList();
        }
        IList<int> keys = list.Keys, values = list.Values, ret = new List<int>(count);
        int n = keys.Count, l = 0, r = n;
        while (l < r) {
            int m = (l + r) / 2;
            if (keys[m] < startTime) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        while (startTime <= endTime) {
            int acc = 0;
            while (l < n && keys[l] >= startTime && keys[l] < startTime + length && keys[l] <= endTime) {
                acc += values[l++];
            }
            ret.Add(acc);
            startTime += length;
        }
        return ret;
    }
}

/**
 * Your TweetCounts object will be instantiated and called as such:
 * TweetCounts obj = new TweetCounts();
 * obj.RecordTweet(tweetName,time);
 * IList<int> param_2 = obj.GetTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
 */
// @lc code=end


/*
 * @lc app=leetcode id=355 lang=csharp
 *
 * [355] Design Twitter
 */

using System.Collections.Generic;
using System.Linq;

public class Twitter {

    private IDictionary<int, ISet<int>> Followings;
    private IDictionary<int, LinkedList<(int, int)>> Tweets;
    private int Time;

    /** Initialize your data structure here. */
    public Twitter() {
        Followings = new Dictionary<int, ISet<int>>();
        Tweets = new Dictionary<int, LinkedList<(int, int)>>();
        Time = int.MinValue;
    }
    
    /** Compose a new tweet. */
    public void PostTweet(int userId, int tweetId) {
        LinkedList<(int, int)> list;
        if (!Tweets.ContainsKey(userId)) {
            list = new LinkedList<(int, int)>();
            Tweets[userId] = list;
        } else {
            list = Tweets[userId];
        }
        list.AddFirst((Time++, tweetId));
    }
    
    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed(int userId) {
        if (!Followings.ContainsKey(userId)) {
            Followings[userId] = new HashSet<int>();
        }
        SortedList<int, int> ret = new SortedList<int, int>(10, Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (LinkedList<(int, int)> list in Followings[userId].Union(Enumerable.Repeat(userId, 1)).Where(Tweets.ContainsKey).Select(u => Tweets[u])) {
            foreach ((int, int) entry in list) {
                int time = entry.Item1, tweet = entry.Item2;
                if (ret.Count < 10) {
                    ret.Add(time, tweet);
                    continue;
                }
                if (time < ret.Last().Key) {
                    break;
                }
                ret.RemoveAt(9);
                ret.Add(time, tweet);
            }
        }
        return ret.Values;
    }
    
    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void Follow(int followerId, int followeeId) {
        ISet<int> set;
        if (!Followings.ContainsKey(followerId)) {
            set = new HashSet<int>();
            Followings[followerId] = set;
        } else {
            set = Followings[followerId];
        }
        set.Add(followeeId);
    }
    
    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void Unfollow(int followerId, int followeeId) {
        if (Followings.ContainsKey(followerId)) {
            Followings[followerId].Remove(followeeId);
        }
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */


import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.TreeSet;

public class Twitter {
    
    int count;
    HashMap<Integer, HashSet<Integer>> follows;
    HashMap<Integer, TreeSet<Tweet>> tweets;
    TreeSet<Tweet> topTen;
    TweetComparator<Tweet> tweetComparator;
    

    /** Initialize your data structure here. */
    public Twitter() {
        this.count = 0;
        this.follows = new HashMap<Integer, HashSet<Integer>>();
        this.tweets= new HashMap<Integer, TreeSet<Tweet>>();
        this.tweetComparator = new TweetComparator<Tweet>(false);
        this.topTen = new TreeSet<Tweet>(new TweetComparator<Tweet>(true));
    }
    
    /** Compose a new tweet. */
    public void postTweet(int userId, int tweetId) {
        follow(userId, userId);
        
        if (! this.tweets.containsKey(userId))
            this.tweets.put(userId, new TreeSet<Tweet>(this.tweetComparator));
        
        this.tweets.get(userId).add(new Tweet(this.count++, tweetId));
    }
    
    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public List<Integer> getNewsFeed(int userId) {
        List<Integer> ret = new ArrayList<Integer>();
        
        if (this.follows.containsKey(userId)) {
            
            for (Integer followee : this.follows.get(userId)) {
                
                if (this.tweets.containsKey(followee)) {
                    
                    for (Tweet tweet : this.tweets.get(followee)) {
                        
                        if (this.topTen.size() < 10)
                            this.topTen.add(tweet);
                        else {
                            
                            if (this.topTen.first().getIndex() > tweet.getIndex())
                                break;
                            else {
                                this.topTen.pollFirst();
                                this.topTen.add(tweet);
                            }
                        }
                    }
                }
            }
        }
        
        for (Tweet tweet : this.topTen) {
            ret.add(0, tweet.getId());
        }
        
        this.topTen.clear();
        
        return ret;
    }
    
    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void follow(int followerId, int followeeId) {
        if (! this.follows.containsKey(followerId))
            this.follows.put(followerId, new HashSet<Integer>());
        
        this.follows.get(followerId).add(followeeId);
    }
    
    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void unfollow(int followerId, int followeeId) {
        if (followerId == followeeId || ! this.follows.containsKey(followerId))
            return;
        
        this.follows.get(followerId).remove(followeeId);
    }
    
    private class Tweet {
        
        private int index;
        private int id;
        
        public Tweet(int index, int id) {
            this.index = index;
            this.id = id;
        }
        
        public int getIndex() {
            return this.index;
        }
        
        public int getId() {
            return this.id;
        }
    }
    
    private class TweetComparator<Tweet> implements Comparator<Tweet> {
        
        private boolean isAscending;
        
        public TweetComparator(boolean isAscending) {
            this.isAscending = isAscending;
        }
        
        @Override
        public int compare(Twitter.Tweet t1, Twitter.Tweet t2) {
            return this.isAscending ? t1.getIndex() - t2.getIndex() : t2.getIndex() - t1.getIndex();
        }
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.postTweet(userId,tweetId);
 * List<Integer> param_2 = obj.getNewsFeed(userId);
 * obj.follow(followerId,followeeId);
 * obj.unfollow(followerId,followeeId);
 */
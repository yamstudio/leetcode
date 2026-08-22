/*
 * @lc app=leetcode id=1797 lang=java
 *
 * [1797] Design Authentication Manager
 */

import java.util.Map;
import java.util.HashMap;
import java.util.SortedSet;
import java.util.TreeSet;

// @lc code=start

import static java.util.Comparator.comparingInt;

class AuthenticationManager {

    private final int timeToLive;
    private final Map<String, Key> tokenToKey;
    private final SortedSet<Key> keys;

    public AuthenticationManager(int timeToLive) {
        this.timeToLive = timeToLive;
        tokenToKey = new HashMap<>();
        keys = new TreeSet<>(comparingInt(Key::time).thenComparing(Key::tokenId));
    }
    
    public void generate(String tokenId, int currentTime) {
        Key key = tokenToKey.get(tokenId);
        if (key != null) {
            keys.remove(key);
        }
        key = new Key(tokenId, currentTime);
        tokenToKey.put(tokenId, key);
        keys.add(key);
    }
    
    public void renew(String tokenId, int currentTime) {
        Key key = tokenToKey.get(tokenId);
        if (key == null) {
            return;
        }
        keys.remove(key);
        if (key.time() + timeToLive <= currentTime) {
            return;
        }
        key = new Key(tokenId, currentTime);
        tokenToKey.put(tokenId, key);
        keys.add(key);
    }
    
    public int countUnexpiredTokens(int currentTime) {
        Key key = new Key("", currentTime - timeToLive + 1);
        keys.retainAll(keys.tailSet(key));
        return keys.size();
    }

    private record Key(String tokenId, int time) {}
}

/**
 * Your AuthenticationManager object will be instantiated and called as such:
 * AuthenticationManager obj = new AuthenticationManager(timeToLive);
 * obj.generate(tokenId,currentTime);
 * obj.renew(tokenId,currentTime);
 * int param_3 = obj.countUnexpiredTokens(currentTime);
 */
// @lc code=end


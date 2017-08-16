import java.util.ArrayList;
import java.util.HashSet;

public class Solution {
    public List<String> findAllConcatenatedWordsInADict(String[] words) {
        int i, j, len;
        HashSet<String> set = new HashSet<String>();
        List<String> ret = new ArrayList<String>();
        boolean[] dp;
        
        for (String s : words)
            set.add(s);
        
        for (String s : words) {
            len = s.length();
            
            if (len == 0)
                continue;
            
            dp = new boolean[len + 1];
            dp[0] = true;
            
            for (i = 0; i < len; ++i) {
                if (! dp[i])
                    continue;
                
                for (j = i + 1; j <= len; ++j) {
                    if (dp[j])
                        continue;
                    
                    if (j - i < len && set.contains(s.substring(i, j)))
                        dp[j] = true;
                }
            }
            
            if (dp[len])
                ret.add(s);
        }
        
        return ret;
    }
}

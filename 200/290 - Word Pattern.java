import java.util.HashMap;

public class Solution {
    public boolean wordPattern(String pattern, String str) {
        String[] s = str.split(" ");
        HashMap<String, Integer> hm = new HashMap<String, Integer>();
        HashMap<Character, Integer> hmc = new HashMap<Character, Integer>();
        int i;
        
        if (s.length != pattern.length())
            return false;
        
        for (i = 0; i < s.length; ++i) {
            if (! Objects.equals(hmc.put(pattern.charAt(i), i), hm.put(s[i], i)))
                return false;
        }
        
        return true;
    }
}

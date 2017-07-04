import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class Solution {
    public String minWindow(String s, String t) {
        int l = -1, r, minLen, sLen, tLen, i;
        boolean flag = false;
        char c, k;
        char[] ret;
        List<Character> ls = new ArrayList<Character>();
        List<Integer> index = new ArrayList<Integer>();
        HashMap<Character, Integer> map = new HashMap<Character, Integer>(), added = new HashMap<Character, Integer>();
        
        sLen = s.length();
        tLen = t.length();
        minLen = sLen + 1;
        
        for (i = 0; i < tLen; ++i) {
            c = t.charAt(i);
            if (map.containsKey(c))
                map.replace(c, map.get(c) + 1);
            else
                map.put(c, 1);
            added.put(c, 0);
        }
        
        for (i = 0; i < sLen; ++i) {
            c = s.charAt(i);
            if (map.containsKey(c)) {
                added.put(c, added.get(c) + 1);
                ls.add(c);
                index.add(i);
                r = ls.size() - 1;
                while (ls.size() > 0) {
                    k = ls.get(0);
                    if (added.get(k) > map.get(k)){
                        added.put(k, added.get(k) - 1);
                        index.remove(0);
                        ls.remove(0);
                        r -= 2;
                    } else
                        break;
                }
                
                if (! flag) {
                    flag = true;
                    for (Character mk : map.keySet()) {
                        if (map.get(mk) > added.get(mk)) {
                            flag = false;
                            break;
                        }
                    }
                }
                
                if (flag) {
                    if (minLen > index.get(index.size() - 1) - index.get(0) + 1) {
                        l = index.get(0);
                        minLen = index.get(index.size() - 1) - index.get(0) + 1;
                    }
                }
            }
        }
        
        if (minLen <= sLen) {
            ret = new char[minLen];
            for (i = 0; i < minLen; ++i)
                ret[i] = s.charAt(i + l);
            return new String(ret);
        }
        return "";
    }
}

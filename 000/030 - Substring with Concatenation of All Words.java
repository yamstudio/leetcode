import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class Solution {
    public List<Integer> findSubstring(String s, String[] words) {
        int len, i, j, words_size, word_len;
        String sub;
        List<Integer> ret = new ArrayList<Integer>();
        HashMap<String, Integer> hm = new HashMap<String, Integer>(), found = new HashMap<String, Integer>();
        HashSet<Integer> excluded = new HashSet<Integer>();
        
        if (s == null || words == null || words.length == 0)
            return ret;
        words_size = words.length;
        word_len = words[0].length();
        len = word_len * words_size;
        
        for (String w : words) {
            if (hm.containsKey(w))
                hm.replace(w, hm.get(w) + 1);
            else
                hm.put(w, 1);
        }
        
        for (i = 0; i <= s.length() - len; ++i) {
            if (excluded.contains(i))
                continue;
            found.clear();

            for (j = 0; j < len; j += word_len) {
                sub = s.substring(i + j, i + j + word_len);
                if (hm.containsKey(sub)) {
                    if (found.containsKey(sub))
                        found.replace(sub, found.get(sub) + 1);
                    else
                        found.put(sub, 1);
                    if (found.get(sub) > hm.get(sub))
                        break;
                } else {
                    excluded.add(i + j);
                    break;
                }
            }
            if (j == len)
                ret.add(i);
        }
        
        return ret;
    }
}

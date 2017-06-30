import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

public class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        ArrayList<List<String>> ret = new ArrayList<List<String>>();
        ArrayList<String> sub;
        ArrayList<Integer> temp;
        HashMap<String, ArrayList<Integer>> hm = new HashMap<String, ArrayList<Integer>>();
        char[] chars;
        String s;
        
        if (strs == null)
            return null;
        if (strs.length == 0)
            return ret;
        
        for (int i = 0; i < strs.length; ++i) {
            chars = strs[i].toCharArray();
            Arrays.sort(chars);
            s = new String(chars);
            if (hm.containsKey(s)) {
                hm.get(s).add(i);
            } else {
                temp = new ArrayList<Integer>();
                temp.add(i);
                hm.put(s, temp);
            }
        }
        
        for (ArrayList<Integer> t : hm.values()) {
            sub = new ArrayList<String>();
            for (Integer i : t)
                sub.add(strs[i]);
            ret.add(new ArrayList<String>(sub));
        }
        
        return ret;
    }
}

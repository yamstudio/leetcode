import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<Integer> partitionLabels(String S) {
        List<Integer> ret = new ArrayList<>();
        int len = S.length();
        int[] last = new int[26];
        int p = 0, l = 0;
        
        for (int i = 0; i < len; ++i) {
            last[S.charAt(i) - 'a'] = i;
        }
        
        for (int i = 0; i < len; ++i) {
            l = Math.max(l, last[S.charAt(i) - 'a']);
            
            if (i == l) {
                ret.add(i - p + 1);
                p = i + 1;
            }
        }
        
        return ret;
    }
}
import java.util.ArrayList;

public class Solution {
    public List<String> restoreIpAddresses(String s) {
        List<String> ret = new ArrayList<String>();
        
        if (s.length() <= 12)
            parseIP(s, 0, new ArrayList<String>(), ret);
        
        return ret;
    }
    
    private void parseIP(String s, int from, List<String> nums, List<String> ret) {
        String sub;
        int i, num;
        
        if (nums.size() == 4) {
            if (from == s.length()) {
                ret.add(String.join(".", nums));
            }
        }
        
        for (i = 1; i < 4 && (i + from <= s.length()); ++i) {
            sub = s.substring(from, i + from);
            num = Integer.parseInt(sub);
            if ((sub.charAt(0) == '0' && i != 1) || num > 255)
                continue;
            nums.add(sub);
            parseIP(s, from + i, nums, ret);
            nums.remove(nums.size() - 1);
        }
    }
}

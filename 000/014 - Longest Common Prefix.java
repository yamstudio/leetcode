public class Solution {
    public String longestCommonPrefix(String[] strs) {
        String ret = new String();
        int i, j;
        
        if (strs == null || strs.length == 0)
            return ret;
        
        for (j = 0; j < strs[0].length(); ++j) {
            for (i = 1; i < strs.length; ++i) {
                if (j >= strs[i].length() || strs[i].charAt(j) != strs[0].charAt(j))
                    return ret;
            }
            ret = ret + strs[0].charAt(j);
        }
        
        return ret;
    }
}
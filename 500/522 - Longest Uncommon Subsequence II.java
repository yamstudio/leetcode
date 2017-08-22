import java.util.HashSet;
import java.util.Comparator;
import java.util.Arrays;

class Solution {
    public int findLUSlength(String[] strs) {
        HashSet<String> set = new HashSet<String>();
        int i, j;
        boolean flag;
        String curr;
        
        Arrays.sort(strs, new Comparator<String>() {
            @Override
            public int compare(String s1, String s2) {
                int len1 = s1.length(), len2 = s2.length();
                if (len1 == len2)
                    return s1.compareTo(s2);
                return len2 - len1;
            }
        });
        
        for (i = 0; i < strs.length; ++i) {
            curr = strs[i];
            if (i == strs.length - 1 || ! curr.equals(strs[i + 1])) {
                flag = true;
                
                for (String added : set) {
                    j = 0;
                    
                    for (char c : added.toCharArray()) {
                        if (c == curr.charAt(j))
                            ++j;
                        if (j == curr.length())
                            break;
                    }
                    
                    if (j == curr.length()) {
                        flag = false;
                        break;
                    }
                }
                
                if (flag)
                    return curr.length();
            }
            
            set.add(curr);
        }
        
        return -1;
    }
}

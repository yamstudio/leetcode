import java.util.HashSet;

class Solution {
    public int longestPalindrome(String s) {
        HashSet<Character> set = new HashSet<Character>();
        int ret = 0;
        
        for (char c : s.toCharArray()) {
            if (set.contains(c)) {
                set.remove(c);
                ret += 2;
            } else
                set.add(c);
        }
        
        if (! set.isEmpty())
            ++ret;
        
        return ret;
    }
}

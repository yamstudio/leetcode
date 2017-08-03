import java.math.BigInteger;

public class Solution {
    public boolean isAdditiveNumber(String num) {
        int i, j, len = num.length();
        
        for (i = 0; i < len - 2; ++i) {
            for (j = i + 1; j < len - 1; ++j) {
                if (dfs(num.substring(0, i + 1), num.substring(i + 1, j + 1), num.substring(j + 1)))
                    return true;
            }
        }
        
        return false;
    }
    
    private boolean dfs(String a, String b, String c) {
        String r;
        int i;
            
        if (Math.max(a.length(), b.length()) > c.length() || (! isValid(a)) || (! isValid(b)))
            return false;
        
        r = new BigInteger(a).add(new BigInteger(b)).toString();
        
        if (r.length() > c.length())
            return false;
        
        for (i = 0; i < r.length(); ++i) {
            if (r.charAt(i) != c.charAt(i))
                return false;
        }
        
        return r.length() == c.length() ? true : dfs(b, r, c.substring(r.length()));
    }
        
    private boolean isValid(String s) {
        return s.length() == 1 || s.charAt(0) != '0';
    }
}

import java.util.HashMap;

public class Solution {
    public String fractionToDecimal(int numerator, int denominator) {
        StringBuilder ret;
        long n, d;
        HashMap<Long, Long> hm;
        
        if (numerator == 0)
            return "0";
        
        ret = new StringBuilder();
        if ((numerator > 0) ^ (denominator > 0))
            ret.append('-');
        
        n = Math.abs((long)numerator);
        d = Math.abs((long)denominator);
        ret.append(n / d);
        n %= d;
        
        if (n == 0) 
            return ret.toString();
        else {
            ret.append('.');
            hm = new HashMap<Long, Long>();
        }
        
        while (n != 0) {
            if (hm.get(n) != null) {
                ret.insert(Math.toIntExact(hm.get(n)), '(');
                ret.append(')');
                break;
            }
            
            hm.put(n, (long)ret.length());
            n *= 10;
            ret.append(n / d);
            n %= d;
        }
        
        return ret.toString();
    }
}

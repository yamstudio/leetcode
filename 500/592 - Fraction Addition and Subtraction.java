import java.util.regex.Pattern;
import java.util.regex.Matcher;
import java.util.ArrayList;

class Solution {
    public String fractionAddition(String expression) {
        ArrayList<String> found = new ArrayList<String>();
        int[] n, d;
        int i, lcm, ret, gcd;
        String num;
        String[] split;

        Matcher m = Pattern.compile("((\\+|\\-)[0-9]+(/[0-9]+)?(?<!\\+\\-\\/))").matcher((expression.charAt(0) == '-' ? "" : "+") + expression);
        
        while (m.find())
            found.add(m.group());
        if (found.size() < 2)
            return expression;
        
        n = new int[found.size()];
        d = new int[found.size()];
        
        for (i = 0; i < found.size(); ++i) {
            num = found.get(i);
            
            split = num.split("\\/");
            n[i] = Integer.valueOf(split[0]);
            
            try {
                d[i] = Integer.valueOf(split[1]);
            } catch (IndexOutOfBoundsException e) {
                d[i] = 1;
            }
        }
        
        lcm = d[0];
        for (int x : d)
            lcm = findLcm(lcm, x);
        
        ret = 0;
        for (i = 0; i < found.size(); ++i)
            ret += n[i] * lcm / d[i];
        
        gcd = findGcd(lcm, Math.abs(ret));
        
        return String.format("%d/%d", ret / gcd, lcm / gcd);
    }
    
    private static int findGcd(int a, int b) {
        int temp;
        
        while (b > 0) {
            temp = b;
            b = a % b;
            a = temp;
        }
        
        return a;
    }
    
    private static int findLcm(int a, int b) {
        return a * b / findGcd(a, b);
    }
}

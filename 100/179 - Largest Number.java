import java.util.ArrayList;
import java.util.Comparator;
import java.util.Collections;

public class Solution {
    public String largestNumber(int[] nums) {
        List<String> s;
        String ret;
        
        if (nums == null || nums.length == 0)
            return "";
        s = new ArrayList<String>();
        for (int num : nums)
            s.add(Integer.toString(num));
        
        Collections.sort(s, new Comparator<String>() {
            @Override
            public int compare(String s1, String s2) {
                String c1 = s1 + s2, c2 = s2 + s1;
                int i;

                for (i = 0; i < c1.length(); ++i) {
                    if (c1.charAt(i) > c2.charAt(i))
                        return -1;
                    else if (c1.charAt(i) < c2.charAt(i))
                        return 1;
                }
                return 0;
            }
        });
        
        ret = String.join("", s);
        return ret.charAt(0) == '0' ? "0" : ret;
    }
}

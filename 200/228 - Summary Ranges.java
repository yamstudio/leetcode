import java.util.ArrayList;

public class Solution {
    public List<String> summaryRanges(int[] nums) {
        int from, to, i, c;
        List<String> ret = new ArrayList<String>();
        
        if (nums.length == 0)
            return ret;
        to = nums[0];
        from = to;
        
        for (i = 1; i < nums.length; ++i) {
            c = nums[i];
            if (c != to + 1) {
                ret.add(from == to ? Integer.toString(from) : from + "->" + to);
                from = c;
            }
            
            to = c;
        }
        
        if (to != nums[0] || ret.isEmpty())
            ret.add(from == to ? Integer.toString(from) : from + "->" + to);
        
        return ret;
    }
}

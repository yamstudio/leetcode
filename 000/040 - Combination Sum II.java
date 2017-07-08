import java.util.ArrayList;
import java.util.Arrays;

public class Solution {
    public List<List<Integer>> combinationSum2(int[] candidates, int target) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        
        if (candidates != null) {
            Arrays.sort(candidates);
            helper(candidates, target, 0, 0, new ArrayList<Integer>(), ret);
        }
        
        return ret;
    }
    
    private void helper(int[] cands, int target, int from, int sum, List<Integer> prefix, List<List<Integer>> ret) {
        int i, c;
        
        if (sum == target) {
            ret.add(new ArrayList<Integer>(prefix));
            return;
        }
        
        for (i = from; i < cands.length; ++i) {
            c = cands[i];
            if (i != from && c == cands[i - 1])
                continue;
            sum += c;
            if (sum > target)
                break;
            prefix.add(c);
            helper(cands, target, i + 1, sum, prefix, ret);
            prefix.remove(prefix.size() - 1);
            sum -= c;
        }
    }
}

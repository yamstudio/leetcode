import java.util.ArrayList;

public class Solution {
    public List<String> generateParenthesis(int n) {
        List<String> ret = new ArrayList<String>();
        helper(n, 0, 0, "", ret);
        return ret;
    }
    
    private void helper(int n, int left, int right, String prefix, List<String> ret) {
        if (n == right) {
            ret.add(new String(prefix));
            return;
        }
        
        if (left < n)
            helper(n, left + 1, right, prefix + "(", ret);
        
        if (right < left)
            helper(n, left, right + 1, prefix + ")", ret);
    }
}

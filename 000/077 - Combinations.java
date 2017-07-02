import java.util.ArrayList;

public class Solution {
    public List<List<Integer>> combine(int n, int k) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        
        if (k <= n)
            addNext(ret, new ArrayList<Integer>(), 1, n, k);
        
        return ret;
    }
    
    private void addNext(List<List<Integer>> ret, List<Integer> curr, int from, int n, int k) {
        List<Integer> copy;
        int i;
        
        if (curr.size() == k) {
            copy = new ArrayList<Integer>(curr);
            ret.add(copy);
        } else {
            for (i = from; i <= n; ++i) {
                curr.add(i);
                addNext(ret, curr, i + 1, n, k);
                curr.remove(curr.size() - 1);
            }
        }
    }
}
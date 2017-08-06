import java.util.ArrayList;

public class Solution {
    public List<Integer> lexicalOrder(int n) {
        List<Integer> ret = new ArrayList<Integer>(n);
        int i, curr = 1;
        
        for (i = 0; i < n; ++i) {
            ret.add(curr);
            if (curr * 10 <= n)
                curr *= 10;
            else {
                if (curr >= n)
                    curr /= 10;
                ++curr;
                while (curr % 10 == 0)
                    curr /= 10;
            }
        }
        
        return ret;
    }
}

import java.util.HashSet;

class Solution {
    public boolean judgeSquareSum(int c) {
        HashSet<Integer> set = new HashSet<Integer>();
        int i, n = (int)Math.sqrt(c);
        
        for (i = 0; i <= n; ++i) {
            set.add(i * i);
            if (set.contains(c - i * i))
                return true;
        }
        
        return false;
    }
}

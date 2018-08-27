import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<Integer> selfDividingNumbers(int left, int right) {
        List<Integer> ret = new ArrayList<>();
        
        for (int i = left; i <= right; ++i) {
            
            int c = i;
            for (; c > 0; c /= 10) {
                int r = c % 10;
                
                if (r == 0 || i % r != 0) {
                    break;
                }
            }
            
            if (c == 0) {
                ret.add(i);
            }
        }
        
        return ret;
    }
}
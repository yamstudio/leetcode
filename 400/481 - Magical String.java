import java.util.ArrayList;

public class Solution {
    public int magicalString(int n) {
        int i, ret = 1, pos = 2, count = 3, num = 1;
        List<Integer> nums = new ArrayList<Integer>();
        
        if (n <= 0)
            return 0;
        if (n <= 3)
            return 1;
        
        nums.add(1);
        nums.add(2);
        nums.add(2);
        
        while (count < n) {
            for (i = 0; i < nums.get(pos); ++i) {
                nums.add(num);
                if (num == 1 && count < n)
                    ++ret;
                ++count;
            }
            num ^= 3;
            ++pos;
        }
        
        return ret;
    }
}

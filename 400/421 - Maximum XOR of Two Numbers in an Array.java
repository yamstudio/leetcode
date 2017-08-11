import java.util.HashSet;

public class Solution {
    public int findMaximumXOR(int[] nums) {
        HashSet<Integer> set = new HashSet<Integer>();
        int mask = 0, ret = 0, i, temp;
        
        for (i = 31; i >= 0; --i) {
            mask |= 1 << i;
            temp = ret | (1 << i);
            
            for (int num : nums)
                set.add(num & mask);
        
            for (int b : set) {
                if (set.contains(b ^ temp)) {
                    ret = temp;
                    break;
                }
            }
            set.clear();
        }
        
        return ret;
    }
}

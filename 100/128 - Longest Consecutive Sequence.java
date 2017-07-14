import java.util.HashMap;

public class Solution {
    public int longestConsecutive(int[] nums) {
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        int ret = 0, temp, len;
        
        for (int num : nums) {
            if (hm.containsKey(num))
                continue;
            
            if (hm.containsKey(num - 1)) {
                temp = hm.get(num - 1);
                if (temp > 0)
                    continue;
                else {
                    len = 1 - temp;
                    hm.put(num, -len);
                    hm.put(num - len, len);
                    ret = Math.max(ret, len + 1);
                }
            }
            
            
            if (hm.containsKey(num + 1)) {
                temp = hm.get(num + 1);
                if (temp >= 0) {
                    if (hm.containsKey(num)) {
                        len = -hm.get(num) + temp + 1;
                        hm.put(num + hm.get(num), len);
                        hm.put(num + 1 + temp, -len);
                        ret = Math.max(ret, len + 1);
                    } else {
                        len = temp + 1;
                        hm.put(num, len);
                        hm.put(num + len, -len);
                        ret = Math.max(ret, len + 1);
                    }
                }
                continue;
            }
            
            if (! hm.containsKey(num)) {
                hm.put(num, 0);
                ret = Math.max(ret, 1);
            }
        }
        
        return ret;
    }
}

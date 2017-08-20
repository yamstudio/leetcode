import java.util.HashMap;

class Solution {
    public int[] nextGreaterElement(int[] nums1, int[] nums2) {
        int i, j, num;
        boolean flag;
        int[] ret = new int[nums1.length];
        HashMap<Integer, Integer> hm = new HashMap<Integer, Integer>();
        
        for (i = 0; i < nums2.length; ++i)
            hm.put(nums2[i], i);
        
        for (i = 0; i < nums1.length; ++i) {
            num = nums1[i];
            flag = true;
            
            for (j = hm.get(num) + 1; j < nums2.length; ++j) {
                if (nums2[j] > num) {
                    flag = false;
                    ret[i] = nums2[j];
                    break;
                }
            }
            
            if (flag)
                ret[i] = -1;
        }
        
        return ret;
    }
}

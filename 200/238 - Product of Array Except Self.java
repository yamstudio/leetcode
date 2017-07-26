public class Solution {
    public int[] productExceptSelf(int[] nums) {
        int[] ret = new int[nums.length];
        int i, temp;
        
        ret[0] = 1;
        for (i = 1; i < nums.length; ++i)
            ret[i] = ret[i - 1] * nums[i - 1];
        
        temp = 1;
        for (i = nums.length - 2; i >= 0; --i) {
            temp *= nums[i + 1];
            ret[i] *= temp;
        }
        
        return ret;
    }
}

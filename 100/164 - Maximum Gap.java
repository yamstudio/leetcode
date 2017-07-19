public class Solution {
    public int maximumGap(int[] nums) {
        int minNum, maxNum, len, i, p, ret;
        int[][] buckets;
        
        if (nums == null || nums.length < 2)
            return 0;
        minNum = nums[0];
        maxNum = nums[0];
         
        for (int num : nums) {
            minNum = Math.min(minNum, num);
            maxNum = Math.max(maxNum, num);
        }
        
        len = (maxNum - minNum) / (nums.length - 1) + 1;
        buckets = new int[(maxNum - minNum) / len + 1][];
        
        for (int num : nums) {
            i = (num - minNum) / len;
            if (buckets[i] == null) {
                buckets[i] = new int[2];
                buckets[i][0] = num;
                buckets[i][1] = num;
            } else {
                if (num < buckets[i][0])
                    buckets[i][0] = num;
                else if (num > buckets[i][1])
                    buckets[i][1] = num;
            }
        }
        
        ret = buckets[0][1] - buckets[0][0];
        p = 0;
        for (i = 1; i < buckets.length; ++i) {
            if (buckets[i] != null) {
                ret = Math.max(ret, buckets[i][0] - buckets[p][1]);
                p = i;
            }
        }
        
        return ret;
    }
}

class Solution {
    public int findNumberOfLIS(int[] nums) {
        int sz = nums.length, max = 0, maxCount = 0;
        int[] len = new int[sz], count = new int[sz];
        
        for (int i = 0; i < sz; ++i) {
            len[i] = 1;
            count[i] = 1;
            
            for (int j = 0; j < i; ++j) {
                if (nums[i] <= nums[j]) {
                    continue;
                }
                
                if (len[i] < len[j] + 1) {
                    len[i] = len[j] + 1;
                    count[i] = count[j];
                } else if (len[i] == len[j] + 1) {
                    count[i] += count[j];
                }
            }
            
            if (max == len[i]) {
                maxCount += count[i];
            } else if (max < len[i]) {
                max = len[i];
                maxCount = count[i];
            }
        }
        return maxCount;
    }
}
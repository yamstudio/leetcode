class Solution {
    private boolean search(int[] nums, boolean[] used, int k, int target, int sum, int from) {
        if (k == 1) {
            return true;
        }
        
        if (sum == target) {
            return search(nums, used, k - 1, target, 0, 0);
        } else if (sum > target) {
            return false;
        }
        
        for (int i = from; i < nums.length; ++i) {
            if (used[i]) {
                continue;
            }
            
            used[i] = true;
            if (search(nums, used, k, target, sum + nums[i], i + 1)) {
                return true;
            }
            used[i] = false;
        }
        
        return false;
    }
    
    public boolean canPartitionKSubsets(int[] nums, int k) {
        int sum = 0;
        
        for (int n : nums) {
            sum += n;
        }
        
        return sum % k == 0 ? search(nums, new boolean[nums.length], k, sum / k, 0, 0) : false;
    }
}
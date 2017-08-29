class Solution {
    public int findPeakElement(int[] nums) {
        int left = 0, right = nums.length - 1, mid;
        
        while (left < right) {
            mid = left + (right - left) / 2;
            
            if (nums[mid] < nums[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }
        
        return right;
    }
}

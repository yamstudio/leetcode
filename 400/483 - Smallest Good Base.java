class Solution {
    public String smallestGoodBase(String n) {
        long num = Long.valueOf(n), sum, left, right, mid;
        int i, j;
        
        for (i = (int)(Math.log(num + 1) / Math.log(2)); i >= 2; --i) {
            left = 2;
            right = (long)Math.pow(num, 1.0 / (i - 1)) + 1;
            
            while (left < right) {
                mid = left + (right - left) / 2;
                sum = 0;
                
                for (j = 0; j < i && sum < num; ++j)
                    sum = sum * mid + 1;
                
                if (sum == num)
                    return Long.toString(mid);
                else if (sum < num)
                    left = mid + 1;
                else
                    right = mid;
            }
        }
        
        return Long.toString(num - 1);
    }
}

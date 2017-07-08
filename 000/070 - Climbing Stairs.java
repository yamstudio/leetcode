public class Solution {
    public int climbStairs(int n) {
        int p1 = 1, p2 = 1, i, temp;
        
        for (i = 2; i <= n; ++i) {
            temp = p1 + p2;
            p1 = p2;
            p2 = temp;
        }
        
        return p2;
    }
}

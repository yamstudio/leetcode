/*
 * @lc app=leetcode id=860 lang=csharp
 *
 * [860] Lemonade Change
 */

// @lc code=start
public class Solution {
    public bool LemonadeChange(int[] bills) {
        int ten = 0, five = 0;
        foreach (int bill in bills) {
            if (bill == 5) {
                ++five;
                continue;
            } else if (bill == 10) {
                ++ten;
                --five;
            } else {
                if (ten > 0) {
                    --ten;
                    --five;
                } else {
                    five -= 3;
                }
            }
            
            if (five < 0) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end


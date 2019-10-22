/*
 * @lc app=leetcode id=551 lang=csharp
 *
 * [551] Student Attendance Record I
 */

// @lc code=start
public class Solution {
    public bool CheckRecord(string s) {
        bool absent = false;
        int count = 0;
        foreach (char curr in s) {
            switch (curr) {
                case 'A':
                    if (absent) {
                        return false;
                    }
                    count = 0;
                    absent = true;
                    break;
                case 'L':
                    ++count;
                    if (count == 3) {
                        return false;
                    }
                    break;
                default:
                    count = 0;
                    break;
            }
        }
        return true;
    }
}
// @lc code=end


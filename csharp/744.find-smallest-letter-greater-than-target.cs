/*
 * @lc app=leetcode id=744 lang=csharp
 *
 * [744] Find Smallest Letter Greater Than Target
 */

// @lc code=start
public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        int left = 0, right = letters.Length;
        while (left < right) {
            int mid = (left + right) / 2;
            if (letters[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return letters[left % letters.Length];
    }
}
// @lc code=end


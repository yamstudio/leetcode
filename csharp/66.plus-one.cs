/*
 * @lc app=leetcode id=66 lang=csharp
 *
 * [66] Plus One
 */
public class Solution {
    public int[] PlusOne(int[] digits) {
        int carry = 1;
        for (int i = digits.Length - 1; carry == 1 && i >= 0; --i) {
            if (digits[i] == 9) {
                digits[i] = 0;
            } else {
                digits[i] += 1;
                carry = 0;
            }
        }
        if (carry == 0) {
            return digits;
        }
        int[] ret = new int[digits.Length + 1];
        ret[0] = 1;
        for (int i = 1; i <= digits.Length; ++i) {
            ret[i] = digits[i - 1];
        }
        return ret;
    }
}


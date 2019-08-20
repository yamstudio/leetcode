/*
 * @lc app=leetcode id=263 lang=csharp
 *
 * [263] Ugly Number
 */
public class Solution {
    public bool IsUgly(int num) {
        return num > 0 && (num == 1 || (num % 2 == 0 && IsUgly(num / 2)) || (num % 3 == 0 && IsUgly(num / 3)) || (num % 5 == 0 && IsUgly(num / 5)));
    }
}


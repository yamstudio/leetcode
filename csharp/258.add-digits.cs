/*
 * @lc app=leetcode id=258 lang=csharp
 *
 * [258] Add Digits
 */
public class Solution {
    public int AddDigits(int num) {
        return (num - 1) % 9  + 1;
    }
}


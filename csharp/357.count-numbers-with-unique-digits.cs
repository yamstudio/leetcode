/*
 * @lc app=leetcode id=357 lang=csharp
 *
 * [357] Count Numbers with Unique Digits
 */
public class Solution {

    private static readonly int[] Answers = new int[] {
        1, 10, 91, 739, 5275, 32491, 168571, 712891, 2345851, 5611771, 8877691
    };

    public int CountNumbersWithUniqueDigits(int n) {
        return Answers[Math.Min(10, n)];
    }
}


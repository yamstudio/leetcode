/*
 * @lc app=leetcode id=390 lang=csharp
 *
 * [390] Elimination Game
 */
public class Solution {
    public int LastRemaining(int n) {
        return n == 1 ? 1 : (2 * ((n + 2) / 2 - LastRemaining(n / 2)));
    }
}


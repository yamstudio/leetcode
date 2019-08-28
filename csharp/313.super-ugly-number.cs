/*
 * @lc app=leetcode id=313 lang=csharp
 *
 * [313] Super Ugly Number
 */
public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
        int k = primes.Length;
        int[] uglies = new int[n], curr = new int[k], last = new int[k];
        uglies[0] = 1;
        for (int i = 1; i < n; ++i) {
            int min = int.MaxValue;
            for (int j = 0; j < k; ++j) {
                curr[j] = primes[j] * uglies[last[j]];
            }
            foreach (int v in curr) {
                min = Math.Min(v, min);
            }
            for (int j = 0; j < k; ++j) {
                if (min == curr[j]) {
                    ++last[j];
                }
            }
            uglies[i] = min;
        }
        return uglies[n - 1];
    }
}


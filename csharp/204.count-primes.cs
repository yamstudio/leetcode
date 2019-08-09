/*
 * @lc app=leetcode id=204 lang=csharp
 *
 * [204] Count Primes
 */
public class Solution {
    public int CountPrimes(int n) {
        bool[] isNotPrime = new bool[n];
        int ret = 0;
        for (int i = 2; i < n; ++i) {
            if (isNotPrime[i]) {
                continue;
            }
            ret++;
            for (int j = 2; j * i < n; ++j) {
                isNotPrime[j * i] = true;
            }
        }
        return ret;
    }
}


/*
 * @lc app=leetcode id=1220 lang=csharp
 *
 * [1220] Count Vowels Permutation
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int CountVowelPermutationRecurse(char c, int n, IDictionary<(char Curr, int Count), int> memo) {
        if (n == 0) {
            return 1;
        }
        var key = (Curr: c, Count: n);
        if (memo.TryGetValue(key, out int ret)) {
            return ret;
        }
        switch (c) {
            case 'a':
                ret = CountVowelPermutationRecurse('e', n - 1, memo);
                break;
            case 'e':
                ret = (CountVowelPermutationRecurse('a', n - 1, memo) + CountVowelPermutationRecurse('i', n - 1, memo)) % 1000000007;
                break;
            case 'i':
                ret = (CountVowelPermutationRecurse('a', n - 1, memo) + CountVowelPermutationRecurse('e', n - 1, memo)) % 1000000007;
                ret = (ret + CountVowelPermutationRecurse('o', n - 1, memo)) % 1000000007;
                ret = (ret + CountVowelPermutationRecurse('u', n - 1, memo)) % 1000000007;
                break;
            case 'o':
                ret = (CountVowelPermutationRecurse('i', n - 1, memo) + CountVowelPermutationRecurse('u', n - 1, memo)) % 1000000007;
                break;
            case 'u':
                ret = CountVowelPermutationRecurse('a', n - 1, memo);
                break;
            default:
                ret = 0;
                break;
        }
        memo[key] = ret;
        return ret;
    }

    public int CountVowelPermutation(int n) {
        var memo = new Dictionary<(char Curr, int Count), int>();
        int ret = (CountVowelPermutationRecurse('a', n - 1, memo) + CountVowelPermutationRecurse('e', n - 1, memo)) % 1000000007;
        ret = (ret + CountVowelPermutationRecurse('i', n - 1, memo)) % 1000000007;
        ret = (ret + CountVowelPermutationRecurse('o', n - 1, memo)) % 1000000007;
        ret = (ret + CountVowelPermutationRecurse('u', n - 1, memo)) % 1000000007;
        return ret;
    }
}
// @lc code=end


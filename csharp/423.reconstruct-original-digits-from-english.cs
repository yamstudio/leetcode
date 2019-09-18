/*
 * @lc app=leetcode id=423 lang=csharp
 *
 * [423] Reconstruct Original Digits from English
 */

using System.Linq;

public class Solution {
    public string OriginalDigits(string s) {
        int[] letters = new int[26], count = new int[10];
        foreach (char c in s) {
            ++letters[(int) c - (int) 'a'];
        }
        count[6] = letters[(int) 'x' - (int) 'a'];
        count[8] = letters[(int) 'g' - (int) 'a'];
        count[2] = letters[(int) 'w' - (int) 'a'];
        count[4] = letters[(int) 'u' - (int) 'a'];
        count[0] = letters[(int) 'z' - (int) 'a'];
        count[3] = letters[(int) 'h' - (int) 'a'] - count[8];
        count[5] = letters[(int) 'f' - (int) 'a'] - count[4];
        count[7] = letters[(int) 'v' - (int) 'a'] - count[5];
        count[1] = letters[(int) 'o' - (int) 'a'] - count[0] - count[2] - count[4];
        count[9] = letters[(int) 'i' - (int) 'a'] - count[5] - count[6] - count[8];
        return new string(count.Select((n, i) => Enumerable.Repeat((char) (i + (int) '0'), n)).Aggregate((acc, list) => acc.Concat(list)).ToArray());
    }
}


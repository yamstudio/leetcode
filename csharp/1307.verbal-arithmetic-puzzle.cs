/*
 * @lc app=leetcode id=1307 lang=csharp
 *
 * [1307] Verbal Arithmetic Puzzle
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int[] Powers = new int[] {
        1, 10, 100, 1000, 10000, 100000, 1000000
    };

    private static bool IsSolvableRecurse(int[] map, bool[] first, bool[] used, int[] chars, int i, int acc) {
        if (i == chars.Length) {
            return acc == 0;
        }
        for (int n = 0; n <= 9; ++n) {
            if (used[n] || (n == 0 && first[chars[i]])) {
                continue;
            }
            used[n] = true;
            if (IsSolvableRecurse(map, first, used, chars, i + 1, acc + n * map[chars[i]])) {
                return true;
            }
            used[n] = false;
        }
        return false;
    }

    public bool IsSolvable(string[] words, string result) {
        var map = new int[26];
        var first = new bool[26];
        var chars = new HashSet<int>();
        foreach (var word in words) {
            int k = word.Length;
            if (k > 1) {
            first[(int)word[0] - (int)'A'] = true;
            }
            for (int i = 0; i < k; ++i) {
                chars.Add((int)word[i] - (int)'A');
                map[(int)word[i] - (int)'A'] += Powers[k - i - 1];
            }
        }
        if (result.Length > 1) {
            first[(int)result[0] - (int)'A'] = true;
        }
        for (int i = 0; i < result.Length; ++i) {
            chars.Add((int)result[i] - (int)'A');
            map[(int)result[i] - (int)'A'] -= Powers[result.Length - i - 1];
        }
        return IsSolvableRecurse(map, first, new bool[10], chars.ToArray(), 0, 0);
    }
}
// @lc code=end


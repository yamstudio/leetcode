/*
 * @lc app=leetcode id=1160 lang=csharp
 *
 * [1160] Find Words That Can Be Formed by Characters
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int CountCharacters(string[] words, string chars) {
        var count = chars
            .GroupBy(c => c, (char c, IEnumerable<char> all) => (Key: c, Count: all.Count()))
            .ToDictionary(t => t.Key, t => t.Count);
        int ret = 0;
        foreach (var word in words) {
            var curr = new int[26];
            bool flag = false;
            foreach (var c in word) {
                if (!count.TryGetValue(c, out var t) || ++curr[(int)c - (int)'a'] > t) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                ret += word.Length;
            }
        }
        return ret;
    }
}
// @lc code=end


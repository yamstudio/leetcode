/*
 * @lc app=leetcode id=893 lang=csharp
 *
 * [893] Groups of Special-Equivalent Strings
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int NumSpecialEquivGroups(string[] A) {
        return A
            .Select(word => {
                int[] count = new int[52];
                for (int i = 0; i < word.Length; ++i) {
                    if (i % 2 == 0) {
                        ++count[(int)word[i] - (int)'a'];
                    } else {
                        ++count[26 + (int)word[i] - (int)'a'];
                    }
                }
                return string.Join(".", count
                    .Select((val, index) => (Value: val, Index: index))
                    .Where(tuple => tuple.Value > 0)
                    .Select(tuple => $"{tuple.Index}.{tuple.Value}")
                );
            })
            .Distinct()
            .Count();
    }
}
// @lc code=end


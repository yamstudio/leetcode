/*
 * @lc app=leetcode id=811 lang=csharp
 *
 * [811] Subdomain Visit Count
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<string> ParseNames(string names) {
        int n = names.Length;
        yield return names;
        for (int i = 0; i < n; ++i) {
            if (names[i] == '.') {
                yield return names.Substring(i + 1, n - i - 1);
            }
        }
    }

    public IList<string> SubdomainVisits(string[] cpdomains) {
        return cpdomains
            .Select(s => s.Split(' '))
            .Select(arr => (Count: int.Parse(arr[0]), Names: ParseNames(arr[1])))
            .SelectMany(tuple => tuple.Names.Select(name => (Count: tuple.Count, Name: name)))
            .GroupBy(
                visit => visit.Name, 
                visit => visit.Count,
                (name, counts) => $"{counts.Sum()} {name}")
            .ToList();
    }
}
// @lc code=end


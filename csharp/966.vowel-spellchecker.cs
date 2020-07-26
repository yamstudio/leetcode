/*
 * @lc app=leetcode id=966 lang=csharp
 *
 * [966] Vowel Spellchecker
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static HashSet<char> Vowels = new HashSet<char>()
    {
        'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'
    };

    public string[] Spellchecker(string[] wordlist, string[] queries) {
        var originals = new HashSet<string>();
        var cases = new Dictionary<string, string>();
        var omits = new Dictionary<string, string>();
        foreach (var word in wordlist) {
            originals.Add(word);
            string caseKey = word.ToLower();
            if (!cases.ContainsKey(caseKey)) {
                cases[caseKey] = word;
            }
            string omitKey = OmitVowel(word);
            if (!omits.ContainsKey(omitKey)) {
                omits[omitKey] = word;
            }
        }
        int n = queries.Length;
        string[] ret = new string[n];
        for (int i = 0; i < n; ++i) {
            string query = queries[i];
            if (originals.Contains(query)){
                ret[i] = query;
                continue;
            }
            string s;
            if (cases.TryGetValue(query.ToLower(), out s)) {
                ret[i] = s;
                continue;
            }
            if (omits.TryGetValue(OmitVowel(query), out s)) {
                ret[i] = s;
                continue;
            }
            ret[i] = "";
        }
        return ret;
    }

    private static string OmitVowel(string s) {
        return new string(s
            .ToLower()
            .Select(c => Vowels.Contains(c) ? '-' : c)
            .ToArray());
    }
}
// @lc code=end


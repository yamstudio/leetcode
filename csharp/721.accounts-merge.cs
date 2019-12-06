/*
 * @lc app=leetcode id=721 lang=csharp
 *
 * [721] Accounts Merge
 */

using System.Collections.Generic;
using System.Linq;
using System;

// @lc code=start
public class Solution {

    private static string Find(IDictionary<string, string> roots, string curr) {
        return roots[curr] == curr ? curr : Find(roots, roots[curr]);
    }

    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        IDictionary<string, string> names = new Dictionary<string, string>();
        IDictionary<string, string> roots = new Dictionary<string, string>();
        IDictionary<string, ISet<string>> ret = new Dictionary<string, ISet<string>>();
        foreach (var account in accounts) {
            var name = account[0];
            foreach (var email in account.Skip(1)) {
                names[email] = name;
                roots[email] = email;
            }
        }
        foreach (var account in accounts) {
            var root = Find(roots, account[1]);
            foreach (var email in account.Skip(2)) {
                roots[Find(roots, email)] = root;
            }
        }
        foreach (var account in accounts) {
            foreach (var email in account.Skip(1)) {
                var root = Find(roots, email);
                ISet<string> set;
                if (!ret.TryGetValue(root, out set)) {
                    set = new HashSet<string>();
                    ret[root] = set;
                }
                set.Add(email);
            }
        }
        return ret.Values.Select(set => (new string[] { names[set.First()] }).Union(set.OrderBy(email => email, StringComparer.Ordinal)).ToList() as IList<string>).ToList();
    }
}
// @lc code=end


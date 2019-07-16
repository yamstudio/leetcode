/*
 * @lc app=leetcode id=93 lang=csharp
 *
 * [93] Restore IP Addresses
 */

using System.Collections.Generic;

public class Solution {

    private void RestoreIpAddressesDFS(string s, IList<string> ret, IList<string> ips, int curr) {
        if (ips.Count > 4) {
            return;
        }
        if (ips.Count == 4) {
            if (curr == s.Length) {
                ret.Add(string.Join(".", ips));
            }
            return;
        }
        int m = Math.Min(s.Length, curr + 3);
        for (int i = curr; i < m; ++i) {
            string sub = s.Substring(curr, i - curr + 1);
            if (int.Parse(sub) > 255) {
                break;
            }
            ips.Add(sub);
            RestoreIpAddressesDFS(s, ret, ips, i + 1);
            ips.RemoveAt(ips.Count - 1);
            if (s[curr] == '0') {
                break;
            }
        }
    }

    public IList<string> RestoreIpAddresses(string s) {
        IList<string> ret = new List<string>();
        RestoreIpAddressesDFS(s, ret, new List<string>(4), 0);
        return ret;
    }
}


/*
 * @lc app=leetcode id=165 lang=csharp
 *
 * [165] Compare Version Numbers
 */
public class Solution {
    public int CompareVersion(string version1, string version2) {
        var v1 = version1.Split(new char[] { '.' });
        var v2 = version2.Split(new char[] { '.' });
        int diff = v1.Length > v2.Length ? 1 : -1;
        var longer = diff > 0 ? v1 : v2;
        var shorter = diff > 0 ? v2 : v1;
        int len = shorter.Length;
        for (int i = 0; i < len; ++i) {
            int a = int.Parse(longer[i]), b = int.Parse(shorter[i]);
            if (a > b) {
                return diff;
            } else if (a < b) {
                return -diff;
            }
        }
        for (int i = len; i < longer.Length; ++i) {
            if (int.Parse(longer[i]) > 0) {
                return diff;
            }
        }
        return 0;
    }
}


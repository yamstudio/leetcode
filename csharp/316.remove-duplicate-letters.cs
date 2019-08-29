/*
 * @lc app=leetcode id=316 lang=csharp
 *
 * [316] Remove Duplicate Letters
 */

using System.Linq;

public class Solution {
    public string RemoveDuplicateLetters(string s) {
        int[] count = new int[26];
        bool[] visited = new bool[26];
        int[] str = s.Select(c => (int) (c - 'a')).ToArray();
        IList<int> ret = new List<int>();
        foreach (int c in str) {
            ++count[c];
        }
        foreach (int c in str) {
            --count[c];
            if (visited[c]) {
                continue;
            }
            while (ret.Count > 0) {
                int last = ret[ret.Count - 1];
                if (last < c || count[last] == 0) {
                    break;
                }
                ret.RemoveAt(ret.Count - 1);
                visited[last] = false;
            }
            ret.Add(c);
            visited[c] = true;
        }
        return new string(ret.Select(c => (char) (c + 'a')).ToArray());
    }
}


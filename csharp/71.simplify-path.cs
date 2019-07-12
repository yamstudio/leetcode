/*
 * @lc app=leetcode id=71 lang=csharp
 *
 * [71] Simplify Path
 */

using System.Collections.Generic;

public class Solution {
    public string SimplifyPath(string path) {
        string[] dirs = path.Split('/');
        IList<string> ret = new List<string>(dirs.Length);
        foreach (string dir in dirs) {
            if (dir == "." || dir == "") {
                continue;
            } else if (dir == "..") {
                if (ret.Count > 0) {
                    ret.RemoveAt(ret.Count - 1);
                }
            } else {
                ret.Add(dir);
            }
        }
        return "/" + String.Join("/", ret);
    }
}


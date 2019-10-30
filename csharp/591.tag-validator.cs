/*
 * @lc app=leetcode id=591 lang=csharp
 *
 * [591] Tag Validator
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static bool FindNext(string code, string p, int n, int k, out int i) {
        int l = p.Length;
        i = k;
        while (i + l <= n) {
            int j;
            for (j = 0; j < l && code[i + j] == p[j]; ++j);
            if (j == l) {
                return true;
            }
            ++i;
        }
        return false;
    }

    public bool IsValid(string code) {
        IList<string> stack = new List<string>();
        int n = code.Length;
        for (int i = 0; i < n; ++i) {
            int j;
            if (i > 0 && stack.Count == 0) {
                return false;
            } 
            if (i + 12 <= n && code.Substring(i, 9) == "<![CDATA[") {
                if (!FindNext(code, "]]>", n, i + 9, out j)) {
                    return false;
                }
                i = j + 2;
            } else if (i + 3 <= n && code.Substring(i, 2) == "</") {
                if (!FindNext(code, ">", n, i + 2, out j)) {
                    return false;
                }
                string tag = code.Substring(i + 2, j - i - 2);
                if (stack.Count == 0 || stack[stack.Count - 1] != tag) {
                    return false;
                }
                stack.RemoveAt(stack.Count - 1);
                i = j;
            } else if (i + 2 <= n && code[i] == '<') {
                if (!FindNext(code, ">", n, i + 1, out j)) {
                    return false;
                }
                string tag = code.Substring(i + 1, j - i - 1);
                if (tag.Length == 0 || tag.Length > 9) {
                    return false;
                }
                foreach (char c in tag) {
                    if (c < 'A' || c > 'Z') {
                        return false;
                    }
                }
                stack.Add(tag);
                i = j;
            }
        }
        return stack.Count == 0;
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=38 lang=csharp
 *
 * [38] Count and Say
 */

using System.Collections.Generic;
using System.Text;

public class Solution {
    public string CountAndSay(int n) {
        IList<char> curr = new List<char>(), prev = new List<char>();
        prev.Add('1');
        while (--n > 0) {
            char num = prev[0];
            int count = 0;
            while (prev.Count > 0) {
                if (prev[0] == num) {
                    ++count;
                    prev.RemoveAt(0);
                } else {
                    foreach (char c in count.ToString()) {
                        curr.Add(c);
                    }
                    curr.Add(num);
                    count = 0;
                    num = prev[0];
                }
            }
            if (count > 0) {
                foreach (char c in count.ToString()) {
                    curr.Add(c);
                }
                curr.Add(num);
            }
            IList<char> tmp = curr;
            curr = prev;
            prev = tmp;
        }
        StringBuilder sb = new StringBuilder();
        foreach (char c in prev) {
            sb.Append(c);
        }
        return sb.ToString();
    }
}


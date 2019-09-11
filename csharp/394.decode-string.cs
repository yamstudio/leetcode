/*
 * @lc app=leetcode id=394 lang=csharp
 *
 * [394] Decode String
 */

using System.Collections.Generic;
using System.Text;

public class Solution {

    private static readonly ISet<char> Specials = new HashSet<char>
    {
        '[', ']', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
    };

    public string DecodeString(string s) {
        StringBuilder sb = new StringBuilder();
        LinkedList<string> stringStack = new LinkedList<string>();
        IList<int> numStack = new List<int>();
        int i = 0, n = s.Length;
        while (i < n) {
            char c = s[i];
            if (Specials.Contains(c)) {
                if (c == '[') {
                    stringStack.AddLast((string) null);
                    ++i;
                } else if (c == ']') {
                    LinkedListNode<string> node, tmp = stringStack.Last;
                    int count = 0, num = numStack[numStack.Count - 1];
                    numStack.RemoveAt(numStack.Count - 1);
                    while (tmp.Value != null) {
                        ++count;
                        tmp = tmp.Previous;
                    }
                    node = tmp.Next;
                    stringStack.Remove(tmp);
                    sb.Clear();
                    while (node != null) {
                        tmp = node.Next;
                        sb.Append(node.Value);
                        stringStack.Remove(node);
                        node = tmp;
                    }
                    string once = sb.ToString();
                    sb.Clear();
                    while (num-- > 0) {
                        sb.Append(once);
                    }
                    stringStack.AddLast(sb.ToString());
                    sb.Clear();
                    ++i;
                } else if (c >= '0' && c <= '9') {
                    int start = i;
                    do {
                        ++i;
                    } while (s[i] >= '0' && s[i] <= '9');
                    numStack.Add(int.Parse(s.Substring(start, i - start)));
                }
                continue;
            }
            int p = i;
            do {
                ++i;
            } while (i < n && !Specials.Contains(s[i]));
            stringStack.AddLast(s.Substring(p, i - p));
        }
        foreach (string word in stringStack) {
            sb.Append(word);
        }
        return sb.ToString();
    }
}


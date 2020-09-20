/*
 * @lc app=leetcode id=1233 lang=csharp
 *
 * [1233] Remove Sub-Folders from the Filesystem
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;

// @lc code=start
public class Solution {

    private static void BuildStrings(TrieNode root, StringBuilder stringBuilder, IList<string> ret) {
        if (root.Children.Count == 0) {
            ret.Add(stringBuilder.ToString());
            return;
        }
        foreach (var child in root.Children) {
            stringBuilder.Append('/');
            stringBuilder.Append(child.Key);
            BuildStrings(child.Value, stringBuilder, ret);
            stringBuilder.Remove(stringBuilder.Length - 1 - child.Key.Length, 1 + child.Key.Length);
        }
    }

    public IList<string> RemoveSubfolders(string[] folder) {
        var root = new TrieNode();
        foreach (var p in folder) {
            var path = p.Split('/');
            var curr = root;
            foreach (var f in path.Skip(1)) {
                if (curr.Children.TryGetValue(f, out var next)) {
                    curr = next;
                    if (curr.Children.Count == 0) {
                        break;
                    }
                } else {
                    next = new TrieNode();
                    curr.Children[f] = next;
                    curr = next;
                }
            }
            curr.Children.Clear();
        }
        var ret = new List<string>();
        BuildStrings(root, new StringBuilder(), ret);
        return ret;
    }

    private class TrieNode {
        public IDictionary<string, TrieNode> Children { get; }

        public TrieNode() {
            Children = new Dictionary<string, TrieNode>();
        }
    }
}
// @lc code=end


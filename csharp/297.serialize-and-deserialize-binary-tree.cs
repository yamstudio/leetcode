/*
 * @lc app=leetcode id=297 lang=csharp
 *
 * [297] Serialize and Deserialize Binary Tree
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) {
            return "$";
        }
        return $"{root.val} {serialize(root.left)} {serialize(root.right)}";
    }

    private TreeNode DeserializeRecuse(string data, ref int i) {
        if (data[i] == '$') {
            i += 2;
            return null;
        }
        int val = 0, neg = 1;
        if (data[i] == '-') {
            neg = -1;
            ++i;
        }
        while (data[i] != ' ') {
            val = val * 10 + (int) (data[i] - '0');
            ++i;
        }
        TreeNode ret = new TreeNode(val * neg);
        ++i;
        ret.left = DeserializeRecuse(data, ref i);
        ret.right = DeserializeRecuse(data, ref i);
        return ret;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        int i = 0;
        return DeserializeRecuse(data, ref i);
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));


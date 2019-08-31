/*
 * @lc app=leetcode id=331 lang=csharp
 *
 * [331] Verify Preorder Serialization of a Binary Tree
 */
public class Solution {

    private int GetRange(string[] split, int i) {
        if (i >= split.Length) {
            return -1;
        }
        if (split[i] == "#") {
            return i + 1;
        }
        i = GetRange(split, i + 1);
        if (i == -1) {
            return -1;
        }
        return GetRange(split, i);
    }

    public bool IsValidSerialization(string preorder) {
        string[] split = preorder.Split(',');
        return GetRange(split, 0) == split.Length;
    }
}


#
# @lc app=leetcode id=113 lang=python3
#
# [113] Path Sum II
#
# autogenerated using scripts/convert.py
#
# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution(object):
    def pathSum(self, root, sum):
        """
        :type root: TreeNode
        :type sum: int
        :rtype: List[List[int]]
        """
        if not root:
            return []
        
        if root.val == sum and root.left is None and root.right is None:
            return [[root.val]]
        
        left = self.pathSum(root.left, sum - root.val) 
        right = self.pathSum(root.right, sum - root.val)
        
        return [[root.val] + x for x in left + right]

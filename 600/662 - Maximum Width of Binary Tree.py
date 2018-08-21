class Solution:
    def widthOfBinaryTree(self, root):
        """
        :type root: TreeNode
        :rtype: int
        """
        if not root:
            return 0
        queue = [(root, 1)]
        ret = 0

        while queue:
            left = queue[0][1]
            right = left
            for _ in range(len(queue)):
                node, right = queue.pop(0)
                if node.left:
                    queue.append((node.left, right * 2))
                if node.right:
                    queue.append((node.right, right * 2 + 1))
                ret = max(ret, right - left + 1)

        return ret
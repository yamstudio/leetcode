class Solution:
    def maxCount(self, m, n, ops):
        """
        :type m: int
        :type n: int
        :type ops: List[List[int]]
        :rtype: int
        """
        if not ops:
            return m * n
        return min(m, min([x[0] for x in ops])) * min(n, min([x[1] for x in ops]));

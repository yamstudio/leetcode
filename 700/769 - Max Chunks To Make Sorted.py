class Solution:
    def maxChunksToSorted(self, arr):
        """
        :type arr: List[int]
        :rtype: int
        """
        m = 0
        ret = 0
        for i, v in enumerate(arr):
            m = max(v, m)
            if i == m:
                ret += 1
        return ret
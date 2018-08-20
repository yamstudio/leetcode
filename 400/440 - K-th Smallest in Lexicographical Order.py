class Solution:
    def findKthNumber(self, n, k):
        """
        :type n: int
        :type k: int
        :rtype: int
        """
        ret = 1
        k -= 1
        while k:
            curr, inc = ret, ret + 1
            diff = 0
            while curr <= n:
                end = min(inc, n + 1)
                diff += max(end - curr, 0)
                curr *= 10
                inc *= 10
            if diff <= k:
                ret += 1
                k -= diff
            else:
                ret *= 10
                k -= 1
        return ret
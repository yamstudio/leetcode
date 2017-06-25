class Solution(object):
    def countArrangement(self, N):
        """
        :type N: int
        :rtype: int
        """
        self.N = N
        return self.helper(set(range(1, N + 1)))
        
    def helper(self, nums):
        d = self.N - len(nums) + 1;
        count = 0;
        for x in nums:
            if not (d % x and x % d):
                if d is self.N:
                    return 1
                count += self.helper(nums - {x})
        return count
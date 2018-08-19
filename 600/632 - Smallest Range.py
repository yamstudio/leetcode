class Solution:
    def smallestRange(self, nums):
        """
        :type nums: List[List[int]]
        :rtype: List[int]
        """
        def merge_lists(l):
            if len(l) == 1:
                return l[0]
            
            ret = []
            try:
                while l:
                    c = l.pop(0)
                    n = l.pop(0)
                    s = []
                    
                    while c and n:
                        if c[0][0] < n[0][0]:
                            s.append(c.pop(0))
                        else:
                            s.append(n.pop(0))

                    s.extend(c)
                    s.extend(n)

                    ret.append(s)
                    
            except IndexError:
                ret.append(c)

            return merge_lists(ret)
            
        k = len(nums)
        nums = merge_lists([[(v, i) for v in l] for i, l in enumerate(nums)])
        m = {i: 0 for i in range(k)}
        dist = 0
        left = 0
        count = 0
        ret = [nums[0][0], nums[-1][0]]

        for right in range(len(nums)):
            if m[nums[right][1]] == 0:
                count += 1
            m[nums[right][1]] += 1
            
            while count == k and left <= right:
                if ret[1] - ret[0] > nums[right][0] - nums[left][0]:
                    ret = [nums[left][0], nums[right][0]]
                
                m[nums[left][1]] -= 1
                if m[nums[left][1]] == 0:
                    count -= 1
                left += 1
        
        return ret

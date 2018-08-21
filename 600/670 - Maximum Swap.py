class Solution:
    def maximumSwap(self, num):
        """
        :type num: int
        :rtype: int
        """
        s = list(str(num))
        for i in range(len(s)):
            if i < len(s) - 1 and s[i] < s[i + 1]:
                break
        if i == len(s) - 1:
            return num
        m = s[i + 1]
        mi = i + 1
        for j, c in enumerate(s[i + 1:]):
            if c >= m:
                m = c
                mi = i + 1 + j

        for i in range(i + 1):
            if s[i] < m:
                s[mi] = s[i]
                s[i] = m
                break
        return int(''.join(s))
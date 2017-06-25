class Solution(object):
    def lengthOfLongestSubstring(self, s):
        """
        :type s: str
        :rtype: int
        """
        l = dict()
        start = 0
        ans = 0
        for i in range(len(s)):
            try:
                if l[s[i]] >= start:
                    start = l[s[i]] + 1
            except:
                pass
            l[s[i]] = i
            ans = max(ans, i - start + 1)
        return ans
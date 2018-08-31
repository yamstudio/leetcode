class Solution:
    def makeLargestSpecial(self, S):
        """
        :type S: str
        :rtype: str
        """
        ones = 0
        l = []
        prev = 0
        for curr in range(len(S)):
            ones += 1 if S[curr] == '1' else -1
            if ones == 0:
                l.append('1%s0' % (self.makeLargestSpecial(S[(prev + 1):curr])))
                prev = curr + 1
        return ''.join(sorted(l, reverse=True))
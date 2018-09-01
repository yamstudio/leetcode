class Solution:
    def reorganizeString(self, S):
        """
        :type S: str
        :rtype: str
        """
        l = len(S)
        count = {}
        for c in S:
            count[c] = count.get(c, 0) + 1
        pairs = []

        for c, v in count.items():
            if v > (l + 1) / 2:
                return ''
            pairs.append((v, c,))

        ret = [None for _ in range(l)]
        i = 0
        for pair in sorted(pairs, reverse=True):
            v, c = pair
            while v > 0:
                ret[i] = c
                v -= 1
                i += 2
                if i >= l:
                    i = 1
        return ''.join(ret)
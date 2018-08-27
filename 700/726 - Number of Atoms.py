class Solution:
    def _get_count(self, formula, i):
        t = i
        while i < len(formula) and formula[i].isnumeric():
            i += 1
        count = 1 if t == i else int(formula[t:i])

        return i, count
    
    def _get_element(self, formula, i):
        name = formula[i]
        i += 1
        if i < len(formula) and formula[i].islower():
            name += formula[i]
            i += 1

        i, count = self._get_count(formula, i)

        return i, name, count
    
    def parse(self, formula, i):
        ret = {}

        while i < len(formula):

            if formula[i] == '(':
                i += 1
                i, tmp = self.parse(formula, i)

                for name, count in tmp.items():
                    ret[name] = ret.get(name, 0) + count

            elif formula[i] == ')':
                i += 1
                i, count = self._get_count(formula, i)
                for name in ret:
                    ret[name] *= count

                return i, ret

            else:
                i, name, count = self._get_element(formula, i)
                ret[name] = ret.get(name, 0) + count

        return i, ret
    
    def countOfAtoms(self, formula):
        """
        :type formula: str
        :rtype: str
        """
        _, ret = self.parse(formula, 0)

        return "".join(sorted(name if count == 1 else "%s%d" % (name, count) for name, count in ret.items()))
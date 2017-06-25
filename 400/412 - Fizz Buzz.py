class Solution(object):
    def fizzBuzz(self, n):
        """
        :type n: int
        :rtype: List[str]
        """
        l = []
        for i in range(n):
            i += 1
            if not (i % 15):
                l.append('FizzBuzz')
            elif not (i % 5):
                l.append('Buzz')
            elif not (i % 3):
                l.append('Fizz')
            else:
                l.append(str(i))
        return l
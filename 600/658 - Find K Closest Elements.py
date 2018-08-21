class Solution:
    def findClosestElements(self, arr, k, x):
        """
        :type arr: List[int]
        :type k: int
        :type x: int
        :rtype: List[int]
        """
        INF = 100000
        if arr[0] >= x:
            i = 0
        else:
            for i in range(len(arr) - 1):
                if arr[i] <= x <= arr[i + 1]:
                    break
        l, r, left, right = i, i + 1, [], []
        while len(left) + len(right) < k:
            ldiff = INF if l < 0 else x - arr[l]
            rdiff = INF if r >= len(arr) else arr[r] - x
            if ldiff <= rdiff:
                left.insert(0, arr[l])
                l -= 1
            else:
                right.append(arr[r])
                r += 1
        return left + right
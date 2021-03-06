#
# @lc app=leetcode id=463 lang=python3
#
# [463] Island Perimeter
#
# autogenerated using scripts/convert.py
#
class Solution(object):
    r = 0
    c = 0
    def islandPerimeter(self, grid):
        """
        :type grid: List[List[int]]
        :rtype: int
        """
        p = 0
        self.r = len(grid)
        self.c = len(grid[0])
        for x in range(self.r):
            for y in range(self.c):
                if grid[x][y]:
                    p += self.helper(grid, x - 1, y) + self.helper(grid, x + 1, y) + self.helper(grid, x, y - 1) + self.helper(grid, x, y + 1)
                    print(p)
        return p
                    
    def helper(self, grid, x, y):
        if 0 <= x < self.r and 0 <= y < self.c:
            return int(not grid[x][y])
        else:
            return 1
            
class Solution:
    directions = [(0, 1), (0, -1), (1, 0), (-1, 0)]
    
    def search(self, grid, mx, my, x, y, visited):
        if visited[x][y]:
            return 0

        visited[x][y] = True
        if grid[x][y] == 0:
            return 0

        ret = 1
        for d in self.directions:
            nx, ny = x + d[0], y + d[1]
            if 0 <= nx < mx and 0 <= ny < my:
                ret += self.search(grid, mx, my, nx, ny, visited)

        return ret
    
    def maxAreaOfIsland(self, grid):
        """
        :type grid: List[List[int]]
        :rtype: int
        """
        mx, my = len(grid), len(grid[0])
        visited = [[False for _ in range(my)] for _ in range(mx)]
        ret = 0
        for i in range(mx):
            for j in range(my):
                ret = max(ret, self.search(grid, mx, my, i, j, visited))
        return ret
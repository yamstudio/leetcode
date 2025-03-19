/*
 * @lc app=leetcode id=1476 lang=java
 *
 * [1476] Subrectangle Queries
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class SubrectangleQueries {

    private final int[][] rectangle;
    private final List<Pair> updates;

    public SubrectangleQueries(int[][] rectangle) {
        this.rectangle = rectangle;
        this.updates = new ArrayList<>();
    }
    
    public void updateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
        updates.add(new Pair(row1, col1, row2, col2, newValue));
    }
    
    public int getValue(int row, int col) {
        for (int i = updates.size() - 1; i >= 0; --i) {
            Pair c = updates.get(i);
            if (c.row1() <= row && c.row2() >= row && c.col1() <= col && c.col2() >= col) {
                return c.newValue();
            }
        }
        return rectangle[row][col];
    }

    private record Pair(int row1, int col1, int row2, int col2, int newValue) {}
}

/**
 * Your SubrectangleQueries object will be instantiated and called as such:
 * SubrectangleQueries obj = new SubrectangleQueries(rectangle);
 * obj.updateSubrectangle(row1,col1,row2,col2,newValue);
 * int param_2 = obj.getValue(row,col);
 */
// @lc code=end


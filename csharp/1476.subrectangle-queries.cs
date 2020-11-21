/*
 * @lc app=leetcode id=1476 lang=csharp
 *
 * [1476] Subrectangle Queries
 */

using System.Collections.Generic;

// @lc code=start
public class SubrectangleQueries {

    private int[][] Rectangle;
    private IList<(int LR, int LC, int RR, int RC, int Value)> Updates;

    public SubrectangleQueries(int[][] rectangle) {
        Rectangle = rectangle;
        Updates = new List<(int LR, int LC, int RR, int RC, int Value)>();
    }
    
    public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
        Updates.Add((LR: row1, LC: col1, RR: row2, RC: col2, Value: newValue));
    }
    
    public int GetValue(int row, int col) {
        for (int i = Updates.Count - 1; i >= 0; --i) {
            var update = Updates[i];
            if (update.LR <= row && update.LC <= col && update.RR >= row && update.RC >= col) {
                return update.Value;
            }
        }
        return Rectangle[row][col];
    }
}

/**
 * Your SubrectangleQueries object will be instantiated and called as such:
 * SubrectangleQueries obj = new SubrectangleQueries(rectangle);
 * obj.UpdateSubrectangle(row1,col1,row2,col2,newValue);
 * int param_2 = obj.GetValue(row,col);
 */
// @lc code=end


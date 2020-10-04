/*
 * @lc app=leetcode id=1298 lang=csharp
 *
 * [1298] Maximum Candies You Can Get from Boxes
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private const int MISSING = 0;
    private const int WANTED = 1;
    private const int OWNED = 2;
    private const int OPENED = 3;

    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        int n = status.Length, ret = 0;
        int[] boxes = new int[n];
        var queue = new Queue<int>();
        foreach (int box in initialBoxes) {
            boxes[box] = OWNED;
            if (status[box] == 1) {
                queue.Enqueue(box);
            }
        }
        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            if (boxes[curr] == OPENED) {
                continue;
            }
            boxes[curr] = OPENED;
            ret += candies[curr];
            foreach (int next in containedBoxes[curr]) {
                if (boxes[next] == MISSING) {
                    boxes[next] = OWNED;
                    if (status[next] == 1) {
                        queue.Enqueue(next);
                    }
                } else if (boxes[next] == WANTED) {
                    boxes[next] = OWNED;
                    queue.Enqueue(next);
                }
            }
            foreach (int next in keys[curr]) {
                if (boxes[next] == MISSING) {
                    boxes[next] = WANTED;
                } else if (boxes[next] == OWNED) {
                    queue.Enqueue(next);
                }
            }
        }
        return ret;
    }
}
// @lc code=end


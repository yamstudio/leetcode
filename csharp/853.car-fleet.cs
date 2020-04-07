/*
 * @lc app=leetcode id=853 lang=csharp
 *
 * [853] Car Fleet
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int ret = 0;
        double time = 0;
        foreach (var car in position.Zip(speed, (p, s) => (Position: p, Speed: s)).OrderByDescending(c => c.Position).ThenByDescending(c => c.Speed)) {
            double t = (double)(target - car.Position) / car.Speed;
            if (t > time) {
                ++ret;
                time = t;
            }
        }
        return ret;
    }
}
// @lc code=end


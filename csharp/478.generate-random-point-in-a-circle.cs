/*
 * @lc app=leetcode id=478 lang=csharp
 *
 * [478] Generate Random Point in a Circle
 */

using System;

// @lc code=start
public class Solution {

    private double Radius, XCenter, YCenter;
    Random Random;

    public Solution(double radius, double x_center, double y_center) {
        Radius = radius;
        XCenter = x_center;
        YCenter = y_center;
        Random = new Random();
    }
    
    public double[] RandPoint() {
        double theta = Random.NextDouble() * 2 * Math.PI;
        double r = Radius * Math.Sqrt(Random.NextDouble());
        return new double[] { XCenter + r * Math.Cos(theta), YCenter + r * Math.Sin(theta) };
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(radius, x_center, y_center);
 * double[] param_1 = obj.RandPoint();
 */
// @lc code=end


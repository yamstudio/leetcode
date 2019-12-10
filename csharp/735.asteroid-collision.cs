/*
 * @lc app=leetcode id=735 lang=csharp
 *
 * [735] Asteroid Collision
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        List<int> stack = new List<int>();
        foreach (var asteroid in asteroids) {
            int i = stack.Count;
            while (i-- > 0) {
                int top = stack[i];
                if (top * asteroid > 0 || top < 0 || top >= -asteroid) {
                    break;
                }
                stack.RemoveAt(i);
            }
            if (i < 0 || stack[i] * asteroid > 0 || asteroid > 0) {
                stack.Add(asteroid);
            } else if (asteroid < 0 && stack[i] == -asteroid) {
                stack.RemoveAt(i);
            }
        }
        return stack.ToArray();
    }
}
// @lc code=end


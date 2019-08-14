/*
 * @lc app=leetcode id=223 lang=csharp
 *
 * [223] Rectangle Area
 */
public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        int a1 = (C - A) * (D - B), a2 = (G - E) * (H - F);
        if (A >= G || B >= H || E >= C || F >= D) {
            return a1 + a2;
        }
        return a1 + a2 - (Math.Min(C, G) - Math.Max(A, E)) * (Math.Min(D, H) - Math.Max(B, F));
    }
}


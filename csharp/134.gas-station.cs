/*
 * @lc app=leetcode id=134 lang=csharp
 *
 * [134] Gas Station
 */
public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalGas = 0, remainingGas = 0, start = 0;
        for (int i = 0; i < gas.Length; ++i) {
            int diff = gas[i] - cost[i];
            totalGas += diff;
            remainingGas += diff;
            if (remainingGas < 0) {
                remainingGas = 0;
                start = i + 1;
            }
        }
        return totalGas < 0 ? -1 : start;
    }
}


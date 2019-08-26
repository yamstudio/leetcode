/*
 * @lc app=leetcode id=309 lang=csharp
 *
 * [309] Best Time to Buy and Sell Stock with Cooldown
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = int.MinValue, pre_buy = int.MinValue, sell = 0, pre_sell = 0;
        foreach (int price in prices) {
            pre_buy = buy;
            buy = Math.Max(pre_sell - price, pre_buy);
            pre_sell = sell;
            sell = Math.Max(pre_sell, pre_buy + price);
        }
        return sell;
    }
}


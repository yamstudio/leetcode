class Solution {
    public int maxProfit(int[] prices, int fee) {
        int len = prices.length;
        int[] hold = new int[len], sell = new int[len];
        
        hold[0] = -prices[0];
        
        for (int i = 1; i < len; ++i) {
            sell[i] = Math.max(sell[i - 1], hold[i - 1] + prices[i] - fee);
            hold[i] = Math.max(hold[i - 1], sell[i - 1] - prices[i]);
        }
        
        return sell[len - 1];
    }
}
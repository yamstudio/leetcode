#define max(a, b) (a > b ? a : b)
#define min(a, b) (a < b ? a : b)

int maxProfit(int* prices, int pricesSize) {
    int i, profit = 0, min_price = INT_MAX;
    
    for (i = 0; i < pricesSize; ++i) {
        profit = max(profit, prices[i] - min_price);
        min_price = min(min_price, prices[i]);
    }
    
    return profit;
}

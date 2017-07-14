int maxProfit(int* prices, int pricesSize) {
    int ret = 0, i;
    
    for (i = 1; i < pricesSize; ++i)
        ret += prices[i] > prices[i - 1] ? prices[i] - prices[i - 1] : 0;
    
    return ret;
}

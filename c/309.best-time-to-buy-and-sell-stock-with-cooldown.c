/*
 * @lc app=leetcode id=309 lang=c
 *
 * [309] Best Time to Buy and Sell Stock with Cooldown
 *
 * autogenerated using scripts/convert.py
 */
#include <limits.h>

#define max(a, b) ((a) > (b) ? (a) : (b))

int maxProfit(int* prices, int pricesSize) {
    int sell = 0, buy = INT_MIN, p_sell = 0, p_buy = 0, i, price;
    
    for (i = 0; i < pricesSize; ++i) {
        price = prices[i];
        
        p_buy = buy;
        buy = max(p_sell - price, buy);
        p_sell = sell;
        sell = max(p_buy + price, sell);
    }
    
    return sell;
}

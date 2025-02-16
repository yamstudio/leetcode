/*
 * @lc app=leetcode id=1357 lang=java
 *
 * [1357] Apply Discount Every n Orders
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Cashier {

    private final int n;
    private final int discount;
    private final Map<Integer, Integer> productToPrice;
    private int c = 0;

    public Cashier(int n, int discount, int[] products, int[] prices) {
        this.n = n;
        this.discount = discount;
        int k = products.length;
        productToPrice = new HashMap<>(k);
        for (int i = 0; i < k; ++i) {
            productToPrice.put(products[i], prices[i]);
        }
    }
    
    public double getBill(int[] product, int[] amount) {
        int k = product.length, ret = 0;
        for (int i = 0; i < k; ++i) {
            ret += amount[i] * productToPrice.get(product[i]);
        }
        c = (c + 1) % n;
        if (c == 0) {
            return (double)ret * ((100.0 - (double)discount) / 100.0);
        }
        return (double)ret;
    }
}

/**
 * Your Cashier object will be instantiated and called as such:
 * Cashier obj = new Cashier(n, discount, products, prices);
 * double param_1 = obj.getBill(product,amount);
 */
// @lc code=end


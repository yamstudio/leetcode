/*
 * @lc app=leetcode id=1357 lang=csharp
 *
 * [1357] Apply Discount Every n Orders
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Cashier {

    private int Index;
    private int N;
    private double Discount;
    private IDictionary<int, int> Prices;

    public Cashier(int n, int discount, int[] products, int[] prices) {
        Index = 0;
        N = n;
        Discount = 1.0 - (double)discount / 100;
        Prices = products
            .Zip(prices, (t, p) => (Product: t, Price: p))
            .ToDictionary(t => t.Product, t => t.Price);
    }
    
    public double GetBill(int[] product, int[] amount) {
        Index = (Index + 1) % N;
        double d = Index == 0 ? Discount : 1.0;
        return product
            .Zip(amount, (p, a) => a * Prices[p])
            .Sum() * d;
    }
}

/**
 * Your Cashier object will be instantiated and called as such:
 * Cashier obj = new Cashier(n, discount, products, prices);
 * double param_1 = obj.GetBill(product,amount);
 */
// @lc code=end


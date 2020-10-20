/*
 * @lc app=leetcode id=1352 lang=csharp
 *
 * [1352] Product of the Last K Numbers
 */

using System.Collections.Generic;

// @lc code=start
public class ProductOfNumbers {

    private IList<int> Products;

    public ProductOfNumbers() {
        Products = new List<int>() { 1 };
    }
    
    public void Add(int num) {
        if (num == 0) {
            Products.Clear();
            Products.Add(1);
            return;
        }
        Products.Add(Products[Products.Count - 1] * num);
    }
    
    public int GetProduct(int k) {
        int n = Products.Count;
        if (n <= k) {
            return 0;
        }
        return Products[n - 1] / Products[n - k - 1];
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */
// @lc code=end


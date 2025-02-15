/*
 * @lc app=leetcode id=1352 lang=java
 *
 * [1352] Product of the Last K Numbers
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class ProductOfNumbers {

    private final List<Integer> products;

    public ProductOfNumbers() {
        products = new ArrayList<>();
        products.add(1);
    }
    
    public void add(int num) {
        if (num == 0) {
            products.clear();
            products.add(1);
            return;
        }
        products.add(products.get(products.size() - 1) * num);
    }
    
    public int getProduct(int k) {
        int n = products.size();
        if (n <= k) {
            return 0;
        }
        return products.get(n - 1) / products.get(n - k - 1);
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.add(num);
 * int param_2 = obj.getProduct(k);
 */
// @lc code=end


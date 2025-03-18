/*
 * @lc app=leetcode id=1472 lang=java
 *
 * [1472] Design Browser History
 */

// @lc code=start
class BrowserHistory {

    private final String[] pages;
    private int l, r;

    public BrowserHistory(String homepage) {
        pages = new String[5000];
        pages[0] = homepage;
        l = 0;
        r = 0;
    }
    
    public void visit(String url) {
        pages[++l] = url;
        r = l;
    }
    
    public String back(int steps) {
        l = Math.max(l - steps, 0);
        return pages[l];
    }
    
    public String forward(int steps) {
        l = Math.min(r, l + steps);
        return pages[l];
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.visit(url);
 * String param_2 = obj.back(steps);
 * String param_3 = obj.forward(steps);
 */
// @lc code=end


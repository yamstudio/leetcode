/*
 * @lc app=leetcode id=1656 lang=java
 *
 * [1656] Design an Ordered Stream
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class OrderedStream {

    private int index;
    private String[] vals;

    public OrderedStream(int n) {
        index = 0;
        vals = new String[n];
    }
    
    public List<String> insert(int idKey, String value) {
        List<String> ret = new ArrayList<>();
        vals[idKey - 1] = value;
        while (index < vals.length && vals[index] != null) {
            ret.add(vals[index++]);
        }
        return ret;
    }
}

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * List<String> param_1 = obj.insert(idKey,value);
 */
// @lc code=end


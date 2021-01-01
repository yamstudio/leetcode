/*
 * @lc app=leetcode id=1656 lang=csharp
 *
 * [1656] Design an Ordered Stream
 */

using System.Collections.Generic;

// @lc code=start
public class OrderedStream {

    private int Index;
    private string[] Values;

    public OrderedStream(int n) {
        Index = 0;
        Values = new string[n];
    }
    
    public IList<string> Insert(int id, string value) {
        Values[id - 1] = value;
        var ret = new List<string>();
        while (Index < Values.Length && Values[Index] != null) {
            ret.Add(Values[Index++]);
        }
        return ret;
    }
}

/**
 * Your OrderedStream object will be instantiated and called as such:
 * OrderedStream obj = new OrderedStream(n);
 * IList<string> param_1 = obj.Insert(id,value);
 */
// @lc code=end


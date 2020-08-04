/*
 * @lc app=leetcode id=989 lang=csharp
 *
 * [989] Add to Array-Form of Integer
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> AddToArrayForm(int[] A, int K) {
        int carry = 0;
        var ret = new LinkedList<int>();
        for (int i = A.Length - 1; i >= 0; --i) {
            int val = K % 10 + carry + A[i];
            K /= 10;
            if (val > 9) {
                val -= 10;
                carry = 1;
            } else {
                carry = 0;
            }
            ret.AddFirst(val);
        }
        while (K != 0) {
            int val = K % 10 + carry;
            K /= 10;
            if (val > 9) {
                val = 0;
                carry = 1;
            } else {
                carry = 0;
            }
            ret.AddFirst(val);
        }
        if (carry != 0) {
            ret.AddFirst(carry);
        }
        return ret.ToList();
    }
}
// @lc code=end


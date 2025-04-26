/*
 * @lc app=leetcode id=1622 lang=java
 *
 * [1622] Fancy Sequence
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

import java.math.BigInteger;

class Fancy {

    private static final BigInteger MOD = BigInteger.valueOf(1000000007);
    private final List<BigInteger> vals;
    private final List<BigInteger> adds;
    private final List<BigInteger> muls;

    public Fancy() {
        vals = new ArrayList<>();
        adds = new ArrayList<>();
        muls = new ArrayList<>();
        adds.add(BigInteger.ZERO);
        muls.add(BigInteger.ONE);
    }
    
    public void append(int val) {
        int k = adds.size();
        vals.add(BigInteger.valueOf(val));
        adds.add(adds.get(k - 1));
        muls.add(muls.get(k - 1));
    }
    
    public void addAll(int inc) {
        int k = adds.size();
        adds.set(k - 1, adds.get(k - 1).add(BigInteger.valueOf(inc)).mod(MOD));
    }
    
    public void multAll(int m) {
        int k = adds.size();
        adds.set(k - 1, adds.get(k - 1).multiply(BigInteger.valueOf(m)).mod(MOD));
        muls.set(k - 1, muls.get(k - 1).multiply(BigInteger.valueOf(m)).mod(MOD));
    }
    
    public int getIndex(int idx) {
        int k = vals.size();
        if (idx >= k) {
            return -1;
        }
        BigInteger m = muls.get(k).multiply(muls.get(idx).modInverse(MOD)).mod(MOD);
        BigInteger a = adds.get(k).subtract(adds.get(idx).multiply(m).mod(MOD));
        return vals.get(idx).multiply(m).mod(MOD).add(a).mod(MOD).intValue();
    }
}

/**
 * Your Fancy object will be instantiated and called as such:
 * Fancy obj = new Fancy();
 * obj.append(val);
 * obj.addAll(inc);
 * obj.multAll(m);
 * int param_4 = obj.getIndex(idx);
 */
// @lc code=end


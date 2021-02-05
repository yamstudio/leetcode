/*
 * @lc app=leetcode id=842 lang=java
 *
 * [842] Split Array into Fibonacci Sequence
 */

// @lc code=start
class Solution {

    private static boolean splitIntoFibonacci(String s, int i, List<Integer> ret) {
        int n = s.length(), k = ret.size();
        if (i == n) {
            return true;
        }
        long need = (long)ret.get(k - 2) + (long)ret.get(k - 1);
        if (need > Integer.MAX_VALUE) {
            return false;
        }
        String t = Long.toString(need);
        if (t.length() > n - i || !t.equals(s.substring(i, i + t.length()))) {
            return false;
        }
        ret.add((int)need);
        if (!splitIntoFibonacci(s, i + t.length(), ret)) {
            ret.remove(k);
            return false;
        }
        return true;
    }

    public List<Integer> splitIntoFibonacci(String S) {
        int n = S.length();
        List<Integer> ret = new ArrayList<Integer>();
        for (int i = 0; i < n; ++i) {
            long v1 = Long.parseLong(S.substring(0, i + 1));
            if (v1 > Integer.MAX_VALUE) {
                break;
            }
            ret.add((int)v1);
            for (int j = i + 1; j < n - 1; ++j) {
                long v2 = Long.parseLong(S.substring(i + 1, j + 1));
                if (v2 > Integer.MAX_VALUE) {
                    break;
                }
                ret.add((int)v2);
                if (splitIntoFibonacci(S, j + 1, ret)) {
                    return ret;
                }
                ret.remove(1);
                if (v2 == 0) {
                    break;
                }
            }
            ret.remove(0);
            if (v1 == 0) {
                break;
            }
        }
        return ret;
    }
}
// @lc code=end


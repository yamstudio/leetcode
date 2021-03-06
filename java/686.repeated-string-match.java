/*
 * @lc app=leetcode id=686 lang=java
 *
 * [686] Repeated String Match
 *
 * autogenerated using scripts/convert.py
 */
class Solution {
    public int repeatedStringMatch(String A, String B) {
        String r = A;
        int max = B.length() / A.length() + 2;
        
        for (int i = 1; i <= max; ++i) {
            if (r.contains(B)) {
                return i;
            }
            
            r += A;
        }
        
        return -1;
    }
}
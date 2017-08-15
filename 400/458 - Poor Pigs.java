public class Solution {
    public int poorPigs(int buckets, int minutesToDie, int minutesToTest) {
        int len = minutesToTest / minutesToDie + 1, pigs = 0, prod = 1;
        
        while (prod < buckets) {
            prod *= len;
            ++pigs;
        }
        
        return pigs;
    }
}

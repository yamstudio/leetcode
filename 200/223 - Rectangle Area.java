public class Solution {
    public int computeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        long sum = ((long)C - (long)A) * ((long)D - (long)B) + ((long)G - (long)E) * ((long)H - (long)F);
        long overlap = Math.max(Math.min((long)C, (long)G) - Math.max((long)A, (long)E), 0) * Math.max(Math.min((long)D, (long)H) - Math.max((long)B, (long)F), 0);
        
        return Math.toIntExact(sum - overlap);
    }
}

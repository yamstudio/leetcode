/*
 * @lc app=leetcode id=1286 lang=java
 *
 * [1286] Iterator for Combination
 */

// @lc code=start
class CombinationIterator {

    private final String characters;
    private final int[] indices;
    private final StringBuilder sb;

    public CombinationIterator(String characters, int combinationLength) {
        this.characters = characters;
        indices = new int[combinationLength];
        sb = new StringBuilder(combinationLength);
        for (int i = 0; i < combinationLength; ++i) {
            sb.append(characters.charAt(i));
            indices[i] = i;
        }
    }
    
    public String next() {
        String ret = sb.toString();
        int n = characters.length(), k = sb.length(), end;
        for (end = 0; end < k && indices[k - 1 - end] == n - 1 - end; ++end) {}
        if (k == end) {
            indices[0] = -1;
        } else {
            sb.delete(k - end - 1, k);
            ++indices[k - end - 1];
            sb.append(characters.charAt(indices[k - end - 1]));
            for (int i = end - 1; i >= 0; --i) {
                indices[k - i - 1] = indices[k - end - 1] + (end - i);
                sb.append(characters.charAt(indices[k - i - 1]));
            }
        }
        return ret;
    }
    
    public boolean hasNext() {
        return indices[0] != -1;
    }
}

/**
 * Your CombinationIterator object will be instantiated and called as such:
 * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
 * String param_1 = obj.next();
 * boolean param_2 = obj.hasNext();
 */
// @lc code=end


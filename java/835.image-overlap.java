/*
 * @lc app=leetcode id=835 lang=java
 *
 * [835] Image Overlap
 */

// @lc code=start
class Solution {

    private static List<int[]> getOnes(int[][] img) {
        int n = img.length;
        List<int[]> ret = new ArrayList<int[]>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (img[i][j] == 1) {
                    ret.add(new int[] { i, j });
                }
            }
        }
        return ret;
    }

    public int largestOverlap(int[][] img1, int[][] img2) {
        List<int[]> one1 = getOnes(img1), one2 = getOnes(img2);
        Map<String, Integer> count = new HashMap<String, Integer>();
        int ret = 0;
        for (int[] a : one1) {
            for (int[] b : one2) {
                String key = String.format("%d,%d", a[0] - b[0], a[1] - b[1]);
                int val;
                if (!count.containsKey(key)) {
                    val = 1;
                } else {
                    val = 1 + count.get(key);
                }
                count.put(key, val);
            }
        }
        for(Map.Entry<String, Integer> entry : count.entrySet()) {
            ret = Math.max(ret, entry.getValue());
        }
        return ret;
    }
}
// @lc code=end


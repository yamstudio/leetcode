class Solution {
    public int maxChunksToSorted(int[] arr) {
        int len = arr.length;
        int[] mins = new int[len];
        mins[len - 1] = arr[len - 1];
        
        for (int i = len - 2; i >= 0; --i) {
            mins[i] = Math.min(arr[i], mins[i + 1]);
        }
        
        int max = -1, ret = 1;
        for (int i = 0; i < len - 1; ++i) {
            max = Math.max(max, arr[i]);
            if (max <= mins[i + 1]) {
                ++ret;
            }
        }
        
        return ret;
    }
}
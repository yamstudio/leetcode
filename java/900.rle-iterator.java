/*
 * @lc app=leetcode id=900 lang=java
 *
 * [900] RLE Iterator
 */

// @lc code=start
class RLEIterator {

    private int[] arr;
    private int index, count;

    public RLEIterator(int[] A) {
        arr = A;
        index = 0;
        count = 0;
    }
    
    public int next(int n) {
        while (n > 0 && arr.length > index) {
            if (n + count > arr[index]) {
                n -= arr[index] - count;
                index += 2;
                count = 0;
            } else {
                count += n;
                n = 0;
            }
        }
        return index < arr.length ? arr[index + 1] : -1;
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(A);
 * int param_1 = obj.next(n);
 */
// @lc code=end


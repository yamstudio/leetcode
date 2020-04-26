/*
 * @lc app=leetcode id=900 lang=csharp
 *
 * [900] RLE Iterator
 */

// @lc code=start
public class RLEIterator {

    private int Index;
    private int Count;
    private int[] Sequence;

    public RLEIterator(int[] A) {
        Sequence = A;
        Index = 0;
        Count = 0;
    }
    
    public int Next(int n) {
        while (n > 0 && Index < Sequence.Length) {
            if (n + Count > Sequence[Index]) {
                n -= Sequence[Index] - Count;
                Index += 2;
                Count = 0;
            } else {
                Count += n;
                n = 0;
            }
        }
        return Index < Sequence.Length ? Sequence[Index + 1] : -1;
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(A);
 * int param_1 = obj.Next(n);
 */
// @lc code=end


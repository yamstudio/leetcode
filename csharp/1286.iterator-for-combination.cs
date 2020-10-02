/*
 * @lc app=leetcode id=1286 lang=csharp
 *
 * [1286] Iterator for Combination
 */

using System.Linq;

// @lc code=start
public class CombinationIterator {

    private string Value;
    private int[] Indices;

    public CombinationIterator(string characters, int combinationLength) {
        Value = characters;
        Indices = Enumerable.Range(0, combinationLength - 1).Append(-1).ToArray();
    }
    
    public string Next() {
        if (Indices[Indices.Length - 1] < 0) {
            Indices[Indices.Length - 1] = Indices.Length - 1;
        } else {
            for (int i = 1; i <= Indices.Length; ++i) {
                if (Indices[Indices.Length - i] == Value.Length - i) {
                    continue;
                }
                int b = ++Indices[Indices.Length - i];
                for (int j = Indices.Length - i + 1; j < Indices.Length; ++j) {
                    Indices[j] = ++b;
                }
                break;
            }
        }
        return new string(Indices.Select(i => Value[i]).ToArray());
    }
    
    public bool HasNext() {
        return Indices[0] != Value.Length - Indices.Length || Indices[Indices.Length - 1] != Value.Length - 1;
    }
}

/**
 * Your CombinationIterator object will be instantiated and called as such:
 * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
 * string param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
// @lc code=end


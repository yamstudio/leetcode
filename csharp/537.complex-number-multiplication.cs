/*
 * @lc app=leetcode id=537 lang=csharp
 *
 * [537] Complex Number Multiplication
 */
// @lc code=start
public class Solution {

    private static (int, int) Parse(string p) {
        string[] pair = p.Substring(0, p.Length - 1).Split('+');
        return (int.Parse(pair[0]), int.Parse(pair[1]));
    }

    public string ComplexNumberMultiply(string a, string b) {
        var pa = Parse(a);
        var pb = Parse(b);
        return $"{pa.Item1 * pb.Item1 - pa.Item2 * pb.Item2}+{pa.Item2 * pb.Item1 + pa.Item1 * pb.Item2}i";
    }
}
// @lc code=end


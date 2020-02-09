 /*
 * @lc app=leetcode id=831 lang=csharp
 *
 * [831] Masking Personal Information
 */

using System.Linq;

// @lc code=start

using System.Text.RegularExpressions;

public class Solution {

    private static Regex EmailPattern = new Regex(
        @"^([a-z]+)@([a-z]+)\.([a-z]+)$",
        RegexOptions.Compiled
    );

    public string MaskPII(string S) {
        S = S.ToLower();
        var emailMatch = EmailPattern.Match(S);
        if (emailMatch.Success) {
            var groups = emailMatch.Groups;
            var name = groups[1].ToString();
            return $"{name[0]}*****{name[name.Length - 1]}@{groups[2]}.{groups[3]}";
        }
        S = new string(S.Where(c => c >= '0' && c <= '9').ToArray());
        int d = S.Length - 10;
        if (d == 0) {
            return $"***-***-{S.Substring(6)}";
        }
        return $"+{new string('*', d)}-***-***-{S.Substring(6 + d)}";
    }
}
// @lc code=end


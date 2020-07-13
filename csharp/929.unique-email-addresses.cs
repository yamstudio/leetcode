/*
 * @lc app=leetcode id=929 lang=csharp
 *
 * [929] Unique Email Addresses
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int NumUniqueEmails(string[] emails) {
        return emails
            .Select(email => {
                var split = email.Split('@');
                return (
                    Local: new string(split[0]
                        .TakeWhile(c => c != '+')
                        .Where(c => c != '.')
                        .ToArray()
                    ),
                    Domain: split[1]
                );
            })
            .Distinct()
            .Count();
    }
}
// @lc code=end


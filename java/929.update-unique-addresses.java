/*
 * @lc app=leetcode id=929 lang=java
 *
 * [929] Unique Email Addresses
 */

 import java.util.Arrays;

 // @lc code=start
 class Solution {
     public int numUniqueEmails(String[] emails) {
         return (int)Arrays
             .stream(emails)
             .map(Solution::toEffectiveEmail)
             .distinct()
             .count();
     }
 
     private static String toEffectiveEmail(String email) {
         String[] split = email.split("@");
         String name = split[0].replace(".", "");
         String domain = split[1];
         int plus = name.indexOf("+");
         return (plus >= 0 ? name.substring(0, plus) : name) + "@" + domain;
     }
 }
 // @lc code=end
 
 
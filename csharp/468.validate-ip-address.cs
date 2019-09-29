/*
 * @lc app=leetcode id=468 lang=csharp
 *
 * [468] Validate IP Address
 */

using System;
using System.Linq;

public class Solution {

    private static bool IsIPv4(string IP) {
        string[] split = IP.Split('.');
        if (split.Length != 4) {
            return false;
        }

        foreach (string s in split) {
            int n = s.Length;
            if (n == 0 || n > 3) {
                return false;
            }
            int num;
            try {
                num = int.Parse(s);
            } catch (FormatException e) {
                return false;
            }
            if (num < 0 || (num == 0 && n > 1) || (num > 0 && s[0] == '0') || num > 255) {
                return false;
            }
        }
        return true;
    }

    private static bool IsIPv6(string IP) {
        string[] split = IP.Split(":");
        if (split.Length != 8) {
            return false;
        }

        foreach (string s in split.Select(s => s.ToLower())) {
            int n = s.Length;
            if (n == 0 || n > 4) {
                return false;
            }

            foreach (char c in s) {
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'))) {
                    return false;
                }
            }
        }
        return true;
    }

    public string ValidIPAddress(string IP) {
        return IsIPv4(IP) ? "IPv4" : (IsIPv6(IP) ? "IPv6" : "Neither");
    }
}


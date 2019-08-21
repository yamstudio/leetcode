/*
 * @lc app=leetcode id=273 lang=csharp
 *
 * [273] Integer to English Words
 */

using System.Collections.Generic;

public class Solution {

    private static readonly string[] Endings = new string[] {
        " Billion", " Million", " Thousand", "",
    };

    private static readonly string[] Tens = new string[] {
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety",
    };

    private static readonly string[] Lows = new string[] {
        "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen",
    };

    private static string ToEnglish(int num) {
        var words = new List<string>(4);
        int a = num / 100, bc = num % 100;
        if (a > 0) {
            words.Add(Lows[a]);
            words.Add("Hundred");
        }
        if (bc < 20) {
            if (bc > 0) {
                words.Add(Lows[bc]);
            }
        } else {
            int b = bc / 10, c = bc % 10;
            words.Add(Tens[b]);
            if (c > 0) {
                words.Add(Lows[c]);
            }
        }
        return string.Join(" ", words);
    }

    public string NumberToWords(int num) {
        var words = new List<string>(4);
        for (int i = 3; i >= 0 && num > 0; --i) {
            int chunk = 0;
            chunk = num % 1000;
            num /= 1000;
            if (chunk == 0) {
                continue;
            }
            words.Insert(0, $"{ToEnglish(chunk)}{Endings[i]}");
        }
        return words.Count == 0 ? "Zero" : string.Join(" ", words);
    }
}


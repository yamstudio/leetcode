/*
 * @lc app=leetcode id=401 lang=csharp
 *
 * [401] Binary Watch
 */
public class Solution {

    private static readonly string[][] Hours = new string[][] {
        new string[] { "0" },
        new string[] { "1", "2", "4", "8" },
        new string[] { "3", "5", "6", "9", "10" },
        new string[] { "7", "11" },
    };
    
    private static readonly string[][] Minutes = new string[][] {
        new string[] { "00" },
        new string[] { "01", "02", "04", "08", "16", "32" },
        new string[] { "03", "05", "06", "09", "10", "12", "17", "18", "20", "24", "33", "34", "36", "40", "48" },
        new string[] { "07", "11", "13", "14", "19", "21", "22", "25", "26", "28", "35", "37", "38", "41", "49", "42", "44", "50", "52", "56" },
        new string[] { "15", "23", "27", "29", "30", "39", "43", "45", "46", "51", "53", "54", "57", "58" },
        new string[] { "31", "47", "55", "59" },
    };

    public IList<string> ReadBinaryWatch(int num) {
        var ret = new List<string>();
        for (int i = Math.Max(0, num - 5); i <= Math.Min(3, num); ++i) {
            foreach (string hour in Hours[i]) {
                foreach (string minute in Minutes[num - i]) {
                    ret.Add($"{hour}:{minute}");
                }
            }
        }
        return ret;
    }
}


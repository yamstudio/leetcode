/*
 * @lc app=leetcode id=1078 lang=java
 *
 * [1078] Occurrences After Bigram
 */

import java.util.ArrayList;

// @lc code=start
import java.util.regex.Pattern;

class Solution {
    public String[] findOcurrences(String text, String first, String second) {
        var pattern = Pattern.compile("(?=((^| )%s %s (\\w+)($| )))".formatted(first, second));
        var matcher = pattern.matcher(text);
        var ret = new ArrayList<String>();
        matcher.results().forEach(result -> ret.add(result.group(3)));
        return ret.toArray(String[]::new);
    }
}
// @lc code=end


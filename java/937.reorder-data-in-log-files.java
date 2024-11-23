/*
 * @lc app=leetcode id=937 lang=java
 *
 * [937] Reorder Data in Log Files
 */

import java.util.stream.IntStream;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public String[] reorderLogFiles(String[] logs) {
        return IntStream.range(0, logs.length)
            .mapToObj(index -> Log.fromString(logs[index], index))
            .sorted(comparing(Log::digitIndex).thenComparing(Log::content).thenComparing(Log::identifier))
            .map(log -> log.identifier + log.content)
            .toArray(String[]::new);
    }

    private record Log(String identifier, String content, int digitIndex) {
        private static Log fromString(String log, int index) {
            int contentIndex = log.indexOf(' ');
            char c = log.charAt(contentIndex + 1);
            int digitIndex = c >= '0' && c <= '9' ? index : -1;
            return new Log(log.substring(0, contentIndex), log.substring( contentIndex), digitIndex);
        }
    }
}
// @lc code=end


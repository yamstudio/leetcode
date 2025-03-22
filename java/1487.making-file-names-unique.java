/*
 * @lc app=leetcode id=1487 lang=java
 *
 * [1487] Making File Names Unique
 */

import java.util.HashMap;
import java.util.Map;
import java.util.SortedSet;
import java.util.TreeSet;

// @lc code=start
import java.util.regex.Pattern;

class Solution {

    private static final Pattern PATTERN = Pattern.compile("^.+\\(([1-9][0-9]*)\\)$");

    public String[] getFolderNames(String[] names) {
        int n = names.length;
        String[] ret = new String[n];
        Map<String, Long> nameToNext = new HashMap<>();
        Map<String, SortedSet<Long>> nameToUsed = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            String name = names[i];
            var match = PATTERN.matcher(name);
            if (match.matches()) {
                String versionString = match.group(1);
                String canonical = name.substring(0, name.length() - 2 - versionString.length());
                long version = Long.parseLong(versionString);
                SortedSet<Long> canonicalUsed = nameToUsed.get(canonical);
                if (canonicalUsed == null) {
                    canonicalUsed = new TreeSet<>();
                    nameToUsed.put(canonical, canonicalUsed);
                    nameToNext.put(canonical, 0L);
                    canonicalUsed.add(version);
                } else {
                    long canonicalNext = nameToNext.get(canonical);
                    if (canonicalNext < version) {
                        canonicalUsed.add(version);
                    } else if (canonicalNext == version) {
                        ++canonicalNext;
                        while (!canonicalUsed.isEmpty() && canonicalUsed.getFirst() <= canonicalNext) {
                            canonicalUsed.removeFirst();
                            ++canonicalNext;
                        }
                        nameToNext.put(canonical, canonicalNext);
                    }
                }
            }
            Long next = nameToNext.get(name);
            if (next == null) {
                nameToUsed.put(name, new TreeSet<>());
                nameToNext.put(name, 1L);
                ret[i] = name;
                continue;
            }
            SortedSet<Long> used = nameToUsed.get(name);
            if (next > 0) {
                String updated = "%s(%d)".formatted(name, next);
                Long updatedNext = nameToNext.get(updated);
                if (updatedNext != null) {
                    if (updatedNext == 0) {
                        SortedSet<Long> updatedUsed = nameToUsed.get(updated);
                        ++updatedNext;
                        while (!updatedUsed.isEmpty() && updatedUsed.getFirst() <= updatedNext) {
                            updatedUsed.removeFirst();
                            ++updatedNext;
                        }
                        nameToNext.put(updated, updatedNext);
                    }
                } else {
                    nameToUsed.put(updated, new TreeSet<>());
                    nameToNext.put(updated, 1L);
                }
                ret[i] = updated;
            } else {
                ret[i] = name;
            }
            ++next;
            while (!used.isEmpty() && used.getFirst() <= next) {
                used.removeFirst();
                ++next;
            }
            nameToNext.put(name, next);
        }
        return ret;
    }
}
// @lc code=end


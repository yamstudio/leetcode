/*
 * @lc app=leetcode id=811 lang=java
 *
 * [811] Subdomain Visit Count
 */

// @lc code=start
class Solution {
    public List<String> subdomainVisits(String[] cpdomains) {
        Map<String, Integer> count = new HashMap<String, Integer>();
        for (String domain : cpdomains) {
            String[] split = domain.split(" ");
            int t = Integer.parseInt(split[0]);
            String name = split[1];
            while (true) {
                if (count.containsKey(name)) {
                    count.put(name, count.get(name) + t);
                } else {
                    count.put(name, t);
                }
                int i = name.indexOf('.');
                if (i >= 0) {
                    name = name.substring(i + 1);
                } else {
                    break;
                }
            }
        }
        List<String> ret = new ArrayList<String>();
        for (Map.Entry<String, Integer> entry : count.entrySet()) {
            ret.add(String.format("%d %s", entry.getValue(), entry.getKey()));
        }
        return ret;
    }
}
// @lc code=end


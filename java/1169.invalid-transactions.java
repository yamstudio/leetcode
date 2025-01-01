/*
 * @lc app=leetcode id=1169 lang=java
 *
 * [1169] Invalid Transactions
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public List<String> invalidTransactions(String[] transactions) {
        Map<String, List<Transaction>> nameToTransactions = new HashMap<>();
        for (String t : transactions) {
            Transaction transaction = Transaction.fromString(t);
            nameToTransactions.computeIfAbsent(transaction.name(), ignored -> new ArrayList<>()).add(transaction);
        }
        List<String> ret = new ArrayList<>();
        for (List<Transaction> txns : nameToTransactions.values()) {
            Collections.sort(txns, comparing(Transaction::time));
            int n = txns.size();
            Set<Integer> indices = new HashSet<>();
            for (int i = 0; i < n; ++i) {
                Transaction curr = txns.get(i);
                if (curr.amount() > 1000) {
                    indices.add(i);
                }
                for (int j = i + 1; j < n; ++j) {
                    Transaction next = txns.get(j);
                    if (next.time() > curr.time() + 60) {
                        break;
                    }
                    if (!curr.city().equals(next.city())) {
                        indices.add(i);
                        indices.add(j);
                    }
                }
            }
            for (Integer i : indices) {
                ret.add(txns.get(i).toString());
            }
        }
        return ret;
    }

    private record Transaction(int time, int amount, String city, String name) {
        private static Transaction fromString(String t) {
            String[] split = t.split(",");
            return new Transaction(
                Integer.parseInt(split[1]),
                Integer.parseInt(split[2]),
                split[3],
                split[0]);
        }

        @Override
        public String toString() {
            return "%s,%d,%d,%s".formatted(name, time, amount, city);
        }
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=1600 lang=java
 *
 * [1600] Throne Inheritance
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start
class ThroneInheritance {

    private final String king;
    private final Map<String, List<String>> children;
    private final Set<String> dead;

    public ThroneInheritance(String kingName) {
        king = kingName;
        children = new HashMap<>();
        dead = new HashSet<>();
        children.put(king, new ArrayList<>());
    }
    
    public void birth(String parentName, String childName) {
        children.get(parentName).add(childName);
        children.put(childName, new ArrayList<>());
    }
    
    public void death(String name) {
        dead.add(name);
    }
    
    public List<String> getInheritanceOrder() {
        List<String> ret = new ArrayList<>();
        getInheritanceOrder(king, ret);
        return ret;
    }

    private void getInheritanceOrder(String name, List<String> ret) {
        if (!dead.contains(name)) {
            ret.add(name);
        }
        for (String child : children.get(name)) {
            getInheritanceOrder(child, ret);
        }
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.birth(parentName,childName);
 * obj.death(name);
 * List<String> param_3 = obj.getInheritanceOrder();
 */
// @lc code=end


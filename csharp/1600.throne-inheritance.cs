/*
 * @lc app=leetcode id=1600 lang=csharp
 *
 * [1600] Throne Inheritance
 */

using System.Collections.Generic;

// @lc code=start
public class ThroneInheritance {

    private IDictionary<string, IList<string>> Map;
    private HashSet<string> Dead;
    private string King;

    public ThroneInheritance(string kingName) {
        Map = new Dictionary<string, IList<string>>();
        Dead = new HashSet<string>();
        King = kingName;
        Map[King] = new List<string>();
    }
    
    public void Birth(string parentName, string childName) {
        Map[childName] = new List<string>();
        Map[parentName].Add(childName);
    }
    
    public void Death(string name) {
        Dead.Add(name);
    }

    private void GetInheritanceOrder(string curr, IList<string> ret) {
        if (!Dead.Contains(curr)) {
            ret.Add(curr);
        }
        foreach (var next in Map[curr]) {
            GetInheritanceOrder(next, ret);
        }
    }
    
    public IList<string> GetInheritanceOrder() {
        var ret = new List<string>();
        GetInheritanceOrder(King, ret);
        return ret;
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */
// @lc code=end


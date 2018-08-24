import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

/*
// Employee info
class Employee {
    // It's the unique id of each node;
    // unique id of this employee
    public int id;
    // the importance value of this employee
    public int importance;
    // the id of direct subordinates
    public List<Integer> subordinates;
};
*/
class Solution {
    private int search(int id, Map<Integer, Employee> map, Set<Integer> visited) {
        if (visited.contains(id)) {
            return 0;
        }
        visited.add(id);
        
        Employee i = map.get(id);
        int ret = i.importance;
        for (int e : i.subordinates) {
            ret += search(e, map, visited);
        }
        
        return ret;
    }
    
    public int getImportance(List<Employee> employees, int id) {
        Map<Integer, Employee> map = new HashMap<>();
        
        for (Employee e : employees) {
            map.put(e.id, e);
        }
        
        return search(id, map, new HashSet<>());
    }
}
import java.util.Deque;
import java.util.LinkedList;

/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * public interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     public boolean isInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     public Integer getInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     public List<NestedInteger> getList();
 * }
 */
public class NestedIterator implements Iterator<Integer> {

    private Deque<NestedInteger> deque;
    
    public NestedIterator(List<NestedInteger> nestedList) {
        this.deque = new LinkedList<NestedInteger>();
        
        for (NestedInteger i : nestedList)
            this.deque.addLast(i);
    }

    @Override
    public Integer next() {
        return this.deque.pollFirst().getInteger();
    }

    @Override
    public boolean hasNext() {
        NestedInteger first;
        List<NestedInteger> list;
        int i;
        
        while (! this.deque.isEmpty()) {
            first = this.deque.peekFirst();
            
            if (first.isInteger())
                return true;
            
            this.deque.pop();
            list = first.getList();
            for (i = list.size() - 1; i >= 0; --i)
                this.deque.addFirst(list.get(i));
        }
        
        return false;
    }
}

/**
 * Your NestedIterator object will be instantiated and called as such:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.hasNext()) v[f()] = i.next();
 */
 
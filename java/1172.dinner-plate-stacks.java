/*
 * @lc app=leetcode id=1172 lang=java
 *
 * [1172] Dinner Plate Stacks
 */

import java.util.ArrayList;
import java.util.List;
import java.util.SortedSet;
import java.util.Stack;
import java.util.TreeSet;

// @lc code=start

class DinnerPlates {

    private final List<Stack<Integer>> stacks;
    private final SortedSet<Integer> spaces;
    private final int capacity;

    public DinnerPlates(int capacity) {
        stacks = new ArrayList<>();
        spaces = new TreeSet<>();
        this.capacity = capacity;
    }
    
    public void push(int val) {
        int index;
        Stack<Integer> stack;
        if (spaces.isEmpty()) {
            index = stacks.size();
            stack = new Stack<>();
            spaces.add(index);
            stacks.add(stack);
        } else {
            index = spaces.first();
            stack = stacks.get(index);
        }
        stack.push(val);
        if (stack.size() == capacity) {
            spaces.remove(index);
        }
    }
    
    public int pop() {
        return popAtStack(stacks.size() - 1);
    }
    
    public int popAtStack(int index) {
        if (index < 0 || index >= stacks.size()) {
            return -1;
        }
        Stack<Integer> stack = stacks.get(index);
        if (stack.isEmpty()) {
            return -1;
        }
        int ret = stack.pop();
        spaces.add(index);
        while (stacks.size() > 0) {
            Stack<Integer> last = stacks.getLast();
            if (!last.isEmpty()) {
                break;
            }
            spaces.remove(stacks.size() - 1);
            stacks.removeLast();
        }
        return ret;
    }
}

/**
 * Your DinnerPlates object will be instantiated and called as such:
 * DinnerPlates obj = new DinnerPlates(capacity);
 * obj.push(val);
 * int param_2 = obj.pop();
 * int param_3 = obj.popAtStack(index);
 */
// @lc code=end


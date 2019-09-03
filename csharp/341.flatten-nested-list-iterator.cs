/*
 * @lc app=leetcode id=341 lang=csharp
 *
 * [341] Flatten Nested List Iterator
 */
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {

    private IList<NestedInteger> NestedList;
    private int Index;
    private NestedIterator Sub;

    public NestedIterator(IList<NestedInteger> nestedList) {
        NestedList = nestedList;
        Index = 0;
        Sub = null;
    }

    public bool HasNext() {
        while (Index < NestedList.Count) {
            if (Sub != null) {
                if (Sub.HasNext()) {
                    return true;
                } else {
                    Sub = null;
                }
            }
            var curr = NestedList[Index++];
            if (curr.IsInteger()) {
                return true;
            }
            Sub = new NestedIterator(curr.GetList());
        }
        return Sub != null && Sub.HasNext();
    }

    public int Next() {
        return Sub == null ? NestedList[Index - 1].GetInteger() : Sub.Next();
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */


// Java Iterator interface reference:
// https://docs.oracle.com/javase/8/docs/api/java/util/Iterator.html
class PeekingIterator implements Iterator<Integer> {
    
    Iterator<Integer> iter;
    Integer curr;

    public PeekingIterator(Iterator<Integer> iterator) {
        // initialize any member here.
        this.iter = iterator;
        this.curr = this.iter.hasNext() ? this.iter.next() : null;
    }

    // Returns the next element in the iteration without advancing the iterator.
    public Integer peek() {
        return this.curr;
    }

    // hasNext() and next() should behave the same as in the Iterator interface.
    // Override them if needed.
    @Override
    public Integer next() {
        Integer ret = this.curr;
        this.curr = this.iter.hasNext() ? this.iter.next() : null;
        return ret;
    }

    @Override
    public boolean hasNext() {
        return this.curr != null;
    }
}

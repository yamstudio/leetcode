/*
 * @lc app=leetcode id=1115 lang=java
 *
 * [1115] Print FooBar Alternately
 */

// @lc code=start

import java.util.concurrent.Semaphore;

class FooBar {
    private final Semaphore first = new Semaphore(1);
    private final Semaphore second = new Semaphore(0);
    private int n;

    public FooBar(int n) {
        this.n = n;
    }

    public void foo(Runnable printFoo) throws InterruptedException {
        
        for (int i = 0; i < n; i++) {
            first.acquire();
        	// printFoo.run() outputs "foo". Do not change or remove this line.
        	printFoo.run();
            second.release();
        }
    }

    public void bar(Runnable printBar) throws InterruptedException {
        
        for (int i = 0; i < n; i++) {
            second.acquire();
            // printBar.run() outputs "bar". Do not change or remove this line.
        	printBar.run();
            first.release();
        }
    }
}
// @lc code=end


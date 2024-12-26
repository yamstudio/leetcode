/*
 * @lc app=leetcode id=1117 lang=java
 *
 * [1117] Building H2O
 */

// @lc code=start

import java.util.concurrent.Semaphore;
import java.util.concurrent.atomic.AtomicInteger;

class H2O {

    private final Semaphore h = new Semaphore(1);
    private final Semaphore o = new Semaphore(0);
    private final AtomicInteger hCount = new AtomicInteger(0);

    public H2O() {
        
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
		h.acquire();
        // releaseHydrogen.run() outputs "H". Do not change or remove this line.
        releaseHydrogen.run();
        if (hCount.incrementAndGet() % 2 == 0) {
            o.release();
        } else {
            h.release();
        }
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        o.acquire();
        // releaseOxygen.run() outputs "O". Do not change or remove this line.
		releaseOxygen.run();
        h.release();
    }
}
// @lc code=end


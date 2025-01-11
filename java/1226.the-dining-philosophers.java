/*
 * @lc app=leetcode id=1226 lang=java
 *
 * [1226] The Dining Philosophers
 */

// @lc code=start

import java.util.concurrent.Semaphore;

class DiningPhilosophers {

    private final Semaphore semaphore = new Semaphore(1);

    // call the run() method of any runnable to execute its code
    public void wantsToEat(int philosopher,
                           Runnable pickLeftFork,
                           Runnable pickRightFork,
                           Runnable eat,
                           Runnable putLeftFork,
                           Runnable putRightFork) throws InterruptedException {
        semaphore.acquire();
        pickLeftFork.run();
        pickRightFork.run();
        eat.run();
        putRightFork.run();
        putLeftFork.run();
        semaphore.release();
    }
}
// @lc code=end


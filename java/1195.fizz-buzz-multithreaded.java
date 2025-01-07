/*
 * @lc app=leetcode id=1195 lang=java
 *
 * [1195] Fizz Buzz Multithreaded
 */

import java.util.function.IntConsumer;

// @lc code=start

import java.util.concurrent.Semaphore;

class FizzBuzz {
    private final int n;
    private final Semaphore fizz = new Semaphore(0);
    private final Semaphore buzz = new Semaphore(0);
    private final Semaphore fizzbuzz = new Semaphore(0);
    private final Semaphore number = new Semaphore(1);

    public FizzBuzz(int n) {
        this.n = n;
    }

    // printFizz.run() outputs "fizz".
    public void fizz(Runnable printFizz) throws InterruptedException {
        for (int i = 1; i <= n; ++i) {
            if (i % 3 == 0 && i % 5 != 0) {
                fizz.acquire();
                printFizz.run();
                release(i + 1);
            }
        }
    }

    // printBuzz.run() outputs "buzz".
    public void buzz(Runnable printBuzz) throws InterruptedException {
        for (int i = 1; i <= n; ++i) {
            if (i % 3 != 0 && i % 5 == 0) {
                buzz.acquire();
                printBuzz.run();
                release(i + 1);
            }
        }
    }

    // printFizzBuzz.run() outputs "fizzbuzz".
    public void fizzbuzz(Runnable printFizzBuzz) throws InterruptedException {
        for (int i = 1; i <= n; ++i) {
            if (i % 15 == 0) {
                fizzbuzz.acquire();
                printFizzBuzz.run();
                release(i + 1);
            }
        }
    }

    // printNumber.accept(x) outputs "x", where x is an integer.
    public void number(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; ++i) {
            if (i % 3 != 0 && i % 5 != 0) {
                number.acquire();
                printNumber.accept(i);
                release(i + 1);
            }
        }
    }

    private void release(int i) {
        if (i % 15 == 0) {
            fizzbuzz.release();
        } else if (i % 3 == 0) {
            fizz.release();
        } else if (i % 5 == 0) {
            buzz.release();
        } else {
            number.release();
        }
    }
}
// @lc code=end


/*
 * @lc app=leetcode id=470 lang=csharp
 *
 * [470] Implement Rand10() Using Rand7()
 */
/**
 * The Rand7() API is already defined in the parent class SolBase.
 * public int Rand7();
 * @return a random integer in the range 1 to 7
 */
public class Solution : SolBase {
    public int Rand10() {
        while (true) {
            int rand = 7 * (Rand7() - 1) + Rand7();
            if (rand <= 40) {
                return rand % 10 + 1;
            }
        }
    }
}


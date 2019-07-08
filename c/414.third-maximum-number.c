/*
 * @lc app=leetcode id=414 lang=c
 *
 * [414] Third Maximum Number
 *
 * autogenerated using scripts/convert.py
 */
#include <limits.h>

int thirdMax(int* nums, int numsSize) {
    long long first = LLONG_MIN, second = LLONG_MIN, third = LLONG_MIN;
    int i, num;
    
    for (i = 0; i < numsSize; ++i) {
        num = nums[i];
        if (num > first) {
            third = second;
            second = first;
            first = num;
        } else if (num > second && num < first) {
            third = second;
            second = num;
        } else if (num > third && num < second)
            third = num;
    }
    
    return (third == LLONG_MIN || third == second) ? (int)first : (int)third; 
}
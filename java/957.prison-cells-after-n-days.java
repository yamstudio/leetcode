/*
 * @lc app=leetcode id=957 lang=java
 *
 * [957] Prison Cells After N Days
 */

// @lc code=start
class Solution {
    public int[] prisonAfterNDays(int[] cells, int n) {
        int[] stateToDay = new int[2 << 9], dayToState = new int[2 << 9], ret = new int[8];
        int state = 0, days = n + 1, retDay = days;
        for (int i = 0; i < 8; ++i) {
            state |= cells[i] << i;
        }
        stateToDay[state] = 1;
        dayToState[1] = state;
        for (int day = 2; day <= days; ++day) {
            int newState = 0;
            for (int i = 1; i <= 6; ++i) {
                newState |= (1 & ~((((1 << (i - 1)) & state) >> (i - 1)) ^ (((1 << (i + 1)) & state) >> (i + 1)))) << i;
            }
            state = newState;
            int prevDay = stateToDay[state];
            if (prevDay != 0) {
                retDay = (days - prevDay) % (day - prevDay) + prevDay;
                break;
            }
            stateToDay[state] = day;
            dayToState[day] = state;
            continue;
        }
        int retState = dayToState[retDay];
        for (int i = 0; i < 8; ++i) {
            ret[i] = ((1 << i) & retState) >> i;
        }
        return ret;
    }
}
// @lc code=end


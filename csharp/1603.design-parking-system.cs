/*
 * @lc app=leetcode id=1603 lang=csharp
 *
 * [1603] Design Parking System
 */

// @lc code=start
public class ParkingSystem {

    int B, M, S;

    public ParkingSystem(int big, int medium, int small) {
        B = big;
        M = medium;
        S = small;
    }
    
    public bool AddCar(int carType) {
        if (carType == 1) {
            if (B > 0) {
                --B;
                return true;
            }
        } else if (carType == 2) {
            if (M > 0) {
                --M;
                return true;
            }
        } else if (carType == 3) {
            if (S > 0) {
                --S;
                return true;
            }
        }
        return false;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */
// @lc code=end


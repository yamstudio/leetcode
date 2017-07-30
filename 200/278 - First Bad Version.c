// Forward declaration of isBadVersion API.
bool isBadVersion(int version);

int firstBadVersion(int n) {
    int left = 1, right = n, mid;
    
    if (n == 1)
        return 1;
    
    while (left + 1 < right) {
        mid = left + (right - left) / 2;
        
        if (isBadVersion(mid))
            right = mid;
        else
            left = mid;
    }
    
    return isBadVersion(left) ? left : right;
}

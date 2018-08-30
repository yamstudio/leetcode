int reachNumber(int target) {
    int ret = 0, curr = 0;
    if (target < 0) {
        target = -target;
    }
    
    while (curr < target || (curr - target) % 2 != 0) {
        ++ret;
        curr += ret;
    }
    
    return ret;
}
int canCompleteCircuit(int* gas, int gasSize, int* cost, int costSize) {
    int curr = 0, sum = 0, i, ret = 0;
    
    if (gasSize != costSize)
        return -1;
    
    for (i = 0; i < costSize; ++i) {
        sum += gas[i] - cost[i];
        curr += gas[i] - cost[i];
        if (curr < 0) {
            ret = i + 1;
            curr = 0;
        }
    }
    
    if (sum < 0)
        return -1;
    return ret;
}

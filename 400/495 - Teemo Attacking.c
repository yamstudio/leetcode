int findPoisonedDuration(int* timeSeries, int timeSeriesSize, int duration) {
    int ret = 0, i, diff;
    
    if (! timeSeriesSize)
        return 0;
    
    for (i = 1; i < timeSeriesSize; ++i) {
        diff = timeSeries[i] - timeSeries[i - 1];
        ret += diff < duration ? diff : duration;
    }
    
    return ret + duration;
}

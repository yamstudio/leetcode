#define max(a, b) ((a) > (b) ? (a) : (b))

int maxRotateFunction(int* A, int ASize) {
    int sum = 0, f = 0, i, ret;
    
    for (i = 0; i < ASize; ++i) {
        sum += A[i];
        f += i * A[i];
    }
    
    ret = f;
    for (i = 1; i < ASize; ++i) {
        f += sum - ASize * A[ASize - i];
        ret = max(f, ret);
    }
    
    return ret;
}

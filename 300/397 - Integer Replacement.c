int integerReplacement(int n) {
    int minus, plus;
    long long f;
    
    if (n == 1)
        return 0;
    if (n % 2 == 0)
        return 1 + integerReplacement(n / 2);
    
    minus = integerReplacement(n / 2);
    plus = integerReplacement(n / 2 + 1);
    
    return minus > plus ? plus + 2 : minus + 2;
}

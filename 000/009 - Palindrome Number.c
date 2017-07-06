bool isPalindrome(int x) {
    int reverse = 0, copy = x;
    
    if (x < 0)
        return 0;
    
    while (copy) {
        reverse *= 10;
        reverse += copy % 10;
        copy /= 10;
    }
    
    return (x == reverse);
}

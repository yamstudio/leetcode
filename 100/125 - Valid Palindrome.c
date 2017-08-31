#include <string.h>
#include <type.h>

bool isPalindrome(char* s) {
    int left, right;
    
    left = 0;
    right = strlen(s) - 1;
    
    while (left < right) {
        if (! (isalpha(s[left]) || isdigit(s[left]))) {
            ++left;
            continue;
        }
        
        if (! (isalpha(s[right]) || isdigit(s[right]))) {
            --right;
            continue;
        }
        
        if (tolower(s[left++]) != tolower(s[right--]))
            return 0;
    }
    
    return 1;
}

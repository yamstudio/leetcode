#include <stdio.h>

#define min(a, b) ((a) < (b) ? (a) : (b))

char* getHint(char* secret, char* guess) {
    int s_map[10] = {0}, g_map[10] = {0}, i, bulls = 0, cows = 0;
    char *ret;
    
    ret = (char *)malloc(32 * sizeof(char));
    
    for (i = 0; secret[i]; ++i) {
        if (secret[i] == guess[i])
            ++bulls;
        else {
            s_map[secret[i] - '0']++;
            g_map[guess[i] - '0']++;
        }
    }
    
    for (i = 0; i < 10; ++i)
        cows += min(s_map[i], g_map[i]);
        
    sprintf(ret, "%dA%dB", bulls, cows);
    
    return ret;
}

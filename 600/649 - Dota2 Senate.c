#include <string.h>

char* predictPartyVictory(char* senate) {
    int n = strlen(senate), r = 0, d = 0, i, j;
    
    for (i = 0; i < n; ++i) {
        if (senate[i] == 'R')
            ++r;
        else
            ++d;
    }
    
    while (r && d) {
        for (i = 0; i < n ; ++i) {
            if (senate[i] == 'R') {
                for (j = i + 1; j < i + n; ++j) {
                    if (senate[j % n] == 'D') {
                        senate[j % n] = '#';
                        --d;
                        break;
                    }
                }
            } else if (senate[i] == 'D') {
                for (j = i + 1; j < i + n; ++j) {
                    if (senate[j % n] == 'R') {
                        senate[j % n] = '#';
                        --r;
                        break;
                    }
                }
            }
        }
    }
    
    return r ? "Radiant" : "Dire";
}
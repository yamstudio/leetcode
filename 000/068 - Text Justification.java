import java.util.ArrayList;

public class Solution {
    public List<String> fullJustify(String[] words, int maxWidth) {
        List<String> ret = new ArrayList<String>(), temp = new ArrayList<String>();
        int len, tempLen = 0;
        char[] container = new char[maxWidth];
        
        for (String curr : words) {
            len = curr.length();
            if (len > maxWidth)
                continue;
            if (temp.size() + len + tempLen <= maxWidth) {
                tempLen += len;
                temp.add(curr);
                continue;
            }
            ret.add(newLine(temp, container, maxWidth, tempLen));
            temp.clear();
            temp.add(curr);
            tempLen = len;
        }
        ret.add(newLine(temp, null, maxWidth, tempLen));
        
        return ret;
    }
    
    private String newLine(List<String> temp, char[] container, int maxWidth, int tempLen) {
        int i = 0, j, k, spaceLen, first;
        String curr;
        
        if (maxWidth == 0)
            return "";
        
        if (container == null || temp.size() == 1)
            return String.format("%1$-" + maxWidth + "s", String.join(" ", temp));
        
        spaceLen = (maxWidth - tempLen) / (temp.size() - 1);
        first = (maxWidth - tempLen) % (temp.size() - 1);
        
        for (j = 0; j < temp.size(); ++j) {
            curr = temp.get(j);
            for (k = 0; k < curr.length(); ++k)
                container[i++] = curr.charAt(k);
            if (j < temp.size() - 1) {
                for (k = 0; k < spaceLen; ++k)
                    container[i++] = ' ';
                if (j < first)
                    container[i++] = ' ';
            }
        }
        
        return new String(container);
    }
}

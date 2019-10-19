/*
 * @lc app=leetcode id=535 lang=csharp
 *
 * [535] Encode and Decode TinyURL
 */

using System.Collections.Generic;

// @lc code=start
public class Codec {

    private IDictionary<string, int> Encoder = new Dictionary<string, int>();
    private IList<string> Decoder = new List<string>();

    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
        int ret;
        if (!Encoder.TryGetValue(longUrl, out ret)) {
            ret = Encoder.Count;
            Decoder.Add(longUrl);
            Encoder[longUrl] = ret;
        }
        return $"https://aka.ms/{ret.ToString()}";
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        return Decoder[int.Parse(shortUrl.Substring(15))];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
// @lc code=end


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodingQuestions;
public static class VowelSubsequence
{
    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        // Sesli harfleri tanımlama işlemi yapıyoruz
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        // Sonucu tutacak listeyi burada tanımlıyoruz
        var result = new List<object>();

        foreach (var word in words)
        {
            // En uzun sesli harf dizisini tutacak değişkeni tanımlıyoruz
            string longestSubSeq = "";

            // Geçici sesli harf dizisi tutacak değişkeni tanımlıyoruz
            string currentSubSeq = "";


            //kelimedeki her karakteri döndüren kontrol işlemini döngüye alıyoruz
            foreach (char c in word)
            {
                //küçük harfe çevirme işlemi ve kontrol işlemi yapıyoruz
                if (vowels.Contains(char.ToLower(c)))
                {
                    //karakter sesli harf ise geçici dizimize ekliyoruz
                    currentSubSeq += c;

                    //eğer geçici dizinin uzunluğu en uzun diziden büyükse, en uzun diziyi güncelliyoruz
                    if (currentSubSeq.Length > longestSubSeq.Length)
                    {
                        longestSubSeq = currentSubSeq;
                    }
                }//karakter sesli harf değilse geçici diziyi sıfırlama işlemini burada yapıyoruz
                else
                {
                    currentSubSeq = "";
                }

            }
            //sonucu listeye ekliyoruz
            result.Add(new
            {
                word,
                sequence = longestSubSeq,
                length = longestSubSeq.Length
            });
        }
        //sonucu json formatında döndürüyoruz
        return JsonSerializer.Serialize(result);
    }
}

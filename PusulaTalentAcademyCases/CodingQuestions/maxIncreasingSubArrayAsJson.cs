using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodingQuestions;
public static class SubArrayCase
{
    public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
    {
        //Öncelikle parametre olarak gelen listeyi kontrol ediyoruz. Bo? mu de?il mi diye.
        //E?er bo?sa veya null ise bo? bir liste döndürme i?lemi yap?yoruz
        if (numbers == null || numbers.Count == 0)
        {
            return JsonSerializer.Serialize(new List<int>());
        }

        //En uzun artan alt diziyi tutacak listeyi tan?ml?yoruz.
        List<int> maxSubArray = new List<int>();

        //Geçici alt dizi tan?ml?yoruz ve ilk eleman? ekliyoruz.
        List<int> currentSubArray = new List<int> { numbers[0] };

        for (int i = 1; i < numbers.Count; i++)
        {
            //E?er mevcut eleman, geçerli alt dizinin son eleman?ndan büyükse, geçerli alt diziye ekliyoruz.
            if (numbers[i] > numbers[i - 1])
            {
                currentSubArray.Add(numbers[i]);
            }
            else
            {
                //Geçerli alt dizinin toplam?, en büyük alt dizinin toplam?ndan büyükse, en büyük alt diziyi güncelliyoruz.
                if (currentSubArray.Sum() > maxSubArray.Sum())
                {
                    maxSubArray = new List<int>(currentSubArray);
                }
                //Geçerli alt diziyi s?f?rlay?p, mevcut eleman? ekliyoruz.
                currentSubArray = new List<int> { numbers[i] };
            }
        }

        //Son kontrolü yap?yoruz. E?er döngü bitti?inde geçerli alt dizinin toplam? en büyük alt dizinin toplam?ndan büyükse, en büyük alt diziyi güncelliyoruz.
        if (currentSubArray.Sum() > maxSubArray.Sum())
        {
            maxSubArray = currentSubArray;
        }

        //Sonuç olarak en uzun artan alt diziyi JSON format?nda döndürüyoruz.
        return JsonSerializer.Serialize(maxSubArray);
    }
}

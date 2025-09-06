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
        //Öncelikle parametre olarak gelen listeyi kontrol ediyoruz. Boş mu değil mi diye.
        //Eğer boşsa veya null ise boş bir liste döndürme işlemi yapıyoruz
        if (numbers == null || numbers.Count == 0)
        {
            return JsonSerializer.Serialize(new List<int>());
        }

        //En uzun artan alt diziyi tutacak listeyi tanımlıyoruz.
        List<int> maxSubArray = new List<int>();

        //Geçici alt dizi tanımlıyoruz ve ilk elemanı ekliyoruz.
        List<int> currentSubArray = new List<int> { numbers[0] };

        for (int i = 1; i < numbers.Count; i++)
        {
            //Eğer mevcut eleman, geçerli alt dizinin son elemanından büyükse, geçerli alt diziye ekliyoruz.
            if (numbers[i] > numbers[i - 1])
            {
                currentSubArray.Add(numbers[i]);
            }
            else
            {
                //Geçerli alt dizinin toplamı, en büyük alt dizinin toplamından büyükse, en büyük alt diziyi güncelliyoruz.
                if (currentSubArray.Sum() > maxSubArray.Sum())
                {
                    maxSubArray = new List<int>(currentSubArray);
                }
                //Geçerli alt diziyi sıfırlayıp, mevcut elemanı ekliyoruz.
                currentSubArray = new List<int> { numbers[i] };
            }
        }

        //Son kontrolü yap?yoruz. Eğer döngü bittiğinde geçerli alt dizinin toplamı en büyük alt dizinin toplamından büyükse, en büyük alt diziyi güncelliyoruz.
        if (currentSubArray.Sum() > maxSubArray.Sum())
        {
            maxSubArray = currentSubArray;
        }

        //Sonuç olarak en uzun artan alt diziyi JSON formatında döndürüyoruz.
        return JsonSerializer.Serialize(maxSubArray);
    }
}

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
        //�ncelikle parametre olarak gelen listeyi kontrol ediyoruz. Bo? mu de?il mi diye.
        //E?er bo?sa veya null ise bo? bir liste d�nd�rme i?lemi yap?yoruz
        if (numbers == null || numbers.Count == 0)
        {
            return JsonSerializer.Serialize(new List<int>());
        }

        //En uzun artan alt diziyi tutacak listeyi tan?ml?yoruz.
        List<int> maxSubArray = new List<int>();

        //Ge�ici alt dizi tan?ml?yoruz ve ilk eleman? ekliyoruz.
        List<int> currentSubArray = new List<int> { numbers[0] };

        for (int i = 1; i < numbers.Count; i++)
        {
            //E?er mevcut eleman, ge�erli alt dizinin son eleman?ndan b�y�kse, ge�erli alt diziye ekliyoruz.
            if (numbers[i] > numbers[i - 1])
            {
                currentSubArray.Add(numbers[i]);
            }
            else
            {
                //Ge�erli alt dizinin toplam?, en b�y�k alt dizinin toplam?ndan b�y�kse, en b�y�k alt diziyi g�ncelliyoruz.
                if (currentSubArray.Sum() > maxSubArray.Sum())
                {
                    maxSubArray = new List<int>(currentSubArray);
                }
                //Ge�erli alt diziyi s?f?rlay?p, mevcut eleman? ekliyoruz.
                currentSubArray = new List<int> { numbers[i] };
            }
        }

        //Son kontrol� yap?yoruz. E?er d�ng� bitti?inde ge�erli alt dizinin toplam? en b�y�k alt dizinin toplam?ndan b�y�kse, en b�y�k alt diziyi g�ncelliyoruz.
        if (currentSubArray.Sum() > maxSubArray.Sum())
        {
            maxSubArray = currentSubArray;
        }

        //Sonu� olarak en uzun artan alt diziyi JSON format?nda d�nd�r�yoruz.
        return JsonSerializer.Serialize(maxSubArray);
    }
}

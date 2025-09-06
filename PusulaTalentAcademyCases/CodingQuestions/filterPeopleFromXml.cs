using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingQuestions;
public static class FilterPeopleCase
{
    public static string FilterPeopleFromXml(string data)
    {
        // String olarak gelen XML verisini XDocument.Parse ile çevirme i?lemi yap?yoruz
        var doc = XDocument.Parse(data);
        // Ki?i bilgilerini çekip filtreleme i?lemi yap?yoruz
        var people = doc.Descendants("Person")
            .Select(p => new// Ki?i bilgilerini anonim tipte tutuyoruz
            {
                Name = (string)p.Element("Name"),
                Age = int.Parse((string)p.Element("Age")),
                Department = (string)p.Element("Department"),
                Salary = int.Parse((string)p.Element("Salary")),
                HireDate = DateTime.Parse((string)p.Element("HireDate"), CultureInfo.InvariantCulture)
            })// ?stenilen filtreleme kriterlerine göre filtre uyguluyoruz
            .Where(p => p.Age > 30 && p.Department == "IT" && p.Salary > 5000 && p.HireDate.Year < 2019)// Sonuçlar? listeye dönü?türüyoruz
            .ToList(); //Listeleme i?lemi

        var names = people.Select(p => p.Name).OrderBy(n => n).ToList();// ?simleri alfabetik yapmak için kullan?yoruz
        var totalSalary = people.Sum(p => p.Salary);// Toplam maa?? hesapl?yoruz
        var count = people.Count;// Ki?i say?s?n? alma i?lemini yap?yoruz
        var averageSalary = count > 0 ? totalSalary / count : 0;// Ortalama maa?? burada hesapl?yoruz
        var maxSalary = count > 0 ? people.Max(p => p.Salary) : 0;// Maksimum maa?? burada hesapl?yoruz
        var minSalary = count > 0 ? people.Min(p => p.Salary) : 0;// Minimum maa?? burada hesapl?yoruz

        var result = new// Sonuçlar? anonim tipte tutuyoruz
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            MinSalary = minSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result);// Sonuçlar? JSON format?nda döndürüyoruz
    }
}

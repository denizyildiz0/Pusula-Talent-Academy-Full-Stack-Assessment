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
        // String olarak gelen XML verisini XDocument.Parse ile çevirme işlemi yapıyoruz
        var doc = XDocument.Parse(data);
        // Kişi bilgilerini çekip filtreleme işlemi yapıyoruz
        var people = doc.Descendants("Person")
            .Select(p => new// Kişi bilgilerini anonim tipte tutuyoruz
            {
                Name = (string)p.Element("Name"),
                Age = int.Parse((string)p.Element("Age")),
                Department = (string)p.Element("Department"),
                Salary = int.Parse((string)p.Element("Salary")),
                HireDate = DateTime.Parse((string)p.Element("HireDate"), CultureInfo.InvariantCulture)
            })// İstenilen filtreleme kriterlerine göre filtre uyguluyoruz
            .Where(p => p.Age > 30 && p.Department == "IT" && p.Salary > 5000 && p.HireDate.Year < 2019)// Sonuçları listeye dönüştürüyoruz
            .ToList(); //Listeleme işlemi

        var names = people.Select(p => p.Name).OrderBy(n => n).ToList();// İsimleri alfabetik yapmak için kullanıyoruz
        var totalSalary = people.Sum(p => p.Salary);// Toplam maaş hesapl?yoruz
        var count = people.Count;// Kişi sayısını alma işlemini yapıyoruz
        var averageSalary = count > 0 ? totalSalary / count : 0;// Ortalama maaş burada hesaplıyoruz
        var maxSalary = count > 0 ? people.Max(p => p.Salary) : 0;// Maksimum maaş burada hesaplıyoruz
        var minSalary = count > 0 ? people.Min(p => p.Salary) : 0;// Minimum maaş burada hesaplıyoruz

        var result = new// Sonuçları anonim tipte tutuyoruz
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            MinSalary = minSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result);// Sonuçları JSON formatında döndürüyoruz
    }
}

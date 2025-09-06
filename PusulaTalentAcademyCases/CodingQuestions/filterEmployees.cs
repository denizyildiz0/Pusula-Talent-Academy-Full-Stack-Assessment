using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodingQuestions;
public static class FilterEmployeeCase
{
    public static class EmployeeAnalyzer
    {
        public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            // Filtreleme kriterlerine uyan çalışanları burada belirtiyoruz
            var filtered = employees
                .Where(e =>
                        e.Age >= 25 && e.Age <= 40 && // Yaş aralığı
                        (e.Department == "IT" || e.Department == "Finance") && // Departman
                        e.Salary >= 5000 && e.Salary <= 9000 &&// Maaş
                        e.HireDate.Year >= 2017 // İşe giriş tarihi
                )
                .ToList();

            // İsimleri alfabetik sıralama ile düzenleme yapmasını burada sağladık
            var names = filtered.Select(e => e.Name).OrderByDescending(n => n.Length).ToList();

            // Toplam maaşş
            var totalSalary = filtered.Sum(e => e.Salary);

            // Çalışan sayısı 
            var count = filtered.Count;

            // Ortalama maaş (virgülden sonra 2 basamak olacak şekilde düzenledim)
            var averageSalary = count > 0 ? Math.Round(totalSalary / count, 2) : 0;

            // En düşük maaş
            var minSalary = count > 0 ? filtered.Min(e => e.Salary) : 0;

            // En yüksek maaş
            var maxSalary = count > 0 ? filtered.Max(e => e.Salary) : 0;

            // JSON formatında sonuç nesnesi oluşturuyoruz
            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = averageSalary,
                MinSalary = minSalary,
                MaxSalary = maxSalary,
                Count = count
            };

            // JSON string olarak döndürme işlemi yapıyoruz
            return JsonSerializer.Serialize(result);
        }
    }
}


using System;
using System.IO;
using System.Text.Json;
using ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "App_Data", "earthquake.json");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"找不到檔案：{filePath}");
            return;
        }

        string json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        Root data = JsonSerializer.Deserialize<Root>(json, options);

        // ✅ 印出地震摘要資訊
        var eq = data.cwaopendata.Earthquake;
        Console.WriteLine(" 地震報告：");
        Console.WriteLine($"說明：{eq.Description}");
        Console.WriteLine($"發生時間：{eq.OriginTime}");
        Console.WriteLine($"震央經緯度：({eq.EpicenterLongitude}, {eq.EpicenterLatitude})");
        Console.WriteLine($"深度：{eq.FocalDepth} 公里");
        Console.WriteLine($"規模：{eq.Magnitude.MagnitudeType} {eq.Magnitude.MagnitudeValue}");
        Console.WriteLine();

        Console.WriteLine("各縣市最大震度：");
        foreach (var county in eq.Intensity.County)
        {
            Console.WriteLine($"　{county.CountyName}（{county.CountyCode}）：{county.CountyMaxIntensity}");
        }

        Console.WriteLine();
        Console.WriteLine("示範列出臺北市前 3 個鄉鎮：");
        var taipei = eq.Intensity.County.Find(c => c.CountyName == "臺北市");
        if (taipei != null)
        {
            foreach (var town in taipei.Town.GetRange(0, Math.Min(3, taipei.Town.Count)))
            {
                Console.WriteLine($"　{town.TownName}：{town.StationIntensity}");
            }
        }
    }
}

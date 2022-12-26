// See https://aka.ms/new-console-template for more information
using Aspose.Cells.Utility;
using Aspose.Cells;
using System.Net;

Console.WriteLine("Prices from https://api.porssisahko.net");

string html = string.Empty;
// string url = @"https://api.porssisahko.net/v1/price.json?date="+ DateTime.Now.ToString("yyyy-MM-dd") + "&hour=" + DateTime.Now.ToString("HH");
string url = @"https://api.porssisahko.net/v1/latest-prices.json";

HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
request.AutomaticDecompression = DecompressionMethods.GZip;

using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
using (Stream stream = response.GetResponseStream())
using (StreamReader reader = new StreamReader(stream))
{
    html = reader.ReadToEnd();
}

Console.WriteLine(html);

Workbook workbook = new Workbook();
Worksheet worksheet = workbook.Worksheets[0];

string jsonInput = html;

JsonLayoutOptions options = new JsonLayoutOptions();
options.ArrayAsTable = true;

JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, options);

workbook.Save("prices.xlsx");
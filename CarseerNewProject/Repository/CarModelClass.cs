using CarseerNewProject.Models;
using CsvHelper;
using Newtonsoft.Json;

namespace CarseerNewProject.Repository
{
    public class CarModelClass : ICarModelClass
    {
        public  string LoadCarMakes(string makename)
        {
            using (var reader = new StreamReader("CarMake.csv"))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    if (record.make_name == makename)
                    {
                        return record.make_id;
                       
                    }
                }
            }


            return null;
        }
        public async Task<string> GetURL(Uri u)
        {

            var response = string.Empty;
            using (var client = new HttpClient())
            {


                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        }

    }
}
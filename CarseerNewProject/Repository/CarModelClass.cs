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
                    carMakesObj.Make_Name = record.make_name;
                    carMakesObj.Make_Id =   record.make_id;
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

        public ModelsByMakeId GetModelsForMakeIdYear(string MakeId,long ModelYear)
        {
            var ModelsByMakeObj = new ModelsByMakeId();
            var ApiUrl = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{MakeId}/modelyear/{ModelYear}?format=json";
            var readTask = Task.Run(() => GetURL(new Uri(ApiUrl)));
            readTask.Wait();

            if (!string.IsNullOrEmpty(readTask.Result) && readTask.IsCompleted)
            {
                ModelsByMakeObj = JsonConvert.DeserializeObject<ModelsByMakeId>(readTask.Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


            }
            return ModelsByMakeObj;
        }
    }
}
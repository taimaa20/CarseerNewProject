using CarseerNewProject.Models;

namespace CarseerNewProject.Repository
{
    public interface ICarModelClass
    {
        string LoadCarMakes(string makename);
        Task<string> GetURL(Uri u);
        ModelsByMakeId GetModelsForMakeIdYear(string MakeId, long ModelYear);
    }
}

using Core.Utilities.Results;
using Entity;

namespace Business.Interfaces
{
    public interface IDuyuruService
    {
        void AddDuyuru(Duyuru duyuru);
        IResult UpdateDuyuru(Duyuru duyuru);
        IResult DeleteDuyuru(int duyuruId);
        Duyuru GetDuyuruById(int duyuruId);
        IEnumerable<Duyuru> GetAllDuyurular();
    }
}

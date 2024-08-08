using Business.Interfaces;
using Core.Utilities.Results;
using DataAccess.IDal;
using Entity;

namespace Business.Concrete
{
    public class DuyuruService : IDuyuruService
    {
        private readonly IDuyuruDal _duyuruDal;

        public DuyuruService(IDuyuruDal duyuruDal)
        {
            _duyuruDal = duyuruDal;
        }

        public void AddDuyuru(Duyuru duyuru)
        {
            _duyuruDal.Add(duyuru);
        }
        public IResult DeleteDuyuru(int duyuruId)
        {
            var duyuru = _duyuruDal.GetById(duyuruId);

            if (duyuru == null)
            {
                return new ErrorResult("Duyuru bulunamadı");
            }

            _duyuruDal.Delete(duyuru);
            return new SuccessResult("Duyuru başarıyla silindi");
        }

        public IEnumerable<Duyuru> GetAllDuyurular()
        {
            return _duyuruDal.GetAll();
        }

        public Duyuru GetDuyuruById(int duyuruId)
        {
            return _duyuruDal.GetById(duyuruId);
        }

        public IResult UpdateDuyuru(Duyuru duyuru)
        {
            _duyuruDal.Update(duyuru);
            return new SuccessResult("Duyuru başarıyla güncellendi");
        }
    }
}

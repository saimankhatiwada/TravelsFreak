using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelsFreak.Data;
using TravelsFreak.Data.DatabaseContext;
using TravelsFreak.Models.DataTransferObject;
using TravelsFreak.Repository.IRepository;

namespace TravelsFreak.Repository
{
    public class TourPackageRepository : ITourPackageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TourPackageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TourPackageDTO> Create(TourPackageDTO objectDTO)
        {
            var tourPackage = _mapper.Map<TourPackageDTO, TourPackage>(objectDTO);
            _db.TourPackages.Add(tourPackage);
            await _db.SaveChangesAsync();
            return _mapper.Map<TourPackage, TourPackageDTO>(tourPackage);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.TourPackages.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.TourPackages.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<TourPackageDTO> Get(int id)
        {
            var obj = await _db.TourPackages.Include(x => x.Destinations).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<TourPackage, TourPackageDTO>(obj);
            }
            return new TourPackageDTO();
        }

        public async Task<IEnumerable<TourPackageDTO>> GetAll()
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<TourPackage>, IEnumerable<TourPackageDTO>>(_db.TourPackages.Include(x => x.Destinations)));
        }

        public async Task<TourPackageDTO> Update(TourPackageDTO objectDTO)
        {
            var objFromDb = await _db.TourPackages.FirstOrDefaultAsync(x => x.Id == objectDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Price = objectDTO.Price;
                objFromDb.Days = objectDTO.Days;
                objFromDb.TourPackageDescription = objectDTO.TourPackageDescription;
                objFromDb.TourPackageImageUrl = objectDTO.TourPackageImageUrl;
                objFromDb.TourPackageLocation = objectDTO.TourPackageLocation;
                objFromDb.DestinationsId = objectDTO.DestinationsId;
                _db.TourPackages.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<TourPackage, TourPackageDTO>(objFromDb);
            }
            return objectDTO;
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsFreak.Data;
using TravelsFreak.Data.DatabaseContext;
using TravelsFreak.Models.DataTransferObject;
using TravelsFreak.Repository.IRepository;

namespace TravelsFreak.Repository
{
    public class DestinationsRepository : IDestinationsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DestinationsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DestinationsDTO> Create(DestinationsDTO objectDTO)
        {
            var destination = _mapper.Map<DestinationsDTO, Destinations>(objectDTO);
            _db.Destinations.Add(destination);
            await _db.SaveChangesAsync();
            return _mapper.Map<Destinations, DestinationsDTO>(destination);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Destinations.FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null)
            {
                _db.Destinations.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<DestinationsDTO> Get(int id)
        {
            var obj = await _db.Destinations.FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null)
            {
                return _mapper.Map<Destinations,DestinationsDTO>(obj);
            }
            return new DestinationsDTO();
        }

        public async Task<IEnumerable<DestinationsDTO>> GetAll()
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<Destinations>, IEnumerable<DestinationsDTO>>(_db.Destinations));
        }

        public async Task<DestinationsDTO> Update(DestinationsDTO objectDTO)
        {
            var objFromDb = await _db.Destinations.FirstOrDefaultAsync(x => x.Id == objectDTO.Id);
            if(objFromDb!= null)
            {
                objFromDb.DestinationTittle = objectDTO.DestinationTittle;
                objFromDb.Location = objectDTO.Location;
                _db.Destinations.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Destinations,DestinationsDTO>(objFromDb);
            }
            return objectDTO;
        }
    }
}

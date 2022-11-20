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
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BlogRepository(ApplicationDbContext db, IMapper mapper)
        { 
            _db = db;
            _mapper = mapper;
        }

        public async Task<BlogDTO> Create(BlogDTO objectDTO)
        {
            var blog = _mapper.Map<BlogDTO, Blog>(objectDTO);
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return _mapper.Map<Blog, BlogDTO>(blog);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Blogs.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<BlogDTO> Get(int id)
        {
            var obj = await _db.Blogs.Include(x => x.Destinations).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Blog, BlogDTO>(obj);
            }
            return new BlogDTO();
        }

        public async Task<IEnumerable<BlogDTO>> GetAll()
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<Blog>, IEnumerable<BlogDTO>>(_db.Blogs.Include(x => x.Destinations)));
        }

        public async Task<BlogDTO> Update(BlogDTO objectDTO)
        {
            var objFromDb = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == objectDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.BlogTittle = objectDTO.BlogTittle;
                objFromDb.BlogDescription = objectDTO.BlogDescription;
                objFromDb.BlogImageUrl = objectDTO.BlogImageUrl;
                objFromDb.DestinationsId = objectDTO.DestinationsId;
                _db.Blogs.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Blog, BlogDTO>(objFromDb);
            }
            return objectDTO;
        }
    }
}

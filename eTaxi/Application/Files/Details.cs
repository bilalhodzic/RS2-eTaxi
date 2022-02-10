using Domain;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Others;
using Model.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Files
{
    public partial class Files
    {
        public override async Task<IEnumerable<FileDto>> Get(FileSearchRequest search = null)
        {
            var entity = _context.Set<File>().AsQueryable();
           
                entity = entity.Where(x => x.UserId == search.UserId);
            
            if (search.Type != null)
            {
                if (search.Type == Messages.ProfileImage)
                    entity = entity.Where(x => x.Type == search.Type);
                if (search.Type == Messages.HeaderImage)
                    entity = entity.Where(x => x.Type == search.Type);
                if (search.Type == Messages.GalleryImage)
                    entity = entity.Where(x => x.Type == search.Type);
            }
            var list = await entity.ToListAsync();
            return _mapper.Map<IEnumerable<FileDto>>(list);

        }
    }
}

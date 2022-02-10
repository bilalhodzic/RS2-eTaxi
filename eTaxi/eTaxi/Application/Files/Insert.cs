using Domain;
using Model.Dto;
using Model.Others;
using Model.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Files
{
    public partial class Files
    {
        public override Task<FileDto> Insert(FileInsert request)
        {
            ID = request.UserId;
            ValidateApi();
            var files = _context.Set<File>().AsQueryable();
            var FileNumbers = files.Where(x => x.Type != Messages.HeaderImage && x.Type != Messages.ProfileImage && x.Type != Messages.SalonImage).Count();
            if (FileNumbers >= 10)
                throw new UserException("Ne mozete dodati vise od 10 slika!!");
            File entity = new File();
            var image = Helper.UploadImage<File>(request.File, _appSettings.ImagesUrl);
            entity = _mapper.Map<File>(image);
            entity.Type = Messages.GalleryImage;
            entity.UserId = request.UserId;
            _context.Add(entity);

            _context.SaveChanges();
            return Task.Run(() =>
            {
                return _mapper.Map<FileDto>(entity);

            });

        }
    }
}

using Domain;
using Model.Dto;
using Model.Others;
using Model.Requests;
using System.Threading.Tasks;

namespace Application.Files
{
    public partial class Files
    {
        public override Task<FileDto> Update(int id, FileUpsert request)
        {
            var entity = _context.Files.Find(id);
            ID = entity.UserId;
            ValidateApi();
            if (entity == null)
            {
                throw new UserException("Nije pronađeno.");
            }
            if (entity.OriginalName != ImagesPath.DefaultProfileImage && entity.OriginalName != ImagesPath.DefaultHeaderImage && entity.OriginalName != ImagesPath.DefaultSalonImage)
            {
                Helper.RemoveImage(entity.FileName, entity.Url);
            }

            var image = Helper.UploadImage<File>(request.File, _appSettings.ImagesUrl);

            entity.FileName = image.FileName;
            entity.OriginalName = image.OriginalName;
            entity.Url = image.Url;
            _context.SaveChanges();

            return Task.Run(() =>
            {
                return _mapper.Map<FileDto>(entity);
            });
        }
    }
}

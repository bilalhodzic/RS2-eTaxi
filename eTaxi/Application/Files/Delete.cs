using Model.Others;


namespace Application.Files
{
    public partial class Files
    {
        public override void Delete(int id)
        {
            var entity = _context.Files.Find(id);
            ID = entity.UserId;
            ValidateApi();
            if (entity == null)
            {
                throw new UserException("Nije pronađeno");
            }
            Helper.RemoveImage(entity.FileName, entity.Url);
            if (entity.Type != Messages.HeaderImage && entity.Type != Messages.ProfileImage && entity.Type != Messages.SalonImage)
            {
                _context.Files.Remove(entity);
            }
            else
            {
                if (entity.Type == Messages.ProfileImage)
                {
                    entity.Url = _appSettings.ImagesUrl + ImagesPath.DefaultProfileImage;
                    entity.FileName = ImagesPath.DefaultProfileImage;
                    entity.OriginalName = ImagesPath.DefaultProfileImage;
                }
                else if (entity.Type == Messages.HeaderImage)
                {
                    entity.Url = _appSettings.ImagesUrl + ImagesPath.DefaultHeaderImage;
                    entity.FileName = ImagesPath.DefaultHeaderImage;
                    entity.OriginalName = ImagesPath.DefaultHeaderImage;
                }
                else if (entity.Type == Messages.SalonImage)
                {
                    entity.Url = _appSettings.ImagesUrl + ImagesPath.DefaultSalonImage;
                    entity.FileName = ImagesPath.DefaultSalonImage;
                    entity.OriginalName = ImagesPath.DefaultSalonImage;
                }
            }
            _context.SaveChanges();
        }
    }
}

using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Dto.Vehicle;
using Model.Others;
using Model.Requests.Vehicle;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.VehicleTypes
{
    public partial class VehicleTypes : CRUD<VehicleTypeDto, VehicleTypeSearchRequest, VehicleType, VehicleTypeInsertRequest, object>
    {
        public VehicleTypes(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }

      
        public override  async Task<IEnumerable<VehicleTypeDto>> Get(VehicleTypeSearchRequest search = null)
        {
            try
            {
                return await _context.Set<VehicleType>().Select(x => new VehicleTypeDto { File = x.File.Url, NumberOfSeats = x.NumberOfSeats, VehicleTypeId = x.VehicleTypeId, Type=x.Type }).ToListAsync();//.Include(x=>x.Icon.Url).ToListAsync();
            }
            catch
            {
                throw new UserException(Messages.WrongData);
            }
        }
    }
}

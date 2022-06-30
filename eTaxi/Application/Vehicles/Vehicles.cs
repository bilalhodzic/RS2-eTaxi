using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.Dto.Vehicle;
using Model.Others;
using Model.Requests.Vehicle;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Vehicles
{
    public partial class Vehicles : CRUD<VehicleDto, VehicleSearchRequest, Vehicle, VehicleInsertRequest, VehicleUpsertRequest>
    {
        public Vehicles(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }

        public override async Task<IEnumerable<VehicleDto>> Get(VehicleSearchRequest search = null)
        {
            try
            {
                return await _context.Set<Vehicle>().Select(x =>
                
                    new VehicleDto
                    {
                        VehicleId = x.VehicleId,
                        Name = x.Name,
                        CreatedTime = x.CreatedTime,
                        KmTraveled = x.KmTraveled,
                        LicenceNumber = x.LicenceNumber,
                        Year = x.Year,
                        AirCondition = x.AirCondition,
                        AirBag = x.AirBag,
                        FuelType = x.FuelType,
                        Transmission = x.Transmission,
                        Color = x.Color,
                        Brand = x.Brand,
                        PricePerKm = x.PricePerKm,
                        NumberOfSeats = x.Type.NumberOfSeats,
                         File=x.Files.Where(y=>y.VehicleId==x.VehicleId).Select(y => y.Url).First(),
                        UserDriverId = x.UserDriverId,
                        CurrentLocationId = x.CurrentLocationId

                    
                }).ToListAsync();
            }
            catch
            {
                throw new UserException(Messages.WrongData);
            }
        }
    }
}

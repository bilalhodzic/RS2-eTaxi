using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.Dto.Hub;
using Model.Others;
using Model.Requests.Hub;
using Persistence;

namespace Application.Hubs
{
    public partial class Hubs : CRUD<HubDto, object, Hub, HubInsertRequest, object>
    {
        public Hubs(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }

        public override async Task<IEnumerable<HubDto>> Get(object search = null)
        {
            try
            {
          
                return await _context.Set<Hub>().Select(x => new HubDto
                {
                    HubId = x.HubId,
                    Name = x.Name,
                    Address = x.Location.Address,
                    City = x.Location.City,
                    Latitude = x.Location.Latitude,
                    Longitude = x.Location.Longitude
                }).ToListAsync();
            }
            catch (Exception)
            {

                throw new UserException(Messages.WrongData);
            }
        }

        public override async Task<HubDto> Insert(HubInsertRequest request)
        {
            ValidateApi();
            try
            {
                var dbLocation = _context.Set<Location>();
                int locationId=0;

                Location findExistingLocation = dbLocation.Where(x=>x.City==request.City).FirstOrDefault();

                if (findExistingLocation != null)
                {
                    locationId = findExistingLocation.LocationId;
                }
                else
                {

                    Location HubLocation = new Location
                    {
                        Address = request.Address,
                        City = request.City,
                        Latitude = request.Latitude,
                        Longitude = request.Longitude,
                    };
                    dbLocation.Add(HubLocation);
                    _context.SaveChanges();
                        locationId = HubLocation.LocationId;
                }

                var dbHub = _context.Set<Hub>();
                Hub entity = _mapper.Map<Hub>(request);
                entity.LocationId = locationId;

                dbHub.Add(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HubDto>(entity);

            }
            catch (Exception ex)
            {

               
                throw new UserException(Messages.WrongData);

            }
        }
    }
}

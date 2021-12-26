using Chopi.API.Controllers.CreatorsControllers.Abstracts;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Chopi.Modules.EFCore.Entities.CarDealership;
using System.Linq;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using System.Threading.Tasks;
using Chopi.Modules.EFCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chopi.API.Controllers.CreatorsControllers
{
    [ApiController]
    public class DataCreatorController : CreatorController
    {
        private AppDbContext _context;

        public DataCreatorController(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            AppDbContext context) 
            : base(userManager, roleManager)
        {
            _context = context;
        }

        [HttpGet("CreateAll")]
        public async Task<IActionResult> CreateAll()
        {
            string res = string.Empty;

            res += await CreateCountry() + "\r\n";
            res += await CreateManufacturers() + "\r\n";
            res += await Models() + "\r\n";
            res += await Autoparts() + "\r\n";


            return Ok(res);
        }

        [HttpGet("CreateCountry")]
        public async Task<string> CreateCountry()
        {
            var list = new List<string>() { "Германия", "Британия", "Польша", "США" };
            list.ForEach(e => _context.Countries.Add(new Country() { Name = e }));
            await _context.SaveChangesAsync();
            return "country";
        }

        [HttpGet("CreateManufacturers")]
        public async Task<string> CreateManufacturers()
        {
            _context.Manufacturers.Add(
                new Manufacturer()
                {
                    Address = "Juper 23",
                    Brand = "Mercedes-Benz",
                    Country = _context.Countries.Where(e => e.Name == "Германия").First(),
                    INN = "843845475657",
                    PhoneNumber = "92909433328",
                });
            _context.Manufacturers.Add(
                new Manufacturer()
                {
                    Address = "Fenix 1",
                    Brand = "Volkswagen",
                    Country = _context.Countries.Where(e => e.Name == "Германия").First(),
                    INN = "38484385",
                    PhoneNumber = "8546586875",
                });
            _context.Manufacturers.Add(
                new Manufacturer()
                {
                    Address = "Hourses 34",
                    Brand = "Brabus",
                    Country = _context.Countries.Where(e => e.Name == "Германия").First(),
                    INN = "28938433",
                    PhoneNumber = "49858945",
                });

            await _context.SaveChangesAsync();

            return "Manufacturer";
        }

        [HttpGet("Models")]
        public async Task<string> Models()
        {
            await _context.Models.AddRangeAsync(
                new Model()
                {
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Name = "G63"
                },
                new Model()
                {
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Name = "GLE 300 D"
                },
                new Model()
                {
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Name = "GLC 250 I"
                },
                new Model()
                {
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Volkswagen").First(),
                    Name = "Touareg"
                },
                new Model()
                {
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Volkswagen").First(),
                    Name = "Golf"
                });

            await _context.SaveChangesAsync();

            return "models";
        }

        [HttpGet("Autoparts")]
        public async Task<string> Autoparts()
        {
            {
                var i = new Autopart()
                {
                    Id = System.Guid.NewGuid(),
                    Article = "UY3AHNV3",
                    Name = "Бампер передний",
                    Description = "Бампер передний, с противотуманками, белый",
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Price = 12990
                };

                var m = _context.Models.Where(e => e.Name == "G63").First();

                _context.Autoparts.Add(i);
                _context.ModelToAutoparts.Add(new ModelToAutopart()
                {
                    ModelId = m.Id,
                    AutopartId = i.Id,
                });

                i = new Autopart()
                {
                    Id = System.Guid.NewGuid(),
                    Article = "UY3AHNV4",
                    Name = "Бампер задний",
                    Description = "Бампер задний, белый",
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Price = 12990
                };

                m = _context.Models.Where(e => e.Name == "G63").First();

                _context.Autoparts.Add(i);
                _context.ModelToAutoparts.Add(new ModelToAutopart()
                {
                    ModelId = m.Id,
                    AutopartId = i.Id,
                });
            }
            {
                var i = new Autopart()
                {
                    Id = System.Guid.NewGuid(),
                    Article = "MVOKF1",
                    Name = "Бампер передний",
                    Description = "Бампер передний, с противотуманками, белый",
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Price = 11990
                };

                var m = _context.Models.Where(e => e.Name == "GLE 300 D").First();

                _context.Autoparts.Add(i);
                _context.ModelToAutoparts.Add(new ModelToAutopart()
                {
                    ModelId = m.Id,
                    AutopartId = i.Id,
                });

                i = new Autopart()
                {
                    Id = System.Guid.NewGuid(),
                    Article = "MVOKF2",
                    Name = "Бампер задний",
                    Description = "Бампер задний, белый",
                    Manufacturer = _context.Manufacturers.Where(e => e.Brand == "Mercedes-Benz").First(),
                    Price = 15990
                };

                m = _context.Models.Where(e => e.Name == "GLE 300 D").First();

                _context.Autoparts.Add(i);
                _context.ModelToAutoparts.Add(new ModelToAutopart()
                {
                    ModelId = m.Id,
                    AutopartId = i.Id,
                });
            }

            await _context.SaveChangesAsync();

            return "autoparts";
        }

        [HttpGet("CreateComplete")]
        public async Task<string> CreateComplete()
        {
            var parts = await _context.Autoparts.Include(s => s.Models).Where(e => e.Models.Any(s => s.Model.Name == "G63")).ToListAsync();

            var complete = new Complete()
            {
                Id = System.Guid.NewGuid(),
                Name = "G63 Brabus"
            };

            var completetoparts = new List<CompleteToAutopart>();

            parts.ForEach(part =>
            {
                completetoparts.Add(new CompleteToAutopart()
                {
                    AutopartId = part.Id,
                    CompleteId = complete.Id
                });
            });

            await _context.Completes.AddAsync(complete);
            await _context.SaveChangesAsync();
            await _context.CompleteToAutoparts.AddRangeAsync(completetoparts);
            await _context.SaveChangesAsync();

            return "CreateComplete";
        }

        [HttpGet("CreateCompliteCars")]
        public async Task<string> CreateCompleteCars()
        {
            var complete = await _context.Completes.Where(e => e.Name == "G63 Brabus").FirstAsync();
            var model = await _context.Models.Where(e => e.Name == "G63").FirstAsync();
            var car = new CompleteCar()
            {
                Year = new DateTime(2019, 5, 17),
                BasePrice = 12950000,
                Color = "Черный",
                CompleteId = complete.Id,
                Id = Guid.NewGuid(),
                ModelId = model.Id,

            };

            await _context.CompleteCars.AddAsync(car);
            await _context.SaveChangesAsync();

            return "CreateCompleteCars";
        }
    }
}

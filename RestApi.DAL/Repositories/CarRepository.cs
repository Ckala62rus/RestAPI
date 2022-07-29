using Microsoft.EntityFrameworkCore;
using RestApi.DAL.Interfaces;
using RestApi.Domain.Entity;
using RestApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Car entity)
        {
            entity.DateCreate = DateTime.Now;
            _db.Car.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(Car Entity)
        {
            _db.Car.Remove(Entity);
            _db.SaveChanges();
            return true;
        }

        public async Task<Car> Get(int id)
        {
            return await _db.Car.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Car GetByName(string name)
        {
            return _db.Car.FirstOrDefault(x => x.Name == name);
        }

        public async Task<List<Car>> Select()
        {
            return await _db.Car.ToListAsync();
        }

        public async Task<Car> Update(Car entity)
        {
            _db.Car.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

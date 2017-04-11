﻿using System;
using System.Data.Entity;
using System.Linq;
using Haris.DataModel.DataModels;

namespace Haris.DataModel.Repositories.Implementation
{
    public class CubeRepository : ICubeRepository
    {
        private readonly HarisDbContext _context;
        private IDbSet<Cube> _cubes;


        public CubeRepository(HarisDbContext context)
        {
            _context = context;
            _cubes = _context.Cubes;
        }

        public void CreateCube(Cube cube)
        {
            _cubes.Add(cube);
            _context.SaveChangesAsync();
        }

        public Cube GetCube(string address)
        {
            return _cubes.FirstOrDefault(x => x.CubeAddress.Contains(address));
        }

        public void AddLog(Log log)
        {
            _context.Logs.Add(log);
        }

        public void UpdateCube(Cube cube)
        {
            _context.Cubes.Attach(cube);
            _context.Entry(cube).Property(x => x.Id == cube.Id).IsModified = true;
            _context.SaveChanges();
        }

    }
}

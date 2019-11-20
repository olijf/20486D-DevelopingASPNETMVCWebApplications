﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupcakes.Models;
using System.IO;
using Cupcakes.Data;
using Microsoft.EntityFrameworkCore;

namespace Cupcakes.Repositories
{
    public class CupcakeRepository : ICupcakeRepository
    {
        private CupcakeContext _context;
        public CupcakeRepository(CupcakeContext context) => _context = context;
        public void CreateCupcake(Cupcake cupcake)
        {
            if (cupcake.PhotoAvatar != null)
            {
                if (cupcake.PhotoAvatar.Length > 0)
                {
                    cupcake.ImageMimeType = cupcake.PhotoAvatar.ContentType;
                    cupcake.ImageName = Path.GetFileName(cupcake.PhotoAvatar.FileName);
                    using (var ms = new MemoryStream())
                    {
                        cupcake.PhotoAvatar.CopyTo(ms);
                        cupcake.PhotoFile = ms.ToArray();
                    }
                }
            }
            _context.Add(cupcake);
            _context.SaveChanges();
        }

        public void DeleteCupcake(int id)
        {
            _context.Cupcakes.Remove(_context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id));
            _context.SaveChanges();
        }

        public Cupcake GetCupcakeById(int id)
        {
            return _context.Cupcakes.Include(b => b.Bakery).SingleOrDefault(c => c.CupcakeId == id);
        }

        public IEnumerable<Cupcake> GetCupcakes()
        {
            return _context.Cupcakes.ToList();
        }

        public IQueryable<Bakery> PopulateBakeriesDropDownList()
        {
            var bakeriesQuery = from b in _context.Bakeries
                                orderby b.BakeryName
                                select b;
            return bakeriesQuery;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

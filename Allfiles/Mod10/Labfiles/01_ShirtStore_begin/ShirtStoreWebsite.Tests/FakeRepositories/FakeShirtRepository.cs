﻿using System;
using System.Collections.Generic;
using System.Text;
using ShirtStoreWebsite.Services;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Tests.FakeRepositories
{
    class FakeShirtRepository : IShirtRepository
    {
        public bool AddShirt(Shirt shirt)
        {
            return true;
        }

        public IEnumerable<Shirt> GetShirts()
        {
            return new List<Shirt>()
                        {
                        new Shirt { Color = ShirtColor.Black, Size = ShirtSize.S, Price = 11F },
                        new Shirt { Color = ShirtColor.Gray, Size = ShirtSize.M, Price = 12F },
                        new Shirt { Color = ShirtColor.White, Size = ShirtSize.L, Price = 13F }
                        };
        }

        public bool RemoveShirt(int id)
        {
            return true;
        }
    }
}

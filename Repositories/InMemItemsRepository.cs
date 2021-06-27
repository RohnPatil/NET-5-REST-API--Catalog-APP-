using System;
using System.Collections.Generic;
using Catalog.Entities;
using System.Linq;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        public readonly List<Item> items = new()
        {
            new Item{ Id = Guid.NewGuid(), Name ="Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name ="Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },

            new Item{ Id = Guid.NewGuid(), Name ="Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }

        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(item => item.Id == Id).SingleOrDefault();
        }

    }
}
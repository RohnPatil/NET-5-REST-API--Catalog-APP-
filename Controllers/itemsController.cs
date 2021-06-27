using System;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;
        public ItemsController()
        {
            repository = new InMemItemsRepository();

        }

        //GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        //GET /items/{Id}
        [HttpGet("{Id}")]
        public ActionResult<Item> GetItem(Guid Id)
        {
            var item = repository.GetItem(Id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }
    }

}
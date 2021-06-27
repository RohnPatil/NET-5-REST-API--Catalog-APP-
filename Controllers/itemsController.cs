using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;

        }
 
        //GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item =>item.AsDto());
            return items;
        }

        //GET /items/{Id}
        [HttpGet("{Id}")]
        public ActionResult<ItemDto> GetItem(Guid Id)
        {
            var item = repository.GetItem(Id);
            if(item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
    }

}
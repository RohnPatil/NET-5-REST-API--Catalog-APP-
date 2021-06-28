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

        //Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price =itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new{id = item.Id}, item.AsDto());
        }

        //Put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
             var existingItem = repository.GetItem(id);

             if(existingItem is null)
             {
                 return NotFound();
             }

             Item updatedItem = existingItem with
             {
                 Name = itemDto.Name,
                 Price = itemDto.Price
             };

             repository.UpdateItem(updatedItem);

             return NoContent();
        }


    }

}
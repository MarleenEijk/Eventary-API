using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unittest.FakeRepositories
{
    public class FakeItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new();

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var itemDtos = _items.Select(i => new ItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                Quantity = i.Quantity,
                ImageUrl = i.ImageUrl,
                Category_Id = i.Category_Id,
                Company_Id = i.Company_Id
            });
            return await Task.FromResult(itemDtos);
        }

        public async Task<ItemDto?> GetByIdAsync(long id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return null;
            }

            return await Task.FromResult(new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                ImageUrl = item.ImageUrl,
                Category_Id = item.Category_Id,
                Company_Id = item.Company_Id
            });
        }

        public async Task AddItemAsync(ItemDto itemDto)
        {
            var item = new Item
            {
                Id = itemDto.Id,
                Name = itemDto.Name,
                Price = itemDto.Price,
                Quantity = itemDto.Quantity,
                ImageUrl = itemDto.ImageUrl,
                Category_Id = itemDto.Category_Id,
                Company_Id = itemDto.Company_Id
            };

            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(ItemDto itemDto)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemDto.Id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            item.Name = itemDto.Name;
            item.Price = itemDto.Price;
            item.Quantity = itemDto.Quantity;
            item.ImageUrl = itemDto.ImageUrl;
            item.Category_Id = itemDto.Category_Id;
            item.Company_Id = itemDto.Company_Id;

            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(long id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            _items.Remove(item);
            await Task.CompletedTask;
        }
    }
}

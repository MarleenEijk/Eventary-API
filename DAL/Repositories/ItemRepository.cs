using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context; 

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            return await _context.item
                .Select(item => new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ImageUrl = item.ImageUrl,
                    Category_Id = item.Category_Id,
                    Company_Id = item.Company_Id
                })
                .ToListAsync();
        }

        public async Task<ItemDto?> GetByIdAsync(long id)
        {
            var item = await _context.item.FindAsync(id);
            if (item == null) return null;

            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                ImageUrl = item.ImageUrl,
                Category_Id = item.Category_Id,
                Company_Id = item.Company_Id
            };
        }


        public async Task<ItemDto> AddItemAsync(ItemDto itemDto)
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

            var addedItem = await _context.item.AddAsync(item);
            await _context.SaveChangesAsync();

            return new ItemDto
            {
                Id = addedItem.Entity.Id,
                Name = addedItem.Entity.Name,
                Price = addedItem.Entity.Price,
                Quantity = addedItem.Entity.Quantity,
                ImageUrl = addedItem.Entity.ImageUrl,
                Category_Id = addedItem.Entity.Category_Id,
                Company_Id = addedItem.Entity.Company_Id
            };
        }


        public async Task UpdateItemAsync(ItemDto itemDto)
        {
            var item = await _context.item.FindAsync(itemDto.Id);
            if (item == null) return;

            item.Name = itemDto.Name;
            item.Price = itemDto.Price;
            item.Quantity = itemDto.Quantity;
            item.ImageUrl = itemDto.ImageUrl;
            item.Category_Id = itemDto.Category_Id;
            item.Company_Id = itemDto.Company_Id;

            _context.item.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(long id)
        {
            var item = await _context.item.FindAsync(id);
            if (item == null) return;

            _context.item.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemDto?> GetByNameAsync(string name)
        {
            var item = await _context.item.FirstOrDefaultAsync(i => i.Name == name);
            if (item == null) return null;

            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                ImageUrl = item.ImageUrl,
                Category_Id = item.Category_Id,
                Company_Id = item.Company_Id
            };
        }
    }
}

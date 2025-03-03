using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
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
            var items = await _context.item.ToListAsync();
            return items.Select(item => new ItemDto
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

        public async Task<ItemDto?> GetByIdAsync(long id)
        {
            var item = await _context.item.FindAsync(id);
            if (item == null)
            {
                return null;
            }

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

            await _context.item.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(ItemDto itemDto)
        {
            var item = await _context.item.FindAsync(itemDto.Id);
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

            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(long id)
        {
            var item = await _context.item.FindAsync(id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            _context.item.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
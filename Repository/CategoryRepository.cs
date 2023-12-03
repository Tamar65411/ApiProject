using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private  StoreDataBase2Context dbContext;
        public CategoryRepository(StoreDataBase2Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await dbContext.Categories.ToListAsync();

        }

    }
}

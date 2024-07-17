﻿using exp.NET6.Infrastructure.Context;
using exp.NET6.Infrastructure.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.NET6.Infrastructure.Repositories.Teams
{
    public class TeamsRepository : GenericRepository<Team>, ITeamsRepository
    {
        public TeamsRepository(FlowerPowerDbContext context) : base(context) { }


        public async Task<Team> DeleteVirtual(int id)
        {
            try
            {
                var entity = await context.Set<Team>().FindAsync(id);
                if (entity == null)
                    throw new KeyNotFoundException("This object does not exist, please enter a valid id");

                entity.IsDeleted = true;
                await context.SaveChangesAsync();

                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

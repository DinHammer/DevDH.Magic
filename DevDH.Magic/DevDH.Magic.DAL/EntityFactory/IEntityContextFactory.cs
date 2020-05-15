using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DevDH.Magic.DAL.EntityFactory
{
    public interface IEntityContextFactory
    {
        DbContext GetDbContext();
    }
}

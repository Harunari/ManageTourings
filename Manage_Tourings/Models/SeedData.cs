using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_Tourings.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ManageTouringsContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ManageTouringsContext>>()))
            {
                if (context.Tourings.Any()) { return; }

                context.Tourings.AddRange(
                    new Touring.Touring
                    {
                        Title = "白浜ツーリング",
                        Note = "初心者向け"
                    },

                    new Touring.Touring
                    {
                        Title = "房総半島ツーリング",
                        Note = "中級者向け"
                    },

                    new Touring.Touring
                    {
                        Title = "乗鞍ツーリング",
                        Note = "上級者向け"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

using Manage_Tourings.Models;
using Manage_Tourings.Models.Touring;
using Manage_Tourings.Models.Touring.Plan;
using Manage_Tourings.Models.Touring.Plan.CheckPoint;
using MangeTouringsUnitTests.Helper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MangeTouringsTests
{
    public class TouringTest
    {
        [Fact]
        public void TouringオブジェクトをDBに追加できるか()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "TouringオブジェクトをDBに追加できるか")
                .Options;

            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                touringService.Add("テストツーリング", "テストです", "プランA");
            }
            using (var context = new DBContextWithValidations(options))
            {
                var resultTourings = context.Tourings.Include("Plans").ToList();
                Assert.Equal(1, context.Tourings.Count());
                Assert.Equal("テストツーリング", resultTourings[0].Title);
                Assert.Equal("テストです", resultTourings[0].Note);
                Assert.Equal("プランA", resultTourings[0].Plans[0].Title);
            }
        }

        [Fact]
        public void Touringが消されるとその配下のPlanは消される()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touringが消されるとその配下のPlanは消される")
                .Options;

            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                touringService.Add("テストツーリング", "テストです", "プランA");
            }

            using (var context = new DBContextWithValidations(options))
            {
                var resultTourings = context.Tourings.Include("Plans").ToList();
                var removingEntity = context.Tourings.FirstOrDefault(m => m.TouringId == resultTourings[0].TouringId);
                context.Tourings.Remove(removingEntity);
                context.SaveChanges();
                Assert.False(context.Plans.Any(p => p.PlanId == resultTourings[0].Plans[0].PlanId));
            }
        }

        [Fact]
        public void Touringが消されるとその配下のCheckPointは消される()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touringが消されるとその配下のPlanは消される")
                .Options;
            
            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                touringService.Add("テストツーリング", "テストです", "プランA");
                context.CheckPoints.Add(new CheckPoint
                {
                    Touring = context.Tourings.FirstOrDefault()
                });
                context.SaveChanges();
            }

            using (var context = new DBContextWithValidations(options))
            {
                var resultTourings = context.Tourings.Include("CheckPoints").ToList();
                var removingEntity = context.Tourings.FirstOrDefault(m => m.TouringId == resultTourings[0].TouringId);
                context.Tourings.Remove(removingEntity);
                context.SaveChanges();
                Assert.False(context.CheckPoints.Any(c => c.CheckPointId == resultTourings[0].CheckPoints[0].CheckPointId));
            }
        }

        [Fact]
        public void Titleが設定されていないとエラーになり登録できない()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Titleが設定されていないとエラーになり登録できない")
                .Options;

            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                try
                {
                    touringService.Add("", "テストです", "プランA");
                }
                catch { }
            }
            using (var context = new DBContextWithValidations(options))
            {
                Assert.Equal(0, context.Tourings.Count());
            }
        }
    }

    internal class TouringServices
    {
        private ManageTouringsContext _context;

        public TouringServices(ManageTouringsContext context)
        {
            _context = context;
        }

        internal void Add(string title, string note = "", string planTitle = "プランA")
        {
            var touring = new Touring
            {
                Title = title,
                Note = note,
                Plans = new List<Plan>
                {
                    new Plan { Title = planTitle }
                },
            };
            _context.Tourings.Add(touring);
            _context.SaveChanges();
        }
    }
}

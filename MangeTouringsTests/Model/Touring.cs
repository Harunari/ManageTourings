using Manage_Tourings.Models;
using Manage_Tourings.Models.Touring;
using Manage_Tourings.Models.Touring.Plan;
using MangeTouringsUnitTests.Helper;
using Microsoft.EntityFrameworkCore;
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
                var resultTourings = context.Tourings.Include("Plan").ToList();
                Assert.Equal(1, context.Tourings.Count());
                Assert.Equal("テストツーリング", resultTourings[0].Title);
                Assert.Equal("テストです", resultTourings[0].Note);
                Assert.Equal("プランA", resultTourings[0].Plan.Title);
            }
        }

        [Fact]
        public void Touringが消されるとその配下のPlanは消される()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touringが消されるとその配下のPlanは消される")
                .Options;
            // TODO
            using (var context = new DBContextWithValidations(options))
            {
                //var touringService = new TouringServices();
            }
            //Assert.
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
                catch {}
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
                Plan = new Plan { Title = planTitle }
            };
            _context.Tourings.Add(touring);
            _context.SaveChanges();
        }
    }
}

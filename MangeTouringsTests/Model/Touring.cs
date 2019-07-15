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
        public void Touring�I�u�W�F�N�g��DB�ɒǉ��ł��邩()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touring�I�u�W�F�N�g��DB�ɒǉ��ł��邩")
                .Options;

            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                touringService.Add("�e�X�g�c�[�����O", "�e�X�g�ł�", "�v����A");
            }
            using (var context = new DBContextWithValidations(options))
            {
                var resultTourings = context.Tourings.Include("Plan").ToList();
                Assert.Equal(1, context.Tourings.Count());
                Assert.Equal("�e�X�g�c�[�����O", resultTourings[0].Title);
                Assert.Equal("�e�X�g�ł�", resultTourings[0].Note);
                Assert.Equal("�v����A", resultTourings[0].Plan.Title);
            }
        }

        [Fact]
        public void Touring���������Ƃ��̔z����Plan�͏������()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touring���������Ƃ��̔z����Plan�͏������")
                .Options;
            // TODO
            using (var context = new DBContextWithValidations(options))
            {
                //var touringService = new TouringServices();
            }
            //Assert.
        }

        [Fact]
        public void Title���ݒ肳��Ă��Ȃ��ƃG���[�ɂȂ�o�^�ł��Ȃ�()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Title���ݒ肳��Ă��Ȃ��ƃG���[�ɂȂ�o�^�ł��Ȃ�")
                .Options;

            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                try
                {
                    touringService.Add("", "�e�X�g�ł�", "�v����A");
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

        internal void Add(string title, string note = "", string planTitle = "�v����A")
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

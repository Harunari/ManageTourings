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
                var resultTourings = context.Tourings.Include("Plans").ToList();
                Assert.Equal(1, context.Tourings.Count());
                Assert.Equal("�e�X�g�c�[�����O", resultTourings[0].Title);
                Assert.Equal("�e�X�g�ł�", resultTourings[0].Note);
                Assert.Equal("�v����A", resultTourings[0].Plans[0].Title);
            }
        }

        [Fact]
        public void Touring���������Ƃ��̔z����Plan�͏������()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touring���������Ƃ��̔z����Plan�͏������")
                .Options;

            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                touringService.Add("�e�X�g�c�[�����O", "�e�X�g�ł�", "�v����A");
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
        public void Touring���������Ƃ��̔z����CheckPoint�͏������()
        {
            var options = new DbContextOptionsBuilder<ManageTouringsContext>()
                .UseInMemoryDatabase(databaseName: "Touring���������Ƃ��̔z����Plan�͏������")
                .Options;
            
            using (var context = new DBContextWithValidations(options))
            {
                var touringService = new TouringServices(context);
                touringService.Add("�e�X�g�c�[�����O", "�e�X�g�ł�", "�v����A");
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

        internal void Add(string title, string note = "", string planTitle = "�v����A")
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

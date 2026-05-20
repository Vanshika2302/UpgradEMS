using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;
using System;
using System.Linq;

namespace UpGradEMS.Tests
{
    public class EventTests
    {
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new AppDbContext(options);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetAllEvents_ShouldReturnList()
        {
            
            _context.Events.Add(new EventDetails
            {
                EventId = Guid.NewGuid(),
                EventName = "Test Event",
                EventCategory = "Tech",
                EventDate = DateTime.Now
            });

            _context.SaveChanges();

            var result = _context.Events.ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void AddEvent_ShouldInsert()
        {
            var ev = new EventDetails
            {
                EventId = Guid.NewGuid(),
                EventName = "New Event",
                EventCategory = "IT",
                EventDate = DateTime.Now
            };

            _context.Events.Add(ev);
            _context.SaveChanges();

            var result = _context.Events.Find(ev.EventId);

            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteEvent_ShouldRemove()
        {
            var ev = new EventDetails
            {
                EventId = Guid.NewGuid(),
                EventName = "Delete Event",
                EventCategory = "Tech",
                EventDate = DateTime.Now
            };

            _context.Events.Add(ev);
            _context.SaveChanges();

            _context.Events.Remove(ev);
            _context.SaveChanges();

            var result = _context.Events.Find(ev.EventId);

            Assert.IsNull(result);
        }
    }
}
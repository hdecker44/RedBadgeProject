﻿using RedBadge.Data;
using RedBadge.Models;
using RedBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Service
{
    public class VenueService
    {
        private readonly Guid _userId;
        public VenueService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateVenue(VenueCreate model)
        {
            var entity =
                new Venue()
                {
                    OwnerId = _userId,
                    VenueName = model.VenueName,
                    StreetNumber = model.StreetNumber,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    NumberOfVIP = model.NumberOfVIP,
                    NumberOfGA = model.NumberOfGA
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Venues
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new VenueListItem
                                {
                                    VenueId = e.VenueId,
                                    VenueName = e.VenueName,
                                    City = e.City,
                                    NumberOfVIP = e.NumberOfVIP,
                                    NumberOfGA = e.NumberOfGA
                                }
                        );

                return query.ToArray();
            }
        }
        public VenueDetails GetVenueById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueId == id && e.OwnerId == _userId);
                return
                    new VenueDetails
                    {
                        VenueId = entity.VenueId,
                        VenueName = entity.VenueName,
                        StreetNumber = entity.StreetNumber,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        NumberOfSeats = entity.NumberOfSeats,
                        NumberOfVIP = entity.NumberOfSeats,
                        NumberOfGA = entity.NumberOfGA
                    };
            }
        }
        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueId == model.VenueId && e.OwnerId == _userId);

                entity.VenueId = model.VenueId;
                entity.VenueName = model.VenueName;
                entity.StreetNumber = model.StreetNumber;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.NumberOfVIP = model.NumberOfVIP;
                entity.NumberOfGA = model.NumberOfGA;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteVenue(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueId == venueId && e.OwnerId == _userId);

                ctx.Venues.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
﻿namespace ReservationAPI.Models.Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }

}

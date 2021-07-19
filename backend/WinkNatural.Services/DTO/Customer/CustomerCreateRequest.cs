﻿using System;

namespace WinkNatural.Services.DTO.Customer
{
    public class CustomerCreateRequest
    {
        public string InsertEnrollerTree { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool CanLogin { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string CustomerType { get; set; }
        public string CustomerStatus { get; set; }
        public string EntryDate { get; set; }
        public string DefaultWarehouseID { get; set; }
        public string CurrencyCode { get; set; }
        public string LanguageID { get; set; }
        public int EnrollerID { get; set; }
        public string MainCountry { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

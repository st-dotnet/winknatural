﻿namespace WinkNatural.Services.DTO.Customer
{
    public class CustomerCreateResponse
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string Token { get; set; } 
        public string ErrorMessage { get; set; } 
    }
}

﻿namespace MyCv.Application.CQRS.DTO
{
    public class GetClientResult
    {
        
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Address { get;  set; }
        public string Email { get;  set; }
        

       
    }

}

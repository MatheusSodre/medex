﻿using Medex.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Models
{
    
    public class UserModel 
    {
        public long Id { get; set; }

        
        public string UserName { get; set; }

        
        public string  FullName { get; set; }

        
        public string Password  { get; set; }

        
        public string RefreshToken { get; set; }

        
        public DateTime RefreshTokenExperyTime { get; set; }

    }
}

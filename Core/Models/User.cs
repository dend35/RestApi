using System;
using Common.Enum;
using Core.Base;

namespace Core.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public Score Score { get; set; }
    }
}
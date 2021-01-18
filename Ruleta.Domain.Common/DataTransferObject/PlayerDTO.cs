using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class PlayerDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public float Balance { get; set; }

        public PlayerDTO() 
        {
            Id = 0;
            FirstName = string.Empty;
            Surname = string.Empty;
            Balance = 0f;
        }

        public PlayerDTO(long id, string firstName, string surname, float balance)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Balance = balance;
        }
    }
}

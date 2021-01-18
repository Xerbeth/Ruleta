using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ruleta.Domain.Common.Models
{
    public class PlayerModel
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public long DocumentTypeId { get; set; }
        [Required]
        public string Document { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion

        #region Methods
        public PlayerModel() { }

        public PlayerModel(long id, string firstName, string secondName, string surname, string secondSurname, DateTime birthdate, long documentTypeId, string document, DateTime creationDate, bool? state)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            SecondName = secondName;
            Birthdate = birthdate;
            DocumentTypeId = documentTypeId;
            Document = document;
            State = (state == null) ? false: true;
            CreationDate = creationDate;
        }
        #endregion
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Ruleta.Domain.Common.Models
{
    public class DocumentTypeModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        public DocumentTypeModel() { } 
        public DocumentTypeModel( long id, string name, string code, bool state, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Code = code;
            State = state;
            CreationDate = creationDate;
        }
    }
}

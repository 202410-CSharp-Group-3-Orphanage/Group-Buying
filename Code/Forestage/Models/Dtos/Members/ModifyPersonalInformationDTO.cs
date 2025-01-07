using System.ComponentModel.DataAnnotations;

namespace Forestage.Models.Dtos.Members
{
    public class ModifyPersonalInformationDTO
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }


        public DateTime Birthday { get; set; }
    }
}

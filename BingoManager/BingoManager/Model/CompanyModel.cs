using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BingoManager.Modelo
{
    public class CompanyModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome deve ter de 5 a 30 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nome para Cartela é obrigatório.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome para Cartela deve ter de 5 a 30 caracteres.")]
        public string CardName { get; set; }

        //[EmailAddress]
        public string Email { get; set; }

        //[Phone]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Logo é obrigatório.")]
        public string Logo { get; set; }

    }
}

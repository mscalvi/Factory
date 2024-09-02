using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BingoManager.Modelo
{
    public class ListModel
    {
        public int Id { get ; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength (30, MinimumLength = 5, ErrorMessage = "Nome deve ter de 5 a 30 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Descrição deve ter de 5 a 500 caracteres.")]
        public string Description { get; set; }

    }
}

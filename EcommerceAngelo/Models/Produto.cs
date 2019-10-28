using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAngelo.Models
{
    //Anotations ASP.NET Core  
    [Table("Produtos")]
    public class Produto
    {
        public Produto() { CriadoEm = DateTime.Now; }
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do Produto:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]  // este campo será obrigatório o preenchimento
        public string Nome { get; set; }

        [Display(Name = "Nome da Descrição:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]   
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "No maximo 100 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Range(1,1000, ErrorMessage = "Somente valores de 1 a 1000")]
        public int? Quantidade { get; set; }

        [Display(Name = "Preço do Produto:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public double Preco { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}

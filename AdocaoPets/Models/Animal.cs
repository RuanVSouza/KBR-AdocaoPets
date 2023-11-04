    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Numerics;

    namespace AdocaoPets.Models;

    public class Animal 
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        //Desconsiderando no DB pois não consigo integrar imagens com MySQL
        [NotMapped]
        [Required(ErrorMessage = "A Galeria de imagens é obrigatória.")]
        [DisplayName("Galeria de Imagens")]
        public ICollection<IFormFile> GaleriaImagens { get; set; }

        [Required(ErrorMessage = "O campo Espécie é obrigatório.")]
        public string Especie { get; set; }

        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("asp-for")]
        [Required(ErrorMessage = "O campo Raça é obrigatório.")]
        [DisplayName("Raça")]
        public string Raca { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório.")]
        public int Idade { get; set; }

        public double? Peso { get; set; }

        [Required(ErrorMessage = "O campo Porte é obrigatório.")]
        public string Porte { get; set; }

        [Required(ErrorMessage = "O campo Local é obrigatório.")]
        public string Local { get; set; }

        // Sobre o pet (inserir o editor de texto Ckeditor)
        public string SobreOPet { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        public Status Status { get; set; }

        public string Genero { get; set; }
        
        public Animal(){}

        public Animal(int codigo, string nome,string especie, string raca, int idade, double? peso, string porte, string local, string sobreOPet, Status status,String genero )
        {
            Codigo = codigo;
            Nome = nome;
            Especie = especie;
            Raca = raca;
            Idade = idade;
            Peso = peso;
            Porte = porte;
            Local = local;
            SobreOPet = sobreOPet;
            Status = status;
            Genero = genero;
        }

       
    }
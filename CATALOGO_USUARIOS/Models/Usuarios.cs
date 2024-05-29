//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CATALOGO_USUARIOS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;



    public partial class Usuarios
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]

        public string Nombre { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        [StringLength(50, ErrorMessage = "El correo no puede tener más de 50 caracteres.")]
        public string Correo { get; set; }

        [Display(Name = "Contraseña")]
        //[Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre  8 y 10 caracteres.")]
        public string Contrasena { get; set; }

        [Display(Name = "CURP")]
        [Required(ErrorMessage = "La CURP es obligatoria.")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "La CURP debe tener exactamente 18 caracteres.")]
        public string Curp { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "La edad es obligatoria.")]
        public int Edad { get; set; }

        [Display(Name = "Género")]
        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Genero { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El rol es obligatorio.")]
        public int IdRol { get; set; }

        
        public bool IsDeleted { get; set; } = false;

        public virtual Roles Roles { get; set; }

        public IEnumerable<Roles> AvailableRoles { get; set; }
    }

    public class ExactLengthAttribute : ValidationAttribute
    {
        private readonly int _exactLength;

        public ExactLengthAttribute(int exactLength)
        {
            _exactLength = exactLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value as string;
            if (str != null && str.Length != _exactLength)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}

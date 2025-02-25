using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace HW02.Models
{
	public class Regis
	{
		[Key]
		[Required(ErrorMessage = "Enter Email")]
		public string? Email { get; set; }
		[Required(ErrorMessage = "Enter Username")]
		public string? Username { get; set; }
		[Required(ErrorMessage = "Enter Password")]
		public string? Password { get; set; }
		[Compare("Password", ErrorMessage = "Password Don't Match")]
		[Required(ErrorMessage = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
		[Required(ErrorMessage = "Enter Phone Number")]
		public string? Phone {  get; set; }
		[Required(ErrorMessage = "Please Upload Image")]
		[Display(Name = "Image")]
		public IFormFile? Image { get; set; }
		[Required(ErrorMessage = "Please Select Your Gender")]
		[Display(Name = "Gender")]
		public string? Gender { get; set; }
	}
}

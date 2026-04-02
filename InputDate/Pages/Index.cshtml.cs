using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InputDate.Pages
{
    public class IndexModel : PageModel
    {
        public string _name { get; set; }
        public int _age { get; set; }
        public string _AdditionalInfo { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }
        public string _error { get; set; }
        

        public void OnGet()
        {

            
        }
        public void OnPost() 
        {
            _name = Request.Form["name"];
            _AdditionalInfo = Request.Form["additional_info"];
            _password = Request.Form["password"];
            _email = Request.Form["email"];
            if (string.IsNullOrEmpty(_name) || !Char.IsLetter(_name, 0))
            {
                _error = "Введите корректное имя";
                return;
            }
            if (!int.TryParse(Request.Form["age"], out int age)) 
            {
                _error = "Возраст должен быть числом";
                return;
            }
            if (string.IsNullOrEmpty(_email))
            {
                _error = "Введите корректный Email";
                return;
            }
            if (string.IsNullOrEmpty(_password) || _password.Length < 6)
            {
                _error = "Введите корректный пароль, минимум 6 символов";
                return;
            }
            _age = age;
        }
    
    }
}

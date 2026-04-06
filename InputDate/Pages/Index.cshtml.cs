using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InputDate.Pages
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string AdditionalInfo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string whatFind { get; set; }

        [BindProperty]
        public string _name { get; set; }
        [BindProperty]
        public int _age { get; set; }
        [BindProperty]
        public string _AdditionalInfo { get; set; }
        [BindProperty]
        public string _email { get; set; }
        [BindProperty]
        public string _password { get; set; }
        public string _error { get; set; }

        public static List<Human> Humans = new List<Human>();

        public static List<Human> HumansFiltred = new List<Human>();
        public void OnGet()
        {
            
        }

        public void what_find_click()
        {
            foreach(Human human in Humans)
            {
                if(human.Name.Contains(whatFind))
                {
                    HumansFiltred.Add(human);
                }
            }
        }

        public void OnPostDelete(int index)
        {
            if (index >= 0 && index < Humans.Count) 
            {
                Humans.RemoveAt(index);
            }
        }
        public void OnPostAdd() 
        {
            if (string.IsNullOrEmpty(_name) || !Char.IsLetter(_name, 0))
            {
                _error = "Введите корректное имя";
                return;
            }
            if (_age < 0)
            {
                _error = "Возраст должен быть больше нуля";
                return;
            }
            if (string.IsNullOrEmpty(_email))
            {
                _error = $"email: {_email}";
                return;
            }
            if (string.IsNullOrEmpty(_password) || _password.Length < 6)
            {
                _error = "Введите корректный пароль, минимум 6 символов";
                return;
            }
            Humans.Add(new Human
            {
                Name = _name,
                Age = _age,
                AdditionalInfo = _AdditionalInfo,
                Email = _email
            });
        }
    
    }
}

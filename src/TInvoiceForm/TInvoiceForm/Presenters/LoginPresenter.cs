using TInvoiceForm.Database;
using TInvoiceForm.Views.Interfaces;

namespace TInvoiceForm.Presenters
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private readonly CustomerRepository _customerRepository;
        public LoginPresenter(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void SetView(ILoginView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        private string ValidateUsername()
        {
            if (string.IsNullOrEmpty(_view.Username))
                return "Username is required";
            if (_view.Username.Length <= 6)
                return "Username must be greater than 6 characters";
            //TODO 
            // Check password is unique??
            return "";
        }
        private string ValidatePassword()
        {
            if (string.IsNullOrEmpty(_view.Password))
                return "Password is required";
            if (_view.Password.Length <= 6)
                return "Password must be greater than 6 characters";
            return "";
        }
        private string GetPasswordHash()
        {
            //TODO
            return _view.Password;
        }
        public bool OnLogin()
        {
            _view.UsernameErrorMessage = ValidateUsername();
            _view.PasswordErrorMessage = ValidatePassword();
            if(string.IsNullOrEmpty(_view.UsernameErrorMessage) && string.IsNullOrEmpty(_view.PasswordErrorMessage))
            {

                if (_view.Username == "tthanhphong" && _view.Password == "12345678x@X")
                {
                    _view.LoginMessage = string.Empty;
                    return true;
                }
            }
            _view.LoginMessage = "Username or password is not correct.";
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Presenters;

namespace TInvoiceForm.Views.Interfaces
{
    public interface ILoginView
    {
        string Username { get; set; }
        string UsernameErrorMessage { get; set; }
        string Password { get; set; }
        string PasswordErrorMessage { get; set; }
        string LoginMessage { get; set; }
        bool RememberMe { get; set; }
        LoginPresenter Presenter { get; set; }
    }
}

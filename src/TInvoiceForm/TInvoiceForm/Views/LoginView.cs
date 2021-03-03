using System;
using System.Net.Http.Headers;
using System.Windows.Forms;
using TInvoiceForm.Presenters;
using TInvoiceForm.Views.Interfaces;

namespace TInvoiceForm.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public LoginPresenter Presenter { get; set; } = ServiceLocator.GetService<LoginPresenter>();
        private ErrorProvider errorProvider = new ErrorProvider();
        public LoginView()
        {
            InitializeComponent();
            Presenter.SetView(this);
        }
        public string Username 
        {
            get => txtUsername.Text;
            set => txtUsername.Text = value;
        }
        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }
        public bool RememberMe
        {
            get => ckbRememberMe.Checked;
            set => ckbRememberMe.Checked = value;
        }

        private string _usernameErrorMessage;
        public string UsernameErrorMessage
        {
            get => _usernameErrorMessage;
            set
            {
                _usernameErrorMessage = value;
                errorProvider.SetError(txtUsername, value);
            }
        }

        private string _passwordErrorMessage;
        public string PasswordErrorMessage
        {
            get => _passwordErrorMessage;
            set
            {
                errorProvider.SetError(txtPassword, value);
                _passwordErrorMessage = value;
            }
        }

        private string _loginErrorMessage;
        public string LoginMessage
        {
            get => _loginErrorMessage;
            set
            {
                _loginErrorMessage = value;

                if (!string.IsNullOrEmpty(_loginErrorMessage))
                    MessageBox.Show(LoginMessage, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(Presenter.OnLogin())
            {
                MessageBox.Show("Login success", "Login success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}

using QUANLICAPHE.View;
using QUANLICAPHE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QUANLICAPHE.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                IsLoaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginView LoginWindow = new LoginView();
                LoginWindow.ShowDialog();

                if (LoginWindow.DataContext == null)
                    return;
                var loginVM = LoginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            }
              );
        }
    }
}
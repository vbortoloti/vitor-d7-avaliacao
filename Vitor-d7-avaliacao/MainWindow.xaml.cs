using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vitor_d7_avaliacao.Data;

namespace Vitor_d7_avaliacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private readonly Context context;
        User user = new User { Username="os"};

        public MainWindow(Context context)
        {
            this.context = context;
            InitializeComponent();
            UserGrid.DataContext = user;
        }

        private void RequestLogin(object sender, RoutedEventArgs e)
        {
            var user = context.Users.Where(u => u.Username == UserBox.Text && u.Password == PasswordBox.Password).FirstOrDefault<User>();
            if (user == null) { MessageBox.Show("Usuário não encontrado"); return; }
            CheckUsername(user.Username);
        }

        private void CheckUsername(string? username)
        {
            if (username == UserBox.Text)
            {
                MessageBox.Show("Usuário autenticado");
            }
            else
            {
                MessageBox.Show("Credenciais inválidas");
            }
        }
    }
}

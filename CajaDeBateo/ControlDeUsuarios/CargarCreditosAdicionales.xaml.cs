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

namespace CajaDeBateo.ControlDeUsuarios
{
    /// <summary>
    /// Interaction logic for CargarCreditosAdicionales.xaml
    /// </summary>
    public partial class CargarCreditosAdicionales : UserControl
    {
        private String AuxPerm = "";
        private String AuxTem = "";

        public CargarCreditosAdicionales()
        {
            InitializeComponent();
        }

        private void BtnCancelarCreditosAdicionales_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Win = (MainWindow)Window.GetWindow(this);
            Win.RegresarPantallaInicial();
        }

        private void CantidadCreditosAdicionales_TextChanged(object sender, TextChangedEventArgs e)
        {
            AuxTem = CantidadCreditosAdicionales.Text;
            if (EsNumCorrecto(AuxTem) || CantidadCreditosAdicionales.Text.Length == 0)
            {
                AuxPerm = AuxTem;
            }
            else
            {
                CantidadCreditosAdicionales.Text = AuxPerm;
                CantidadCreditosAdicionales.CaretIndex = CantidadCreditosAdicionales.Text.Length;
            }

            BtnGuardarCargarCreditosAdicionales.IsEnabled = (CantidadCreditosAdicionales.Text.Length > 0);
        }

        private bool EsNumCorrecto(String Cadena)
        {
            int n = 0;
            bool EsNumero = int.TryParse(Cadena, out n);
            return (EsNumero && n > 0 && n <= 2147483647);
        }

        private void BtnGuardarCargarCreditosAdicionales_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

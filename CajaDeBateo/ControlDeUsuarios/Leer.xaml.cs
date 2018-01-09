using CajaDeBateo.ComunicacionArduino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para Leer.xaml
    /// </summary>
    public partial class Leer : UserControl
    {
        ArduinoComunication arduino;
        string info;
        Label aux;
        public Leer(ref ArduinoComunication arduino)
        {
            InitializeComponent();
            this.arduino = arduino;
            //arduino.Reset();
            arduino.RespuestaRecivida += new EventHandler(Read);
            aux = lblID;
            arduino.Write("2");
            lblDato.Content = "Pase la tarjeta";
        }
        string data;
        private void Read(object sender, EventArgs e)
        {
            data = (string)sender;
            lblDato.Dispatcher.Invoke(new Action(() => { lblDato.Content = data; }));
        }
    }
}

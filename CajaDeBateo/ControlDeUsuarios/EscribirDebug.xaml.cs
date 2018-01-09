using CajaDeBateo.ComunicacionArduino;
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
    /// Lógica de interacción para EscribirDebug.xaml
    /// </summary>
    public partial class EscribirDebug : UserControl
    {
        Random random = new Random();
        int id;
        ArduinoComunication arduino;
        bool escribirID = false;
        bool leer = false;
        public EscribirDebug(ref ArduinoComunication arduino)
        {
            InitializeComponent();
            escribirID = false;
            leer = false;
            this.arduino = arduino;
            //arduino.Reset();
            arduino.RespuestaRecivida += new EventHandler(Read);
            id = random.Next(0, 50000);
            lblID.Content = "ID" + id.ToString();
            arduino.Write("1");
        }

        private void Read(object sender, EventArgs e)
        {
            string data = (string)sender;
            if(!escribirID)
            {
                lblDato.Dispatcher.Invoke(new Action(() => { lblDato.Content = "Enviando dato"; })); 
                arduino.Write(id.ToString()+"#");
                escribirID = true;
            }
            else if(!leer)
            {
                lblDato.Dispatcher.Invoke(new Action(() => { lblDato.Content = "Pase tarjeta"; }));
                leer = true;
            }
            else
            {
                lblDato.Dispatcher.Invoke(new Action(() => { lblDato.Content = "Bienvenido"; }));
            }
        }
    }
}

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


namespace TeoriaDeColas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double miu = 0, lamda = 0, jornada=0;
        double Ls = 0, Lq, Ws = 0, Wq = 0, P0 = 0, P = 0, no=0;
        double resta = 0;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                miu = Convert.ToDouble(textboxPromedioAtencion.Text);
                lamda = Convert.ToDouble(textboxPromedioLlegada.Text);
                if (miu>lamda)
                {                   
                    jornada = Convert.ToDouble(textboxJornada.Text);
                    resta = miu - lamda;
                    Ls = lamda / resta;
                    Ws = 1 / resta;
                    Lq = Math.Pow(lamda, 2) / (miu * resta);
                    if ((Math.Round(Lq, 2) - Math.Round(Lq, 0) > 0.55))
                        Lq = Math.Round(Lq, 0) + 1;
                    else
                        Lq = Math.Round(Lq, 0);

                    Wq = lamda / (miu * resta);
                    Wq = Wq * 60;



                    P = lamda / miu;
                    P0 = 1 - P;
                    P = jornada * P;
                    P0 = P0 * 100;
                    no = jornada - P;

                    LsLabel.Content = "Numero promedio de unidades en el sistema: " + Math.Round(Ls, 2) + " unidades";
                    WsLabel.Content = "Tiempo medio que unidad pasa en el sistema: " + Math.Round(Ws, 2) + " horas";
                    LqLabel.Content = "Numero medio de unidades esperando en la cola: " + Lq + " unidades";

                    if (Wq < 60)
                        WqLabel.Content = "Tiempo medio que una unidad pasa esperando en la cola: " + Math.Round(Wq, 2) + " minutos";
                    else
                        WqLabel.Content = "Tiempo medio que una unidad pasa esperando en la cola: " + (Wq / 60) + " horas";

                    PLabel.Content = "Factor de utilizacion del sistema: " + Math.Round(P, 2) + " horas de las " + jornada;
                    P0Label.Content = "Probabilidad de que halla 0 unidades en el sistema: " + Math.Round(P0, 2) + "%";
                    noLabel.Content = "Factor de no utilizacion del sistema: " + Math.Round(no, 0) + " horas de las " + jornada;
                }
                else
                {
                    MessageBox.Show("El promedio de atencion debe ser mayor al promedio de llegadas");
                }
                
            }
            catch (Exception error)
            {

                MessageBox.Show("Rellene bien los campos ");
            }
                

        }
    }
}

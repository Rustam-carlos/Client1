using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Client1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 12345; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        static int flag = 0;
        static string message;
        static string answer;
        static byte[] buf = new byte[1024];
        static string content = "X";
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);               
                    // подключаемся к удаленному хосту
                socket.Connect(ipPoint);

                message = flag.ToString();
                buf = Encoding.Unicode.GetBytes(message);
                socket.Send(buf);
                

                // получаем ответ
                buf = new byte[256]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт

                    do
                    {
                        bytes = socket.Receive(buf, buf.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(buf, 0, bytes));
                    }
                    while (socket.Available > 0);
                    answer = builder.ToString();
                //Console.WriteLine("ответ сервера: " + builder.ToString());
                if (answer == "1")
                {
                    Button1.Content = content;
                    Button1.IsEnabled = false;
                }
                else if (answer == "2")
                {
                    Button2.Content = content;
                    Button2.IsEnabled = false;
                }
                else if (answer == "3")
                {
                    Button3.Content = content;
                    Button3.IsEnabled = false;
                }
                else if (answer == "4")
                {
                    Button4.Content = content;
                    Button4.IsEnabled = false;
                }
                else if (answer == "5")
                {
                    Button5.Content = content;
                    Button5.IsEnabled = false;
                }
                else if (answer == "6")
                {
                    Button6.Content = content;
                    Button6.IsEnabled = false;
                }
                else if (answer == "7")
                {
                    Button7.Content = content;
                    Button7.IsEnabled = false;
                }
                else if (answer == "8")
                {
                    Button8.Content = content;
                    Button8.IsEnabled = false;
                }
                else if (answer == "9")
                {
                    Button9.Content = content;
                    Button9.IsEnabled = false;
                }
                               
                // закрываем сокет
                //socket.Shutdown(SocketShutdown.Both);
                //socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button1.Content = "O";
            flag = 1;
            Button1.IsEnabled = false;
        }
    }
}

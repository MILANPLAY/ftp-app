using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
namespace FTP_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task RefreshDevices(int Port)
        {
            List<IPEndPoint> list = await NetworkDiscovery.ListenUDP(Port);
            foreach (var item in list)
            {
                Button buttonAddLabel = new Button
                {
                    Text = $"{item.Address}",
                    Dock = DockStyle.Top,
                    Size = new Size(140, 48),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                Device_List.Controls.Add(buttonAddLabel);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            RefreshDevices(64000);
        }


    }

}

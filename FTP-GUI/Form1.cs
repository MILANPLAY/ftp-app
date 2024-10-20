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
                    FlatStyle = FlatStyle.Flat,
                };
                buttonAddLabel.Click += DeviceSelect;
               

                Device_List.Controls.Add(buttonAddLabel);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await RefreshDevices(64000);

        }

        private void Device_InfoL_Click(object sender, EventArgs e)
        {

        }

        private void DeviceSelect(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                Device_InfoL.Text = $"Name: {NetworkUtility.GetHostNameFromIP(clickedButton.Text)}\nIP: {clickedButton.Text}\nPlatform: {null}\nOS: {0}";
            }
        }


    }

}

using System.Drawing.Imaging;
using System.Net.Sockets;

namespace client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream mainStream;
        private int portNumber;

        public Form1()
        {
            InitializeComponent();
        }

        private static byte[] CaptureDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    screenshot.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        private void TransmitDesktopImage()
        {
            if (client != null && client.Connected)
            {
                mainStream = client.GetStream();
                byte[] imageBytes = CaptureDesktop();
                mainStream.Write(BitConverter.GetBytes(imageBytes.Length), 0, 4);
                mainStream.Write(imageBytes, 0, imageBytes.Length);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btShare.Enabled = false;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(tbPort.Text);
            client = new TcpClient();
            try
            {
                client.Connect(tbIP.Text, portNumber);
                btConnect.Text = "Connected";
                MessageBox.Show("Connected");
                btConnect.Enabled = false;
                btShare.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect..");
                btConnect.Text = "Not Connected";
            }
        }

        private void btShare_Click(object sender, EventArgs e)
        {
            if (btShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btShare.Text = "Stop Sharing";
            }
            else
            {
                timer1.Stop();
                btShare.Text = "Share My Screen";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TransmitDesktopImage();
        }
    }
}

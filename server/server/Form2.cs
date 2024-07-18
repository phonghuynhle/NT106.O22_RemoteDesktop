using System.Net;
using System.Net.Sockets;
namespace server
{
    public partial class Form2 : Form
    {
        private int port;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream mainStream;
        private Thread listeningThread;
        private Thread receivingThread;

        public Form2(int Port)
        {
            InitializeComponent();
            port = Port;
            listeningThread = new Thread(StartListening);
            receivingThread = new Thread(ReceiveImage);
        }

        private void StartListening()
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            client = server.AcceptTcpClient();
            receivingThread.Start();
        }

        private void StopListening()
        {
            if (server != null)
            {
                server.Stop();
                server = null;
            }
            if (client != null)
            {
                client.Close();
                client = null;
            }
            if (listeningThread.IsAlive)
                listeningThread.Abort();
            if (receivingThread.IsAlive)
                receivingThread.Abort();
        }

        private void ReceiveImage()
        {
            while (client != null && client.Connected)
            {
                try
                {
                    mainStream = client.GetStream();
                    byte[] lengthBytes = new byte[4];
                    mainStream.Read(lengthBytes, 0, 4);
                    int imageLength = BitConverter.ToInt32(lengthBytes, 0);

                    byte[] imageBytes = new byte[imageLength];
                    int bytesRead = 0;
                    while (bytesRead < imageLength)
                    {
                        int read = mainStream.Read(imageBytes, bytesRead, imageLength - bytesRead);
                        if (read == 0) break;
                        bytesRead += read;
                    }

                    if (bytesRead == imageLength)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            listeningThread.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListening();
        }
    }
}

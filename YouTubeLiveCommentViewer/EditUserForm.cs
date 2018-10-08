using System.Diagnostics;
using System.Windows.Forms;

namespace YouTubeLiveCommentViewer
{
    public partial class EditUserForm : Form
    {
        public EditUserForm(string channelName, string channelId, string name)
        {
            InitializeComponent();
            _channelName = channelName;
            _channelId = channelId;
            SetName = name;

            linkLabel1.Text = _channelName;
            linkLabel1.Click += (s, e) =>
                Process.Start("https://www.youtube.com/channel/" + _channelId);
            textBox1.Text = SetName;
        }
        private string _channelName;
        private string _channelId;
        internal string SetName { get => this.textBox1.Text; private set => this.textBox1.Text = value; }
    }
}

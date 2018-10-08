using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Settings = YouTubeLiveCommentViewer.Properties.Settings;

namespace YouTubeLiveCommentViewer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            //読み込み処理
            this.fontLabel.Font = Settings.Default.font;
            this.normalSample.BackColor = Settings.Default.normalBack;
            this.normalSample.ForeColor = Settings.Default.normalFore;
            this.modSample.BackColor = Settings.Default.moderatorBack;
            this.modSample.ForeColor = Settings.Default.moderatorFore;
            this.ownerSample.BackColor = Settings.Default.ownerBack;
            this.ownerSample.ForeColor = Settings.Default.ownerFore;
            this.sponserSample.BackColor = Settings.Default.sponserBack;
            this.sponserSample.ForeColor = Settings.Default.sponserFore;
            
            //変更処理
            button1.Click += (sender, args) => {
                var fd = new FontDialog {
                    Font =  this.fontLabel.Font,
                    ShowApply = false,
                    ShowColor = false,
                    MaxSize = 18
                };
                if (fd.ShowDialog() != DialogResult.OK) return;
                this.fontLabel.Font = fd.Font;
            };

            this.button2.Click += (sender, args) => {
                var cd = new ColorDialog {AllowFullOpen = true, AnyColor = true, Color = this.normalSample.BackColor};
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.normalSample.BackColor = cd.Color;
            };
            this.button3.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.ownerSample.BackColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.ownerSample.BackColor = cd.Color;
            };
            this.button4.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.modSample.BackColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.modSample.BackColor = cd.Color;
            };
            this.button10.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.sponserSample.BackColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.sponserSample.BackColor = cd.Color;
            };

            this.button5.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.normalSample.ForeColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.normalSample.ForeColor = cd.Color;
            };
            this.button6.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.ownerSample.ForeColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.ownerSample.ForeColor = cd.Color;
            };
            this.button7.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.modSample.ForeColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.modSample.ForeColor = cd.Color;
            };
            this.button8.Click += (sender, args) => {
                var cd = new ColorDialog { AllowFullOpen = true, AnyColor = true, Color = this.sponserSample.ForeColor };
                if (cd.ShowDialog() != DialogResult.OK) return;
                this.sponserSample.ForeColor = cd.Color;
            };

            this.OKButton.Click += (s, e) => {
                //保存処理
                Settings.Default.font = this.fontLabel.Font;
                Settings.Default.normalBack = this.normalSample.BackColor;
                Settings.Default.normalFore = this.normalSample.ForeColor;
                Settings.Default.moderatorBack = this.modSample.BackColor;
                Settings.Default.moderatorFore = this.modSample.ForeColor;
                Settings.Default.ownerBack = this.ownerSample.BackColor;
                Settings.Default.ownerFore = this.ownerSample.ForeColor;
                Settings.Default.sponserBack = this.sponserSample.BackColor;
                Settings.Default.sponserFore = this.sponserSample.ForeColor;

                DialogResult = DialogResult.OK;
            };

        }

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;

namespace YouTubeLiveCommentViewer
{
    public partial class KotehansForm : Form
    {
        internal KotehansForm(IDictionary<string, string> dict)
        {
            InitializeComponent();
            foreach (var e in dict) 
                this.dataGridView1.Rows.Add(e.Key, e.Value);
            
        }

        internal Dictionary<string, string> Values =>
            this.dataGridView1.Rows.Cast<DataGridViewRow>()
                .ToDictionary(x => x.Cells[0].Value as string, x => x.Cells[1].Value as string);
    }
}

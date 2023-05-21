using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Photo_EF_Prog.FolderModelEF;

namespace Photo_EF_Prog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModelEF model = new ModelEF();
            dataGridView1.DataSource = model.Student.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2AddData form2 = new Form2AddData();
            form2.Show();
            Hide();
        }
    }
}

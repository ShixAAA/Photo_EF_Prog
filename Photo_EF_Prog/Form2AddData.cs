﻿using System;
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
    public partial class Form2AddData : Form
    {
        public Form2AddData()
        {
            InitializeComponent();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nametextBox.Text) || String.IsNullOrWhiteSpace(grouptextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (pictureBox1.Image == null) 
            {
                MessageBox.Show("Не задан файл с фотографией!");
                return;
            }
            ModelEF model = new ModelEF();
            Student student = new Student();
            student.Name = nametextBox.Text;
            student.Group_ = grouptextBox.Text;

            byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            student.Photo = bImg;

            model.Student.Add(student);

            try 
            {
                model.SaveChanges();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Сохранено");
            nametextBox.Text = "";
            grouptextBox.Text = "";
            pictureBox1.Image = null;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото сотрудника";
            ofd.Filter = "Файлы JPG, PNG|*.jpg; *.png|Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}

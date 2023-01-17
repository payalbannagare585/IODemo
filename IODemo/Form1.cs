using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IODemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string path = @"C:\SkillMineDoc";
            try
            {
                if(Directory.Exists(path))
                {
                    MessageBox.Show("Directory id already exists");

                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory Created.");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string path = @"C:\SkillMineDoc\TextDemo.txt";
            try
            {
                if(File.Exists(path))
                {
                    MessageBox.Show("File is already exists.");

                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File is created.");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            string path = @"C:\SkillMineDoc\TextDemo.txt";
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    MessageBox.Show("File has been removed");
                }
                else
                {
                    MessageBox.Show("File not found");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs=new FileStream(@"C:\SkillMineDoc\emp.dat",FileMode.Create,FileAccess.Write);  
                BinaryWriter bw=new BinaryWriter(fs);   
                bw.Write(Convert.ToInt32(txtId.Text));
                bw.Write(txtName.Text);
                bw.Write(Convert.ToDouble(txtSalary.Text));
                bw.Close();
                fs.Close();
                MessageBox.Show("Data Saved to File....");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\SkillMineDoc\emp.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtSalary.Text = br.ReadDouble().ToString();
                br.Close();
                fs.Close();
            }catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

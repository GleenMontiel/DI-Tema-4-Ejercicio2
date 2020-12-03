using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Seguro?", "Ejercicio2", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                    this.Close();
            }
        }

        public bool ComprobarRango(int n)
        {
            if(n < 256 && n >= 0)
            {
                return true;
            }
            return false;
        }

        public void CambiarColorFondo()
        {
            Color c;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    int r = int.Parse(textBox1.Text);
                    int g = int.Parse(textBox2.Text);
                    int b = int.Parse(textBox3.Text);
                    if (ComprobarRango(r) && ComprobarRango(g) && ComprobarRango(b))
                    {
                        c = Color.FromArgb(r, g, b);
                        this.BackColor = c;
                    }
                    else
                    {
                        MessageBox.Show("Introduce números en el rango 0 - 255", "Ejercicio2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Introduce números en el rango 0 - 255", "Ejercicio2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Calma", "Ejercicio2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CambiarColorFondo();
        }

        public void MostrarImagen()
        {
            string ruta = textBox4.Text;
            if (File.Exists(ruta))
            {
                try
                {
                    Image img = Image.FromFile(ruta);
                    label5.Size = new Size(img.Width, img.Height);
                    label5.Image = img;

                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarImagen();
        }



        private void Button_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Aqua;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = DefaultBackColor;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MostrarImagen();
            }
        }

        private void txtRgb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CambiarColorFondo();
            }
        }
    }
}

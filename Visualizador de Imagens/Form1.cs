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

namespace Visualizador_de_Imagens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] aqruivos  = Directory.GetFiles(@"C:\windows\web\Wallpaper","*.jpg",SearchOption.AllDirectories);
            ImagemListBox1.Items.AddRange(aqruivos);

            string path = obterNomeArquivoConfiguracao();

            if (File.Exists(path))
            {
                //Ler do arquivos favoritos
               
                var reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    string arquivos = reader.ReadLine();
                    favoritosListBox1.Items.Add(arquivos);
                }
            }

           

        }

        private void ImagemListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = ImagemListBox1.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void favoritosListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = favoritosListBox1.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private string obterNomeArquivoConfiguracao()
        {
            var pasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string arquivo = "imagensConfig.txt";
            string path = Path.Combine(pasta, arquivo);
            return path;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            favoritosListBox1.Items.Add(ImagemListBox1.Text);
            gravaConfiguracao();

        }

        private void gravaConfiguracao()
        {

            // Gravar

            string path = obterNomeArquivoConfiguracao();
            var whriter = new StreamWriter(path);
            foreach (string arquivos in favoritosListBox1.Items)
            {
                whriter.WriteLine(arquivos);
            }
            whriter.Close();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            if (favoritosListBox1.SelectedItem != null)
            {
                string itemSelecionado = favoritosListBox1.SelectedItem.ToString();
                favoritosListBox1.Items.Remove(itemSelecionado);
                gravaConfiguracao();
            }
        }
    }
}

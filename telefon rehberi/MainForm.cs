/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: abuzer
 * Tarih: 26.7.2018
 * Zaman: 17:00
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace telefon_rehberi
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		DataTable dt = new DataTable();
		DataColumn sütun;
		DataRow satır ;
		int say;
		string[,] liste=new string[300,4];
		int deger;
		public void ekleme(string ad,string soyad,string tel)
		{
			string dosya_yolu="kayıt.txt";
			System.IO.FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);
			sw.WriteLine(" ");
			sw.WriteLine(ad);
			sw.WriteLine(soyad);
			sw.WriteLine(tel);
			sw.Flush();
			sw.Close();
			fs.Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
			
			
			string ad=textBox1.Text;
			string soyad=textBox2.Text;
			string tel=textBox3.Text;
			ekleme(ad,soyad,tel);
			MessageBox.Show("Ekleme başarılı!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		public void sil(int i)
		{
			var file = new List<string>(System.IO.File.ReadAllLines("kayıt.txt"));
			file.RemoveAt(4*i); 
			file.RemoveAt(4*i); 
			file.RemoveAt(4*i); 
			file.RemoveAt(4*i); 
			File.WriteAllLines("kayıt.txt", file.ToArray());
		}
		public void ara()
		{
			dt.Clear();
			
			for(int i=0;i<say;i++){
				if( liste[i,0].Contains(textBox6.Text))
				{
					satır=dt.NewRow();
					satır["ad"]=liste[i,0];
					satır["soyad"]=liste[i,1];
					satır["tel"]=liste[i,2];
					satır["no"]=liste[i,3];
					dt.Rows.Add(satır);
					//	dt.Clear();
				}
				
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			string NewRow;
			StreamReader ShowFile = File.OpenText("kayıt.txt");
			NewRow = ShowFile.ReadLine();
			say=0;
			int sayac=0;
			while(NewRow != null)
			{
				NewRow = ShowFile.ReadLine();
				switch(sayac++){
					case 0:
						liste[say, 0] = (string) NewRow;break;
					case 1:
						liste[say, 1] = (string) NewRow;break;
					case 2:
						liste[say, 2] = (string)NewRow;break;
					case 3:
						liste[say,3]=say.ToString();
						sayac=0;
						say++;
						break;
				}
			}
			ShowFile.Close();
			ara();
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			sütun = new DataColumn("ad");
			sütun.DataType = Type.GetType("System.String");
			//Sütunlara ekle
			dt.Columns.Add(sütun);
			
			//Yeni bir sütun daha  oluştur
			sütun = new DataColumn("soyad");
			sütun.DataType = Type.GetType("System.String");
			//Sütunlara ekle
			dt.Columns.Add(sütun);
			//Yeni bir sütun daha  oluştur
			sütun = new DataColumn("tel");
			sütun.DataType = Type.GetType("System.String");
			//Sütunlara ekle
			dt.Columns.Add(sütun);
						//Yeni bir sütun daha  oluştur
			sütun = new DataColumn("no");
			sütun.DataType = Type.GetType("System.String");
			//Sütunlara ekle
			dt.Columns.Add(sütun);
			
			//dataGrid kontrolünde oluşturduğumuz tabloyu göster*/
			dataGridView1.DataSource = dt;
		}
		void Button3Click(object sender, EventArgs e)
		{
			sil(deger);
			MessageBox.Show("Silme başarılı!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
			
		}
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			deger = Convert.ToInt32(dataGridView1.CurrentRow.Cells["no"].Value);
			textBox6.Text=dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
				textBox5.Text=dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
				textBox4.Text=dataGridView1.CurrentRow.Cells["tel"].Value.ToString();
		}
		void Button4Click(object sender, EventArgs e)
		{
			sil(deger);
			string ad=textBox6.Text;
			string soyad=textBox5.Text;
			string tel=textBox4.Text;
			ekleme(ad,soyad,tel);
			MessageBox.Show("Güncelleme başarılı!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
			
		}
		
	}
}

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

namespace WindowsFormsApp1
{
	public partial class Note : Form
	{
		string path = "";
		public Note()
		{
			InitializeComponent();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string toSave = NoteBox.Text;
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Text File|*.txt";
			if (path == "")
			{
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					path = dialog.FileName;
					StreamWriter writer = new StreamWriter(File.Create(path));
					writer.Write(toSave);
					writer.Flush();
					writer.Close();
				}
			}
			else
			{
				StreamWriter writer = new StreamWriter(File.Create(path));
				writer.Write(toSave);
				writer.Flush();
				writer.Close();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{

			string toSave = NoteBox.Text;
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Text File|*.txt";

			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				path = dialog.FileName;
				StreamWriter writer = new StreamWriter(File.Create(path));
				writer.Write(toSave);
				writer.Flush();
				writer.Close();
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Text File|*.txt";
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				path = dialog.FileName;
				StreamReader reader = new StreamReader(path);
				string data = reader.ReadToEnd();
				NoteBox.Text = data;
				reader.Close();
			}
		}
	}
}


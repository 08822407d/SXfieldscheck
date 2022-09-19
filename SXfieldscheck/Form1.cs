using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utils;

namespace SXfieldscheck
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent();
		}

		private void btn_inputDIR_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd =new FolderBrowserDialog();
			fbd.Description = "请选择文件夹";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string dir = fbd.SelectedPath;
				if (dir != null)
				{
					tbx_inputDIR.Text = dir;
				}
			}
		}

		private void btn_outputDIR_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd =new FolderBrowserDialog();
			fbd.Description = "请选择文件夹";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string dir = fbd.SelectedPath;
				if (dir != null)
				{
					tbx_outputDIR.Text = dir;
				}
			}
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			string input_dir = tbx_inputDIR.Text;
			string output_dir = tbx_outputDIR.Text;

			//input_dir = @"C:\Users\cheyh\Desktop\testdata\xSXcheck";
			//output_dir = @"C:\Users\cheyh\Desktop\testdata\xSXresult";

			if (!Directory.Exists(input_dir))
			{
				MessageBox.Show("错误：输入文件夹不存在");
				return;
			}
			if (!Directory.Exists(output_dir))
			{
				MessageBox.Show("错误：输出文件夹不存在");
				return;
			}
			if (output_dir.Equals(input_dir))
			{
				MessageBox.Show("错误：输出目录和输入目录相同");
				return;
			}

			List<string> jsx_files = Utils.FIO.traverseSearchFile_Ext(input_dir, ".jsx");
			List<string> bsx_files = Utils.FIO.traverseSearchFile_Ext(input_dir, ".bsx");
			List<string> dsx_files = Utils.FIO.traverseSearchFile_Ext(input_dir, ".dsx");
			List<string> rsx_files = Utils.FIO.traverseSearchFile_Ext(input_dir, ".rsx");
			List<string> isx_files = Utils.FIO.traverseSearchFile_Ext(input_dir, ".isx");

			foreach (string f in jsx_files)
				check_jsx(f, input_dir, output_dir);
			foreach (string f in bsx_files)
				check_bsx(f, input_dir, output_dir);
			foreach (string f in dsx_files)
				check_dsx(f, input_dir, output_dir);
			foreach (string f in rsx_files)
				check_rsx(f, input_dir, output_dir);
			foreach (string f in isx_files)
				check_isx(f, input_dir, output_dir);
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void check_jsx(string f, string in_dir, string out_dir)
		{
			string outfile = f.Replace(in_dir, out_dir) + ".txt";
			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			File.Create(outfile).Close();

			StreamWriter sw = new StreamWriter(outfile);
			string[] lines = File.ReadAllLines(f);
			foreach (string line in lines)
			{
				char[] delimiterChars = { ' ', '\t' };
				string[] fields = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				if (fields.Length == 12)
				{
					string number = fields[0];
					string code = fields[1];
					string err = number;
					if (code.Equals("200206"))
					{
						double digit = 0;
						if(Double.TryParse(fields[6], out digit))
						{
							string[] valstr = fields[6].Split('.');
							Int64 integer;
							Int64.TryParse(valstr[0], out integer);
							if ((integer >= 3 && !valstr[1].Equals("00")) ||
								(integer < 3 && valstr[1][1] != '0'))
									err += "\t字段格式违规";
						}
						else
						{
							err += "\t字段非数值";
						}
					}

					if(err.Length > number.Length)
						sw.WriteLine(err);
				}
			}
			sw.Flush();
			sw.Close();
		}

		void check_bsx(string f, string in_dir, string out_dir)
		{
			string outfile = f.Replace(in_dir, out_dir) + ".txt";
			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			File.Create(outfile).Close();

			StreamWriter sw = new StreamWriter(outfile);
			string[] lines = File.ReadAllLines(f);
			foreach (string line in lines)
			{
				char[] delimiterChars = { ' ', '\t' };
				string[] fields = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				if (fields.Length == 10)
				{
					string number = fields[0];
					string code = fields[1];
					string err = number;
					if (code.Equals("120101") ||
						code.Equals("120102") ||
						code.Equals("120103") ||
						code.Equals("120106") ||
						code.Equals("120201") ||
						code.Equals("120301"))
					{
						double digit = 0;
						if(Double.TryParse(fields[5], out digit))
						{
							string[] valstr = fields[5].Split('.');
							if (!valstr[1].Equals("00"))
									err += "\t字段格式违规";
						}
						else
						{
							err += "\t字段非数值";
						}
					}

					if(err.Length > number.Length)
						sw.WriteLine(err);
				}
			}
			sw.Flush();
			sw.Close();
		}

		void check_dsx(string f, string in_dir, string out_dir)
		{
			string outfile = f.Replace(in_dir, out_dir) + ".txt";
			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			File.Create(outfile).Close();

			StreamWriter sw = new StreamWriter(outfile);
			string[] lines = File.ReadAllLines(f);
			foreach (string line in lines)
			{
				char[] delimiterChars = { ' ', '\t' };
				string[] fields = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				if (fields.Length == 21)
				{
					string number = fields[0];
					string code = fields[1];
					string err = number;

					if (code.Equals("140401") ||
						code.Equals("140403"))
					{
						if (!fields[2].Equals("NULL"))
							err += "\t第3列";
						if (!fields[3].Equals("NULL"))
							err += "\t第4列";
						if (!fields[6].Equals("0.00"))
							err += "\t第7列";
						if (!fields[7].Equals("0.00"))
							err += "\t第8列";
					}

					if (code.Equals("140402"))
						err += "\t非法编码";
					
					if (code.Equals("130416"))
					{
						if (!fields[3].Equals("NULL"))
							err += "\t第4列";
						if (!fields[5].Equals("NULL"))
							err += "\t第6列";
						double val = 0;
						if (!fields[7].Equals("0.00") &&
							!Double.TryParse(fields[7], out val) &&
							val < 25)
							err += "\t第8列";
					}

					if (code.Equals("130417"))
					{
						if (!fields[3].Equals("NULL"))
							err += "\t第4列";
						if (!fields[5].Equals("NULL"))
							err += "\t第6列";
						double val = 0;
						if (!fields[7].Equals("0.00") &&
							!Double.TryParse(fields[7], out val) &&
							val < 15)
							err += "\t第8列";
					}

					if (code.Equals("140521") ||
						code.Equals("140523") ||
						code.Equals("140524") ||
						code.Equals("140525") ||
						code.Equals("140526") ||
						code.Equals("140527") ||
						code.Equals("140528"))
					{
						if (!fields[3].Equals("NULL"))
							err += "\t第4列";
						if (!fields[5].Equals("NULL"))
							err += "\t第6列";
					}

					if (code.Equals("149998") ||
						code.Equals("149999"))
					{
						if (!fields[2].Equals("NULL"))
							err += "\t第3列";
						if (!fields[3].Equals("NULL"))
							err += "\t第4列";
						if (!fields[4].Equals("NULL"))
							err += "\t第5列";
						if (!fields[5].Equals("NULL"))
							err += "\t第6列";
						if (!fields[6].Equals("0.00"))
							err += "\t第7列";
						if (!fields[7].Equals("0.00"))
							err += "\t第8列";
					}

					if(err.Length > number.Length)
						sw.WriteLine(err);
				}
			}
			sw.Flush();
			sw.Close();
		}

		void check_rsx(string f, string in_dir, string out_dir)
		{
			string outfile = f.Replace(in_dir, out_dir) + ".txt";
			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			File.Create(outfile).Close();

			StreamWriter sw = new StreamWriter(outfile);
			string[] lines = File.ReadAllLines(f);
			foreach (string line in lines)
			{
				char[] delimiterChars = { ' ', '\t' };
				string[] fields = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				if (fields.Length == 8)
				{
					string number = fields[0];
					string code = fields[1];
					string err = number;
					if (code.Equals("280309") ||
						code.Equals("280401") ||
						code.Equals("280402") ||
						code.Equals("280500") ||
						code.Equals("280501") ||
						code.Equals("280600") ||
						code.Equals("280800"))
					{
						err += "\t非法编码";
					}

					if(err.Length > number.Length)
						sw.WriteLine(err);
				}
			}
			sw.Flush();
			sw.Close();
		}

		void check_isx(string f, string in_dir, string out_dir)
		{
			string outfile = f.Replace(in_dir, out_dir) + ".txt";
			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			File.Create(outfile).Close();

			StreamWriter sw = new StreamWriter(outfile);
			string[] lines = File.ReadAllLines(f);
			foreach (string line in lines)
			{
				char[] delimiterChars = { ' ', '\t' };
				string[] fields = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				if (fields.Length == 14)
				{
					string number = fields[0];
					string code = fields[1];
					string err = number;
					if (code.Equals("190102") && !fields[8].Equals("-32767.00"))
						err += "\t字段值违规";

					if(err.Length > number.Length)
						sw.WriteLine(err);
				}
			}
			sw.Flush();
			sw.Close();
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 01/03/2016
 * Time: 20:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BW_tool
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
		public string dsfilter = "NDS save data|*.sav;*.dsv|All Files (*.*)|*.*";
		public byte[] savebuffer;
		public static SAV5 save;


		void Loadsave_butClick(object sender, EventArgs e)
		{
			versiontext.Text = "";
			string path = null;
			if(FileIO.load_file(ref savebuffer, ref path, dsfilter) == 1)
			{
				savegamename.Text = path;
				save = new SAV5(savebuffer);
				if (save.B2W2) versiontext.Text = "Black/White 2";
				else if (save.BW) versiontext.Text = "Black/White 1";
				else versiontext.Text = "Invalid file";
				
			}else{
				savegamename.Text = "";
			}
		}
		void Save_butClick(object sender, EventArgs e)
		{
			if (save.Edited)
				FileIO.save_data(save.Data);
			else MessageBox.Show("Save has not been edited");
		}
		void Dumper_butClick(object sender, EventArgs e)
		{
			Form dumper = new Dumper();
			dumper.ShowDialog();
		}
		void Chk_butClick(object sender, EventArgs e)
		{
			save.chkCheck(false); //Only verify
		}
		void Chk_updt_butClick(object sender, EventArgs e)
		{
			save.chkCheck(true); //Recalculate checksums and set them to savefile
		}
		void SavegamenameTextChanged(object sender, EventArgs e)
		{
			if (savegamename.Text != "")
			{
				dumper_but.Enabled = true;
				chk_but.Enabled = true;
				chk_updt_but.Enabled = true;
				save_but.Enabled = true;
			}
			else
			{
				dumper_but.Enabled = false;
				chk_but.Enabled = false;
				chk_updt_but.Enabled = false;
				save_but.Enabled = false;
			}
		}
	}
}

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
			int filesize = FileIO.load_file(ref savebuffer, ref path, dsfilter);
			if( filesize == SAV5.SIZERAW || filesize == SAV5.SIZERAW+122 )
			{
				//Convert DSV to SAV
				if (filesize == SAV5.SIZERAW+122)
					Array.Resize(ref savebuffer, SAV5.SIZERAW);
				
				savegamename.Text = path;
				save = new SAV5(savebuffer);
			
				if (save.B2W2)
				{
					versiontext.Text = "Black/White 2";
					
					dumper_but.Enabled = true;
					chk_but.Enabled = true;
					chk_updt_but.Enabled = true;
					save_but.Enabled = true;
					grotto_but.Enabled = true;
					trainer_records_but.Enabled = true;
					medal_but.Enabled = true;
					forest_but.Enabled = true;
				}
				else if (save.BW)
				{
					versiontext.Text = "Black/White 1";
					
					dumper_but.Enabled = true;
					chk_but.Enabled = true;
					chk_updt_but.Enabled = true;
					save_but.Enabled = true;
					grotto_but.Enabled = false;
					trainer_records_but.Enabled = false;
					medal_but.Enabled = false;
					forest_but.Enabled = true;
				}
				else versiontext.Text = "Invalid file";

				
			}else{
				MessageBox.Show("Invalid file.");
				savegamename.Text = "";
				dumper_but.Enabled = false;
				chk_but.Enabled = false;
				chk_updt_but.Enabled = false;
				save_but.Enabled = false;
				grotto_but.Enabled = false;
				trainer_records_but.Enabled = false;
				medal_but.Enabled = false;
				forest_but.Enabled = false;
			}
		}
		void Save_butClick(object sender, EventArgs e)
		{
			if (save.Edited)
				FileIO.save_data(save.Data);
			else MessageBox.Show("Save has not been edited");
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

		}
		void Dumper_butClick(object sender, EventArgs e)
		{
			Form dumper = new Dumper();
			dumper.ShowDialog();
		}
		void Grotto_butClick(object sender, EventArgs e)
		{
			Form grotto = new Grotto();
			grotto.ShowDialog();
		}
		void Trainer_records_butClick(object sender, EventArgs e)
		{
			Form trainerrec = new TrainerRec();
			trainerrec.ShowDialog();
		}
		void Medal_butClick(object sender, EventArgs e)
		{
			Form medals = new Medals();
			medals.ShowDialog();
		}
		void Forest_butClick(object sender, EventArgs e)
		{
			Form forest = new Entralink();
			forest.ShowDialog();
		}
	}
}

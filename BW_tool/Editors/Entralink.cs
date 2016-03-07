/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 05/03/2016
 * Time: 11:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BW_tool
{
	/// <summary>
	/// Description of Entralink.
	/// </summary>
	public partial class Entralink : Form
	{
		FOREST forest;
		List<RadioButton> checkboxlist = new List<RadioButton>();
		public Entralink()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			checkboxlist.Add(checkdeep);
			checkboxlist.Add(check9c);
			checkboxlist.Add(check9l);
			checkboxlist.Add(check9r);
			checkboxlist.Add(check1c);
			checkboxlist.Add(check1l);
			checkboxlist.Add(check1r);
			checkboxlist.Add(check2c);
			checkboxlist.Add(check2l);
			checkboxlist.Add(check2r);
			checkboxlist.Add(check3c);
			checkboxlist.Add(check3l);
			checkboxlist.Add(check3r);
			checkboxlist.Add(check4c);
			checkboxlist.Add(check4l);
			checkboxlist.Add(check4r);
			checkboxlist.Add(check5c);
			checkboxlist.Add(check5l);
			checkboxlist.Add(check5r);
			checkboxlist.Add(check6c);
			checkboxlist.Add(check6l);
			checkboxlist.Add(check6r);
			checkboxlist.Add(check7c);
			checkboxlist.Add(check7l);
			checkboxlist.Add(check7r);
			checkboxlist.Add(check8c);
			checkboxlist.Add(check8l);
			checkboxlist.Add(check8r);
			
			dataGridView1.Rows.Add(19);

			forest =  new FOREST(MainForm.save.B2W2? MainForm.save.getBlockDec(60) : MainForm.save.getBlockDec(61));
			unlock8box.SelectedIndex = forest.Unlock8;
			unlock9.SelectedIndex = forest.Unlock9;
			forest.Area = 4;
			forest.Indexpkm = 0;
			slot.Value = forest.Indexpkm;
			slot.Maximum = 19;
			check1c.Checked = true;
			updateslot();
			updatearea();


			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void updatearea()
		{
			int i = 0;
			foreach (RadioButton item in checkboxlist)
			{
				if (forest.Unlock9 == 1 && (i > 0 && i <4))
				{
						item.Enabled = true;
				}
				else if (forest.Unlock9 == 0 && (i > 0 && i <4))
				{
						item.Enabled = false;
				}
				switch (forest.Unlock8)
				{
					case 0x0:
						if (i > 3 && i < 10 )
							item.Enabled = true;
						else if (i>9)
							item.Enabled = false;
						break;
					case 0x1:
						if (i > 9 && i <13)
							item.Enabled = true;
						else if (i>=13)
							item.Enabled = false;
						break;
					case 0x2:
						if (i > 9 && i <16)
							item.Enabled = true;
						else if (i>=16)
							item.Enabled = false;
						break;
					case 0x3:
						if (i > 9 && i < 19)
							item.Enabled = true;
						else if (i>=19)
							item.Enabled = false;
						break;
					case 0x4:
						if (i > 9 && i <22)
							item.Enabled = true;
						else if (i>=22)
							item.Enabled = false;
						break;
					case 0x5:
						if (i > 9 && i <25)
							item.Enabled = true;
						else if (i>=25)
							item.Enabled = false;
						break;
					case 0x6:
						if (i > 9 && i <28)
							item.Enabled = true;
						else if (i>=28)
							//We should never reach this point
							MessageBox.Show("Updatearea error 1");
						break;
					default:
						MessageBox.Show("Updatearea error 2");
						break;
												
				}
				i++;
			}
			
			i = 0;
			foreach (RadioButton item in checkboxlist)
			{
				if (item.Checked)
				{
					forest.Area = i;
				}
		
				i++;
			}
			if (forest.Area > 0 && forest.Area < 4)
				slot.Maximum = 9;
			else
				slot.Maximum = 19;
			
			forest.Indexpkm = 0;
			slot.Value = forest.Indexpkm;
			updateGrid();
			
		}
	
		void updateslot()
		{
			spbox1.SelectedIndex = forest.Species;
			move1box.SelectedIndex = forest.Move;
			genderbox1.SelectedIndex = forest.Gender;
			formbox1.Value = forest.Form;
			animbox1.Value = forest.Animation;
		}

		void SlotValueChanged(object sender, EventArgs e)
		{
			forest.Indexpkm = (int)slot.Value;
			updateslot();
			
		}
		void areaChanged(object sender, EventArgs e)
		{
			updatearea();
			updateslot();
		}
		void Unlock8boxSelectedIndexChanged(object sender, EventArgs e)
		{
			forest.Unlock8 = (byte)unlock8box.SelectedIndex;
			updatearea();
			updateslot();
		}
		void Unlock9SelectedIndexChanged(object sender, EventArgs e)
		{
			forest.Unlock9 = (byte)unlock9.SelectedIndex;
			updatearea();
			updateslot();
		}
		void updateGrid()
		{
			int n;
			int i;
			int temp = forest.Indexpkm;
			for (i=0;i<20;i++)
			{
				if (forest.Area > 0 && forest.Area < 3 && i > 9)
				{
					dataGridView1.Rows[i].Cells[0].Value = " ";
					dataGridView1.Rows[i].Cells[1].Value = " ";
					dataGridView1.Rows[i].Cells[2].Value = " ";
					dataGridView1.Rows[i].Cells[3].Value = " ";
					dataGridView1.Rows[i].Cells[4].Value = " ";
				}else
				{
					forest.Indexpkm = i;
					if (forest.Species == 0)
					{
						dataGridView1.Rows[i].Cells[0].Value = " ";
						dataGridView1.Rows[i].Cells[1].Value = " ";
						dataGridView1.Rows[i].Cells[2].Value = " ";
						dataGridView1.Rows[i].Cells[3].Value = " ";
						dataGridView1.Rows[i].Cells[4].Value = " ";
					}
					else
					{
						dataGridView1.Rows[i].Cells[0].Value = TEXT.pkmlist[forest.Species];
						dataGridView1.Rows[i].Cells[1].Value = TEXT.movelist[forest.Move];
						dataGridView1.Rows[i].Cells[2].Value = forest.Gender;
						dataGridView1.Rows[i].Cells[3].Value = forest.Form;
						dataGridView1.Rows[i].Cells[4].Value = forest.Animation;
					}

				}
			}
			forest.Indexpkm = temp;
		}
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//if (!(forest.Area >0 && forest.Area > 4 && dataGridView1.CurrentRow.Index > 9))
				slot.Value = (int)dataGridView1.CurrentRow.Index;
		}

	public class FOREST
	    {

			internal int Size = MainForm.save.B2W2? MainForm.save.getBlockLength(60) : MainForm.save.getBlockLength(61);
	
	        public byte[] Data;
	        public FOREST(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	        }

	        private int area = 4;
	        private int indexpkm = 0;
	        private int total_areas = (9*3)+1;
	        private int area_size = 0x50;
	        private int deep_area_size = 0x28;
	        private int pkmnsize = 4;
			public int Area {
	        	get { return area; }
	        	set { if ((value >= 0) && (value < total_areas)){ area = value;} } }
			public int Indexpkm {
	        	get { return indexpkm; }
	        	set { if ((value >= 0) && (value < 20)){ indexpkm = (int)(value);} } }
	        public byte Unlock9 {
	        	get { return Data[0x848]; }
	            set { Data[0x848] = value; } }
	        public byte Unlock8 {
	        	get { return Data[0x849]; }
	            set { Data[0x849] = value; } }
	        internal int get_pkmoffset()
	        {

	        	if (area == 0) //Deepest area
	        	{	if (indexpkm > 19) return -1;
	        		return indexpkm*pkmnsize;
	        	}
	        	else if(area > 0 && area < 4) //Area 9 ony holds 10 pokes
	        	{
	        		if (indexpkm > 9) return -1;
	        		return area_size + (indexpkm*pkmnsize) + deep_area_size*area - deep_area_size;
	        	}
	        	else if(area > 3 && area < 28) //Areas 1-8
	        	{
	        		if (indexpkm > 19) return -1;
	        		return area_size + (deep_area_size*3) + ((area-4)*area_size) + (indexpkm*pkmnsize);
	        	}else 
	        		return -1;
	        }

/*
Pokemon Structure (4 bytes)
Bits
00-10   Species
11-20   Special Move
21-22   Gender (0 -> male, 1 -> female, 2 -> genderless)
23-27   Form
28-31   Animation (only even numbers allowed, last bit makes Pokemon invisible)
*/
			private int species;
			private int move;
			private int gender;
			private int form;
			private int animation;

	        public int Species {
	        	get { return (int)(BitConverter.ToInt32(Data, get_pkmoffset()) & 0x7FF) ; }
	            set { species = value; } }
	        public int Move {
				get { return (int)((BitConverter.ToInt32(Data, get_pkmoffset()) & 0x1FF800) >> 11); }
	            set { move = value; } }
	        public int Gender {
				get { return (int)((BitConverter.ToInt32(Data, get_pkmoffset()) & 0x600000) >> 21); }
	            set { gender = value; } }
	        public int Form {
				get { return (int)((BitConverter.ToInt32(Data, get_pkmoffset()) & 0xF800000) >> 23); }
	            set { form = value; } }
	        public int Animation {
				get { return (int)((BitConverter.ToInt32(Data, get_pkmoffset()) & 0xF0000000) >> 27); }
	            set { animation = value; } }
	        private UInt32 build_pkm()
	        {
	        	return (UInt32) ( ((species & 0x1F) << 11) | ((move & 0x0F) << 7) | (gender & 0x7F) | ((form & 0x0F) << 7) | ((animation & 0x0F) << 7) );
	        }
	        public void set_pkm()
	        {
	        	Array.Copy(BitConverter.GetBytes(build_pkm()), 0, Data, get_pkmoffset(), 4);
	        }
		}
	}
}

/* Structure gathered by BlackShark

General Structure
0x000   encrypted data
0x84C   initial encryption seed
0x850   update counter
0x852   checksum from 0x000 to 0x84F (CRC16-CCITT)
 
Decrypted Data Structure (0x000 - 0x84B)
20 Pokemon in each area from 1 - 8 as well as in the deepest area.
10 Pokemon in 9th area.
So they let you store a total of 530 Pokemon there!
 
0x000   Deepest Area
0x050   9th Area center
0x078   9th Area left
0x0A0   9th Area right
0x0C8   1st Area center
0x118   1st Area left
0x168   1st Area right
0x1B8   2nd Area center
0x208   2nd Area left
0x258   2nd Area right
0x2A8   3rd Area center
0x2F8   3rd Area left
0x348   3rd Area right
0x398   4th Area center
0x3E8   4th Area left
0x438   4th Area right
0x488   5th Area center
0x4D8   5th Area left
0x528   5th Area right
0x578   6th Area center
0x5C8   6th Area left
0x618   6th Area right
0x668   7th Area center
0x6B8   7th Area left
0x708   7th Area right
0x758   8th Area center
0x7A8   8th Area left
0x7F8   8th Area right
0x848   Unlock Area 9 (0x01 to unlock)
0x849   Unlock Areas 3 - 8 (0x00 - 0x06, any higher value will corrupt your forest!) (Area 1 & 2 and the deepest Area are unlocked by default -> 0x00)
0x84A   0x00
0x84B   0x00
 
Pokemon Structure (4 bytes)
Bits
00-10   Species
11-20   Special Move
21-22   Gender (0 -> male, 1 -> female, 2 -> genderless)
23-27   Form
28-31   Animation (only even numbers allowed, last bit makes Pokemon invisible)
*/

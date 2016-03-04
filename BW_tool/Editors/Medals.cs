/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 03/03/2016
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BW_tool
{
	/// <summary>
	/// Description of Medals.
	/// </summary>
	public partial class Medals : Form
	{
		MEDAL medals;
		public Medals()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			medals =  new MEDAL(MainForm.save.getBlock(68));
			indexbox.SelectedIndex = 0;
			day.Value = medals.Day;
			month.Value = medals.Month;
			year.Value = medals.Year;
			flag1box.Checked = medals.Flag1;
			flag2box.Checked = medals.Flag2;
			flag3box.Checked = medals.Flag3;
			flag4box.Checked = medals.Flag4;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if (indexbox.SelectedIndex == 0)
			{
				indexbox.SelectedIndex = 1;
			}
			else if (indexbox.SelectedIndex == 8)
			{
				indexbox.SelectedIndex = 9;
			}
			else if (indexbox.SelectedIndex == 107)
			{
				indexbox.SelectedIndex = 108;
			}
			else if (indexbox.SelectedIndex == 164)
			{
				indexbox.SelectedIndex = 165;
			}
			else if (indexbox.SelectedIndex == 189)
			{
				indexbox.SelectedIndex = 190;
			}

			if (indexbox.SelectedIndex > 0 && indexbox.SelectedIndex < 8)
			{
				medals.Index = (int)indexbox.SelectedIndex - 1;
			}
			else if (indexbox.SelectedIndex > 8 && indexbox.SelectedIndex < 107)
			{
				medals.Index = (int)indexbox.SelectedIndex - 2;
			}
			else if (indexbox.SelectedIndex > 107 && indexbox.SelectedIndex < 164)
			{
				medals.Index = (int)indexbox.SelectedIndex - 3;
			}
			else if (indexbox.SelectedIndex > 164 && indexbox.SelectedIndex < 189)
			{
				medals.Index = (int)indexbox.SelectedIndex - 4;
			}
			else if (indexbox.SelectedIndex > 189)
			{
				medals.Index = (int)indexbox.SelectedIndex - 5;
			}
			day.Value = medals.Day;
			month.Value = medals.Month;
			year.Value = medals.Year;
			flag1box.Checked = medals.Flag1;
			flag2box.Checked = medals.Flag2;
			flag3box.Checked = medals.Flag3;
			flag4box.Checked = medals.Flag4;
		}
		void DayValueChanged(object sender, EventArgs e)
		{
			medals.Day = (int)day.Value;
		}
		void MonthValueChanged(object sender, EventArgs e)
		{
			medals.Month = (int)month.Value;
		}
		void YearValueChanged(object sender, EventArgs e)
		{
			medals.Year = (int)year.Value;
		}
		void Exit_butClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void Saveexit_butClick(object sender, EventArgs e)
		{
			MainForm.save.setBlock(medals.Data, 68);
			this.Close();
		}
		void Flag1boxCheckedChanged(object sender, EventArgs e)
		{
			medals.Flag1 = flag1box.Checked;
		}
		void Flag2boxCheckedChanged(object sender, EventArgs e)
		{
			medals.Flag2 = flag2box.Checked;
		}
		void Flag3boxCheckedChanged(object sender, EventArgs e)
		{
			medals.Flag3 = flag3box.Checked;
		}
		void Flag4boxCheckedChanged(object sender, EventArgs e)
		{
			medals.Flag4 = flag4box.Checked;
		}
	public class MEDAL
	    {
			internal int MedalSize = 4;
			internal int Size = MainForm.save.getBlockLength(68);
	
	        public byte[] Data;
	        public MEDAL(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	        }
	        private int index = 0;
			public int Index {
	        	get { return index/4; }
	        	set { if ((value >= 0) && (value < 256)){ index = (int)(value*MedalSize);} } }
	        
	        private UInt16 build_date(int day, int month, int year)
	        {
        	
	        	return (UInt16) ( ((day & 0x1F) << 11) | ((month & 0x0F) << 7) | (year & 0x7F)  );
	        }
	        

	        public int Day {
	        	get { return (BitConverter.ToUInt16(Data, index)) >> 11; }
	        	set { BitConverter.GetBytes(build_date(value, Month, Year)).CopyTo(Data, index); } }
	        public int Month {
	        	get { return (BitConverter.ToUInt16(Data, index) & 0x0780) >> 7; }
	            set { BitConverter.GetBytes(build_date(Day, value, Year)).CopyTo(Data, index); } }
	        public int Year {
	        	get { return (BitConverter.ToUInt16(Data, index) & 0x007F); }
	            set { BitConverter.GetBytes(build_date(Day, Month, value)).CopyTo(Data, index); } }
	        public UInt16 Flags {
	        	get { return BitConverter.ToUInt16(Data, index+0x02); }
	            set { BitConverter.GetBytes((UInt16)value).CopyTo(Data, index+0x2); } }
	        
        	public bool Flag1{
	        	get { return Convert.ToBoolean(Flags&0x1); }
	        	//set { Flags = (UInt16)(Convert.ToByte(value) | (Flags & ~(0x1))); } }
	        	set { if (value) Flags = (UInt16)(0x1 | (Flags & ~(0x4))); else Flags = (UInt16)(Flags & ~(0x1)); } }
        	public bool Flag2{
	        	get { return Convert.ToBoolean(Flags&0x2); }
	        	set { if (value) Flags = (UInt16)(0x2 | (Flags & ~(0x4))); else Flags = (UInt16)(Flags & ~(0x2)); } }
        	public bool Flag3{
	        	get { return Convert.ToBoolean(Flags&0x4); }
	        	set { if (value) Flags = (UInt16)(0x4 | (Flags & ~(0x4))); else Flags = (UInt16)(Flags & ~(0x4)); } }
        	public bool Flag4{
	        	get { return Convert.ToBoolean(Flags&0x8); }
	        	set { if (value) Flags = (UInt16)(0x8 | (Flags & ~(0x4))); else Flags = (UInt16)(Flags & ~(0x8)); } }
		}
	}
}

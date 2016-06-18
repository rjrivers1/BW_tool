/*
 * Created by SharpDevelop.
 * User: sergi
 * Date: 17/06/2016
 * Time: 21:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace BW_tool
{
	/// <summary>
	/// Description of TrainerInfo.
	/// </summary>
	public partial class TrainerInfo : Form
	{
		TRAINER ash;
		int trainer_block = 27;
		RIVAL gary;
		int rival_block = 66;
		BADGES badge;
		int badges_block = 52;
		BATTLE battle;
		int battle_block = 57;
		CARDSIG card;
		int cardsig_block = 33;
		
		public TrainerInfo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			money.Maximum = 9999999;
			bp.Maximum = 9999;
			
			ash =  new TRAINER(MainForm.save.getBlock(trainer_block));
			gary =  new RIVAL(MainForm.save.getBlock(rival_block));
			badge =  new BADGES(MainForm.save.getBlock(badges_block));
			battle =  new BATTLE(MainForm.save.getBlock(battle_block));
			card =  new CARDSIG(MainForm.save.getBlock(cardsig_block));
			
			load_data();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void load_data()
		{
			name.Text = ash.name;
			rival_name.Text = gary.name;
			
			tid.Value = ash.TID;
			sid.Value = ash.SID;
			
			money.Value = badge.money;

			
			if (ash.gender == 0)
			{
				tnr_class.Items.Clear();
				tnr_class.Items.AddRange(new object[] {
					"Youngster",
					"Ace trainer",
					"PKMN Ranger",
					"PKMN Breeder",
					"Scientist",
					"Hiker",
					"Roughneck",
					"Preschooler"});
				tnr_class.SelectedIndex = ash.trainer_class;
			}
			else
			{
				tnr_class.Items.Clear();
				tnr_class.Items.AddRange(new object[] {
					"Lass",
					"Ace trainer",
					"PKMN Ranger",
					"PKMN Breeder",
					"Scientist",
					"Parasol Lady",
					"Nurse",
					"Preschooler"});
				tnr_class.SelectedIndex = ash.trainer_class-8;
			}
			gender.SelectedIndex = ash.gender;

			hours.Value = ash.hours;
			minutes.Value = ash.minutes;
			seconds.Value = ash.seconds;
			
			bp.Value = battle.bp;
			
			tnr_nature.SelectedIndex = card.nature;
			
			badge1.Checked = badge.badge1;
			badge1_date.Value = card.badge1;
			
		}
		
		void set_data()
		{
			ash.name = name.Text;
			gary.name = rival_name.Text;
			
			ash.TID = (UInt16)tid.Value;
			ash.SID = (UInt16)sid.Value;
			
			badge.money = (UInt32)money.Value;

			ash.gender = (byte)gender.SelectedIndex;
						
			if(gender.SelectedIndex == 1)
				ash.trainer_class = (byte)(tnr_class.SelectedIndex+8);
			else
				ash.trainer_class = (byte)(tnr_class.SelectedIndex);


			ash.hours = (UInt16)hours.Value;
			ash.minutes = (byte)minutes.Value ;
			ash.seconds = (byte)seconds.Value;
			
			battle.bp = (UInt16)bp.Value;
			
			card.nature = (byte)tnr_nature.SelectedIndex;
			
			
			
		}
		void Exit_butClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void Saveexit_butClick(object sender, EventArgs e)
		{
			MainForm.save.setBlock(ash.Data, trainer_block);
			MainForm.save.setBlock(gary.Data, rival_block);
			MainForm.save.setBlock(badge.Data, badges_block);
			MainForm.save.setBlock(battle.Data, badges_block);
			MainForm.save.setBlock(card.Data, badges_block);
			this.Close();
		}
		
		public class TRAINER
	    {
			internal int Size = MainForm.save.getBlockLength(27);//Block 67
	
	        public byte[] Data;
	        public TRAINER(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	                        
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        //Helper functions from pkhex
	        internal static string TrimFromFFFF(string input)
	        {
	            int index = input.IndexOf((char)0xFFFF);
	            return index < 0 ? input : input.Substring(0, index);
	        }

	        public string name
	        {
	            get
	            {
	                return TrimFromFFFF(Encoding.Unicode.GetString(Data, 0x04, 0xE))
	                    .Replace("\uE08F", "\u2640") // nidoran
	                    .Replace("\uE08E", "\u2642") // nidoran
	                    .Replace("\u2019", "\u0027"); // farfetch'd
	            }
	            set
	            {
	                if (value.Length > 0xE/2)
	                    value = value.Substring(0, 0xE/2); // Hard cap
	                string TempNick = value // Replace Special Characters and add Terminator
	                    .Replace("\u2640", "\uE08F") // nidoran
	                    .Replace("\u2642", "\uE08E") // nidoran
	                    .Replace("\u0027", "\u2019") // farfetch'd
	                    .PadRight(value.Length + 1, (char)0xFFFF); // Null Terminator
	                Encoding.Unicode.GetBytes(TempNick).CopyTo(Data, 0x04);
	            }
	        }
	        public UInt16 TID
	        {
	            get
	            {
	            	return BitConverter.ToUInt16(getData(0x14, 2), 0);
	            }
	            set
	            {
	            	setData(BitConverter.GetBytes(value), 0x14);
	            }
	        }
	        public UInt16 SID
	        {
	            get
	            {
	            	return BitConverter.ToUInt16(getData(0x16, 2), 0);
	            }
	            set
	            {
	            	setData(BitConverter.GetBytes(value), 0x16);
	            }
	        }
	        public UInt16 hours
	        {
	            get
	            {
	            	return BitConverter.ToUInt16(getData(0x24, 2), 0);
	            }
	            set
	            {
	            	setData(BitConverter.GetBytes(value), 0x24);
	            }
	        }
	        public byte minutes
	        {
	            get
	            {
	            	return Data[0x26];
	            }
	            set
	            {
	            	Data[0x26] = (byte) value;
	            }
	        }
	        public byte seconds
	        {
	            get
	            {
	            	return Data[0x27];
	            }
	            set
	            {
	            	Data[0x27] = (byte) value;
	            }
	        }
	        
	        public int gender
	        {
	            get
	            {
	            	if (Data[0x21] == 0x01)
	            		return 1;
	            	else
	            		return 0;
	            }
	            set
	            {
	            	if (value == 1)
	            		Data[0x21] = 0x01;
	            	else
	            		Data[0x21] = 0;
	            }
	        }
			
	        public byte trainer_class
	        {
	            get
	            {
	            	return Data[0x20];
	            }
	            set
	            {
	            	Data[0x20] = (byte) value;
	            }
	        }
	     
	        
		}
		public class RIVAL
	    {
			internal int Size = MainForm.save.getBlockLength(66);//Block 66
	
	        public byte[] Data;
	        public RIVAL(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	                        
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        //Helper functions from pkhex
	        internal static string TrimFromFFFF(string input)
	        {
	            int index = input.IndexOf((char)0xFFFF);
	            return index < 0 ? input : input.Substring(0, index);
	        }

	        public string name
	        {
	            get
	            {
	                return TrimFromFFFF(Encoding.Unicode.GetString(Data, 0xA4, 0xE))
	                    .Replace("\uE08F", "\u2640") // nidoran
	                    .Replace("\uE08E", "\u2642") // nidoran
	                    .Replace("\u2019", "\u0027"); // farfetch'd
	            }
	            set
	            {
	                if (value.Length > 0xE/2)
	                    value = value.Substring(0, 0xE/2); // Hard cap
	                string TempNick = value // Replace Special Characters and add Terminator
	                    .Replace("\u2640", "\uE08F") // nidoran
	                    .Replace("\u2642", "\uE08E") // nidoran
	                    .Replace("\u0027", "\u2019") // farfetch'd
	                    .PadRight(value.Length + 1, (char)0xFFFF); // Null Terminator
	                Encoding.Unicode.GetBytes(TempNick).CopyTo(Data, 0xA4);
	            }
	        }
		}

		public class BADGES
	    {
			internal int Size = MainForm.save.getBlockLength(52);//Block 66
	
	        public byte[] Data;
	        public BADGES(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	                        
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        public UInt32 money
	        {
	            get
	            {
	            	return BitConverter.ToUInt32(getData(0, 4), 0);
	            }
	            set
	            {
	            	setData(BitConverter.GetBytes((UInt32)value), 0);
	            }
	        }
	        
	        public bool badge1
	        {
	            get
	            {
	            	if ((Data[0x4] & 0x1) != 0)
	            		return true;
	            	else
	            		return false;
	            }
	            set
	            {
	            	if (value == true)
	            		Data[0x4] = (byte)(Data[0x4]|0x1);
	            	else
	            		Data[0x4] =(byte)(Data[0x4]|~0x1);
	            }
	        }
		}
		public class BATTLE
	    {
			internal int Size = MainForm.save.getBlockLength(57);//Block 57 BW2
	
	        public byte[] Data;
	        public BATTLE(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	                        
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        public UInt16 bp
	        {
	            get
	            {
	            	return BitConverter.ToUInt16(getData(0, 2), 0);
	            }
	            set
	            {
	            	setData(BitConverter.GetBytes((UInt16)value), 0);
	            }
	        }
		}
		public class CARDSIG
	    {
			internal int Size = MainForm.save.getBlockLength(33);//Block 57 BW2
	
	        public byte[] Data;
	        public CARDSIG(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	                        
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        public byte nature
	        {
	            get
	            {
	            	return Data[0x600];
	            }
	            set
	            {
	            	Data[0x600] = (byte) value;
	            }
	        }
	          
	        public DateTime badge1
	        {
	            get
	            {
	            	if (Data[0x604] != 0 && Data[0x605] != 0 && Data[0x606] != 0)
	            		return new DateTime(2000+Data[0x604], Data[0x605], Data[0x606]);
	            	else
	            		return new DateTime(2000, 1, 1);
	            }
	            set
	            {
	            	if(value == new DateTime(2000, 1, 1))
	            	{
	            	   	
	            	}
	            	else
	            	{
		            	Data[0x604] = (byte) (value.Year-2000);
		            	Data[0x605] = (byte) value.Month;
		            	Data[0x606] = (byte) value.Day;
	            	}
	            }
	        }
		}
	}
}

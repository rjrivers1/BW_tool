﻿/*
 * Created by SharpDevelop.
 * User: LAURA
 * Date: 19/06/2016
 * Time: 10:19
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
	/// Description of MemoryLink.
	/// </summary>
	public partial class MemoryLink : Form
	{
		MEMORIES ml;
		Random rand;
		public MemoryLink()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			rand = new Random(Guid.NewGuid().GetHashCode());
			
			ml = new MEMORIES (MainForm.save.getData(MEMORIES.Offset, MEMORIES.Size));
			
			if (ml.block2.name == "")
			{
				MessageBox.Show("The savegame does not contain memory link Data.\n\nA default memory link data will be loaded, it unlocks the following:" +
				                "\n\t- All 8 flashbacks" +
				                "\n\t- NPC Battles with Cheren and Bianca" +
				                "\n\t- NPC will use BW1 trainer name instead of just Trainer" +
				                "\n\t- Certificates for completed Pokedex and trophies from Battle Subway\n\t   (they are placed in the players room)" +
				                "\n\t- My personal hall of fame from my BW1 playthrough\n\t    (no known use in-game)" +
				                "\n\nNote: No data related to Loblolly's Studio (would unlock Dream World furniture from BW on BW2) is present, but Dream World has closed anyways.");
				
				ml = new MEMORIES(default_memories);
				ml.block2.name = "PPorg";
				ml.block2.TID = 25560;
				ml.block2.SID = 13453;
				
				UInt32 newseed = (UInt32)(rand.Next(0xFFFF+1)<<16);
				ml.block1.crypt_seed = newseed;
				ml.block1_mirror.crypt_seed = newseed;
				
				//Needed so export memory doesn't export my own data (default_memories)
				load_data();
				set_data();
			}
			
			load_data();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void load_data()
		{
			name.Text = ml.block2.name;
			tid.Value = ml.block2.TID;
			sid.Value = ml.block2.SID;
			starter.SelectedIndex = ml.block2.STARTER;
			
			flag1.Checked = ml.block2.checkflag(0);
			flag2.Checked = ml.block2.checkflag(1);
			flag3.Checked = ml.block2.checkflag(2);
			flag4.Checked = ml.block2.checkflag(3);
			flag5.Checked = ml.block2.checkflag(4);
			flag6.Checked = ml.block2.checkflag(5);
			flag7.Checked = ml.block2.checkflag(6);
			flag8.Checked = ml.block2.checkflag(7);
		}
		
		void set_data()
		{
			ml.block2.name = name.Text;
			ml.block2.TID = (UInt16)tid.Value;
			ml.block2.SID = (UInt16)sid.Value;
			ml.block2.STARTER = (byte)starter.SelectedIndex;
			
			ml.block2.setflag(0, flag1.Checked);
			ml.block2.setflag(1, flag2.Checked);
			ml.block2.setflag(2, flag3.Checked);
			ml.block2.setflag(3, flag4.Checked);
			ml.block2.setflag(4, flag5.Checked);
			ml.block2.setflag(5, flag6.Checked);
			ml.block2.setflag(6, flag7.Checked);
			ml.block2.setflag(7, flag8.Checked);
			
			ml.set_blocks();
		}
		
		void Exit_butClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void Saveexit_butClick(object sender, EventArgs e)
		{
			set_data();
			
			MainForm.save.setData(ml.Data, MEMORIES.Offset);
			
			this.Close();
		}
		void B1_exportClick(object sender, EventArgs e)
		{
			FileIO.save_file(ml.block1.Data, "Memory Link Data|*.bin|All Files (*.*)|*.*");
		}
		void B1m_exportClick(object sender, EventArgs e)
		{
			FileIO.save_file(ml.block1_mirror.Data, "Memory Link Data|*.bin|All Files (*.*)|*.*");
		}
		void B2_exportClick(object sender, EventArgs e)
		{
			FileIO.save_file(ml.block2.Data, "Memory Link Data|*.bin|All Files (*.*)|*.*");
		}
		void B1_importClick(object sender, EventArgs e)
		{
			byte[] new_block1 = new byte[MEMORIES.ML_BLOCK1.Size];
	      	string path = null;
	        int filesize = FileIO.load_file(ref new_block1, ref path, "Memory Link Data|*.bin|All Files (*.*)|*.*");
	        
	        if( filesize == MEMORIES.ML_BLOCK1.Size )
			{
		        new_block1.CopyTo(ml.block1.Data, 0);
		        //Reload
		        load_data();
		    }else
	        {
	        	MessageBox.Show("Invalid file");
	        }
		}
		void B1m_importClick(object sender, EventArgs e)
		{
			byte[] new_block1m = new byte[MEMORIES.ML_BLOCK1.Size];
	      	string path = null;
	        int filesize =  FileIO.load_file(ref new_block1m, ref path, "Memory Link Data|*.bin|All Files (*.*)|*.*");

	     	if( filesize == MEMORIES.ML_BLOCK1.Size )
			{
		     	new_block1m.CopyTo(ml.block1_mirror.Data, 0);
		        //Reload
		        load_data();
 			}else
	        {
	        	MessageBox.Show("Invalid file");
	        }
		}
		void B2_importClick(object sender, EventArgs e)
		{
			byte[] new_block2 = new byte[MEMORIES.ML_BLOCK2.Size];
	      	string path = null;
	     	int filesize =  FileIO.load_file(ref new_block2, ref path, "Memory Link Data|*.bin|All Files (*.*)|*.*");
	        
	     	if( filesize == MEMORIES.ML_BLOCK2.Size )
			{
		     	new_block2.CopyTo(ml.block2.Data, 0);
		        //Reload
		        load_data();
 			}else
	        {
	        	MessageBox.Show("Invalid file");
	        }
		}
		void Memory_importClick(object sender, EventArgs e)
		{
			byte[] new_memory = new byte[MEMORIES.Size];
	      	string path = null;
	        int filesize = FileIO.load_file(ref new_memory, ref path, "Memory Link Data|*.mld|All Files (*.*)|*.*");
	        if( filesize == MEMORIES.Size )
			{
	        	ml = new MEMORIES(new_memory);
				//Reload all data
				load_data();
	        }else
	        {
	        	MessageBox.Show("Invalid file");
	        }
		}
		void Memory_exportClick(object sender, EventArgs e)
		{
			FileIO.save_file(ml.Data, "Memory Link Data|*.mld|All Files (*.*)|*.*");
		}
		void Import_bw1Click(object sender, EventArgs e)
		{
			byte[] bw1 = new byte[SAV5.SIZERAW+122];
	      	string path = null;
	        
			int filesize = FileIO.load_file(ref bw1, ref path, "NDS save data|*.sav;*.dsv|All Files (*.*)|*.*");

			if( filesize == SAV5.SIZERAW || filesize == SAV5.SIZERAW+122 )
			{
				//Convert DSV to SAV
				if (filesize == SAV5.SIZERAW+122)
					Array.Resize(ref bw1, SAV5.SIZERAW);
				
				SAV5 bw1save = new SAV5(bw1);
			
				if (bw1save.B2W2 == false)
				{
	        
			        ml.block2.name_fromarray(bw1.Skip(0x19404).Take(0xF).ToArray());
			        ml.block2.TID = BitConverter.ToUInt16(bw1, 0x19414);
			        ml.block2.SID = BitConverter.ToUInt16(bw1, 0x19416);
			        ml.block2.STARTER = bw1save.Data[0x20160];
			        
			        ml.block2.set_hof(bw1.Skip(0x23B00).Take(0x168).ToArray());
			        
			        UInt32 newseed = (UInt32)(rand.Next(0xFFFF+1)<<16);
					ml.block1.crypt_seed = newseed;
					ml.block1_mirror.crypt_seed = newseed;
			        
					//Reload all data
					load_data();
					
					MessageBox.Show("Imported: Trainer Name, TID, SID, Starter, Hall of Fame");
				}
				else{
					
					MessageBox.Show("Not a valid savegame!");
				}
			}
		}
		
		public class MEMORIES
	    {
			public static int Size = 0xA20;
			public static int Offset = 0x7E000;
	
	        public byte[] Data;
	        public MEMORIES(byte[] data = null)
	        {
	            Data = data ?? new byte[Size];
	            
	            load_blocks();
	                        
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        public ML_BLOCK1 block1;
	        public ML_BLOCK1 block1_mirror;
	        public ML_BLOCK2 block2;
	        
	        private void load_blocks()
	        {
	        	byte[] decrypt1 = new byte[ML_BLOCK1.Size];
	        	byte[] decrypt2 = new byte[ML_BLOCK2.Size];
	        	
	        	decrypt1 = SAV5.cryptoArray(getData(0, ML_BLOCK1.Size), 0xC, 0x364, 0x374-4);
	        	decrypt2 = SAV5.cryptoArray(getData(0x400, ML_BLOCK1.Size), 0xC, 0x364, 0x374-4);
	        	block1 = new ML_BLOCK1(decrypt1);
	        	block1_mirror = new ML_BLOCK1(decrypt2);
	        	
	        	block2 = new ML_BLOCK2(getData(0x800, ML_BLOCK2.Size));//Not encrypted, but has CRC
	        }
	        
	        public void set_blocks()
	        {
	        //Block 1
	        	//Recrypt 
				byte[] encrypt1 = new byte[ML_BLOCK1.Size];
	        	encrypt1 = SAV5.cryptoArray(block1.Data, 0xC, 0x364, 0x374-4);
	        	//Recalculate CRC
	        	ushort crc = SAV5.ccitt16(encrypt1.Skip(0xC).Take(0x368).ToArray());
	        	BitConverter.GetBytes(crc).CopyTo(encrypt1, 0x8);
	        	//Set new data
	        	setData(encrypt1, 0);
	        	
			//Block 1 Mirror
				//Just put block 1 for now as mirror
				setData(encrypt1, 0x400);
			/*
	        	//Recrypt 
				byte[] encrypt_mirror = new byte[ML_BLOCK1.Size];
	        	encrypt_mirror = SAV5.cryptoArray(block1_mirror.Data, 0xC, 0x364, 0x374-4);
	        	//Recalculate CRC
	        	ushort crc_mirror = SAV5.ccitt16(encrypt_mirror.Skip(0xC).Take(0x368).ToArray());
	        	BitConverter.GetBytes(crc_mirror).CopyTo(encrypt_mirror, 0x8);
	        	//Set new data
	        	setData(encrypt_mirror, 0x400);
	        */
	       
			//Block 2
	        	//Recalculate CRC
	        	ushort crc2 = SAV5.ccitt16(block2.Data.Skip(0xC).Take(0x214).ToArray());
	        	block2.crc = crc2;
	        	//Set new data
	        	setData(block2.Data, 0x800);
	        }
	        
		        public ushort block1_crc
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt16(Data, 0x8);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt16)value), 0x8);
		        	}
		        }
		        public UInt32 block1_crypt_seed
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt32(Data, 0x370);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt32)value), 0x370);
		        	}
		        }
		        public ushort block1_mirror_crc
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt16(Data, 0x400+0x8);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt16)value), 0x400+0x8);
		        	}
		        }
		        public UInt32 block1_mirror_crypt_seed
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt32(Data, 0x400+0x370);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt32)value), 0x400+0x370);
		        	}
		        }
		        public ushort block2_crc
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt16(Data, 0x800+0x8);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt16)value), 0x800+0x8);
		        	}
		        }
	        
	        public class ML_BLOCK1
	        {
				public static int Size = 0x374;
		
		        public byte[] Data;
		        public ML_BLOCK1(byte[] data = null)
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
		        
		        public ushort crc
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt16(Data, 0x8);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt16)value), 0x8);
		        	}
		        }
		        public UInt32 crypt_seed
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt32(Data, 0x370);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt32)value), 0x370);
		        	}
		        }
	        }
	        public class ML_BLOCK2
	        {
				public static int Size = 0x2A0;
		
		        public byte[] Data;
		        public ML_BLOCK2(byte[] data = null)
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
		        
		        public ushort crc
		        {
		        	get
		        	{
		        		return BitConverter.ToUInt16(Data, 0x8);
		        	}
		        	set
		        	{
		        		setData(BitConverter.GetBytes((UInt16)value), 0x8);
		        	}
		        }
		        
		        //Helper functions from pkhex
		        internal static string TrimFromFFFF(string input)
		        {
		            int index = input.IndexOf((char)0xFFFF);
		            return index < 0 ? input : input.Substring(0, index);
		        }
				
		        public void name_fromarray(byte[] input)
		        {
		        	name = TrimFromFFFF(Encoding.Unicode.GetString(input, 0x0, 0xE))
		                    .Replace("\uE08F", "\u2640") // nidoran
		                    .Replace("\uE08E", "\u2642") // nidoran
		                    .Replace("\u2019", "\u0027"); // farfetch'd
		        }
		        public string name
		        {
		            get
		            {
		                return TrimFromFFFF(Encoding.Unicode.GetString(Data, 0x48, 0xE))
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
		                Encoding.Unicode.GetBytes(TempNick).CopyTo(Data, 0x48);
                            	Encoding.Unicode.GetBytes(TempNick).CopyTo(Data, 0x60);
		                Encoding.Unicode.GetBytes(TempNick).CopyTo(Data, 0x78);
		            }
		        }
		        public UInt16 TID
		        {
		            get
		            {
		            	return BitConverter.ToUInt16(getData(0x44, 2), 0);
		            }
		            set
		            {
		            	setData(BitConverter.GetBytes((UInt16)value), 0x44);
                            	setData(BitConverter.GetBytes((UInt16)value), 0x5C);
		            	setData(BitConverter.GetBytes((UInt16)value), 0x74);
		            }
		        }
		        public UInt16 SID
		        {
		            get
		            {
		            	return BitConverter.ToUInt16(getData(0x46, 2), 0);
		            }
		            set
		            {
		            	setData(BitConverter.GetBytes((UInt16)value), 0x46);
                            	setData(BitConverter.GetBytes((UInt16)value), 0x5E);
		            	setData(BitConverter.GetBytes((UInt16)value), 0x76);
		            }
		        }
		        public byte STARTER
		        {
		        	get
		        	{
		        		return Data[0x8E];
		        	}
		        	set
		        	{
		        		Data[0x8E]=(byte)value;
		        	}
		        }
				
		        public bool checkflag(int index)
		        {
		        	if (index > 7)
		        		index = 7;
		        	if ((Data[0x8D] & (0x1<<index)) == 0)
		        		return false;
		        	else
		        		return true;
		        }
		        public void setflag(int index, bool status)
		        {
		        	if (index > 7)
		        		index = 7;
		        	
		        	if (status == true)
		        		Data[0x8D] |= (byte) (0x1<<index);
		        	else
		        		Data[0x8D] &= (byte) (~(0x1<<index));
		        }
		        
		        public void set_hof(byte[] input)
		        {
		        	setData(input.Skip(0x23B00).Take(0x168).ToArray(), 0xB8);
		        }
			}
		}
		
		private byte[] default_memories = new byte[] {
			0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x31, 0x15, 0x00, 0x00,
			0xCE, 0xA7, 0x34, 0x20, 0xEF, 0x11, 0x56, 0x1E, 0xF0, 0xE4, 0xE2, 0xCE,
			0x23, 0xE9, 0xE1, 0x78, 0xC1, 0x0F, 0xA2, 0x86, 0x9C, 0x6D, 0x2B, 0xE6,
			0x44, 0xAA, 0x13, 0x32, 0xDA, 0xC1, 0x6D, 0x37, 0x24, 0x95, 0xAE, 0xE1,
			0xA4, 0xC2, 0xB3, 0xC3, 0xC0, 0x74, 0x4E, 0xED, 0x3B, 0x84, 0x06, 0x8F,
			0x8A, 0x53, 0xF1, 0xA9, 0xD1, 0x6E, 0xCD, 0xBF, 0x91, 0x15, 0xBF, 0xB7,
			0x3C, 0xAE, 0x6F, 0x06, 0x5B, 0x91, 0x4C, 0x2C, 0xE6, 0xE8, 0x3D, 0xDB,
			0xF7, 0x61, 0x19, 0x1D, 0x08, 0x72, 0x8F, 0xB6, 0x53, 0xC6, 0x60, 0x4E,
			0x17, 0x6B, 0x2C, 0xA7, 0xCA, 0x21, 0x11, 0x0A, 0x7D, 0x88, 0xEE, 0xEA,
			0x01, 0xF2, 0x17, 0x63, 0x8C, 0x6D, 0xA5, 0x6D, 0xF2, 0x4D, 0xDE, 0x68,
			0xAF, 0xD3, 0x3C, 0x52, 0x49, 0x42, 0x19, 0x0F, 0xE1, 0xF0, 0x1A, 0xEA,
			0xEE, 0x9E, 0xC0, 0xCD, 0x63, 0xD1, 0xCA, 0xBE, 0xE2, 0x09, 0x57, 0x3D,
			0xA9, 0x98, 0xDE, 0x91, 0x4E, 0x6B, 0x76, 0x33, 0x94, 0xDD, 0x0F, 0x77,
			0xD9, 0x06, 0x84, 0x23, 0xE6, 0x95, 0xA9, 0x6C, 0x39, 0xD6, 0xC5, 0xC7,
			0xF2, 0x44, 0x25, 0x16, 0x0C, 0xF9, 0x97, 0x56, 0x93, 0x61, 0x17, 0x7D,
			0xE8, 0x4D, 0xF8, 0xC7, 0x5E, 0x27, 0x4A, 0xFC, 0xB0, 0x88, 0x4B, 0xEF,
			0x1A, 0x47, 0x28, 0xB9, 0x28, 0x5A, 0x5B, 0x6D, 0x70, 0x2A, 0x5F, 0x4F,
			0xCB, 0x7C, 0x9F, 0xBE, 0xDE, 0xBE, 0xC1, 0x92, 0xDC, 0xBA, 0xBF, 0xE9,
			0xF1, 0xFB, 0x6C, 0x8B, 0xBB, 0x41, 0x56, 0x92, 0xB2, 0x98, 0x2A, 0x10,
			0x79, 0xD6, 0xF9, 0x73, 0x61, 0xA4, 0x1A, 0xA3, 0xAE, 0xBF, 0x78, 0x89,
			0x60, 0xF6, 0x8F, 0x74, 0x89, 0x78, 0x63, 0x64, 0x71, 0xA9, 0x37, 0xB0,
			0x27, 0x81, 0xCF, 0x78, 0x24, 0x16, 0x7F, 0x78, 0x28, 0xE0, 0x59, 0x61,
			0x8A, 0x00, 0x36, 0x34, 0x7F, 0x29, 0x6B, 0x5F, 0x2E, 0xED, 0x6F, 0x12,
			0x8A, 0x1E, 0xBD, 0x9B, 0x45, 0xD1, 0xAC, 0xE8, 0x62, 0x3B, 0x1F, 0xEB,
			0x23, 0x92, 0x38, 0xCF, 0x73, 0xC5, 0x74, 0x1B, 0xF1, 0x07, 0xD4, 0x1F,
			0x4E, 0x2F, 0x01, 0x0D, 0x9D, 0x77, 0x95, 0xBA, 0xBD, 0xE5, 0xE7, 0x1B,
			0x11, 0xB8, 0x0C, 0xB5, 0x17, 0xDA, 0xED, 0x9D, 0xA6, 0x76, 0xA6, 0xD7,
			0xD5, 0x5D, 0x83, 0x78, 0xDA, 0x4E, 0x56, 0x8D, 0x65, 0x23, 0x03, 0x13,
			0x41, 0xA9, 0x70, 0x29, 0x3E, 0x78, 0x39, 0x29, 0xB9, 0x95, 0xD7, 0xA7,
			0x35, 0x0C, 0x25, 0x42, 0xE1, 0x14, 0x5B, 0x4B, 0x0D, 0xDA, 0xFE, 0xCE,
			0xCB, 0x84, 0x5C, 0xBE, 0x54, 0x05, 0x7A, 0x36, 0xF0, 0x24, 0xB2, 0x99,
			0x6C, 0xC1, 0x4C, 0x50, 0x63, 0xE5, 0xD0, 0x75, 0xE7, 0x95, 0xEE, 0x14,
			0x49, 0xF5, 0x26, 0xEA, 0x18, 0x94, 0x9F, 0x85, 0x89, 0xC4, 0xC7, 0x1E,
			0xE6, 0x51, 0xAF, 0x10, 0xBF, 0x6C, 0x4B, 0xD4, 0xE2, 0xBD, 0xFA, 0xF5,
			0x75, 0xB5, 0xF7, 0x05, 0x9C, 0x20, 0xB1, 0x6F, 0x94, 0x27, 0x1A, 0x8A,
			0x32, 0xDF, 0x5F, 0xA3, 0x17, 0xE4, 0xB9, 0x54, 0x28, 0xD3, 0x2B, 0x9F,
			0x02, 0x32, 0x6E, 0x40, 0x7F, 0x4B, 0x5A, 0xE7, 0x92, 0xF7, 0x8C, 0x81,
			0x00, 0x0B, 0x18, 0x58, 0xB5, 0x92, 0x87, 0x27, 0xD8, 0xD7, 0x77, 0x5F,
			0xBC, 0xC4, 0x92, 0x50, 0x69, 0x70, 0xB7, 0xD3, 0x4F, 0xA5, 0x89, 0xF3,
			0x5E, 0xF9, 0xC7, 0xE9, 0xA1, 0xD0, 0x11, 0x64, 0xFF, 0x38, 0x0B, 0x10,
			0xE3, 0x44, 0xFE, 0xF4, 0xC7, 0x33, 0x60, 0xB1, 0xFD, 0xA2, 0xF4, 0x5C,
			0x33, 0xFE, 0x5C, 0x24, 0x7B, 0xC6, 0x50, 0xC1, 0xDD, 0xD7, 0xD9, 0x4A,
			0xC5, 0xE8, 0x47, 0x8B, 0xC8, 0xE3, 0xB4, 0xA5, 0x92, 0xC3, 0x50, 0x6B,
			0xFD, 0x11, 0xD2, 0xE0, 0x9E, 0x66, 0xBF, 0x2E, 0x56, 0x0E, 0x63, 0x1B,
			0x9A, 0xB4, 0xB2, 0x4B, 0x98, 0x48, 0x6A, 0x70, 0x64, 0xBB, 0x30, 0x47,
			0xC7, 0x69, 0x7C, 0x83, 0x78, 0x5B, 0x8E, 0x59, 0xB6, 0xCA, 0xC7, 0x15,
			0xA5, 0xF2, 0x14, 0xF5, 0xDD, 0xBF, 0x55, 0xE7, 0x03, 0xFE, 0xE0, 0x12,
			0x6E, 0xCE, 0x92, 0x68, 0x23, 0xE7, 0x0A, 0x6A, 0xA9, 0x1E, 0x0B, 0x00,
			0x88, 0x70, 0x09, 0xF5, 0x6F, 0xBF, 0x77, 0xE8, 0x56, 0x75, 0x55, 0x69,
			0x15, 0x8F, 0xFB, 0xEA, 0x48, 0xF0, 0x4D, 0x85, 0x7A, 0xDD, 0xAA, 0x79,
			0xE7, 0x7D, 0x59, 0x58, 0x5C, 0x1B, 0x4A, 0xEE, 0xF9, 0xCD, 0x53, 0xE9,
			0xE6, 0x2A, 0x5D, 0xF1, 0x36, 0xB8, 0x22, 0xDF, 0x8C, 0x25, 0x5E, 0x4D,
			0x41, 0xE8, 0xA7, 0x0F, 0x1B, 0xAB, 0x4B, 0xB2, 0xD5, 0x54, 0xDD, 0x18,
			0x0B, 0x0E, 0x63, 0x2D, 0x3E, 0xF6, 0x3B, 0x68, 0x17, 0xF1, 0x30, 0x59,
			0x0B, 0x70, 0x5D, 0x54, 0x0F, 0x2A, 0xC7, 0x89, 0x01, 0xA2, 0xE2, 0x2C,
			0xEC, 0xFD, 0x4E, 0x79, 0x52, 0x54, 0x97, 0x64, 0x24, 0x0A, 0xBF, 0x38,
			0x0F, 0x73, 0xD4, 0x39, 0x3F, 0x6F, 0xEA, 0x68, 0xDA, 0x8C, 0x26, 0x81,
			0xAA, 0x10, 0xC0, 0xFF, 0xDE, 0x88, 0x2D, 0x76, 0xCB, 0xFD, 0xCD, 0x1D,
			0x03, 0xC8, 0xC7, 0xB6, 0x54, 0x58, 0x06, 0xB8, 0x5E, 0x25, 0x6E, 0xCC,
			0xDC, 0x4B, 0xC4, 0x19, 0xE6, 0x89, 0xDE, 0xE7, 0xAB, 0xEA, 0x10, 0x83,
			0x6D, 0x07, 0xFA, 0xB2, 0xD4, 0x03, 0x20, 0x67, 0xCD, 0xAE, 0xF0, 0x5C,
			0x89, 0x46, 0x21, 0x0F, 0x61, 0x95, 0x9A, 0x44, 0xAA, 0x46, 0x37, 0xA5,
			0xB7, 0xBD, 0x27, 0xE5, 0x9E, 0x36, 0xC1, 0xEB, 0x83, 0xD7, 0xFA, 0xE8,
			0x66, 0x6A, 0xE1, 0x24, 0xD5, 0x0A, 0xD1, 0x86, 0xEE, 0xF7, 0x3A, 0xEE,
			0x8E, 0x42, 0x29, 0x8D, 0xA6, 0x08, 0xFB, 0x14, 0x0F, 0xAA, 0xE1, 0xBF,
			0x51, 0xB0, 0x1C, 0xA6, 0x34, 0x52, 0x1D, 0x6C, 0x1C, 0x5D, 0xE7, 0xBE,
			0x80, 0x31, 0x6C, 0x56, 0xF2, 0x34, 0xBA, 0xE1, 0x99, 0xF3, 0x2C, 0x67,
			0x0E, 0xF4, 0x0A, 0xD3, 0xF6, 0x4B, 0x2D, 0xB9, 0xD1, 0x20, 0xAA, 0x42,
			0xD6, 0xBF, 0x95, 0xEE, 0xD5, 0xA8, 0x4D, 0xC5, 0x73, 0x1B, 0x02, 0xF0,
			0x41, 0x3B, 0x49, 0xE2, 0x77, 0x06, 0xF5, 0x79, 0x5E, 0xF4, 0x9D, 0x39,
			0xAE, 0x6B, 0x6D, 0x1C, 0x6A, 0x2E, 0x35, 0x06, 0xFD, 0xA7, 0xD2, 0x90,
			0xAC, 0x8B, 0x6B, 0x80, 0x93, 0xB4, 0x14, 0x8A, 0xC8, 0x8D, 0xD0, 0xE4,
			0x5D, 0xC0, 0x14, 0x63, 0x53, 0x4E, 0x2D, 0x23, 0xBE, 0xEC, 0x42, 0x4F,
			0xA9, 0x2C, 0xC4, 0x79, 0x00, 0x00, 0x46, 0x4E, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
			0x31, 0x15, 0x00, 0x00, 0xCE, 0xA7, 0x34, 0x20, 0xEF, 0x11, 0x56, 0x1E,
			0xF0, 0xE4, 0xE2, 0xCE, 0x23, 0xE9, 0xE1, 0x78, 0xC1, 0x0F, 0xA2, 0x86,
			0x9C, 0x6D, 0x2B, 0xE6, 0x44, 0xAA, 0x13, 0x32, 0xDA, 0xC1, 0x6D, 0x37,
			0x24, 0x95, 0xAE, 0xE1, 0xA4, 0xC2, 0xB3, 0xC3, 0xC0, 0x74, 0x4E, 0xED,
			0x3B, 0x84, 0x06, 0x8F, 0x8A, 0x53, 0xF1, 0xA9, 0xD1, 0x6E, 0xCD, 0xBF,
			0x91, 0x15, 0xBF, 0xB7, 0x3C, 0xAE, 0x6F, 0x06, 0x5B, 0x91, 0x4C, 0x2C,
			0xE6, 0xE8, 0x3D, 0xDB, 0xF7, 0x61, 0x19, 0x1D, 0x08, 0x72, 0x8F, 0xB6,
			0x53, 0xC6, 0x60, 0x4E, 0x17, 0x6B, 0x2C, 0xA7, 0xCA, 0x21, 0x11, 0x0A,
			0x7D, 0x88, 0xEE, 0xEA, 0x01, 0xF2, 0x17, 0x63, 0x8C, 0x6D, 0xA5, 0x6D,
			0xF2, 0x4D, 0xDE, 0x68, 0xAF, 0xD3, 0x3C, 0x52, 0x49, 0x42, 0x19, 0x0F,
			0xE1, 0xF0, 0x1A, 0xEA, 0xEE, 0x9E, 0xC0, 0xCD, 0x63, 0xD1, 0xCA, 0xBE,
			0xE2, 0x09, 0x57, 0x3D, 0xA9, 0x98, 0xDE, 0x91, 0x4E, 0x6B, 0x76, 0x33,
			0x94, 0xDD, 0x0F, 0x77, 0xD9, 0x06, 0x84, 0x23, 0xE6, 0x95, 0xA9, 0x6C,
			0x39, 0xD6, 0xC5, 0xC7, 0xF2, 0x44, 0x25, 0x16, 0x0C, 0xF9, 0x97, 0x56,
			0x93, 0x61, 0x17, 0x7D, 0xE8, 0x4D, 0xF8, 0xC7, 0x5E, 0x27, 0x4A, 0xFC,
			0xB0, 0x88, 0x4B, 0xEF, 0x1A, 0x47, 0x28, 0xB9, 0x28, 0x5A, 0x5B, 0x6D,
			0x70, 0x2A, 0x5F, 0x4F, 0xCB, 0x7C, 0x9F, 0xBE, 0xDE, 0xBE, 0xC1, 0x92,
			0xDC, 0xBA, 0xBF, 0xE9, 0xF1, 0xFB, 0x6C, 0x8B, 0xBB, 0x41, 0x56, 0x92,
			0xB2, 0x98, 0x2A, 0x10, 0x79, 0xD6, 0xF9, 0x73, 0x61, 0xA4, 0x1A, 0xA3,
			0xAE, 0xBF, 0x78, 0x89, 0x60, 0xF6, 0x8F, 0x74, 0x89, 0x78, 0x63, 0x64,
			0x71, 0xA9, 0x37, 0xB0, 0x27, 0x81, 0xCF, 0x78, 0x24, 0x16, 0x7F, 0x78,
			0x28, 0xE0, 0x59, 0x61, 0x8A, 0x00, 0x36, 0x34, 0x7F, 0x29, 0x6B, 0x5F,
			0x2E, 0xED, 0x6F, 0x12, 0x8A, 0x1E, 0xBD, 0x9B, 0x45, 0xD1, 0xAC, 0xE8,
			0x62, 0x3B, 0x1F, 0xEB, 0x23, 0x92, 0x38, 0xCF, 0x73, 0xC5, 0x74, 0x1B,
			0xF1, 0x07, 0xD4, 0x1F, 0x4E, 0x2F, 0x01, 0x0D, 0x9D, 0x77, 0x95, 0xBA,
			0xBD, 0xE5, 0xE7, 0x1B, 0x11, 0xB8, 0x0C, 0xB5, 0x17, 0xDA, 0xED, 0x9D,
			0xA6, 0x76, 0xA6, 0xD7, 0xD5, 0x5D, 0x83, 0x78, 0xDA, 0x4E, 0x56, 0x8D,
			0x65, 0x23, 0x03, 0x13, 0x41, 0xA9, 0x70, 0x29, 0x3E, 0x78, 0x39, 0x29,
			0xB9, 0x95, 0xD7, 0xA7, 0x35, 0x0C, 0x25, 0x42, 0xE1, 0x14, 0x5B, 0x4B,
			0x0D, 0xDA, 0xFE, 0xCE, 0xCB, 0x84, 0x5C, 0xBE, 0x54, 0x05, 0x7A, 0x36,
			0xF0, 0x24, 0xB2, 0x99, 0x6C, 0xC1, 0x4C, 0x50, 0x63, 0xE5, 0xD0, 0x75,
			0xE7, 0x95, 0xEE, 0x14, 0x49, 0xF5, 0x26, 0xEA, 0x18, 0x94, 0x9F, 0x85,
			0x89, 0xC4, 0xC7, 0x1E, 0xE6, 0x51, 0xAF, 0x10, 0xBF, 0x6C, 0x4B, 0xD4,
			0xE2, 0xBD, 0xFA, 0xF5, 0x75, 0xB5, 0xF7, 0x05, 0x9C, 0x20, 0xB1, 0x6F,
			0x94, 0x27, 0x1A, 0x8A, 0x32, 0xDF, 0x5F, 0xA3, 0x17, 0xE4, 0xB9, 0x54,
			0x28, 0xD3, 0x2B, 0x9F, 0x02, 0x32, 0x6E, 0x40, 0x7F, 0x4B, 0x5A, 0xE7,
			0x92, 0xF7, 0x8C, 0x81, 0x00, 0x0B, 0x18, 0x58, 0xB5, 0x92, 0x87, 0x27,
			0xD8, 0xD7, 0x77, 0x5F, 0xBC, 0xC4, 0x92, 0x50, 0x69, 0x70, 0xB7, 0xD3,
			0x4F, 0xA5, 0x89, 0xF3, 0x5E, 0xF9, 0xC7, 0xE9, 0xA1, 0xD0, 0x11, 0x64,
			0xFF, 0x38, 0x0B, 0x10, 0xE3, 0x44, 0xFE, 0xF4, 0xC7, 0x33, 0x60, 0xB1,
			0xFD, 0xA2, 0xF4, 0x5C, 0x33, 0xFE, 0x5C, 0x24, 0x7B, 0xC6, 0x50, 0xC1,
			0xDD, 0xD7, 0xD9, 0x4A, 0xC5, 0xE8, 0x47, 0x8B, 0xC8, 0xE3, 0xB4, 0xA5,
			0x92, 0xC3, 0x50, 0x6B, 0xFD, 0x11, 0xD2, 0xE0, 0x9E, 0x66, 0xBF, 0x2E,
			0x56, 0x0E, 0x63, 0x1B, 0x9A, 0xB4, 0xB2, 0x4B, 0x98, 0x48, 0x6A, 0x70,
			0x64, 0xBB, 0x30, 0x47, 0xC7, 0x69, 0x7C, 0x83, 0x78, 0x5B, 0x8E, 0x59,
			0xB6, 0xCA, 0xC7, 0x15, 0xA5, 0xF2, 0x14, 0xF5, 0xDD, 0xBF, 0x55, 0xE7,
			0x03, 0xFE, 0xE0, 0x12, 0x6E, 0xCE, 0x92, 0x68, 0x23, 0xE7, 0x0A, 0x6A,
			0xA9, 0x1E, 0x0B, 0x00, 0x88, 0x70, 0x09, 0xF5, 0x6F, 0xBF, 0x77, 0xE8,
			0x56, 0x75, 0x55, 0x69, 0x15, 0x8F, 0xFB, 0xEA, 0x48, 0xF0, 0x4D, 0x85,
			0x7A, 0xDD, 0xAA, 0x79, 0xE7, 0x7D, 0x59, 0x58, 0x5C, 0x1B, 0x4A, 0xEE,
			0xF9, 0xCD, 0x53, 0xE9, 0xE6, 0x2A, 0x5D, 0xF1, 0x36, 0xB8, 0x22, 0xDF,
			0x8C, 0x25, 0x5E, 0x4D, 0x41, 0xE8, 0xA7, 0x0F, 0x1B, 0xAB, 0x4B, 0xB2,
			0xD5, 0x54, 0xDD, 0x18, 0x0B, 0x0E, 0x63, 0x2D, 0x3E, 0xF6, 0x3B, 0x68,
			0x17, 0xF1, 0x30, 0x59, 0x0B, 0x70, 0x5D, 0x54, 0x0F, 0x2A, 0xC7, 0x89,
			0x01, 0xA2, 0xE2, 0x2C, 0xEC, 0xFD, 0x4E, 0x79, 0x52, 0x54, 0x97, 0x64,
			0x24, 0x0A, 0xBF, 0x38, 0x0F, 0x73, 0xD4, 0x39, 0x3F, 0x6F, 0xEA, 0x68,
			0xDA, 0x8C, 0x26, 0x81, 0xAA, 0x10, 0xC0, 0xFF, 0xDE, 0x88, 0x2D, 0x76,
			0xCB, 0xFD, 0xCD, 0x1D, 0x03, 0xC8, 0xC7, 0xB6, 0x54, 0x58, 0x06, 0xB8,
			0x5E, 0x25, 0x6E, 0xCC, 0xDC, 0x4B, 0xC4, 0x19, 0xE6, 0x89, 0xDE, 0xE7,
			0xAB, 0xEA, 0x10, 0x83, 0x6D, 0x07, 0xFA, 0xB2, 0xD4, 0x03, 0x20, 0x67,
			0xCD, 0xAE, 0xF0, 0x5C, 0x89, 0x46, 0x21, 0x0F, 0x61, 0x95, 0x9A, 0x44,
			0xAA, 0x46, 0x37, 0xA5, 0xB7, 0xBD, 0x27, 0xE5, 0x9E, 0x36, 0xC1, 0xEB,
			0x83, 0xD7, 0xFA, 0xE8, 0x66, 0x6A, 0xE1, 0x24, 0xD5, 0x0A, 0xD1, 0x86,
			0xEE, 0xF7, 0x3A, 0xEE, 0x8E, 0x42, 0x29, 0x8D, 0xA6, 0x08, 0xFB, 0x14,
			0x0F, 0xAA, 0xE1, 0xBF, 0x51, 0xB0, 0x1C, 0xA6, 0x34, 0x52, 0x1D, 0x6C,
			0x1C, 0x5D, 0xE7, 0xBE, 0x80, 0x31, 0x6C, 0x56, 0xF2, 0x34, 0xBA, 0xE1,
			0x99, 0xF3, 0x2C, 0x67, 0x0E, 0xF4, 0x0A, 0xD3, 0xF6, 0x4B, 0x2D, 0xB9,
			0xD1, 0x20, 0xAA, 0x42, 0xD6, 0xBF, 0x95, 0xEE, 0xD5, 0xA8, 0x4D, 0xC5,
			0x73, 0x1B, 0x02, 0xF0, 0x41, 0x3B, 0x49, 0xE2, 0x77, 0x06, 0xF5, 0x79,
			0x5E, 0xF4, 0x9D, 0x39, 0xAE, 0x6B, 0x6D, 0x1C, 0x6A, 0x2E, 0x35, 0x06,
			0xFD, 0xA7, 0xD2, 0x90, 0xAC, 0x8B, 0x6B, 0x80, 0x93, 0xB4, 0x14, 0x8A,
			0xC8, 0x8D, 0xD0, 0xE4, 0x5D, 0xC0, 0x14, 0x63, 0x53, 0x4E, 0x2D, 0x23,
			0xBE, 0xEC, 0x42, 0x4F, 0xA9, 0x2C, 0xC4, 0x79, 0x00, 0x00, 0x46, 0x4E,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xAE, 0x49, 0x0F, 0xA1,
			0x00, 0x00, 0x00, 0x00, 0x3F, 0x9A, 0x14, 0x02, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0xC2, 0x06, 0xB7, 0xA2, 0x80, 0x2A, 0x59, 0xEB, 0x53, 0x00, 0x75, 0x00,
			0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF, 0x00, 0x00,
			0x00, 0x15, 0x01, 0x00, 0x80, 0x2A, 0x59, 0xEB, 0x53, 0x00, 0x75, 0x00,
			0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF, 0x00, 0x00,
			0x00, 0x15, 0x01, 0x00, 0x80, 0x2A, 0x59, 0xEB, 0x53, 0x00, 0x75, 0x00,
			0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF, 0x00, 0x00,
			0x00, 0x15, 0x01, 0x00, 0xFF, 0xFF, 0x02, 0x00, 0x01, 0x00, 0x00, 0x00,
			0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
			0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x0A, 0x1E, 0x00,
			0xF7, 0x01, 0x43, 0x00, 0xDE, 0x9D, 0xB5, 0x0D, 0x80, 0x2A, 0x59, 0xEB,
			0x53, 0x00, 0x61, 0x00, 0x6D, 0x00, 0x75, 0x00, 0x72, 0x00, 0x6F, 0x00,
			0x74, 0x00, 0x74, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00,
			0x75, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF,
			0x00, 0x00, 0x5B, 0x00, 0x38, 0x00, 0x39, 0x00, 0x17, 0x01, 0x00, 0x00,
			0x02, 0x02, 0x39, 0x00, 0x6E, 0x1A, 0x98, 0x00, 0x80, 0x2A, 0x59, 0xEB,
			0x53, 0x00, 0x69, 0x00, 0x6D, 0x00, 0x69, 0x00, 0x73, 0x00, 0x65, 0x00,
			0x61, 0x00, 0x72, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00,
			0x75, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF,
			0x00, 0x00, 0xF2, 0x00, 0x7E, 0x00, 0x00, 0x02, 0xE1, 0x01, 0x00, 0x00,
			0x6D, 0x02, 0x35, 0x00, 0xD6, 0x54, 0x1F, 0xDA, 0x80, 0x2A, 0x59, 0xEB,
			0x44, 0x00, 0x72, 0x00, 0x75, 0x00, 0x64, 0x00, 0x64, 0x00, 0x69, 0x00,
			0x67, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x53, 0x00,
			0x75, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF,
			0x00, 0x00, 0xA3, 0x00, 0x90, 0x01, 0x51, 0x01, 0xAF, 0x01, 0x00, 0x00,
			0x63, 0x02, 0x28, 0x00, 0xDE, 0x2C, 0x7D, 0xBD, 0x80, 0x2A, 0x59, 0xEB,
			0x46, 0x00, 0x72, 0x00, 0x61, 0x00, 0x78, 0x00, 0x75, 0x00, 0x72, 0x00,
			0x65, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00,
			0x75, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF,
			0x00, 0x00, 0xCE, 0x00, 0x51, 0x01, 0x5D, 0x01, 0x0D, 0x01, 0x00, 0x00,
			0xF9, 0x01, 0x1C, 0x40, 0x08, 0xBD, 0x0E, 0xD7, 0x80, 0x2A, 0x59, 0xEB,
			0x57, 0x00, 0x61, 0x00, 0x74, 0x00, 0x63, 0x00, 0x68, 0x00, 0x6F, 0x00,
			0x67, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00,
			0x75, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF,
			0x00, 0x00, 0xF9, 0x00, 0x94, 0x00, 0x46, 0x00, 0x0F, 0x00, 0x00, 0x00,
			0x44, 0x02, 0x1C, 0x00, 0xB0, 0x9C, 0x9B, 0xDF, 0x80, 0x2A, 0x59, 0xEB,
			0x44, 0x00, 0x75, 0x00, 0x63, 0x00, 0x6B, 0x00, 0x6C, 0x00, 0x65, 0x00,
			0x74, 0x00, 0x74, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00,
			0x75, 0x00, 0x6C, 0x00, 0x6F, 0x00, 0x6B, 0x00, 0x75, 0x00, 0xFF, 0xFF,
			0x00, 0x00, 0x93, 0x01, 0x39, 0x00, 0x13, 0x00, 0x88, 0x01, 0x00, 0x00
		};

	}
}

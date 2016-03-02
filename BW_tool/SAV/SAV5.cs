//Base file from kaphotic's pkhex

using System;
using System.Linq;


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
	public class Crypto
    {
        public int start;
        public int length;
        public int seed;      
    }
	public class BlockInfo
    {
        public int Offset;
        public int Length;
        public int ID;
        public int updtcnt;
        public int Checksum;
        public bool encrypted;
        public Crypto crypto;       
    }
	public class SAV5 : PKX5
    {
    	private static int[] BlockTableBW2 =
		{0x00000, 0x00400, 0x01400, 0x02400, 0x03400, 0x04400, 0x05400, //6
		 0x06400, 0x07400, 0x08400, 0x09400, 0x0A400, 0x0B400, 0x0C400, //13
		 0x0D400, 0x0E400, 0x0F400, 0x10400, 0x11400, 0x12400, 0x13400, //20
		 0x14400, 0x15400, 0x16400, 0x17400, 0x18400, 0x18E00, 0x19400, //27
		 0x19500, 0x19600, 0x1AA00, 0x1B200, 0x1C000, 0x1C100, 0x1C800, //34
		 0x1D300, 0x1D500, 0x1D900, 0x1DA00, 0x1DC00, 0x1DD00, 0x1E200, //41
		 0x1F700, 0x1FA00, 0x1FB00, 0x1FF00, 0x20400, 0x20500, 0x20800, //48
		 0x20900, 0x20D00, 0x20F00, 0x21100, 0x21200, 0x21400, 0x21900, //55
		 0x21A00, 0x21B00, 0x21D00, 0x22900, 0x22A00, 0x23300, 0x23600, //62
		 0x23700, 0x23800, 0x23A00, 0x23B00, 0x23C00, 0x25300, 0x25800, //69
		 0x25900, 0x25A00, 0x25E00, 0x25F00}; //73
	
    	private static int[] BlockTableLengthBW2 =
		{0x3E0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, //6
		 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, //13
		 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0xFF0, //20
		 0xFF0, 0xFF0, 0xFF0, 0xFF0, 0x9EC, 0X534, 0xB0, //27
		 0xA8, 0x1338, 0x7C4, 0xD54, 0X94, 0x658, 0xA94, //34
		 0x1AC, 0x3EC, 0x5C, 0x1E0, 0xA8, 0x460, 0x1400, //41
		 0x2A4, 0xE0, 0x34C, 0x4E0, 0xF8, 0x2FC, 0x94, //48
		 0x35C, 0x1D4, 0x1E0, 0xF0, 0x1B4, 0x4DC, 0x34, //55
		 0X3C, 0x1AC, 0xB90, 0xAC, 0x850, 0x284, 0x10, //62
		 0xA8, 0x16C, 0x80, 0xFC, 0x16A8, 0x498, 0x60, //69
		 0xFC, 0x3E4, 0xF0, 0x94};
	
        internal const int SIZERAW = 0x80000; // 512KB
        internal const int SIZE1 = 0x24000; // B/W
        internal const int SIZE2 = 0x26000; // B2/W2

        // Global Settings
        // Save Data Attributes
        public byte[] Data;
        public bool Edited;
        public readonly bool Exportable;
        public readonly byte[] BAK;
        public string FileName, FilePath;
        public BlockInfo[] blocks = new BlockInfo[74];
        public bool B2W2;
        public bool BW;
        public SAV5(byte[] data)
        {
            Data = (byte[])(data ?? new byte[SIZERAW]).Clone();
            BAK = (byte[])Data.Clone();
            Exportable = !Data.SequenceEqual(new byte[Data.Length]);

            // Get Version
            // Validate Checksum over the Checksum Block to find BW or B2W2
            ushort chk2 = BitConverter.ToUInt16(Data, SIZE2 - 0x100 + 0x94 + 0xE);
            ushort actual2 = ccitt16(Data.Skip(SIZE2 - 0x100).Take(0x94).ToArray());
            B2W2 = chk2 == actual2;
            ushort chk1 = BitConverter.ToUInt16(Data, SIZE1 - 0x100 + 0x8C + 0xE);
            ushort actual1 = ccitt16(Data.Skip(SIZE1 - 0x100).Take(0x8C).ToArray());
            BW = chk1 == actual1;
			          
            if (!BW && !B2W2 && data != null){
                Data = null; // Invalid/Not G5 Save File
            }else if (B2W2)
            {
	
	           //Build blockinfos
	           int i;
	           for (i=0;i<74;i++)
	           {
	           		blocks[i] = new BlockInfo();
	           		blocks[i].crypto = new Crypto();
		           	blocks[i].Offset=BlockTableBW2[i];
	           		blocks[i].Length=BlockTableLengthBW2[i];
	           		blocks[i].ID= i;
	           		blocks[i].updtcnt=blocks[i].Offset+blocks[i].Length;
	           		if (i != 73)
	           		{
	           			blocks[i].Checksum=blocks[i].Offset+blocks[i].Length+2;
	           		}
	           		else
	           		{
	           			blocks[i].Checksum=0x25FA2;
	           		}
	           		switch (i)
	           		{
	           			case 60: //Entralink forest
	           				blocks[i].encrypted=true;
	           				blocks[i].crypto.start = 0x00;
	           				blocks[i].crypto.length = 0x84C;
	           				blocks[i].crypto.seed = 0x84C;
	           				break;
	           			default:
	           				blocks[i].encrypted=false;
	           				break;
	           		}	           	
	           }
	           
	            // Different Offsets for different games.
	            BattleBox = B2W2 ? 0x20A00 : 0x20900;
            }
        }

        private const int Box = 0x400;
        private const int Party = 0x18E00;
        private readonly int BattleBox;
        private const int Trainer = 0x19400;
        private const int Wondercard = 0x1C800;
        private const int wcSeed = 0x1D290;

        public byte[] getData(int Offset, int Length)
        {
            return Data.Skip(Offset).Take(Length).ToArray();
        }
        public byte[] getBlock(int index)
        {
        	if (B2W2)
        	{
        		if (index <73)
        		{
					return Data.Skip(blocks[index].Offset).Take(blocks[index+1].Offset-blocks[index].Offset).ToArray();
        		}
        		else if (index == 73)
        		{
	        		return Data.Skip(blocks[index].Offset).Take(SIZE2-blocks[index].Offset).ToArray();
        		}
        		else return null;
        	}
        	else return null;
        }
        public byte[] getBlockDec(int index)
        {
        	byte[] decrypt = new byte[getBlockLength(index)];
        	
        	if (B2W2)
        	{
        		if (index <73)
        		{
        			//MessageBox.Show(decrypt.Length.ToString());
        			//MessageBox.Show((blocks[index].Length-4).ToString());
        			decrypt = PKX5.cryptoArray(Data.Skip(blocks[index].Offset).Take(blocks[index+1].Offset-blocks[index].Offset).ToArray(), blocks[index].crypto.start, blocks[index].crypto.length, blocks[index].crypto.seed);
					//MessageBox.Show((blocks[index].Length-4).ToString());
        			return decrypt;
        		}
        		else if (index == 73)
        		{
	        		return Data.Skip(blocks[index].Offset).Take(SIZE2-blocks[index].Offset).ToArray();
        		}
        		else return null;
        	}
        	else return null;
        }
        public int getBlockLength(int index)
        {
        	if (B2W2){
	        	if (index < 73)
	        		return blocks[index+1].Offset-blocks[index].Offset;
	        	else if (index == 73)
	        		return SIZE2-blocks[index].Offset;
	        	else return -1;
        	}
        	else return -1;
        }
        public void setBlock(byte[] input, int index)
        {
        	if (getBlockLength(index) != input.Length)
        	{
        		MessageBox.Show("Block has invalid size!");
        		return;
        	}
        	
        	if (B2W2)
        	{
        		if (index <74)
        		{
        			//Recalculate checksum before applying to savedata
        			ushort crc = ccitt16(input.Take(blocks[index].Length).ToArray());
        			if (crc != BitConverter.ToUInt16(input, blocks[index].Checksum-blocks[index].Offset) )
        			{
        				Array.Copy(BitConverter.GetBytes(crc), 0, input, blocks[index].Checksum-blocks[index].Offset, 2);
        				MessageBox.Show("Block's checksum updated");
        			}else
        			{
        				MessageBox.Show("Checksum doesn't need update");
        			}


        			
					input.CopyTo(Data, blocks[index].Offset);
					input.CopyTo(Data, blocks[index].Offset+SIZE2);
					Edited = true;
        		}
        		else return;
        	}
        	else return;
        }
        public void setBlockCrypt(byte[] input, int index)
        {
        	if (getBlockLength(index) != input.Length)
        	{
        		MessageBox.Show("Block has invalid size!");
        		return;
        	}
        	
        	if (B2W2)
        	{
        		if (index <74)
        		{
        			//Encrypt
        			byte[] encrypt = new byte[getBlockLength(index)];
        			encrypt = PKX5.cryptoArray(input, blocks[index].crypto.start, blocks[index].crypto.length, blocks[index].crypto.seed);
        			
        			//Recalculate checksum before applying to savedata
        			ushort crc = ccitt16(encrypt.Take(blocks[index].Length).ToArray());
        			if (crc != BitConverter.ToUInt16(encrypt, blocks[index].Checksum-blocks[index].Offset) )
        			{
        				Array.Copy(BitConverter.GetBytes(crc), 0, encrypt, blocks[index].Checksum-blocks[index].Offset, 2);
        				MessageBox.Show("Block's checksum updated");
        			}else
        			{
        				MessageBox.Show("Checksum doesn't need update");
        			}
        			
					encrypt.CopyTo(Data, blocks[index].Offset);
					encrypt.CopyTo(Data, blocks[index].Offset+SIZE2);
					Edited = true;
        		}
        		else return;
        	}
        	else return;
        }
        public void setData(byte[] input, int Offset)
        {
            input.CopyTo(Data, Offset);
            Edited = true;
        }
        public void chkCheck(bool correct)
        {
        	int i = 0;
        	string badblocks;
        	badblocks = "Found bad checksums in MAIN save at blocks: ";
        	string correctedblocks;
        	correctedblocks = "Corrected checksums in MAIN save at blocks: ";
        	bool badcheck = false;
        	bool firstcorrect = false;
        	if (B2W2)
        	{
        		//Main save checksums
        		for(i=0; i<74; i++)
        		{
        			ushort crc = ccitt16(Data.Skip(blocks[i].Offset).Take(blocks[i].Length).ToArray());
        			if ( crc != BitConverter.ToUInt16(Data, blocks[i].Checksum) )
        			{
        				if (correct)
        				{
        					Array.Copy(BitConverter.GetBytes(crc), 0, Data, blocks[i].Checksum, 2);
	        				if (!firstcorrect)
	        				{
	        					firstcorrect = true;
	        					correctedblocks = correctedblocks + i.ToString();
	        				}else
	        				{
	        					correctedblocks = correctedblocks + ", " + i.ToString();
	        				}
        					Edited = true;
        				}
        				//Build bad checksum message
        				if (!badcheck)
        				{
        					badcheck = true;
        					badblocks = badblocks + i.ToString();
        				}else
        				{
        					badblocks = badblocks + ", " + i.ToString();
        				}
        			}
        			else
        			{
        				//MessageBox.Show("Checksum doesn't need update " + i.ToString());
        			}
        		}
        		
        		if(badcheck)
        		{
        			if (correct)
        				MessageBox.Show(correctedblocks);
        			else
        				MessageBox.Show(badblocks);
        		}
        		else
        			MessageBox.Show("All 74 checksums OK in MAIN save");

        		//Backup save checksums
        		badcheck = false;
        		badblocks = "Found bad checksums in BACKUP save at blocks: ";
        		firstcorrect = false;
        		correctedblocks = "Corrected checksums in BACKUP save at blocks: ";
        		for(i=0; i<74; i++)
        		{
        			ushort crc = ccitt16(Data.Skip(blocks[i].Offset+SIZE2).Take(blocks[i].Length).ToArray());
        			if ( crc != BitConverter.ToUInt16(Data, blocks[i].Checksum+SIZE2) )
        			{
        				if (correct)
        				{
        					Array.Copy(BitConverter.GetBytes(crc), 0, Data, blocks[i].Checksum+SIZE2, 2);
	        				if (!firstcorrect)
	        				{
	        					firstcorrect = true;
	        					correctedblocks = correctedblocks + i.ToString();
	        				}else
	        				{
	        					correctedblocks = correctedblocks + ", " + i.ToString();
	        				}
        					Edited = true;
        				}
        				//Build bad checksum message
        				if (!badcheck)
        				{
        					badcheck = true;
        					badblocks = badblocks + i.ToString();
        				}else
        				{
        					badblocks = badblocks + ", " + i.ToString();
        				}
        			}
        			else
        			{
        				//MessageBox.Show("Checksum doesn't need update " + i.ToString());
        			}
        		}
        		
        		if(badcheck)
        		{
        			if (correct)
        				MessageBox.Show(correctedblocks);
        			else
        				MessageBox.Show(badblocks);
        		}
        		else
        			MessageBox.Show("All 74 checksums OK in BACKUP save");
        		
        		return;
        	}
        	else if (BW)
        	{
        		MessageBox.Show("Not yet implemented for BW 1");
        	}
        	else
        	{
        		MessageBox.Show("Invalid file");
        		return;
        	}
        }
    }
}
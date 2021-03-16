/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 15/03/2021
 * Time: 20:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BW_tool
{
	partial class PropCase
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.Proplist = new System.Windows.Forms.ComboBox();
			this.hasprop_checkbox = new System.Windows.Forms.CheckBox();
			this.unloackAllBut = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.propHex = new System.Windows.Forms.Label();
			this.Exit_but = new System.Windows.Forms.Button();
			this.Saveexit_but = new System.Windows.Forms.Button();
			this.spriteBox = new System.Windows.Forms.PictureBox();
			this.removeAllBut = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.spriteBox)).BeginInit();
			this.SuspendLayout();
			// 
			// Proplist
			// 
			this.Proplist.FormattingEnabled = true;
			this.Proplist.Items.AddRange(new object[] {
									"Pink Barrette",
									"Blue Barrette",
									"Red Barrette",
									"Blue Flower",
									"Crimson Scarf",
									"Red Flower",
									"Big Barrette",
									"Headband",
									"Square Glasses",
									"Striped Barrette",
									"Small Barrette",
									"Decorative Ribbon",
									"Purse",
									"Necklace",
									"Gorgeous Flower",
									"Round Button",
									"Green Barrette",
									"Straw Hat",
									"Snow Crystal",
									"Lonely Flower",
									"Paintbrush",
									"Beret",
									"Whisk",
									"Ladle",
									"Toy Cake",
									"Chef\'s Hat",
									"Frying Pan",
									"Bib",
									"Red Parasol",
									"Germ Mask",
									"Mallet",
									"Colorful Parasol",
									"Wrench",
									"Lantern",
									"Windup Key",
									"Helmet",
									"Frilly Apron",
									"Dressy Tie",
									"Lace Cap",
									"Scarlet Cape",
									"Toy Cutlass",
									"Toy Sword",
									"Pirate Hat",
									"Cowboy Hat",
									"Rigid Shield",
									"Black Wings",
									"Witchy Hat",
									"White Wings",
									"Umber Belt",
									"Horned Helm",
									"Trident",
									"Magic Wand",
									"Red Nose",
									"Jester\'s Cap",
									"Googly Specs",
									"Crown",
									"Black Tie",
									"Black Cape",
									"Gorgeous Specs",
									"Top Hat",
									"White Domino Mask",
									"White Cape",
									"Gentleman\'s Hat",
									"Cane",
									"Striped Tie",
									"Pocket Watch",
									"Bowtie",
									"Tiara",
									"Rose",
									"Monocle",
									"Tie",
									"Wig",
									"Standing Mike",
									"Tambourine",
									"Fedora",
									"Microphone",
									"Maraca",
									"Trumpet",
									"Laurel Wreath",
									"White Pompom",
									"Pennant",
									"Football",
									"Winner\'s Belt",
									"Racket",
									"Electric Guitar",
									"Toy Fishing Rod",
									"Smiley-Face Mask",
									"Fake Belly Button",
									"Professor Hat",
									"Hula Skirt",
									"Thick Book",
									"Bouquet",
									"Fake Bone",
									"Round Mushroom",
									"Shuriken",
									"Scarlet Hat",
									"Big Bag",
									"Candy",
									"Fluffy Beard",
									"Gift Box"});
			this.Proplist.Location = new System.Drawing.Point(26, 28);
			this.Proplist.Name = "Proplist";
			this.Proplist.Size = new System.Drawing.Size(121, 21);
			this.Proplist.TabIndex = 0;
			this.Proplist.SelectedIndexChanged += new System.EventHandler(this.ProplistSelectedIndexChanged);
			// 
			// hasprop_checkbox
			// 
			this.hasprop_checkbox.Location = new System.Drawing.Point(168, 28);
			this.hasprop_checkbox.Name = "hasprop_checkbox";
			this.hasprop_checkbox.Size = new System.Drawing.Size(104, 24);
			this.hasprop_checkbox.TabIndex = 1;
			this.hasprop_checkbox.Text = "Obtained";
			this.hasprop_checkbox.UseVisualStyleBackColor = true;
			this.hasprop_checkbox.CheckedChanged += new System.EventHandler(this.Hasprop_checkboxCheckedChanged);
			// 
			// unloackAllBut
			// 
			this.unloackAllBut.Location = new System.Drawing.Point(26, 68);
			this.unloackAllBut.Name = "unloackAllBut";
			this.unloackAllBut.Size = new System.Drawing.Size(102, 23);
			this.unloackAllBut.TabIndex = 2;
			this.unloackAllBut.Text = "Unlock all";
			this.unloackAllBut.UseVisualStyleBackColor = true;
			this.unloackAllBut.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(26, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Hex value:";
			// 
			// propHex
			// 
			this.propHex.Location = new System.Drawing.Point(93, 94);
			this.propHex.Name = "propHex";
			this.propHex.Size = new System.Drawing.Size(290, 23);
			this.propHex.TabIndex = 4;
			this.propHex.Text = "0x";
			// 
			// Exit_but
			// 
			this.Exit_but.Location = new System.Drawing.Point(26, 111);
			this.Exit_but.Name = "Exit_but";
			this.Exit_but.Size = new System.Drawing.Size(102, 23);
			this.Exit_but.TabIndex = 21;
			this.Exit_but.Text = "Exit";
			this.Exit_but.UseVisualStyleBackColor = true;
			this.Exit_but.Click += new System.EventHandler(this.Exit_butClick);
			// 
			// Saveexit_but
			// 
			this.Saveexit_but.Location = new System.Drawing.Point(133, 111);
			this.Saveexit_but.Name = "Saveexit_but";
			this.Saveexit_but.Size = new System.Drawing.Size(102, 23);
			this.Saveexit_but.TabIndex = 20;
			this.Saveexit_but.Text = "Save and Exit";
			this.Saveexit_but.UseVisualStyleBackColor = true;
			this.Saveexit_but.Click += new System.EventHandler(this.Saveexit_butClick);
			// 
			// spriteBox
			// 
			this.spriteBox.Location = new System.Drawing.Point(254, 18);
			this.spriteBox.Name = "spriteBox";
			this.spriteBox.Size = new System.Drawing.Size(129, 73);
			this.spriteBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.spriteBox.TabIndex = 22;
			this.spriteBox.TabStop = false;
			// 
			// removeAllBut
			// 
			this.removeAllBut.Location = new System.Drawing.Point(133, 68);
			this.removeAllBut.Name = "removeAllBut";
			this.removeAllBut.Size = new System.Drawing.Size(102, 23);
			this.removeAllBut.TabIndex = 23;
			this.removeAllBut.Text = "Remove all";
			this.removeAllBut.UseVisualStyleBackColor = true;
			this.removeAllBut.Click += new System.EventHandler(this.RemoveAllButClick);
			// 
			// PropCase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 141);
			this.Controls.Add(this.removeAllBut);
			this.Controls.Add(this.unloackAllBut);
			this.Controls.Add(this.spriteBox);
			this.Controls.Add(this.Exit_but);
			this.Controls.Add(this.Saveexit_but);
			this.Controls.Add(this.propHex);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.hasprop_checkbox);
			this.Controls.Add(this.Proplist);
			this.Name = "PropCase";
			this.Text = "Props Case editor";
			((System.ComponentModel.ISupportInitialize)(this.spriteBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button removeAllBut;
		private System.Windows.Forms.PictureBox spriteBox;
		private System.Windows.Forms.Button Saveexit_but;
		private System.Windows.Forms.Button Exit_but;
		private System.Windows.Forms.Label propHex;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button unloackAllBut;
		private System.Windows.Forms.CheckBox hasprop_checkbox;
		private System.Windows.Forms.ComboBox Proplist;
	}
}

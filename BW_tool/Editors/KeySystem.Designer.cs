/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 08/03/2016
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BW_tool
{
	partial class KeySystem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox icebergkeybox;
		private System.Windows.Forms.CheckBox easykeybox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox ironkeybox;
		private System.Windows.Forms.CheckBox challengekeybox;
		private System.Windows.Forms.CheckBox citykeybox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox challengemodebox;
		private System.Windows.Forms.CheckBox easymodebox;
		private System.Windows.Forms.CheckBox icebergbox;
		private System.Windows.Forms.CheckBox ironbox;
		private System.Windows.Forms.CheckBox citybox;
		private System.Windows.Forms.RadioButton cfg_chamber_ice;
		private System.Windows.Forms.RadioButton cfg_chamber_iron;
		private System.Windows.Forms.RadioButton cfg_chamber_rock;
		private System.Windows.Forms.RadioButton cfg_chamber_def;
		private System.Windows.Forms.RadioButton cfg_city_foreing;
		private System.Windows.Forms.RadioButton cfg_city_game;
		private System.Windows.Forms.RadioButton cfg_city_def;
		private System.Windows.Forms.RadioButton cfg_mode_3;
		private System.Windows.Forms.RadioButton cfg_mode_2;
		private System.Windows.Forms.RadioButton cfg_mode_1;
		private System.Windows.Forms.RadioButton cfg_mode_def;
		private System.Windows.Forms.Button Saveexit_but;
		private System.Windows.Forms.Button Exit_but;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.icebergkeybox = new System.Windows.Forms.CheckBox();
			this.easykeybox = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ironkeybox = new System.Windows.Forms.CheckBox();
			this.challengekeybox = new System.Windows.Forms.CheckBox();
			this.citykeybox = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.icebergbox = new System.Windows.Forms.CheckBox();
			this.ironbox = new System.Windows.Forms.CheckBox();
			this.citybox = new System.Windows.Forms.CheckBox();
			this.challengemodebox = new System.Windows.Forms.CheckBox();
			this.easymodebox = new System.Windows.Forms.CheckBox();
			this.Saveexit_but = new System.Windows.Forms.Button();
			this.Exit_but = new System.Windows.Forms.Button();
			this.cfg_mode_def = new System.Windows.Forms.RadioButton();
			this.cfg_mode_1 = new System.Windows.Forms.RadioButton();
			this.cfg_mode_2 = new System.Windows.Forms.RadioButton();
			this.cfg_mode_3 = new System.Windows.Forms.RadioButton();
			this.cfg_city_def = new System.Windows.Forms.RadioButton();
			this.cfg_city_game = new System.Windows.Forms.RadioButton();
			this.cfg_city_foreing = new System.Windows.Forms.RadioButton();
			this.cfg_chamber_def = new System.Windows.Forms.RadioButton();
			this.cfg_chamber_rock = new System.Windows.Forms.RadioButton();
			this.cfg_chamber_iron = new System.Windows.Forms.RadioButton();
			this.cfg_chamber_ice = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.icebergkeybox);
			this.groupBox1.Controls.Add(this.easykeybox);
			this.groupBox1.Location = new System.Drawing.Point(23, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(210, 77);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "White 2 Keys";
			// 
			// icebergkeybox
			// 
			this.icebergkeybox.Location = new System.Drawing.Point(6, 43);
			this.icebergkeybox.Name = "icebergkeybox";
			this.icebergkeybox.Size = new System.Drawing.Size(141, 24);
			this.icebergkeybox.TabIndex = 1;
			this.icebergkeybox.Text = "Iceberg Chamber Key";
			this.icebergkeybox.UseVisualStyleBackColor = true;
			// 
			// easykeybox
			// 
			this.easykeybox.Location = new System.Drawing.Point(6, 19);
			this.easykeybox.Name = "easykeybox";
			this.easykeybox.Size = new System.Drawing.Size(104, 24);
			this.easykeybox.TabIndex = 0;
			this.easykeybox.Text = "Easy Mode Key";
			this.easykeybox.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ironkeybox);
			this.groupBox2.Controls.Add(this.challengekeybox);
			this.groupBox2.Location = new System.Drawing.Point(239, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(210, 77);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Black 2 Keys";
			// 
			// ironkeybox
			// 
			this.ironkeybox.Location = new System.Drawing.Point(6, 43);
			this.ironkeybox.Name = "ironkeybox";
			this.ironkeybox.Size = new System.Drawing.Size(141, 24);
			this.ironkeybox.TabIndex = 2;
			this.ironkeybox.Text = "Iron Chamber Key";
			this.ironkeybox.UseVisualStyleBackColor = true;
			// 
			// challengekeybox
			// 
			this.challengekeybox.Location = new System.Drawing.Point(6, 19);
			this.challengekeybox.Name = "challengekeybox";
			this.challengekeybox.Size = new System.Drawing.Size(104, 24);
			this.challengekeybox.TabIndex = 1;
			this.challengekeybox.Text = "Challenge Mode Key";
			this.challengekeybox.UseVisualStyleBackColor = true;
			// 
			// citykeybox
			// 
			this.citykeybox.Location = new System.Drawing.Point(164, 95);
			this.citykeybox.Name = "citykeybox";
			this.citykeybox.Size = new System.Drawing.Size(138, 24);
			this.citykeybox.TabIndex = 2;
			this.citykeybox.Text = "Tower/Treehollow Key";
			this.citykeybox.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.icebergbox);
			this.groupBox3.Controls.Add(this.ironbox);
			this.groupBox3.Controls.Add(this.citybox);
			this.groupBox3.Controls.Add(this.challengemodebox);
			this.groupBox3.Controls.Add(this.easymodebox);
			this.groupBox3.Location = new System.Drawing.Point(29, 125);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(423, 79);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Unlockables";
			// 
			// icebergbox
			// 
			this.icebergbox.Location = new System.Drawing.Point(291, 42);
			this.icebergbox.Name = "icebergbox";
			this.icebergbox.Size = new System.Drawing.Size(115, 24);
			this.icebergbox.TabIndex = 6;
			this.icebergbox.Text = "Iceberg Chamber";
			this.icebergbox.UseVisualStyleBackColor = true;
			// 
			// ironbox
			// 
			this.ironbox.Location = new System.Drawing.Point(291, 19);
			this.ironbox.Name = "ironbox";
			this.ironbox.Size = new System.Drawing.Size(104, 24);
			this.ironbox.TabIndex = 5;
			this.ironbox.Text = "Iron Chamber";
			this.ironbox.UseVisualStyleBackColor = true;
			// 
			// citybox
			// 
			this.citybox.Location = new System.Drawing.Point(139, 19);
			this.citybox.Name = "citybox";
			this.citybox.Size = new System.Drawing.Size(146, 24);
			this.citybox.TabIndex = 4;
			this.citybox.Text = "Black City/White Forest";
			this.citybox.UseVisualStyleBackColor = true;
			// 
			// challengemodebox
			// 
			this.challengemodebox.Location = new System.Drawing.Point(6, 42);
			this.challengemodebox.Name = "challengemodebox";
			this.challengemodebox.Size = new System.Drawing.Size(104, 24);
			this.challengemodebox.TabIndex = 3;
			this.challengemodebox.Text = "Challenge Mode";
			this.challengemodebox.UseVisualStyleBackColor = true;
			// 
			// easymodebox
			// 
			this.easymodebox.Location = new System.Drawing.Point(6, 19);
			this.easymodebox.Name = "easymodebox";
			this.easymodebox.Size = new System.Drawing.Size(104, 24);
			this.easymodebox.TabIndex = 2;
			this.easymodebox.Text = "Easy Mode";
			this.easymodebox.UseVisualStyleBackColor = true;
			// 
			// Saveexit_but
			// 
			this.Saveexit_but.Location = new System.Drawing.Point(350, 334);
			this.Saveexit_but.Name = "Saveexit_but";
			this.Saveexit_but.Size = new System.Drawing.Size(102, 23);
			this.Saveexit_but.TabIndex = 5;
			this.Saveexit_but.Text = "Save and Exit";
			this.Saveexit_but.UseVisualStyleBackColor = true;
			this.Saveexit_but.Click += new System.EventHandler(this.Saveexit_butClick);
			// 
			// Exit_but
			// 
			this.Exit_but.Location = new System.Drawing.Point(29, 334);
			this.Exit_but.Name = "Exit_but";
			this.Exit_but.Size = new System.Drawing.Size(102, 23);
			this.Exit_but.TabIndex = 6;
			this.Exit_but.Text = "Exit";
			this.Exit_but.UseVisualStyleBackColor = true;
			this.Exit_but.Click += new System.EventHandler(this.Exit_butClick);
			// 
			// cfg_mode_def
			// 
			this.cfg_mode_def.Enabled = false;
			this.cfg_mode_def.Location = new System.Drawing.Point(6, 16);
			this.cfg_mode_def.Name = "cfg_mode_def";
			this.cfg_mode_def.Size = new System.Drawing.Size(104, 24);
			this.cfg_mode_def.TabIndex = 0;
			this.cfg_mode_def.TabStop = true;
			this.cfg_mode_def.Text = "Default";
			this.cfg_mode_def.UseVisualStyleBackColor = true;
			// 
			// cfg_mode_1
			// 
			this.cfg_mode_1.Enabled = false;
			this.cfg_mode_1.Location = new System.Drawing.Point(6, 36);
			this.cfg_mode_1.Name = "cfg_mode_1";
			this.cfg_mode_1.Size = new System.Drawing.Size(104, 24);
			this.cfg_mode_1.TabIndex = 1;
			this.cfg_mode_1.TabStop = true;
			this.cfg_mode_1.Text = "Easy Mode";
			this.cfg_mode_1.UseVisualStyleBackColor = true;
			// 
			// cfg_mode_2
			// 
			this.cfg_mode_2.Enabled = false;
			this.cfg_mode_2.Location = new System.Drawing.Point(6, 55);
			this.cfg_mode_2.Name = "cfg_mode_2";
			this.cfg_mode_2.Size = new System.Drawing.Size(104, 24);
			this.cfg_mode_2.TabIndex = 2;
			this.cfg_mode_2.TabStop = true;
			this.cfg_mode_2.Text = "Normal Mode";
			this.cfg_mode_2.UseVisualStyleBackColor = true;
			// 
			// cfg_mode_3
			// 
			this.cfg_mode_3.Enabled = false;
			this.cfg_mode_3.Location = new System.Drawing.Point(6, 74);
			this.cfg_mode_3.Name = "cfg_mode_3";
			this.cfg_mode_3.Size = new System.Drawing.Size(104, 24);
			this.cfg_mode_3.TabIndex = 3;
			this.cfg_mode_3.TabStop = true;
			this.cfg_mode_3.Text = "Challenge Mode";
			this.cfg_mode_3.UseVisualStyleBackColor = true;
			// 
			// cfg_city_def
			// 
			this.cfg_city_def.Enabled = false;
			this.cfg_city_def.Location = new System.Drawing.Point(13, 17);
			this.cfg_city_def.Name = "cfg_city_def";
			this.cfg_city_def.Size = new System.Drawing.Size(104, 23);
			this.cfg_city_def.TabIndex = 4;
			this.cfg_city_def.TabStop = true;
			this.cfg_city_def.Text = "Default";
			this.cfg_city_def.UseVisualStyleBackColor = true;
			// 
			// cfg_city_game
			// 
			this.cfg_city_game.Enabled = false;
			this.cfg_city_game.Location = new System.Drawing.Point(13, 38);
			this.cfg_city_game.Name = "cfg_city_game";
			this.cfg_city_game.Size = new System.Drawing.Size(104, 20);
			this.cfg_city_game.TabIndex = 5;
			this.cfg_city_game.TabStop = true;
			this.cfg_city_game.Text = "Game\'s City";
			this.cfg_city_game.UseVisualStyleBackColor = true;
			// 
			// cfg_city_foreing
			// 
			this.cfg_city_foreing.Enabled = false;
			this.cfg_city_foreing.Location = new System.Drawing.Point(13, 56);
			this.cfg_city_foreing.Name = "cfg_city_foreing";
			this.cfg_city_foreing.Size = new System.Drawing.Size(104, 22);
			this.cfg_city_foreing.TabIndex = 6;
			this.cfg_city_foreing.TabStop = true;
			this.cfg_city_foreing.Text = "Foreign City";
			this.cfg_city_foreing.UseVisualStyleBackColor = true;
			// 
			// cfg_chamber_def
			// 
			this.cfg_chamber_def.Enabled = false;
			this.cfg_chamber_def.Location = new System.Drawing.Point(22, 16);
			this.cfg_chamber_def.Name = "cfg_chamber_def";
			this.cfg_chamber_def.Size = new System.Drawing.Size(104, 24);
			this.cfg_chamber_def.TabIndex = 7;
			this.cfg_chamber_def.TabStop = true;
			this.cfg_chamber_def.Text = "Default";
			this.cfg_chamber_def.UseVisualStyleBackColor = true;
			// 
			// cfg_chamber_rock
			// 
			this.cfg_chamber_rock.Enabled = false;
			this.cfg_chamber_rock.Location = new System.Drawing.Point(22, 36);
			this.cfg_chamber_rock.Name = "cfg_chamber_rock";
			this.cfg_chamber_rock.Size = new System.Drawing.Size(104, 24);
			this.cfg_chamber_rock.TabIndex = 8;
			this.cfg_chamber_rock.TabStop = true;
			this.cfg_chamber_rock.Text = "Rock Chamber";
			this.cfg_chamber_rock.UseVisualStyleBackColor = true;
			// 
			// cfg_chamber_iron
			// 
			this.cfg_chamber_iron.Enabled = false;
			this.cfg_chamber_iron.Location = new System.Drawing.Point(22, 55);
			this.cfg_chamber_iron.Name = "cfg_chamber_iron";
			this.cfg_chamber_iron.Size = new System.Drawing.Size(104, 24);
			this.cfg_chamber_iron.TabIndex = 9;
			this.cfg_chamber_iron.TabStop = true;
			this.cfg_chamber_iron.Text = "Iron Chamber";
			this.cfg_chamber_iron.UseVisualStyleBackColor = true;
			// 
			// cfg_chamber_ice
			// 
			this.cfg_chamber_ice.Enabled = false;
			this.cfg_chamber_ice.Location = new System.Drawing.Point(22, 74);
			this.cfg_chamber_ice.Name = "cfg_chamber_ice";
			this.cfg_chamber_ice.Size = new System.Drawing.Size(115, 24);
			this.cfg_chamber_ice.TabIndex = 10;
			this.cfg_chamber_ice.TabStop = true;
			this.cfg_chamber_ice.Text = "Iceberg Chamber";
			this.cfg_chamber_ice.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cfg_mode_3);
			this.groupBox4.Controls.Add(this.cfg_mode_2);
			this.groupBox4.Controls.Add(this.cfg_mode_def);
			this.groupBox4.Controls.Add(this.cfg_mode_1);
			this.groupBox4.Location = new System.Drawing.Point(29, 213);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(116, 100);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Difficulty config:";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cfg_city_foreing);
			this.groupBox5.Controls.Add(this.cfg_city_game);
			this.groupBox5.Controls.Add(this.cfg_city_def);
			this.groupBox5.Location = new System.Drawing.Point(151, 213);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(136, 100);
			this.groupBox5.TabIndex = 12;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "City config:";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cfg_chamber_iron);
			this.groupBox6.Controls.Add(this.cfg_chamber_rock);
			this.groupBox6.Controls.Add(this.cfg_chamber_def);
			this.groupBox6.Controls.Add(this.cfg_chamber_ice);
			this.groupBox6.Location = new System.Drawing.Point(293, 213);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(159, 100);
			this.groupBox6.TabIndex = 13;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Chamber config:";
			// 
			// KeySystem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 369);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.Exit_but);
			this.Controls.Add(this.Saveexit_but);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.citykeybox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "KeySystem";
			this.Text = "KeySystem";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}

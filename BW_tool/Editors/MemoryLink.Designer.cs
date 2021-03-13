/*
 * Created by SharpDevelop.
 * User: LAURA
 * Date: 19/06/2016
 * Time: 10:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BW_tool
{
	partial class MemoryLink
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button Exit_but;
		private System.Windows.Forms.Button Saveexit_but;
		private System.Windows.Forms.Button b1_export;
		private System.Windows.Forms.Button b1m_export;
		private System.Windows.Forms.Button b2_export;
		private System.Windows.Forms.Button b2_import;
		private System.Windows.Forms.Button b1m_import;
		private System.Windows.Forms.Button b1_import;
		private System.Windows.Forms.Button memory_export;
		private System.Windows.Forms.Button memory_import;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown sid;
		private System.Windows.Forms.NumericUpDown tid;
		private System.Windows.Forms.CheckBox flag8;
		private System.Windows.Forms.CheckBox flag7;
		private System.Windows.Forms.CheckBox flag6;
		private System.Windows.Forms.CheckBox flag5;
		private System.Windows.Forms.CheckBox flag4;
		private System.Windows.Forms.CheckBox flag3;
		private System.Windows.Forms.CheckBox flag2;
		private System.Windows.Forms.CheckBox flag1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button import_bw1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		
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
			this.Exit_but = new System.Windows.Forms.Button();
			this.Saveexit_but = new System.Windows.Forms.Button();
			this.b1_export = new System.Windows.Forms.Button();
			this.b1m_export = new System.Windows.Forms.Button();
			this.b2_export = new System.Windows.Forms.Button();
			this.b2_import = new System.Windows.Forms.Button();
			this.b1m_import = new System.Windows.Forms.Button();
			this.b1_import = new System.Windows.Forms.Button();
			this.memory_export = new System.Windows.Forms.Button();
			this.memory_import = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.name = new System.Windows.Forms.TextBox();
			this.sid = new System.Windows.Forms.NumericUpDown();
			this.tid = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.flag8 = new System.Windows.Forms.CheckBox();
			this.flag7 = new System.Windows.Forms.CheckBox();
			this.flag6 = new System.Windows.Forms.CheckBox();
			this.flag5 = new System.Windows.Forms.CheckBox();
			this.flag4 = new System.Windows.Forms.CheckBox();
			this.flag3 = new System.Windows.Forms.CheckBox();
			this.flag2 = new System.Windows.Forms.CheckBox();
			this.flag1 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.import_bw1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.starter = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tid)).BeginInit();
			this.SuspendLayout();
			// 
			// Exit_but
			// 
			this.Exit_but.Location = new System.Drawing.Point(30, 282);
			this.Exit_but.Name = "Exit_but";
			this.Exit_but.Size = new System.Drawing.Size(102, 23);
			this.Exit_but.TabIndex = 21;
			this.Exit_but.Text = "Exit";
			this.Exit_but.UseVisualStyleBackColor = true;
			this.Exit_but.Click += new System.EventHandler(this.Exit_butClick);
			// 
			// Saveexit_but
			// 
			this.Saveexit_but.Location = new System.Drawing.Point(137, 282);
			this.Saveexit_but.Name = "Saveexit_but";
			this.Saveexit_but.Size = new System.Drawing.Size(102, 23);
			this.Saveexit_but.TabIndex = 20;
			this.Saveexit_but.Text = "Save and Exit";
			this.Saveexit_but.UseVisualStyleBackColor = true;
			this.Saveexit_but.Click += new System.EventHandler(this.Saveexit_butClick);
			// 
			// b1_export
			// 
			this.b1_export.Location = new System.Drawing.Point(6, 19);
			this.b1_export.Name = "b1_export";
			this.b1_export.Size = new System.Drawing.Size(119, 37);
			this.b1_export.TabIndex = 22;
			this.b1_export.Text = "Export Block 1 (decrypted)";
			this.b1_export.UseVisualStyleBackColor = true;
			this.b1_export.Click += new System.EventHandler(this.B1_exportClick);
			// 
			// b1m_export
			// 
			this.b1m_export.Location = new System.Drawing.Point(6, 62);
			this.b1m_export.Name = "b1m_export";
			this.b1m_export.Size = new System.Drawing.Size(119, 37);
			this.b1m_export.TabIndex = 23;
			this.b1m_export.Text = "Export Block 1 Mirror (decrypted)";
			this.b1m_export.UseVisualStyleBackColor = true;
			this.b1m_export.Click += new System.EventHandler(this.B1m_exportClick);
			// 
			// b2_export
			// 
			this.b2_export.Location = new System.Drawing.Point(6, 105);
			this.b2_export.Name = "b2_export";
			this.b2_export.Size = new System.Drawing.Size(119, 37);
			this.b2_export.TabIndex = 24;
			this.b2_export.Text = "Export Block 2";
			this.b2_export.UseVisualStyleBackColor = true;
			this.b2_export.Click += new System.EventHandler(this.B2_exportClick);
			// 
			// b2_import
			// 
			this.b2_import.Location = new System.Drawing.Point(131, 105);
			this.b2_import.Name = "b2_import";
			this.b2_import.Size = new System.Drawing.Size(119, 37);
			this.b2_import.TabIndex = 27;
			this.b2_import.Text = "Import Block 2";
			this.b2_import.UseVisualStyleBackColor = true;
			this.b2_import.Click += new System.EventHandler(this.B2_importClick);
			// 
			// b1m_import
			// 
			this.b1m_import.Location = new System.Drawing.Point(131, 62);
			this.b1m_import.Name = "b1m_import";
			this.b1m_import.Size = new System.Drawing.Size(119, 37);
			this.b1m_import.TabIndex = 26;
			this.b1m_import.Text = "Import Block 1 Mirror (decrypted)";
			this.b1m_import.UseVisualStyleBackColor = true;
			this.b1m_import.Click += new System.EventHandler(this.B1m_importClick);
			// 
			// b1_import
			// 
			this.b1_import.Location = new System.Drawing.Point(131, 19);
			this.b1_import.Name = "b1_import";
			this.b1_import.Size = new System.Drawing.Size(119, 37);
			this.b1_import.TabIndex = 25;
			this.b1_import.Text = "Import Block 1 (decrypted)";
			this.b1_import.UseVisualStyleBackColor = true;
			this.b1_import.Click += new System.EventHandler(this.B1_importClick);
			// 
			// memory_export
			// 
			this.memory_export.Location = new System.Drawing.Point(12, 12);
			this.memory_export.Name = "memory_export";
			this.memory_export.Size = new System.Drawing.Size(119, 37);
			this.memory_export.TabIndex = 29;
			this.memory_export.Text = "Export Memories";
			this.memory_export.UseVisualStyleBackColor = true;
			this.memory_export.Click += new System.EventHandler(this.Memory_exportClick);
			// 
			// memory_import
			// 
			this.memory_import.Location = new System.Drawing.Point(137, 12);
			this.memory_import.Name = "memory_import";
			this.memory_import.Size = new System.Drawing.Size(119, 37);
			this.memory_import.TabIndex = 28;
			this.memory_import.Text = "Import Memories";
			this.memory_import.UseVisualStyleBackColor = true;
			this.memory_import.Click += new System.EventHandler(this.Memory_importClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.b2_import);
			this.groupBox1.Controls.Add(this.b1m_import);
			this.groupBox1.Controls.Add(this.b1_import);
			this.groupBox1.Controls.Add(this.b2_export);
			this.groupBox1.Controls.Add(this.b1m_export);
			this.groupBox1.Controls.Add(this.b1_export);
			this.groupBox1.Location = new System.Drawing.Point(391, 149);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(256, 156);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Research Purposes";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(116, 74);
			this.name.MaxLength = 8;
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(120, 20);
			this.name.TabIndex = 36;
			// 
			// sid
			// 
			this.sid.Location = new System.Drawing.Point(117, 126);
			this.sid.Maximum = new decimal(new int[] {
									65535,
									0,
									0,
									0});
			this.sid.Name = "sid";
			this.sid.Size = new System.Drawing.Size(120, 20);
			this.sid.TabIndex = 35;
			// 
			// tid
			// 
			this.tid.Location = new System.Drawing.Point(117, 100);
			this.tid.Maximum = new decimal(new int[] {
									65535,
									0,
									0,
									0});
			this.tid.Name = "tid";
			this.tid.Size = new System.Drawing.Size(120, 20);
			this.tid.TabIndex = 34;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(34, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 23);
			this.label3.TabIndex = 33;
			this.label3.Text = "SID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(34, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 23);
			this.label2.TabIndex = 32;
			this.label2.Text = "TID";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(34, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 23);
			this.label1.TabIndex = 31;
			this.label1.Text = "Name";
			// 
			// flag8
			// 
			this.flag8.Location = new System.Drawing.Point(205, 247);
			this.flag8.Name = "flag8";
			this.flag8.Size = new System.Drawing.Size(164, 29);
			this.flag8.TabIndex = 44;
			this.flag8.Text = "flag 8";
			this.flag8.UseVisualStyleBackColor = true;
			// 
			// flag7
			// 
			this.flag7.Location = new System.Drawing.Point(205, 221);
			this.flag7.Name = "flag7";
			this.flag7.Size = new System.Drawing.Size(125, 29);
			this.flag7.TabIndex = 43;
			this.flag7.Text = "flag 7";
			this.flag7.UseVisualStyleBackColor = true;
			// 
			// flag6
			// 
			this.flag6.Location = new System.Drawing.Point(205, 195);
			this.flag6.Name = "flag6";
			this.flag6.Size = new System.Drawing.Size(125, 29);
			this.flag6.TabIndex = 42;
			this.flag6.Text = "flag 6";
			this.flag6.UseVisualStyleBackColor = true;
			// 
			// flag5
			// 
			this.flag5.Location = new System.Drawing.Point(205, 169);
			this.flag5.Name = "flag5";
			this.flag5.Size = new System.Drawing.Size(125, 29);
			this.flag5.TabIndex = 41;
			this.flag5.Text = "flag 5";
			this.flag5.UseVisualStyleBackColor = true;
			// 
			// flag4
			// 
			this.flag4.Location = new System.Drawing.Point(53, 247);
			this.flag4.Name = "flag4";
			this.flag4.Size = new System.Drawing.Size(125, 29);
			this.flag4.TabIndex = 40;
			this.flag4.Text = "flag 4";
			this.flag4.UseVisualStyleBackColor = true;
			// 
			// flag3
			// 
			this.flag3.Location = new System.Drawing.Point(53, 221);
			this.flag3.Name = "flag3";
			this.flag3.Size = new System.Drawing.Size(125, 29);
			this.flag3.TabIndex = 39;
			this.flag3.Text = "flag 3";
			this.flag3.UseVisualStyleBackColor = true;
			// 
			// flag2
			// 
			this.flag2.Location = new System.Drawing.Point(53, 195);
			this.flag2.Name = "flag2";
			this.flag2.Size = new System.Drawing.Size(125, 29);
			this.flag2.TabIndex = 38;
			this.flag2.Text = "flag 2";
			this.flag2.UseVisualStyleBackColor = true;
			// 
			// flag1
			// 
			this.flag1.Location = new System.Drawing.Point(53, 169);
			this.flag1.Name = "flag1";
			this.flag1.Size = new System.Drawing.Size(125, 29);
			this.flag1.TabIndex = 37;
			this.flag1.Text = "A Triple Team";
			this.flag1.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(306, 19);
			this.label4.TabIndex = 45;
			this.label4.Text = "Unlocked Memories: (still under research, better not to touch)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// import_bw1
			// 
			this.import_bw1.Location = new System.Drawing.Point(273, 12);
			this.import_bw1.Name = "import_bw1";
			this.import_bw1.Size = new System.Drawing.Size(119, 37);
			this.import_bw1.TabIndex = 46;
			this.import_bw1.Text = "Import data from BW1";
			this.import_bw1.UseVisualStyleBackColor = true;
			this.import_bw1.Click += new System.EventHandler(this.Import_bw1Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(398, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 37);
			this.label5.TabIndex = 47;
			this.label5.Text = "Will import:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(465, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(132, 23);
			this.label6.TabIndex = 48;
			this.label6.Text = "- Trainer name, TID, SID";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(465, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(132, 23);
			this.label7.TabIndex = 49;
			this.label7.Text = "- Hall of Fame";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(465, 39);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(132, 23);
			this.label8.TabIndex = 50;
			this.label8.Text = "- Starter Pokémon";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(242, 77);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(51, 23);
			this.label9.TabIndex = 51;
			this.label9.Text = "Starter";
			// 
			// starter
			// 
			this.starter.FormattingEnabled = true;
			this.starter.Items.AddRange(new object[] {
									"Snivy",
									"Tepig",
									"Oshawott"});
			this.starter.Location = new System.Drawing.Point(282, 74);
			this.starter.Name = "starter";
			this.starter.Size = new System.Drawing.Size(121, 21);
			this.starter.TabIndex = 52;
			// 
			// MemoryLink
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 317);
			this.Controls.Add(this.starter);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.import_bw1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.flag8);
			this.Controls.Add(this.flag7);
			this.Controls.Add(this.flag6);
			this.Controls.Add(this.flag5);
			this.Controls.Add(this.flag4);
			this.Controls.Add(this.flag3);
			this.Controls.Add(this.flag2);
			this.Controls.Add(this.flag1);
			this.Controls.Add(this.name);
			this.Controls.Add(this.sid);
			this.Controls.Add(this.tid);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.memory_export);
			this.Controls.Add(this.memory_import);
			this.Controls.Add(this.Exit_but);
			this.Controls.Add(this.Saveexit_but);
			this.Name = "MemoryLink";
			this.Text = "Memory Link Editor";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox starter;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
	}
}

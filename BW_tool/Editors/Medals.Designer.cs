/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 03/03/2016
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BW_tool
{
	partial class Medals
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.NumericUpDown day;
		private System.Windows.Forms.NumericUpDown month;
		private System.Windows.Forms.NumericUpDown year;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox indexbox;
		private System.Windows.Forms.Button exit_but;
		private System.Windows.Forms.Button saveexit_but;
		private System.Windows.Forms.CheckBox flag1box;
		private System.Windows.Forms.CheckBox flag2box;
		private System.Windows.Forms.CheckBox flag3box;
		private System.Windows.Forms.CheckBox flag4box;
		
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
		private void InitializeComponent()
		{
			this.day = new System.Windows.Forms.NumericUpDown();
			this.month = new System.Windows.Forms.NumericUpDown();
			this.year = new System.Windows.Forms.NumericUpDown();
			this.indexbox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.exit_but = new System.Windows.Forms.Button();
			this.saveexit_but = new System.Windows.Forms.Button();
			this.flag1box = new System.Windows.Forms.CheckBox();
			this.flag2box = new System.Windows.Forms.CheckBox();
			this.flag3box = new System.Windows.Forms.CheckBox();
			this.flag4box = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.day)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.month)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.year)).BeginInit();
			this.SuspendLayout();
			// 
			// day
			// 
			this.day.Location = new System.Drawing.Point(49, 39);
			this.day.Maximum = new decimal(new int[]{
			31,
			0,
			0,
			0});
			this.day.Name = "day";
			this.day.Size = new System.Drawing.Size(46, 20);
			this.day.TabIndex = 0;
			this.day.ValueChanged += new System.EventHandler(this.DayValueChanged);
			// 
			// month
			// 
			this.month.Location = new System.Drawing.Point(140, 39);
			this.month.Maximum = new decimal(new int[]{
			12,
			0,
			0,
			0});
			this.month.Name = "month";
			this.month.Size = new System.Drawing.Size(46, 20);
			this.month.TabIndex = 1;
			this.month.ValueChanged += new System.EventHandler(this.MonthValueChanged);
			// 
			// year
			// 
			this.year.Location = new System.Drawing.Point(229, 39);
			this.year.Maximum = new decimal(new int[]{
			127,
			0,
			0,
			0});
			this.year.Name = "year";
			this.year.Size = new System.Drawing.Size(46, 20);
			this.year.TabIndex = 2;
			this.year.ValueChanged += new System.EventHandler(this.YearValueChanged);
			// 
			// indexbox
			// 
			this.indexbox.FormattingEnabled = true;
			this.indexbox.Items.AddRange(new object[] {
			" ======= Special Medaling medals =======",
			"000 - First Step",
			"001 - Participation Prize",
			"002 - Rookie Medalist",
			"003 - Elite Medalist",
			"004 - Master Medalist",
			"005 - Legend Medalist",
			"006 - Top Medalist",
			"======= Adventure Medal =======",
			"007 - Light Walker",
			"008 - Middle Walker",
			"009 - Heavy Walker",
			"010 - Honored Footprints",
			"011 - Step-by-Step Saver",
			"012 - Busy Saver",
			"013 - Experienced Saver",
			"014 - Wonder Writer",
			"015 - Pokémon Center Fan",
			"016 - Signboard Starter",
			"017 - Signboard Savvy",
			"018 - Graffiti Gazer",
			"019 - Starter Cycling",
			"020 - Easy Cycling",
			"021 - Hard Cycling",
			"022 - Pedaling Legend",
			"023 - Old Rod Fisherman",
			"024 - Good Rod Fisherman",
			"025 - Super Rod Fisherman",
			"026 - Mighty Fisher",
			"027 - Normal-type Catcher",
			"028 - Fire-type Catcher",
			"029 - Water-type Catcher",
			"030 - ElectricCollector",
			"031 - Grass-type Catcher",
			"032 - Ice-type Catcher",
			"033 - Fighting-type Catcher",
			"034 - Poison-type Catcher",
			"035 - Ground-type Catcher",
			"036 - Flying-type Catcher",
			"037 - Psychic-type Catcher",
			"038 - Bug-type Catcher",
			"039 - Rock-type Catcher",
			"040 - Ghost-type Catcher",
			"041 - Dragon-type Catcher",
			"042 - Dark-type Catcher",
			"043 - Steel-type Catcher",
			"044 - Unova Catcher",
			"045 - National Catcher",
			"046 - 30 Boxed",
			"047 - 120 Boxed",
			"048 - 360 Boxed",
			"049 - Boxes Max",
			"050 - Capturing Spree",
			"051 - Vending Virtuoso",
			"052 - Lucky Drink",
			"053 - Evolution Hopeful",
			"054 - Evolution Tech",
			"055 - Evolution Expert",
			"056 - Evolution Authority",
			"057 - Ace Pilot",
			"058 - Hustle Muscle",
			"059 - Trash Master",
			"060 - Dowsing Beginner",
			"061 - Dowsing Specialist",
			"062 - Dowsing Collector",
			"063 - Dowsing Wizard",
			"064 - Naming Champ",
			"065 - Television Kid",
			"066 - Regular Customer",
			"067 - Moderate Customer",
			"068 - Great Customer",
			"069 - Indulgent Customer",
			"070 - Super Rich",
			"071 - Smart Shopper",
			"072 - Sweet Home",
			"073 - The First Passerby",
			"074 - 30 Passersby",
			"075 - 100 Passersby",
			"076 - Heavy Traffic",
			"077 - Pass Power+",
			"078 - Pass Power++",
			"079 - Pass Power+++",
			"080 - Pass Power MAX",
			"081 - Dozing Capture",
			"082 - Sleeping Capture",
			"083 - Deep Sleep Capture",
			"084 - Sweet Dreamer",
			"085 - Hidden Grotto Adept",
			"086 - Egg Beginner",
			"087 - Egg Breeder",
			"088 - Egg Elite ",
			"089 - Hatching Aficionado",
			"090 - Day-Care Faithful",
			"091 - Archeology Lover",
			"092 - Pure Youth",
			"093 - Lucky Colour",
			"094 - Pokerus Discoverer",
			"095 - Castelia Boss",
			"096 - Rail Enthusiast",
			"097 - Wailord Watcher",
			"098 - Face Board Memorial",
			"099 - Heavy Machinery Pro",
			"Ruins Raider",
			"Diamond Dust",
			"Bridge Enthusiast",
			"Around Unova",
			"Great Adventurer",
			"======= Battle Medal =======",
			"Battle Learner",
			"Battle Teacher",
			"Battle Veteran",
			"Battle Virtuoso",
			"Link Battle Amateur",
			"Link Battle Pioneer",
			"Link Battle Expert",
			"Born To Battle",
			"Magikarp Award",
			"Never Give Up",
			"Noneffective Artist",
			"Supereffective Savant",
			"Subway Low Gear",
			"Subway Accelerator",
			"Subway Top Gear",
			"Runaway Express",
			"Single Express",
			"Double Express",
			"Multi Express",
			"Test Novice",
			"Test Fan",
			"Test Enthusiast",
			"Exam Genius",
			"Exp. Millionaire",
			"BP Wealthy",
			"Superb Locator",
			"Battle Repeater",
			"Cruise Connoisseur",
			"Driftveil Mightiest",
			"Rental Champ",
			"Mix Champ",
			"Unova Mightiest",
			"Kanto Mightiest",
			"Johto Mightiest",
			"Hoenn Mightiest",
			"Sinnoh Mightiest",
			"Mightiest Leader",
			"World\'s Mightiest",
			"Rental Master",
			"Mix Master",
			"All Types Champ",
			"Tower Junior",
			"Tower Master",
			"Treehollow Junior",
			"Treehollow Master",
			"20 Victories",
			"50 Victories",
			"100 Victories",
			"1,000 Wins",
			"Undefeated: Easy",
			"Undefeated: Hard",
			"Pinpoint: Easy",
			"Pinpoint: Hard",
			"Quick Clear: Easy",
			"Quick Clear: Hard",
			"Battle Guru",
			"======= Entertainment Medal =======",
			"Beginning Trader",
			"Occasional Trader",
			"Frequent Trader",
			"Great Trade-Up",
			"Opposite Trader",
			"Pen Pal",
			"Talented Cast Member",
			"Rising Star",
			"Big Star",
			"Superstar",
			"Musical Prima Donna",
			"Musical Star",
			"10 Followers",
			"First Friend",
			"Broad Friendship",
			"Extensive Friendship",
			"Global Connection",
			"Spin Trade Whiz",
			"Feeling Master",
			"Ace of Hearts",
			"Ferris Wheel Fan",
			"New Guide",
			"Elite Guide",
			"Veteran Guide",
			"======= Challenge Medal =======",
			"Guiding Champ",
			"Shop Starter",
			"Shop Builder",
			"Shop Constructor",
			"Extreme Developer",
			"OK Souvenir Getter",
			"Good Souvenir Getter",
			"Great Souvenir Getter",
			"Tycoon of Souvenirs",
			"Avenue of Fame",
			"Minigame Fan",
			"Minigame Buff",
			"Minigame Expert",
			"Best Minigamer",
			"Balloon Rookie",
			"Balloon Technician",
			"Balloon Expert",
			"Balloon Conqueror",
			"New Face Hero",
			"Hero Movie Star",
			"Cop Movie Master",
			"UFO Movie Master",
			"Monster Movie Master",
			"Sci-Fi Movie Master",
			"Romantic Movie Star",
			"Fantasy Movie Master",
			"Comedic Movie Star",
			"Horror Movie Star",
			"Robot Movie Master",
			"Ghost Movie Master",
			"Hero Ending",
			"Popular Movie Star",
			"Blockbuster Star",
			"Masterpiece Star",
			"First Cult Classic",
			"Cult Classic Star",
			"10 People Funfest",
			"30 People Funfest",
			"Scored 100",
			"Scored 1,000",
			"Mission Host Lv1",
			"Mission Host Lv 2",
			"Participant Lv 1",
			"Participant Lv 2",
			"Achiever Lv 1",
			"Achiever Lv 2",
			"Funfest Complete",
			"Good Night",
			"Beginning of Memory",
			"Memory Master",
			"Entertainment Master",
			"Normal-type Champ",
			"Fire-type Champ",
			"Water-type Champ",
			"Electric-type Champ",
			"Grass-type Champ",
			"Ice-type Champ",
			"Fighting-type Champ",
			"Poison-type Champ",
			"Ground-type Champ",
			"Flying-type Champ",
			"Psychic-type Champ",
			"Bug-type Champ",
			"Rock-type Champ",
			"Ghost-type Champ",
			"Dragon-type Champ",
			"Dark-type Champ",
			"Steel-type Champ",
			"One and Only",
			"Supreme Challenger"});
			this.indexbox.Location = new System.Drawing.Point(12, 12);
			this.indexbox.MaxDropDownItems = 10;
			this.indexbox.Name = "indexbox";
			this.indexbox.Size = new System.Drawing.Size(263, 21);
			this.indexbox.TabIndex = 4;
			this.indexbox.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Day";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(101, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Month";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(192, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Year";
			// 
			// exit_but
			// 
			this.exit_but.Location = new System.Drawing.Point(178, 184);
			this.exit_but.Name = "exit_but";
			this.exit_but.Size = new System.Drawing.Size(97, 27);
			this.exit_but.TabIndex = 8;
			this.exit_but.Text = "Exit";
			this.exit_but.UseVisualStyleBackColor = true;
			this.exit_but.Click += new System.EventHandler(this.Exit_butClick);
			// 
			// saveexit_but
			// 
			this.saveexit_but.Location = new System.Drawing.Point(178, 217);
			this.saveexit_but.Name = "saveexit_but";
			this.saveexit_but.Size = new System.Drawing.Size(99, 29);
			this.saveexit_but.TabIndex = 9;
			this.saveexit_but.Text = "Save and Exit";
			this.saveexit_but.UseVisualStyleBackColor = true;
			this.saveexit_but.Click += new System.EventHandler(this.Saveexit_butClick);
			// 
			// flag1box
			// 
			this.flag1box.Location = new System.Drawing.Point(70, 67);
			this.flag1box.Name = "flag1box";
			this.flag1box.Size = new System.Drawing.Size(104, 24);
			this.flag1box.TabIndex = 10;
			this.flag1box.Text = "Flag 1";
			this.flag1box.UseVisualStyleBackColor = true;
			this.flag1box.CheckedChanged += new System.EventHandler(this.Flag1boxCheckedChanged);
			// 
			// flag2box
			// 
			this.flag2box.Location = new System.Drawing.Point(140, 67);
			this.flag2box.Name = "flag2box";
			this.flag2box.Size = new System.Drawing.Size(104, 24);
			this.flag2box.TabIndex = 11;
			this.flag2box.Text = "Flag 2";
			this.flag2box.UseVisualStyleBackColor = true;
			this.flag2box.CheckedChanged += new System.EventHandler(this.Flag2boxCheckedChanged);
			// 
			// flag3box
			// 
			this.flag3box.Location = new System.Drawing.Point(70, 97);
			this.flag3box.Name = "flag3box";
			this.flag3box.Size = new System.Drawing.Size(104, 24);
			this.flag3box.TabIndex = 12;
			this.flag3box.Text = "Flag 3";
			this.flag3box.UseVisualStyleBackColor = true;
			this.flag3box.CheckedChanged += new System.EventHandler(this.Flag3boxCheckedChanged);
			// 
			// flag4box
			// 
			this.flag4box.Location = new System.Drawing.Point(140, 97);
			this.flag4box.Name = "flag4box";
			this.flag4box.Size = new System.Drawing.Size(104, 24);
			this.flag4box.TabIndex = 13;
			this.flag4box.Text = "Flag 4";
			this.flag4box.UseVisualStyleBackColor = true;
			this.flag4box.CheckedChanged += new System.EventHandler(this.Flag4boxCheckedChanged);
			// 
			// Medals
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 258);
			this.Controls.Add(this.flag4box);
			this.Controls.Add(this.flag3box);
			this.Controls.Add(this.flag2box);
			this.Controls.Add(this.flag1box);
			this.Controls.Add(this.saveexit_but);
			this.Controls.Add(this.exit_but);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.indexbox);
			this.Controls.Add(this.year);
			this.Controls.Add(this.month);
			this.Controls.Add(this.day);
			this.Name = "Medals";
			this.Text = "Medals";
			((System.ComponentModel.ISupportInitialize)(this.day)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.month)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.year)).EndInit();
			this.ResumeLayout(false);

		}
	}
}

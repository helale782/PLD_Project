namespace PLD_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Lyxi_Anal_grbox = new GroupBox();
			Lexical_lstBox = new ListBox();
			Parse_lstBox = new ListBox();
			Source_grbox = new GroupBox();
			textBox3 = new TextBox();
			groupBox3 = new GroupBox();
			Lyxi_Anal_grbox.SuspendLayout();
			Source_grbox.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// Lyxi_Anal_grbox
			// 
			Lyxi_Anal_grbox.Controls.Add(Lexical_lstBox);
			Lyxi_Anal_grbox.Location = new Point(454, 12);
			Lyxi_Anal_grbox.Margin = new Padding(4, 3, 4, 3);
			Lyxi_Anal_grbox.Name = "Lyxi_Anal_grbox";
			Lyxi_Anal_grbox.Padding = new Padding(4, 3, 4, 3);
			Lyxi_Anal_grbox.Size = new Size(434, 295);
			Lyxi_Anal_grbox.TabIndex = 2;
			Lyxi_Anal_grbox.TabStop = false;
			Lyxi_Anal_grbox.Text = "Lexical Analyzer";
			// 
			// Lexical_lstBox
			// 
			Lexical_lstBox.Cursor = Cursors.IBeam;
			Lexical_lstBox.FormattingEnabled = true;
			Lexical_lstBox.ItemHeight = 23;
			Lexical_lstBox.Location = new Point(8, 29);
			Lexical_lstBox.Margin = new Padding(4, 3, 4, 3);
			Lexical_lstBox.Name = "Lexical_lstBox";
			Lexical_lstBox.Size = new Size(418, 257);
			Lexical_lstBox.TabIndex = 0;
			// 
			// Parse_lstBox
			// 
			Parse_lstBox.Cursor = Cursors.IBeam;
			Parse_lstBox.FormattingEnabled = true;
			Parse_lstBox.ItemHeight = 23;
			Parse_lstBox.Location = new Point(7, 36);
			Parse_lstBox.Margin = new Padding(4, 3, 4, 3);
			Parse_lstBox.Name = "Parse_lstBox";
			Parse_lstBox.Size = new Size(858, 96);
			Parse_lstBox.TabIndex = 1;
			// 
			// Source_grbox
			// 
			Source_grbox.Controls.Add(textBox3);
			Source_grbox.Location = new Point(14, 12);
			Source_grbox.Margin = new Padding(4, 3, 4, 3);
			Source_grbox.Name = "Source_grbox";
			Source_grbox.Padding = new Padding(4, 3, 4, 3);
			Source_grbox.Size = new Size(434, 295);
			Source_grbox.TabIndex = 3;
			Source_grbox.TabStop = false;
			Source_grbox.Text = "Source";
			// 
			// textBox3
			// 
			textBox3.Cursor = Cursors.IBeam;
			textBox3.Location = new Point(7, 26);
			textBox3.Margin = new Padding(4, 3, 4, 3);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(420, 263);
			textBox3.TabIndex = 0;
			textBox3.TextChanged += textBox3_TextChanged;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(Parse_lstBox);
			groupBox3.Location = new Point(14, 312);
			groupBox3.Margin = new Padding(4, 3, 4, 3);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(4, 3, 4, 3);
			groupBox3.Size = new Size(873, 135);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Parse Errors";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(11F, 23F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.GradientActiveCaption;
			BackgroundImageLayout = ImageLayout.None;
			ClientSize = new Size(900, 450);
			Controls.Add(groupBox3);
			Controls.Add(Source_grbox);
			Controls.Add(Lyxi_Anal_grbox);
			Font = new Font("MV Boli", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Margin = new Padding(4, 3, 4, 3);
			Name = "Form1";
			Text = "PLD";
			Load += Form1_Load;
			Lyxi_Anal_grbox.ResumeLayout(false);
			Source_grbox.ResumeLayout(false);
			Source_grbox.PerformLayout();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private GroupBox Lyxi_Anal_grbox;
		private GroupBox Source_grbox;
		private TextBox textBox3;
		private GroupBox groupBox3;
		private ListBox Parse_lstBox;
		private ListBox Lexical_lstBox;
	}
}

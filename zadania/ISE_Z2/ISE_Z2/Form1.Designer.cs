namespace ISE_Z2
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonRun = new System.Windows.Forms.Button();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.openGLControl1 = new SharpGL.OpenGLCtrl();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.buttonApp = new System.Windows.Forms.Button();
			this.buttonOut = new System.Windows.Forms.Button();
			this.buttonLeft = new System.Windows.Forms.Button();
			this.buttonRight = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonRun
			// 
			this.buttonRun.Location = new System.Drawing.Point( 83, 3 );
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size( 75, 35 );
			this.buttonRun.TabIndex = 0;
			this.buttonRun.Text = "Start";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler( this.buttonRun_Click );
			// 
			// buttonCreate
			// 
			this.buttonCreate.Location = new System.Drawing.Point( 2, 3 );
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size( 75, 35 );
			this.buttonCreate.TabIndex = 1;
			this.buttonCreate.Text = "Stwórz powie¿chniê";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler( this.buttonCreate_Click );
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.backgroundWorker_DoWork );
			// 
			// openGLControl1
			// 
			this.openGLControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.openGLControl1.AutoScroll = true;
			this.openGLControl1.DrawRenderTime = false;
			this.openGLControl1.FrameRate = 29.41176F;
			this.openGLControl1.GDIEnabled = false;
			this.openGLControl1.Location = new System.Drawing.Point( 12, 55 );
			this.openGLControl1.Name = "openGLControl1";
			this.openGLControl1.Size = new System.Drawing.Size( 482, 278 );
			this.openGLControl1.TabIndex = 2;
			this.openGLControl1.OpenGLDraw += new System.Windows.Forms.PaintEventHandler( this.openGLControl1_OpenGLDraw );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 164, 3 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 3;
			this.button1.Text = "^";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 164, 25 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 24 );
			this.button2.TabIndex = 4;
			this.button2.Text = "v";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// buttonApp
			// 
			this.buttonApp.Location = new System.Drawing.Point( 254, 3 );
			this.buttonApp.Name = "buttonApp";
			this.buttonApp.Size = new System.Drawing.Size( 75, 23 );
			this.buttonApp.TabIndex = 5;
			this.buttonApp.Text = "+";
			this.buttonApp.UseVisualStyleBackColor = true;
			this.buttonApp.Click += new System.EventHandler( this.buttonApp_Click );
			// 
			// buttonOut
			// 
			this.buttonOut.Location = new System.Drawing.Point( 254, 26 );
			this.buttonOut.Name = "buttonOut";
			this.buttonOut.Size = new System.Drawing.Size( 75, 23 );
			this.buttonOut.TabIndex = 6;
			this.buttonOut.Text = "-";
			this.buttonOut.UseVisualStyleBackColor = true;
			this.buttonOut.Click += new System.EventHandler( this.buttonOut_Click );
			// 
			// buttonLeft
			// 
			this.buttonLeft.Location = new System.Drawing.Point( 345, 26 );
			this.buttonLeft.Name = "buttonLeft";
			this.buttonLeft.Size = new System.Drawing.Size( 75, 23 );
			this.buttonLeft.TabIndex = 8;
			this.buttonLeft.Text = "<";
			this.buttonLeft.UseVisualStyleBackColor = true;
			this.buttonLeft.Click += new System.EventHandler( this.buttonLeft_Click );
			// 
			// buttonRight
			// 
			this.buttonRight.Location = new System.Drawing.Point( 345, 3 );
			this.buttonRight.Name = "buttonRight";
			this.buttonRight.Size = new System.Drawing.Size( 75, 23 );
			this.buttonRight.TabIndex = 9;
			this.buttonRight.Text = ">";
			this.buttonRight.UseVisualStyleBackColor = true;
			this.buttonRight.Click += new System.EventHandler( this.buttonRight_Click );
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 506, 345 );
			this.Controls.Add( this.buttonRight );
			this.Controls.Add( this.buttonLeft );
			this.Controls.Add( this.buttonOut );
			this.Controls.Add( this.buttonApp );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.openGLControl1 );
			this.Controls.Add( this.buttonCreate );
			this.Controls.Add( this.buttonRun );
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.Button buttonCreate;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private SharpGL.OpenGLCtrl openGLControl1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button buttonApp;
		private System.Windows.Forms.Button buttonOut;
		private System.Windows.Forms.Button buttonLeft;
		private System.Windows.Forms.Button buttonRight;
	}
}


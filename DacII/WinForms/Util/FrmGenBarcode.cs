using System;
using System.Drawing;
using System.Windows.Forms;

namespace DacII.WinForms.Util
{
    using Barcode.Code128;
    using Barcode.Code39;
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmGenBarcode : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtInput;
      private System.Windows.Forms.VistaButton cmdMakeBarcode;
      private System.Windows.Forms.PictureBox pictBarcode;
      private System.Drawing.Printing.PrintDocument printDocument1;
      private System.Windows.Forms.VistaButton cmdPrint;
      private VistaButton btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGenBarcode()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public void GenBarcode(string content)
        {
            txtInput.Text = content;
            MakeBarcode();
            ShowDialog();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmdMakeBarcode = new System.Windows.Forms.VistaButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.cmdPrint = new System.Windows.Forms.VistaButton();
            this.pictBarcode = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(57, 8);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(475, 20);
            this.txtInput.TabIndex = 1;
            // 
            // cmdMakeBarcode
            // 
            this.cmdMakeBarcode.BackColor = System.Drawing.Color.Transparent;
            this.cmdMakeBarcode.BaseColor = System.Drawing.Color.Transparent;
            this.cmdMakeBarcode.ButtonText = "Make barcode";
            this.cmdMakeBarcode.Location = new System.Drawing.Point(8, 168);
            this.cmdMakeBarcode.Name = "cmdMakeBarcode";
            this.cmdMakeBarcode.Size = new System.Drawing.Size(121, 33);
            this.cmdMakeBarcode.TabIndex = 2;
            this.cmdMakeBarcode.Click += new System.EventHandler(this.cmdMakeBarcode_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.BackColor = System.Drawing.Color.Transparent;
            this.cmdPrint.BaseColor = System.Drawing.Color.Transparent;
            this.cmdPrint.ButtonText = "Print";
            this.cmdPrint.Location = new System.Drawing.Point(368, 168);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(79, 33);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // pictBarcode
            // 
            this.pictBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictBarcode.BackColor = System.Drawing.Color.AliceBlue;
            this.pictBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictBarcode.Location = new System.Drawing.Point(8, 34);
            this.pictBarcode.Name = "pictBarcode";
            this.pictBarcode.Size = new System.Drawing.Size(528, 128);
            this.pictBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictBarcode.TabIndex = 3;
            this.pictBarcode.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Location = new System.Drawing.Point(453, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmGenBarcode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(540, 213);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.pictBarcode);
            this.Controls.Add(this.cmdMakeBarcode);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenBarcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barcode Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }
		#endregion

      private void cmdMakeBarcode_Click(object sender, System.EventArgs e)
      {
          MakeBarcode();
      }

      private void MakeBarcode()
      {
          try
          {
              Image myimg = Code128Rendering.MakeBarcodeImage(txtInput.Text, 2, true);
              pictBarcode.Image = myimg;
          }
          catch (Exception ex)
          {
              MessageBox.Show(this, ex.Message, this.Text);
          }
          //if (rdoCode128.Checked)
          //{
          //    try
          //    {
          //        Image myimg = Code128Rendering.MakeBarcodeImage(txtInput.Text, 2, true);
          //        pictBarcode.Image = myimg;
          //    }
          //    catch (Exception ex)
          //    {
          //        MessageBox.Show(this, ex.Message, this.Text);
          //    }
          //}
          //else
          //{
          //    try
          //    {
          //        Code39 code = new Code39(txtInput.Text);
          //        Image myimg = code.Paint();
          //        pictBarcode.Image = myimg;
          //    }
          //    catch (Exception ex)
          //    {
          //        MessageBox.Show(ex.ToString());
          //    }
          //}
      }

      private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         using (Graphics g = e.Graphics)
         {
            using (Font fnt = new Font("Arial", 16))
            {
                string caption = string.Format("Code128 barcode weight={0}", 2);

                //string caption = "Code 39 barcode";
                //if (rdoCode128.Checked)
                //{
                //    caption = string.Format("Code128 barcode weight={0}", 2);
                //}
               g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 50, 50);
               caption = string.Format("message='{0}'", txtInput.Text);
               g.DrawString(caption, fnt, System.Drawing.Brushes.Black, 50, 75);
               g.DrawImage(pictBarcode.Image, 50, 110);
            }
         }
      }

      private void cmdPrint_Click(object sender, System.EventArgs e)
      {
         printDocument1.Print();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
          string curr_dir = System.IO.Directory.GetCurrentDirectory();
          SaveFileDialog dlg = new SaveFileDialog();
          dlg.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
          DialogResult result = dlg.ShowDialog();
          if (result != DialogResult.OK)
          {    
              System.IO.Directory.SetCurrentDirectory(curr_dir);
              return;
          }
          
          string filename = dlg.FileName;
          System.IO.Directory.SetCurrentDirectory(curr_dir);
          
          pictBarcode.Image.Save(filename);
      }

	}
}

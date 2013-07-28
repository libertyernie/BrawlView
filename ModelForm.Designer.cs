namespace BrawlView {
	partial class ModelForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.modelPanel1 = new System.Windows.Forms.ModelPanel();
			this.SuspendLayout();
			// 
			// modelPanel1
			// 
			this.modelPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelPanel1.InitialYFactor = 100;
			this.modelPanel1.InitialZoomFactor = 5;
			this.modelPanel1.Location = new System.Drawing.Point(0, 0);
			this.modelPanel1.Name = "modelPanel1";
			this.modelPanel1.RotationScale = 0.1F;
			this.modelPanel1.Size = new System.Drawing.Size(624, 441);
			this.modelPanel1.TabIndex = 1;
			this.modelPanel1.TranslationScale = 0.05F;
			this.modelPanel1.ZoomScale = 2.5F;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.modelPanel1);
			this.Name = "Form1";
			this.Text = "BrawlView";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ModelPanel modelPanel1;
	}
}


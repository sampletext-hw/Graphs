
namespace Graphs
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
            this.pictureBoxFrame = new System.Windows.Forms.PictureBox();
            this.listBoxConnections = new System.Windows.Forms.ListBox();
            this.numericUpDownConnectionWeight = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConnectionWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFrame
            // 
            this.pictureBoxFrame.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxFrame.Location = new System.Drawing.Point(8, 8);
            this.pictureBoxFrame.Name = "pictureBoxFrame";
            this.pictureBoxFrame.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxFrame.TabIndex = 0;
            this.pictureBoxFrame.TabStop = false;
            this.pictureBoxFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFrame_Paint);
            this.pictureBoxFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFrame_MouseDown);
            this.pictureBoxFrame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFrame_MouseMove);
            this.pictureBoxFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFrame_MouseUp);
            // 
            // listBoxConnections
            // 
            this.listBoxConnections.FormattingEnabled = true;
            this.listBoxConnections.ItemHeight = 15;
            this.listBoxConnections.Location = new System.Drawing.Point(416, 8);
            this.listBoxConnections.Name = "listBoxConnections";
            this.listBoxConnections.Size = new System.Drawing.Size(152, 394);
            this.listBoxConnections.TabIndex = 1;
            this.listBoxConnections.SelectedIndexChanged += new System.EventHandler(this.listBoxConnections_SelectedIndexChanged);
            this.listBoxConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxConnections_KeyDown);
            // 
            // numericUpDownConnectionWeight
            // 
            this.numericUpDownConnectionWeight.Location = new System.Drawing.Point(576, 8);
            this.numericUpDownConnectionWeight.Name = "numericUpDownConnectionWeight";
            this.numericUpDownConnectionWeight.Size = new System.Drawing.Size(192, 23);
            this.numericUpDownConnectionWeight.TabIndex = 2;
            this.numericUpDownConnectionWeight.Visible = false;
            this.numericUpDownConnectionWeight.ValueChanged += new System.EventHandler(this.numericUpDownConnectionWeight_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDownConnectionWeight);
            this.Controls.Add(this.listBoxConnections);
            this.Controls.Add(this.pictureBoxFrame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConnectionWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFrame;
        private System.Windows.Forms.ListBox listBoxConnections;
        private System.Windows.Forms.NumericUpDown numericUpDownConnectionWeight;
    }
}


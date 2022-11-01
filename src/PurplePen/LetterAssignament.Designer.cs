namespace PurplePen
{
    partial class LetterAssignament
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.courseSelector1 = new PurplePen.CourseSelector();
            this.firstLetter_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 157);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(105, 157);
            // 
            // courseSelector1
            // 
            this.courseSelector1.Filter = null;
            this.courseSelector1.Location = new System.Drawing.Point(12, 12);
            this.courseSelector1.Name = "courseSelector1";
            this.courseSelector1.ShowAllControls = false;
            this.courseSelector1.ShowCourseParts = false;
            this.courseSelector1.ShowVariationChooser = false;
            this.courseSelector1.Size = new System.Drawing.Size(180, 104);
            this.courseSelector1.TabIndex = 0;
            // 
            // firstLetter_box
            // 
            this.firstLetter_box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.firstLetter_box.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.firstLetter_box.Location = new System.Drawing.Point(105, 122);
            this.firstLetter_box.MaxLength = 1;
            this.firstLetter_box.Name = "firstLetter_box";
            this.firstLetter_box.Size = new System.Drawing.Size(87, 23);
            this.firstLetter_box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 125);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "First Letter";
            // 
            // LetterAssignament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 191);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstLetter_box);
            this.Controls.Add(this.courseSelector1);
            this.Name = "LetterAssignament";
            this.Text = "Letter assignament";
            this.Controls.SetChildIndex(this.courseSelector1, 0);
            this.Controls.SetChildIndex(this.firstLetter_box, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CourseSelector courseSelector1;
        private System.Windows.Forms.TextBox firstLetter_box;
        private System.Windows.Forms.Label label1;
    }
}
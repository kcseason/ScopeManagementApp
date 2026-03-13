using System.Drawing.Printing;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ScopeManagementApp.UserControls
{
    partial class KnowledgeDomainControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAnswer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvMain = new DataGridView();
            btnSubmit = new Button();
            btnClear = new Button();
            btnAnswer = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // dgvMain
            // 
            dgvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = DockStyle.Top;
            dgvMain.Location = new Point(0, 0);
            dgvMain.Name = "dgvMain";
            dgvMain.RowTemplate.Height = 23;
            dgvMain.Size = new Size(1460, 955);
            dgvMain.TabIndex = 0;
            dgvMain.CellPainting += dgvMain_CellPainting;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(1107, 981);
            btnSubmit.Margin = new Padding(4, 5, 4, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(105, 43);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1224, 981);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 43);
            btnClear.TabIndex = 2;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnAnswer
            // 
            btnAnswer.Location = new Point(1341, 981);
            btnAnswer.Margin = new Padding(4, 5, 4, 5);
            btnAnswer.Name = "btnAnswer";
            btnAnswer.Size = new Size(105, 43);
            btnAnswer.TabIndex = 3;
            btnAnswer.Text = "答案";
            btnAnswer.UseVisualStyleBackColor = true;
            btnAnswer.Click += btnShowAnswer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(70, 1300);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(16, 993);
            label2.Name = "label2";
            label2.Size = new Size(66, 31);
            label2.TabIndex = 5;
            label2.Text = "0/49";
            // 
            // KnowledgeDomainControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAnswer);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(dgvMain);
            Margin = new Padding(4, 5, 4, 5);
            Name = "KnowledgeDomainControl";
            Size = new Size(1460, 1037);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
    }
}
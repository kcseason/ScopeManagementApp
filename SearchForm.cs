
using ScopeManagementApp;
using System;
using System.Windows.Forms;

namespace ScopeManagementApp
{
    public partial class SearchForm : Form
    {
        private TextBox searchTextBox;
        private Button searchButton;
        private Button cancelButton;
        private MainForm mainForm;

        public SearchForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.searchTextBox = new TextBox();
            this.searchButton = new Button();
            this.cancelButton = new Button();
            this.SuspendLayout();

            // 搜索文本框
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 25);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.KeyDown += SearchTextBox_KeyDown;

            // 搜索按钮
            this.searchButton.Location = new System.Drawing.Point(12, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 30);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += SearchButton_Click;

            // 取消按钮
            this.cancelButton.Location = new System.Drawing.Point(137, 43);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += CancelButton_Click;

            // 搜索窗体
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 85);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "搜索";
            this.ShowInTaskbar = false;
            this.FormClosed += SearchForm_FormClosed;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            mainForm.ClearHighlights();
            this.Close();
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.ClearHighlights();
        }

        private void PerformSearch()
        {
            string searchText = searchTextBox.Text.Trim();
            mainForm.SearchAndHighlight(searchText);
        }
    }
}

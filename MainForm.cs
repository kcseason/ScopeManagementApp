using PMPManagementTool.UserControls;

namespace ScopeManagementApp
{
    public partial class MainForm : Form
    {
        private ToolStrip toolStrip;
        private ToolStripButton showTableButton;
        private Panel contentPanel;

        private DataGridView dataGridView;
        private List<DataGridViewCell> highlightedCells = new List<DataGridViewCell>();
        private SearchForm searchForm;
        private Color originalCellColor;

        private string[] tableNameStr =
        { 
            "知识领域", "整合管理", "范围管理", "进度管理", "成本管理", "质量管理", 
            "资源管理", "沟通管理", "风险管理", "采购管理", "干系人管理", "工具与技术",
            "易混术语"
        };

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1184, 661);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "软考高项帮助工具";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        private void SetupUI()
        {
            // 创建工具栏
            toolStrip = new ToolStrip
            {
                Name = "toolStrip",
                GripStyle = ToolStripGripStyle.Hidden,
                BackColor = Color.FromArgb(145, 90, 0)
            };

            foreach (var tableName in tableNameStr)
            {
                showTableButton = new ToolStripButton(tableName)
                {
                    ForeColor = Color.White,
                    Font = new Font("微软雅黑", 14, FontStyle.Bold),
                    Size = new Size(180, 35)
                };
                showTableButton.Click += ShowTableButton_Click;
                toolStrip.Items.Add(showTableButton);
            }

            // 先添加工具栏到窗体
            this.Controls.Add(toolStrip);
            toolStrip.Dock = DockStyle.Top;

            // 创建内容面板，位于工具栏下方
            contentPanel = new Panel
            {
                Name = "contentPanel",
                Dock = DockStyle.Fill,
                BackColor = SystemColors.ControlLight
            };

            // 确保内容面板在工具栏下方
            this.Controls.Add(contentPanel);
            contentPanel.BringToFront();
        }

        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            ParentControl userControl = null;
            var btnName = (sender as ToolStripButton)?.Text;

            switch (btnName)
            {
                case "知识领域": userControl = new KnowledgeDomainControl(); break;
                case "整合管理": userControl = new IntegrationManagementControl(); break;
                case "范围管理": userControl = new ScopeManagementControl(); break;
                case "进度管理": userControl = new ScheduleManagementControl(); break;
                case "成本管理": userControl = new CostManagementControl(); break;
                case "质量管理": userControl = new QualityManagementControl(); break;
                case "资源管理": userControl = new ResourceManagementControl(); break;
                case "沟通管理": userControl = new CommunicationManagementControl(); break;
                case "风险管理": userControl = new RiskManagementControl(); break;
                case "采购管理": userControl = new ProcurementManagementControl(); break;
                case "干系人管理": userControl = new StakeholderManagementControl(); break;
                case "工具与技术": userControl = new ToolAndTechControl(); break;
                case "易混术语": userControl = new TermComparisonControl(); break;
            }

            if (userControl != null)
            {
                dataGridView = userControl.dataGridView;
                userControl.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(userControl);

                // 确保控件正确显示
                userControl.BringToFront();
                contentPanel.PerformLayout();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (contentPanel != null)
            {
                contentPanel.Invalidate();
            }
        }

        public void SearchAndHighlight(string searchText)
        {
            // 清除之前的高亮
            ClearHighlights();

            if (string.IsNullOrEmpty(searchText))
                return;

            // 查找匹配的单元格
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Index == 0)
                    continue;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null &&
                        cell.Value.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        highlightedCells.Add(cell);
                        cell.Style.BackColor = Color.LightGreen;
                    }
                }
            }

            // 定位到第一个匹配项
            if (highlightedCells.Count > 0)
            {
                var firstMatch = highlightedCells[0];
                dataGridView.CurrentCell = firstMatch;
                dataGridView.FirstDisplayedScrollingRowIndex = firstMatch.RowIndex;
            }
        }

        public void ClearHighlights()
        {
            // 恢复所有高亮单元格的原始颜色
            foreach (var cell in highlightedCells)
            {
                cell.Style.BackColor = originalCellColor;
            }
            highlightedCells.Clear();
        }
    }

    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

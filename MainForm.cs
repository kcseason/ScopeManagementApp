using ClosedXML.Excel;
using PMPManagementTool.UserControls;
using System.Diagnostics;
using System.Reflection;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

namespace ScopeManagementApp
{
    public partial class MainForm : Form
    {
        private ToolStrip toolStrip;
        private ToolStripButton showTableButton;
        private Panel contentPanel;
        private List<ParentControl> parentControls = new List<ParentControl>();

        private DataGridView dataGridView;
        private List<DataGridViewCell> highlightedCells = new List<DataGridViewCell>();
        private Color originalCellColor;

        public MainForm()
        {
            InitializeComponent();
            FindExportParentControl();
            GetAllTableName();
            SetupUI();
        }

        private void GetAllTableName()
        {

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

            foreach (var tableName in parentControls.Select(x => x.ControlName).ToList())
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

            showTableButton = new ToolStripButton("导出文档")
            {
                ForeColor = Color.White,
                Font = new Font("微软雅黑", 14, FontStyle.Bold),
                Size = new Size(180, 35)
            };
            showTableButton.Click += Export_Click;
            toolStrip.Items.Add(showTableButton);

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

        private void Export_Click(object? sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDialog.FileName = "软考高项导出资料";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToCsv(saveDialog.FileName);
                    MessageBox.Show($"成功导出{parentControls.Count}个表格数据！", "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToCsv(string fileName)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                foreach (var parentCtrl in parentControls)
                {
                    var worksheet = workbook.Worksheets.Add(parentCtrl.ControlName);

                    if (parentCtrl.dataGridView != null && parentCtrl.ControlName.Equals("知识领域"))
                    {
                        var ctrl = (KnowledgeDomainControl)parentCtrl;
                        ctrl.btnShowAnswer_Click(null, null);
                        // 写入数据行
                        for (int row = 0; row < ctrl.dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < ctrl.dataGridView.Columns.Count; col++)
                            {
                                var cellValue = ctrl.dataGridView.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 1, col + 1).Value = cellValue?.ToString() ?? "";
                                worksheet.Cell(row + 1, col + 1).Style.Font.FontName = "微软雅黑";
                                worksheet.Cell(row + 1, col + 1).Style.Font.FontSize = 16;
                                if (row == 0 || col == 0)
                                {
                                    worksheet.Cell(row + 1, col + 1).Style.Font.Bold = true;
                                    worksheet.Cell(row + 1, col + 1).Style.Fill.BackgroundColor = XLColor.AshGrey;
                                }
                            }
                        }
                    }
                    else if (parentCtrl.dataGridView != null)
                    {
                        // 写入数据行
                        for (int row = 0; row < parentCtrl.dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < parentCtrl.dataGridView.Columns.Count; col++)
                            {
                                var cellValue = parentCtrl.dataGridView.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 1, col + 1).Value = cellValue?.ToString() ?? "";
                                worksheet.Cell(row + 1, col + 1).Style.Alignment.WrapText = true; // 启用自动换行
                                worksheet.Cell(row + 1, col + 1).Style.Font.FontName = "微软雅黑";
                                worksheet.Cell(row + 1, col + 1).Style.Font.FontSize = 16;
                                if (row == 0)
                                {
                                    worksheet.Cell(row + 1, col + 1).Style.Font.Bold = true;
                                    worksheet.Cell(row + 1, col + 1).Style.Fill.BackgroundColor = XLColor.AshGrey;
                                }
                            }
                        }
                    }
                    var endChar = GetLetterAfterOffset('A', parentCtrl.dataGridView.Columns.Count - 1);
                    // 方法1：设置单个单元格边框
                    worksheet.Range($"A1:{endChar}{parentCtrl.dataGridView.Rows.Count}").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                    worksheet.Range($"A1:{endChar}{parentCtrl.dataGridView.Rows.Count}").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);

                    // 自动调整列宽
                    worksheet.Columns().AdjustToContents();
                    worksheet.Column(1).Width = 30;
                    worksheet.Column(2).Width = 50;
                    worksheet.Column(3).Width = 50;
                    worksheet.Column(4).Width = 50;
                    worksheet.Column(5).Width = 50;
                    worksheet.Column(6).Width = 50;

                    worksheet.Rows().AdjustToContents();
                }

                workbook.SaveAs(fileName);
            }
        }


        private void FindExportParentControl()
        {
            // 获取当前程序集
            var assembly = Assembly.GetExecutingAssembly();

            // 查找自定义控件
            var typeControls = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ParentControl))
                           && t.Namespace != null && !t.Namespace.StartsWith("System.Windows.Forms"))
                .ToList();

            foreach (var typeControl in typeControls)
            {
                var ctrl = Activator.CreateInstance(typeControl) as ParentControl;
                if (ctrl.ControlName.Equals("知识领域"))
                    parentControls.Insert(0, ctrl);
                else
                    parentControls.Add(ctrl);
            }
        }

        private void ShowTableButton_Click(object? sender, EventArgs e)
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

        /// <summary>
        /// 根据起始字母和偏移量计算目标字母
        /// </summary>
        /// <param name="startChar">起始字母</param>
        /// <param name="offset">偏移量</param>
        /// <returns>计算后的字母</returns>
        public static char GetLetterAfterOffset(char startChar, int offset)
        {
            // 转换为大写字母处理
            char upperChar = char.ToUpper(startChar);

            // 检查是否为有效字母
            if (upperChar < 'A' || upperChar > 'Z')
            {
                throw new ArgumentException("输入的字符必须是字母");
            }

            // 计算偏移后的字母位置
            int startPosition = upperChar - 'A';
            int newPosition = (startPosition + offset) % 26;

            // 处理负数偏移
            if (newPosition < 0)
            {
                newPosition += 26;
            }

            // 转换回字符
            return (char)('A' + newPosition);
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

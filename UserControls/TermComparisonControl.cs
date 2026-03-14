namespace PMPManagementTool.UserControls
{
    public class TermComparisonControl : ParentControl
    {
        private List<int> isolationRows = new List<int>() { 3 };
        public TermComparisonControl()
        {
            InitializeComponent();
            LoadToolData();
            SetIsolationRow();
        }

        private void InitializeComponent()
        {
            // 添加列（2列：易混术语+解释说明+备注）
            for (int i = 0; i < 3; i++)
            {
                dataGridView.Columns.Add($"Column{i}", "");
            }
            dataGridView.Columns[0].Width = 500; // 设置列宽
            dataGridView.Columns[1].Width = 1200; // 设置列宽
            dataGridView.Columns[2].Width = 600; // 设置列宽
        }

        private void LoadToolData()
        {
            // 定义表头数据
            string[] headers = { "易混术语", "解释说明", "备注" };

            // 添加表头行
            dataGridView.Rows.Add(headers);

            // 设置表头样式
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(64, 128, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var rowCount = dataGridView.Rows.Count;
            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Rows[rowCount - 1].Cells[i].Style = headerStyle;
            }

            // 添加范围管理六大过程数据
            string[,] scopeData = {
                {
                    "资源平衡",
                    "‌核心目标‌：解决资源过度分配或短缺问题，确保资源需求 ≤ 资源供给\n‌是否改变关键路径‌：通常会改变，且往往导致项目工期延长\n调整范围‌：可调整关键路径和非关键路径上的活动\n" +
                    "动因‌：资源冲突（如一人同时被安排多个任务）\n调整后果‌：可能延长项目周期，牺牲时间换资源平衡\n记忆口诀‌：“平衡靠延时，路径会变长”"
                },
                {
                    "资源平衡",
                    "‌核心目标‌：在不改变项目工期的前提下，“削峰填谷”，使资源使用更平稳\n‌是否改变关键路径‌：不会改变关键路径，项目总工期保持不变\n调整范围‌：仅在非关键路径活动的‌自由浮动时间‌和‌总浮动时间‌内调整\n" +
                    "动因‌：资源波动大（如某周需5人，下周仅需1人）\n调整后果‌：不影响交付日期，追求效率与资源稳定\n记忆口诀‌：“平滑不动期，只调非关键”"
                },
                {
                    "",
                    "‌"
                },
            };

            // 填充数据到表格
            for (int i = 0; i < scopeData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    scopeData[i, 0],  // 工具与技术
                    scopeData[i, 1]  // 解释说明
                );
            }

            // 数据加载完成后重新调整行高
            dataGridView.PerformLayout();

            // 强制刷新以确保行高正确计算
            dataGridView.Refresh();
        }

        private void SetIsolationRow()
        {
            foreach (var row in isolationRows)
            {
                dataGridView.Rows[row].DefaultCellStyle.Font = new Font("微软雅黑", 1);
                dataGridView.Rows[row].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }
}

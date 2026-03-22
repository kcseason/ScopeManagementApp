namespace PMPManagementTool.UserControls
{
    public class CostManagementControl : ParentControl
    {
        private Dictionary<(int, int, int), string> mergeCells = new Dictionary<(int, int, int), string>
        {
            { (0, 1, 3), "规划过程组" }
        };
        public CostManagementControl()
        {
            this.ControlName = "成本管理";
            InitializeComponent();
            LoadCostData();
        }

        private void InitializeComponent()
        {
            // 添加列（6列：组+过程+目的+输入+工具与技术+输出）
            for (int i = 0; i < 6; i++)
            {
                dataGridView.Columns.Add($"Column{i}", "");
                if (i >= 3 && i <= 5)
                    dataGridView.Columns[i].Width = 550; // 设置列宽
                else
                    dataGridView.Columns[i].Width = 200; // 设置列宽
            }
            dataGridView.CellPainting += dgvMain_CellPainting;
        }

        private void LoadCostData()
        {
            string[] headers = { "组", "过程", "目的", "输入", "工具与技术", "输出" };
            dataGridView.Rows.Add(headers);

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(64, 128, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Rows[0].Cells[i].Style = headerStyle;
            }

            string[,] costData = {
                {
                    "规划过程组",
                    "规划成本管理",
                    "确定如何估算、预算、管理、监督和控制项目成本",
                    "项目管理计划\n项目文件(假设日志、风险登记册、经验教训登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析)\n会议",
                    "成本管理计划"
                },
                {
                    "规划过程组",
                    "估算成本",
                    "对完成项目活动所需资金进行近似估算",
                    "项目管理计划\n项目文件(经验教训登记册、资源需求、风险登记册、活动清单、活动属性、假设日志)\n质量成本\n事业环境因素\n组织过程资产",
                    "专家判断\n类比估算\n参数估算\n自下而上估算\n三点估算\n数据分析(备选方案分析)\n项目管理信息系统\n会议",
                    "成本估算\n估算依据"
                },
                {
                    "规划过程组",
                    "制定预算",
                    "汇总所有单个活动或工作包的估算成本，建立一个经批准的成本基准",
                    "项目管理计划\n项目文件(成本估算、估算依据、范围基准、项目进度计划、资源需求、风险登记册)\n协议\n事业环境因素\n组织过程资产",
                    "成本汇总\n数据分析(储备分析)\n专家判断\n历史信息审核\n资金限制平衡",
                    "成本基准\n项目资金需求\n项目文件更新"
                },
                {
                    "监控过程组",
                    "控制成本",
                    "监督项目状态，以更新项目成本，管理成本基准变更",
                    "项目管理计划\n项目文件(经验教训登记册、成本基准、成本估算、成本预测、估算依据)\n项目资金需求\n工作绩效数据\n组织过程资产",
                    "专家判断\n数据分析(挣值分析、偏差分析、趋势分析)\n项目管理信息系统\n完工尚需绩效指数",
                    "工作绩效信息\n成本预测\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            for (int i = 0; i < costData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    costData[i, 0],
                    costData[i, 1],
                    costData[i, 2],
                    costData[i, 3],
                    costData[i, 4],
                    costData[i, 5]
                );
            }

            dataGridView.PerformLayout();
            dataGridView.Refresh();
        }

        private void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvMain_CellPainting(sender, e, mergeCells);
        }
    }
}

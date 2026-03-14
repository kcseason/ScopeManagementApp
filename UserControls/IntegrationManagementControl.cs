namespace PMPManagementTool.UserControls
{
    public class IntegrationManagementControl : ParentControl
    {
        private Dictionary<(int, int, int), string> mergeCells = new Dictionary<(int, int, int), string>
        {
            { (0, 3, 4), "执行过程组" },
            { (0, 5, 6), "监控过程组" },
        };

        public IntegrationManagementControl()
        {
            InitializeComponent();
            LoadIntegrationData();
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

        private void LoadIntegrationData()
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

            string[,] integrationData = {
                {
                    "启动过程组",
                    "制定项目章程",
                    "正式授权项目或阶段，并记录能反映干系人需要和期望的初步要求",
                    "协议\n项目工作说明书\n商业论证\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(成本效益分析)\n会议",
                    "项目章程"
                },
                {
                    "规划过程组",
                    "制定项目管理计划",
                    "定义、准备和协调所有子计划，并将其整合进项目管理计划",
                    "项目章程\n其他规划过程的输出\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析)\n会议",
                    "项目管理计划"
                },
                {
                    "执行过程组",
                    "指导与管理项目工作",
                    "为实现项目目标而领导和执行项目管理计划中所确定的工作",
                    "项目管理计划\n项目文件\n批准的变更请求\n事业环境因素\n组织过程资产",
                    "专家判断\n项目管理信息系统\n会议",
                    "可交付成果\n工作绩效数据\n问题日志\n变更请求\n项目管理计划更新\n项目文件更新"
                },
                {
                    "执行过程组",
                    "管理项目知识",
                    "使用现有知识并生成新知识，以实现项目目标，并帮助组织学习",
                    "项目管理计划\n项目文件\n可交付成果\n事业环境因素\n组织过程资产",
                    "专家判断\n知识管理工具\n信息管理工具\n人际关系与团队技能(积极倾听、领导力、政治意识、影响力)",
                    "经验教训登记册\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                },
                {
                    "监控过程组",
                    "监控项目工作",
                    "跟踪、审查和报告项目进展，以满足项目管理计划中确定的绩效目标",
                    "项目管理计划\n项目文件\n工作绩效信息\n协议\n事业环境因素\n组织过程资产",
                    "数据分析(备选方案分析、趋势分析、根本原因分析)\n决策(投票)\n会议",
                    "工作绩效报告\n变更请求\n项目管理计划更新\n项目文件更新"
                },
                {
                    "监控过程组",
                    "实施整体变更控制",
                    "审查所有变更请求，批准变更，管理对可交付成果、组织过程资产、项目文件和项目管理计划的变更，并对变更处理结果进行沟通",
                    "项目管理计划\n项目文件\n工作绩效报告\n变更请求\n事业环境因素\n组织过程资产",
                    "数据分析(备选方案分析)\n决策(投票)\n会议",
                    "批准的变更请求\n变更日志\n项目管理计划更新\n项目文件更新"
                },
                {
                    "收尾过程组",
                    "结束项目或阶段",
                    "终结项目、阶段或合同的所有活动",
                    "项目章程\n项目管理计划\n项目文件\n验收的可交付成果\n商业文件\n协议\n采购文档\n事业环境因素\n组织过程资产",
                    "数据分析(文件分析、回归分析)\n会议",
                    "最终产品、服务或成果移交\n最终报告\n更新的组织过程资产"
                }
            };

            for (int i = 0; i < integrationData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    integrationData[i, 0],
                    integrationData[i, 1],
                    integrationData[i, 2],
                    integrationData[i, 3],
                    integrationData[i, 4],
                    integrationData[i, 5]
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

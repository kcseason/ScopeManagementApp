namespace PMPManagementTool.UserControls
{
    public class ProcurementManagementControl : ParentControl
    {
        public ProcurementManagementControl()
        {
            this.ControlName = "采购管理";
            InitializeComponent();
            LoadProcurementData();
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
        }

        private void LoadProcurementData()
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

            string[,] procurementData = {
                {
                    "规划过程组",
                    "规划采购管理",
                    "记录项目采购决策，明确采购方法，识别潜在卖方",
                    "项目管理计划\n项目文件(需求文件、活动清单、活动成本估算、干系人登记册、风险登记册、需求跟踪矩阵、资源需求、范围基准)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(自制或外购分析、备选方案分析)\n会议",
                    "采购管理计划\n招标文件\n采购工作说明书\n供方选择标准\n独立成本估算\n变更请求"
                },
                {
                    "执行过程组",
                    "实施采购",
                    "获取卖方应答，选择卖方并授予合同",
                    "项目管理计划\n项目文件(采购管理计划、招标文件、供方选择标准、独立成本估算、卖方建议书)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(建议书评价技术、独立估算)\n决策(投票)\n人际关系与团队技能(谈判、会议)\n广告\n投标人会议\n采购谈判",
                    "协议\n采购文档\n变更请求\n项目管理计划更新\n项目文件更新"
                },
                {
                    "监控过程组",
                    "控制采购",
                    "管理采购关系，监督合同绩效，实施必要的变更和纠正措施，并关闭合同",
                    "项目管理计划\n项目文件(采购文档、估算依据、进度计划、需求文件、需求跟踪矩阵、资源需求、风险登记册)\n批准的变更请求\n工作绩效报告\n事业环境因素\n组织过程资产",
                    "数据分析(绩效审查、挣值分析、趋势分析)\n检查\n审计\n会议",
                    "采购关闭\n工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            for (int i = 0; i < procurementData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    procurementData[i, 0],
                    procurementData[i, 1],
                    procurementData[i, 2],
                    procurementData[i, 3],
                    procurementData[i, 4],
                    procurementData[i, 5]
                );
            }

            dataGridView.PerformLayout();
            dataGridView.Refresh();
        }
    }
}

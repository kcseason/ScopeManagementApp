namespace PMPManagementTool.UserControls
{
    public class CommunicationManagementControl : ParentControl
    {
        public CommunicationManagementControl()
        {
            this.ControlName = "沟通管理";
            InitializeComponent();
            LoadCommunicationData();
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

        private void LoadCommunicationData()
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

            string[,] communicationData = {
                {
                    "规划过程组",
                    "规划沟通管理",
                    "基于干系人的信息需要，制定合适的项目沟通方式和计划",
                    "项目管理计划\n项目文件(干系人登记册、需求文件、风险登记册、经验教训登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析、沟通技术分析)\n会议",
                    "沟通管理计划"
                },
                {
                    "执行过程组",
                    "管理沟通",
                    "确保项目信息及时且恰当地收集、生成、发布、存储、检索、管理、监督和最终处置",
                    "项目管理计划\n项目文件(资源管理计划、干系人登记册、沟通管理计划、问题日志、经验教训登记册)\n可交付成果\n事业环境因素\n组织过程资产",
                    "沟通技能\n沟通模型\n沟通方法(交互式沟通、推式沟通、拉式沟通)\n项目管理信息系统\n会议",
                    "项目沟通\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                },
                {
                    "监控过程组",
                    "监督沟通",
                    "确保满足项目及其干系人的信息需求",
                    "项目管理计划\n项目文件(沟通管理计划、问题日志、经验教训登记册、干系人登记册)\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "数据分析(绩效审查、趋势分析)\n项目管理信息系统",
                    "工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            for (int i = 0; i < communicationData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    communicationData[i, 0],
                    communicationData[i, 1],
                    communicationData[i, 2],
                    communicationData[i, 3],
                    communicationData[i, 4],
                    communicationData[i, 5]
                );
            }

            dataGridView.PerformLayout();
            dataGridView.Refresh();
        }
    }
}

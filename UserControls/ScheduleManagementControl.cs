namespace PMPManagementTool.UserControls
{
    public class ScheduleManagementControl : ParentControl
    {
        private Dictionary<(int, int, int), string> mergeCells = new Dictionary<(int, int, int), string>
        {
            { (0, 1, 5), "规划过程组" }
        };

        public ScheduleManagementControl()
        {
            this.ControlName = "进度管理";
            InitializeComponent();
            LoadScheduleData();
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

        private void LoadScheduleData()
        {
            // 定义表头数据
            string[] headers = { "组", "过程", "目的", "输入", "工具与技术", "输出" };

            // 添加表头行
            dataGridView.Rows.Add(headers);

            // 设置表头样式
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(64, 128, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Rows[0].Cells[i].Style = headerStyle;
            }

            // 添加进度管理六大过程数据
            string[,] scheduleData = {
                {
                    "规划过程组",
                    "规划进度管理",
                    "为规划、编制、管理、执行和控制项目进度而制定政策、程序和文档",
                    "项目章程\n项目管理计划\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析\n会议",
                    "进度管理计划"
                },
                {
                    "规划过程组",
                    "定义活动",
                    "识别和记录为完成项目可交付成果而需采取的具体行动",
                    "项目管理计划\n项目文件(假设日志、 lessons learned register、里程碑清单、项目进度网络图、需求文件、风险登记册、范围基准)",
                    "专家判断\n分解\n滚动式规划",
                    "活动清单\n活动属性\n里程碑清单"
                },
                {
                    "规划过程组",
                    "排列活动顺序",
                    "识别和记录项目活动之间的关系",
                    "项目管理计划\n项目文件(活动清单、活动属性、假设日志、里程碑清单、风险登记册)",
                    "紧前关系绘图法(PDM)\n确定和整合依赖关系\n提前量和滞后量",
                    "项目进度网络图\n项目文件更新(活动清单、活动属性、假设日志)"
                },
                {
                    "规划过程组",
                    "估算活动持续时间",
                    "根据资源估算的结果，估算完成单项活动所需工作时段数",
                    "项目管理计划\n项目文件(活动清单、活动属性、资源需求、风险登记册、假设日志、资源分解结构)",
                    "专家判断\n类比估算\n参数估算\n三点估算\n自下而上估算\n数据分析(备选方案分析)\n会议",
                    "持续时间估算\n估算依据"
                },
                {
                    "规划过程组",
                    "制定进度计划",
                    "分析活动顺序、持续时间、资源需求和进度制约因素，创建项目进度模型",
                    "项目管理计划\n项目文件(活动清单、活动属性、估算依据、持续时间估算、里程碑清单、项目进度网络图、资源需求、风险登记册、假设日志)",
                    "进度网络分析\n关键路径法\n关键链法\n资源优化\n数据分析(假设情景分析、模拟)\n敏捷发布规划",
                    "进度基准\n项目进度计划\n进度数据\n项目日历"
                },
                {
                    "监控过程组",
                    "控制进度",
                    "监督项目活动状态，更新项目进展，管理进度基准变更",
                    "项目管理计划\n项目文件(经验教训登记册、项目进度计划、进度数据、进度基准)\n工作绩效数据\n批准的变更请求\n事业环境因素",
                    "数据分析(绩效审查、趋势分析、关键路径法、项目管理信息系统)\n会议",
                    "工作绩效信息\n进度预测\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            // 填充数据到表格
            for (int i = 0; i < scheduleData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    scheduleData[i, 0],  // 组
                    scheduleData[i, 1],  // 过程
                    scheduleData[i, 2],  // 目的
                    scheduleData[i, 3],  // 输入
                    scheduleData[i, 4],  // 工具与技术
                    scheduleData[i, 5]   // 输出
                );
            }

            // 数据加载完成后重新调整行高
            dataGridView.PerformLayout();

            // 强制刷新以确保行高正确计算
            dataGridView.Refresh();
        }

        private void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvMain_CellPainting(sender, e, mergeCells);
        }
    }
}

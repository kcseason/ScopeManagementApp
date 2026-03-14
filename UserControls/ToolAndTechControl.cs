namespace PMPManagementTool.UserControls
{
    public class ToolAndTechControl : ParentControl
    {
        public ToolAndTechControl()
        {
            InitializeComponent();
            LoadToolData1();
            LoadToolData2();
            LoadToolData3();
        }

        private void InitializeComponent()
        {
            // 添加列（2列：工具与技术+解释说明）
            for (int i = 0; i < 2; i++)
            {
                dataGridView.Columns.Add($"Column{i}", "");
            }
            dataGridView.Columns[0].Width = 500; // 设置列宽
            dataGridView.Columns[1].Width = 1200; // 设置列宽
        }

        private void LoadToolData1()
        {
            // 定义表头数据
            string[] headers1 = { "一、高频通用类工具与技术", "" };
            string[] headers = { "工具与技术", "解释说明" };

            // 添加表头行
            dataGridView.Rows.Add(headers1);
            dataGridView.Rows.Add(headers);

            // 设置表头样式
            DataGridViewCellStyle headerStyleTitle = new DataGridViewCellStyle();
            headerStyleTitle.BackColor = Color.FromArgb(138, 138, 138);
            headerStyleTitle.ForeColor = Color.White;
            headerStyleTitle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyleTitle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(64, 128, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var rowCount = dataGridView.Rows.Count;
            for (int i = 0; i < headers1.Length; i++)
            {
                dataGridView.Rows[rowCount - 2].Cells[i].Style = headerStyleTitle;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Rows[rowCount - 1].Cells[i].Style = headerStyle;
            }

            // 添加范围管理六大过程数据
            string[,] scopeData = {
                {
                    "1.专家判断",
                    "依赖具备专业知识的个人或团队（如PMO、行业专家）对项目决策提供支持，广泛应用于制定项目章程、范围定义、风险识别等过程。"
                },
                {
                    "2.会议",
                    "包括项目启动会、评审会、状态更新会等，用于信息交换、方案评估和决策制定，是沟通管理的核心手段之一。"
                },
                {
                    "3.数据分析技术 - 备选方案分析",
                    "比较不同执行路径（如资源调配、工具选择），选出最优解，应用于成本、进度、质量管理等多个环节。"
                },
                {
                    "                          ‌ 敏感性分析‌",
                    "综合评估项目进度与成本绩效，通过PV、EV、AC三个指标计算CV、SV，判断项目偏差。"
                },
                {
                    "                           挣值分析(EVM)",
                    "识别对项目结果影响最大的风险因素，常用于定量风险分析。"
                },
                {
                    "                           根本原因分析(RCA)",
                    "用于质量管理和问题解决，定位问题根源并制定预防措施。"
                },
                {
                    "                           偏差分析",
                    "对比实际进度与计划进度，计算进度偏差（SV）和成本偏差（CV）。"
                },
                {
                    "                           趋势分析",
                    "预测未来绩效走向，如成本超支是否会持续恶化。"
                },
                {
                    "                           储备分析",
                    "判断应急储备是否充足，是否需要申请动用管理储备。"
                },
                {
                    "3.数据收集技术 - 访谈",
                    "一对一沟通获取干系人需求，适用于需求收集和干系人分析。"
                },
                {
                    "                           焦点小组",
                    "召集关键干系人（如客户代表、技术负责人）深入讨论项目高层级需求。"
                },
                {
                    "                           头脑风暴",
                    "激发团队创意，常用于需求生成和风险识别。"
                },
                {
                    "                           问卷调查",
                    "适用于大规模用户需求采集，提升效率。"
                },
                {
                    "                           德尔菲技术",
                    "通过多轮匿名问卷征求专家意见，减少偏见，达成共识。"
                },
                {
                    "4.决策技术 - 多标准决策分析(MCDA)",
                    "使用加权矩阵对多个方案评分排序，适用于资源分配、供应商选择等场景。"
                },
                {
                    "                   投票",
                    "包括“大多数同意”“相对多数同意”，用于集体决策，常见于需求优先级排序。"
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

        private void LoadToolData2()
        {
            // 定义表头数据
            string[] headers2 = { "二、按知识领域划分的核心工具与技术", "" };
            string[] headers = { "工具与技术", "解释说明" };

            // 添加表头行
            dataGridView.Rows.Add(headers2);
            dataGridView.Rows.Add(headers);

            // 设置表头样式
            DataGridViewCellStyle headerStyleTitle = new DataGridViewCellStyle();
            headerStyleTitle.BackColor = Color.FromArgb(138, 138, 138);
            headerStyleTitle.ForeColor = Color.White;
            headerStyleTitle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyleTitle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(64, 128, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var rowCount = dataGridView.Rows.Count;
            for (int i = 0; i < headers2.Length; i++)
            {
                dataGridView.Rows[rowCount - 2].Cells[i].Style = headerStyleTitle;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Rows[rowCount - 1].Cells[i].Style = headerStyle;
            }

            // 添加范围管理六大过程数据
            string[,] scopeData = {
                {
                    "1. ‌整合管理 - 项目管理信息系统(PMIS)",
                    "自动化工具集(如JIRA、Microsoft Project、禅道)，支持进度计划、配置管理、信息分发、任务分配、进度跟踪、文档共享等，是执行与监控的重要支撑。"
                },
                {
                    "                     变更控制工具",
                    "使用JIRA、ChangeMan等系统记录、审批、跟踪变更请求，实现流程自动化。支持变更日志、影响分析模板、审批流配置。"
                },
                {
                    "                     变更控制委员会",
                    "由关键干系人组成（如客户代表、技术总监、项目经理），负责重大变更的评审与决策。小型项目可由项目经理直接审批。"
                },
                {
                    "‌                     知识管理",
                    "建立项目知识库，记录技术方案、问题处理过程、最佳实践。可通过文档、视频、音频等多种形式留存隐性知识。例如，录制核心模块开发讲解视频供新人学习。"
                },
                {
                    "‌                     经验教训登记册",
                    "在项目早期创建，持续更新遇到的问题、风险应对措施、改进建议，为后续阶段和未来项目提供参考。"
                },
                {
                    "‌                     信息管理系统",
                    "利用Wiki、Confluence等平台集中存储项目资料，支持全文检索和版本控制。"
                },
                {
                    "2. ‌范围管理 - 产品分析",
                    "自动化工具集，支持进度计划、配置管理、信息分发等，是执行与监控的重要支撑。"
                },
                {
                    "                     分解(WBS)",
                    "将项目可交付成果逐层拆解为工作包，形成结构化的工作分解结构。"
                },
                {
                    "‌                     滚动式规划‌",
                    "在信息不完整时逐步细化计划，适用于敏捷或复杂项目。"
                },
                {
                    "3. ‌进度管理 - 关键路径法(CPM)",
                    "识别项目中最长路径，确定最短完成时间，是进度计划制定的核心方法。"
                },
                {
                    "                     计划评审技术(PERT)",
                    "采用三点估算法（乐观、悲观、最可能）计算活动持续时间，提升估算准确性。"
                },
                {
                    "‌                     甘特图‌‌",
                    "可视化展示任务时间安排，便于进度跟踪。"
                },
                {
                    "‌                     储备分析 - 应急储备‌‌",
                    "应对“已知-未知”风险，纳入进度基准。"
                },
                {
                    "‌                     储备分析 - 管理储备‌‌",
                    "应对“未知-未知”风险，不包含在进度基准中，需变更才能启用。"
                },
                {
                    "4. ‌成本管理 - 类比估算",
                    "基于历史项目数据进行粗略估算，适用于早期阶段。"
                },
                {
                    "                     参数估算",
                    "利用统计模型（如单位工作量×单价）进行计算，依赖数据可靠性。"
                },
                {
                    "                     自下而上估算‌",
                    "对工作包逐项估算后汇总，精度高但耗时。"
                },
                {
                    "                     挣值管理(EVM)‌",
                    "结合范围、进度、成本进行综合绩效分析，支持预测与控制。"
                },
                {
                    "5. ‌质量管理 - 质量成(COQ)",
                    "分为一致性成本（预防、评估）和非一致性成本（内部、外部失败），用于权衡质量投入与损失。"
                },
                {
                    "                     标杆对照(Benchmarking)",
                    "对标行业最佳实践，设定质量目标。"
                },
                {
                    "                     七种基本质量工具(老七工具)",
                    "包括因果图、控制图、直方图等，用于问题分析与过程控制。"
                },
                {
                    "                     质量审计‌",
                    "结构性审查质量管理活动，识别改进机会。"
                },
                {
                    "6. ‌风险管理 - SWOT分析",
                    "分析组织的优势、劣势、机会与威胁，辅助战略决策。"
                },
                {
                    "                     概率影响矩阵‌",
                    "对风险进行定性排序，确定优先处理对象。"
                },
                {
                    "                     蒙特卡洛模拟‌",
                    "通过建模预测项目完成概率，用于定量风险分析。"
                },
                {
                    "                     决策树分析",
                    "评估不同决策路径的预期货币价值(EMV)，支持风险应对选择。"
                },
                {
                    "7. ‌干系人管理 - 干系人分析",
                    "识别干系人的权力、兴趣、影响程度，制定管理策略。"
                },
                {
                    "                     ‌沟通风格评估‌‌",
                    "了解干系人偏好，优化沟通方式。"
                },
                {
                    "                     影响力技巧‌",
                    "在无命令权的情况下推动协作，尤其适用于矩阵型组织。"
                }
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

        private void LoadToolData3()
        {
            // 定义表头数据
            string[] headers3 = { "三、其他重要工具与技术", "" };
            string[] headers = { "工具与技术", "解释说明" };

            // 添加表头行
            dataGridView.Rows.Add(headers3);
            dataGridView.Rows.Add(headers);

            // 设置表头样式
            DataGridViewCellStyle headerStyleTitle = new DataGridViewCellStyle();
            headerStyleTitle.BackColor = Color.FromArgb(138, 138, 138);
            headerStyleTitle.ForeColor = Color.White;
            headerStyleTitle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyleTitle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(64, 128, 128);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("微软雅黑", 18, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var rowCount = dataGridView.Rows.Count;
            for (int i = 0; i < headers3.Length; i++)
            {
                dataGridView.Rows[rowCount - 2].Cells[i].Style = headerStyleTitle;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Rows[rowCount - 1].Cells[i].Style = headerStyle;
            }

            // 添加范围管理六大过程数据
            string[,] scopeData = {
                {
                    "1.核对单(Checklist)",
                    "结构化验证工具，确保关键步骤不遗漏，常用于质量控制和变更管理。"
                },
                {
                    "2.引导技术",
                    "通过 facilitation 技巧促进团队达成共识，应用于需求研讨会、风险评估会等。"
                },
                {
                    "3.人际关系与团队技能",
                    "包括积极倾听、冲突管理、领导力、引导、会议管理等，提升团队协作效能。"
                },
                {
                    "4.文件分析",
                    "审核现有文档（如合同、需求说明书），提取改进信息。"
                },
                {
                    "5.审计",
                    "对项目全过程进行合规性审查，检查合同履行、财务结算、知识产权归属等。"
                }
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
    }
}

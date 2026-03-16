namespace PMPManagementTool.UserControls
{
    public class ToolAndTechControl : ParentControl
    {
        public ToolAndTechControl()
        {
            this.ControlName = "工具与技术";
            InitializeComponent();
            LoadToolData1();
            LoadToolData2();
            LoadToolData3();
            LoadToolData4();
        }

        private void InitializeComponent()
        {
            // 添加列（3列：工具与技术+解释说明+备注）
            for (int i = 0; i < 3; i++)
            {
                dataGridView.Columns.Add($"Column{i}", "");
            }
            dataGridView.Columns[0].Width = 500; // 设置列宽
            dataGridView.Columns[1].Width = 1200; // 设置列宽
            dataGridView.Columns[2].Width = 600; // 设置列宽
        }

        private void LoadToolData1()
        {
            // 定义表头数据
            string[] headers1 = { "一、高频通用类工具与技术", "", "" };
            string[] headers = { "工具与技术", "解释说明", "备注" };

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
                    "3.数据分析 - 备选方案分析",
                    "比较不同执行路径（如资源调配、工具选择），选出最优解，应用于成本、进度、质量管理等多个环节。"
                },
                {
                    "                    敏感性分析‌",
                    "综合评估项目进度与成本绩效，通过PV、EV、AC三个指标计算CV、SV，判断项目偏差。"
                },
                {
                    "                    挣值分析(EVM)",
                    "识别对项目结果影响最大的风险因素，常用于定量风险分析。"
                },
                {
                    "                    根本原因分析(RCA)",
                    "用于质量管理和问题解决，定位问题根源并制定预防措施。"
                },
                {
                    "                    偏差分析",
                    "对比实际进度与计划进度，计算进度偏差（SV）和成本偏差（CV）。"
                },
                {
                    "                    趋势分析",
                    "预测未来绩效走向，如成本超支是否会持续恶化。"
                },
                {
                    "                    储备分析",
                    "判断应急储备是否充足，是否需要申请动用管理储备。"
                },
                {
                    "                    成本效益分析",
                    "用于评估项目或决策的经济可行性，其核心是通过比较项目的总成本与总效益，判断投入是否值得。"
                },
                {
                    "3.数据收集 - 访谈",
                    "一对一沟通获取干系人需求，适用于需求收集和干系人分析。"
                },
                {
                    "                    焦点小组",
                    "召集关键干系人（如客户代表、技术负责人）深入讨论项目高层级需求。"
                },
                {
                    "                    头脑风暴",
                    "激发团队创意，常用于需求生成和风险识别。"
                },
                {
                    "                    问卷调查",
                    "适用于大规模用户需求采集，提升效率。"
                },
                {
                    "                    德尔菲技术",
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
            string[] headers2 = { "二、按知识领域划分的核心工具与技术", "", "" };
            string[] headers = { "工具与技术", "解释说明", "备注" };

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
                    "                     ‌面向X的设计(DfX)‌",
                    "通过预防性设计降低后期变更成本，提高产品质量、客户满意度和整体效率 。\n“降低生产不良率” → ‌DFM‌\r\n“减少装配工时” → ‌DFA‌\r\n“控制总拥有成本” → ‌DFC‌\r\n“便于后期维修” → ‌DFS"
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
                    "                     ‌   沟通风格评估‌‌",
                    "了解干系人偏好，优化沟通方式。"
                },
                {
                    "                        影响力技巧‌",
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
            string[] headers3 = { "三、其他重要工具与技术", "", "" };
            string[] headers = { "工具与技术", "解释说明", "备注" };

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
                    "2.核查表",
                    "又称‌计数表‌，用于按类型收集潜在质量问题的数据，是控制质量过程中常用的数据收集工具 。"
                },
                {
                    "3.引导技术",
                    "通过 facilitation 技巧促进团队达成共识，应用于需求研讨会、风险评估会等。"
                },
                {
                    "4.人际关系与团队技能",
                    "包括积极倾听、冲突管理、领导力、引导、会议管理等，提升团队协作效能。"
                },
                {
                    "5.文件分析",
                    "审核现有文档（如合同、需求说明书），提取改进信息。"
                },
                {
                    "6.审计",
                    "对项目全过程进行合规性审查，检查合同履行、财务结算、知识产权归属等。"
                },
                {
                    "7.统计抽样",
                    "指从项目总体中随机抽取部分样本进行检查，并运用概率论评估结果，以判断整体质量状况的科学方法‌ 。"
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

        private void LoadToolData4()
        {
            // 定义表头数据
            string[] headers3 = { "四、核心图表技术分类与详解", "", "" };
            string[] headers = { "工具与技术", "解释说明", "备注" };

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
                    "1.甘特图（Gantt Chart）",
                    "以条状图形式展示项目进度，横轴为时间，纵轴为活动，条形长度表示持续时间。",
                    "‌应用场景‌：\r\n制定项目进度计划\r\n跟踪实际进度与计划偏差\r\n向干系人汇报项目进展\r\n‌考试重点‌：常用于“制定进度计划”过程，是控制进度的核心工具。"
                },
                {
                    "2.PERT图（计划评审技术图）",
                    "通过节点和箭线表示活动及其依赖关系，采用三点估算计算期望工期。",
                    "应用场景‌：\r\n不确定性较高的项目（如研发类）\r\n关键路径分析与工期预测\r\n‌考试提示‌：与CPM结合考察，强调对“最可能、乐观、悲观”时间的处理。"
                },
                {
                    "3.关键路径法图（CPM图）",
                    "识别项目中最长路径（即决定总工期的路径），用于优化资源分配和进度控制。",
                    "‌应用场景‌：\r\n缩短项目周期（赶工、快速跟进）\r\n识别可压缩的非关键任务浮动时间\r\n‌记忆技巧‌：关键路径上总浮动时间为零。"
                },
                {
                    "4.控制图（Control Chart）",
                    "用于监控过程是否处于统计控制状态，判断数据点是否超出上下控制限。\n‌核心规则‌：七点运行定律——连续7个点在均值一侧或呈单调趋势即视为失控。",
                    "应用场景‌：\r\n质量控制过程（如软件缺陷率监控）\r\n生产流程稳定性分析\r\n‌考试高频点‌：常与“七点原则”联动出题。"
                },
                {
                    "5.因果图（鱼骨图 / 石川图 / why-why分析图）",
                    "将问题结果放在“鱼头”，通过“为什么”逐层追溯根本原因，分类为人、机、料、法、环等维度。",
                    "应用场景‌：\r\n根本原因分析（RCA）\r\n质量问题溯源会议\r\n‌考试提示‌：属于“管理质量”过程的工具之一。"
                },
                {
                    "6.流程图（Process Flow Diagram）",
                    "用图形符号表示工作流程的顺序和逻辑关系。",
                    "‌应用场景‌：\r\n需求分析阶段梳理业务流程\r\n识别非增值活动与瓶颈环节\r\n‌考试关联‌：常用于“过程分析”和“范围管理”。"
                },
                {
                    "7.系统交互图（System Context Diagram）",
                    "展示系统与外部实体（用户、其他系统）之间的交互方式。",
                    "‌应用场景‌：\r\n产品范围定义\r\n接口设计与集成测试规划\r\n‌考试价值‌：在论文写作中可作为“范围管理”部分的可视化支撑。"
                },
                {
                    "8.需求跟踪矩阵（Requirements Traceability Matrix, RTM）",
                    "将需求从来源连接到可交付成果的表格，确保每个需求都有对应实现。",
                    "‌跟踪内容‌：\r\n业务目标 → 项目目标 → WBS → 测试用例\r\n‌考试重点‌：确认范围和控制范围过程的关键工具。"
                },
                {
                    "9.资源直方图（Resource Histogram）",
                    "显示某时间段内资源（如人力、设备）的使用量。",
                    "‌应用场景‌：\r\n识别资源过度分配\r\n支持资源平衡与平滑操作\r\n‌考试提示‌：常与“资源优化技术”结合出题。"
                },
                {
                    "10.资源累积曲线（S曲线）",
                    "横轴为时间，纵轴为累计资源消耗（如成本、工时），呈“S”形增长。",
                    "‌应用场景‌：\r\n成本基准设定\r\n挣值分析（EV、AC、PV）对比\r\n‌考试趋势‌：2024年论文考试曾要求绘制S曲线图。"
                },
                {
                    "11.帕累托图（Pareto Chart）",
                    "结合柱状图与折线图，按频率排序问题类别，累计百分比线体现“二八法则”。",
                    "‌应用场景‌：\r\n质量问题优先级排序\r\n风险影响集中度分析\r\n‌考试价值‌：体现“抓主要矛盾”的管理思维。"
                },
                {
                    "12.散点图（Scatter Diagram）",
                    "展示两个变量之间的相关性（正相关、负相关、无相关）。",
                    "‌‌应用场景‌：\r\n分析成本与进度的关系\r\n评估培训投入与缺陷率下降的相关性\r\n‌考试提示‌：属于数据分析类工具。"
                },
                {
                    "13.雷达图 / 蜘蛛网图（Radar Chart）",
                    "多维度指标在同一图中展示，形成多边形面积。",
                    "‌‌‌应用场景‌：\r\n团队能力评估\r\n项目绩效综合评价（成本、进度、质量、范围）\r\n‌考试优势‌：适合论文中展示“整体绩效”。"
                },
                {
                    "14.迭代燃尽图（Iteration Burndown Chart）",
                    "追踪敏捷迭代中剩余工作量的变化，理想线与实际线对比反映进度偏差。",
                    "‌‌‌应用场景‌：\r\nScrum团队每日站会跟踪\r\n预测迭代结束时的工作完成情况\r\n‌考试趋势‌：适应型生命周期相关题目高频出现。"
                },
                {
                    "15.责任分配矩阵（RAM）与RACI图",
                    "将WBS中的工作包与团队成员对应，RACI细化为执行（R）、批准（A）、咨询（C）、知会（I）。",
                    "‌‌‌应用场景‌：\r\n明确角色职责，避免推诿\r\n大型项目跨部门协作管理\r\n‌考试重点‌：RACI是RAM的具体实现形式。"
                },
                {
                    "16.风险概率和影响矩阵（Risk Matrix）",
                    "二维矩阵，横轴为概率，纵轴为影响，划分高中低风险区域。",
                    "‌‌‌‌应用场景‌：\r\n定性风险分析\r\n风险优先级排序\r\n‌考试提示‌：常用于“识别风险”和“定性风险分析”过程。"
                },
                {
                    "17.SWOT分析图",
                    "从优势（Strengths）、劣势（Weaknesses）、机会（Opportunities）、威胁（Threats）四个维度进行战略分析。",
                    "‌‌‌‌‌应用场景‌：\r\n项目启动前可行性分析\r\n干系人策略制定\r\n‌考试价值‌：可用于论文中的“项目背景分析”部分。"
                },
                {
                    "18.标杆对照图（Benchmarking Diagram）",
                    "将本项目指标与行业最佳实践对比，找出差距并设定改进目标。",
                    "‌‌‌‌‌‌应用场景‌：\r\n成本控制优化\r\n质量标准提升\r\n‌考试提示‌：属于“规划质量管理”工具之一。"
                },
                {
                    "19.亲和图（Affinity Diagram）",
                    "将大量杂乱无章的想法、意见或需求，按照其内在关联性进行‌自然归类‌的图形化工具，帮助团队从混乱中提炼结构。",
                    "‌‌‌‌‌‌应用场景‌：\r\n需求收集\r\n‌问题分析会议‌\r\n‌敏捷用户故事梳理\r\n项目复盘总结\r\n考试提示‌：在“收集需求”和“管理质量”过程中，‌亲和图常与头脑风暴、思维导图并列出现‌，属于“群体创新技术”之一。"
                },
                {
                    "20.项目进度网络图",
                    "用于清晰展示项目中各项任务之间的逻辑关系、先后顺序和依赖关系，是项目管理中制定进度计划的核心技术之一。",
                    "‌‌‌‌‌‌应用场景‌：\r\n项目规划阶段\r\n‌进度控制与监控‌\r\n‌资源优化与风险管理\r\n跨团队协作沟通\r\n考试提示‌：考试中，项目进度网络图常与‌甘特图对比考查‌。甘特图适合向高管汇报进度，而网络图更适用于分析逻辑关系与关键路径 "
                },
            };

            // 填充数据到表格
            for (int i = 0; i < scopeData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    scopeData[i, 0],  // 工具与技术
                    scopeData[i, 1],  // 解释说明
                    scopeData[i, 2]  // 备注
                );
            }

            // 数据加载完成后重新调整行高
            dataGridView.PerformLayout();

            // 强制刷新以确保行高正确计算
            dataGridView.Refresh();
        }
    }
}

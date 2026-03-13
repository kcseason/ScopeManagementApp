using PMPManagementApp;

namespace ScopeManagementApp.UserControls
{
    public class ScopeManagementControl : UserControl
    {
        private DataGridView dataGridView;
        private Dictionary<(int, int, int), string> mergeCells = new Dictionary<(int, int, int), string>
        {
            { (0, 1, 4), "规划过程组" },
            { (0, 5, 6), "监控过程组" },
        };

        public ScopeManagementControl()
        {
            InitializeComponent();
            LoadScopeData();
        }

        private void InitializeComponent()
        {
            // 设置控件属性
            this.Dock = DockStyle.Fill;
            
            this.BackColor = SystemColors.ControlLight;

            // 创建并配置DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                GridColor = SystemColors.ControlDark,
                BorderStyle = BorderStyle.Fixed3D,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,  // 隐藏默认行标题
                ColumnHeadersVisible = false, // 隐藏默认列标题
                Font = new Font("微软雅黑", 18) // 设置字体大小为18
            };

            // 设置行样式
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.LightBlue,
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.TopLeft,
                Font = new Font("微软雅黑", 18) // 设置行字体大小为18
            };
            dataGridView.DefaultCellStyle = rowStyle;

            // 设置行高自适应
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.RowTemplate.Height = 0;

            // 添加列（6列：组+过程+目的+输入+工具与技术+输出）
            for (int i = 0; i < 6; i++)
            {
                dataGridView.Columns.Add($"Column{i}", "");
                if (i >= 3  && i <= 5)
                    dataGridView.Columns[i].Width = 550; // 设置列宽
                else
                    dataGridView.Columns[i].Width = 200; // 设置列宽
            }
            dataGridView.CellPainting += dgvMain_CellPainting;
            this.Controls.Add(dataGridView);
        }

        private void LoadScopeData()
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

            // 添加范围管理六大过程数据
            string[,] scopeData = {
                {
                    "规划过程组",
                    "规划范围管理",
                    "制定如何定义、确认和控制项目范围的指南",
                    "项目章程\n项目管理计划\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析\n会议",
                    "范围管理计划\n需求管理计划"
                },
                {
                    "规划过程组",
                    "收集需求",
                    "全面识别干系人需求，为定义范围奠定基础",
                    "项目章程\n项目管理计划\n协议\n干系人登记册",
                    "数据收集(访谈、焦点小组、问卷调查、标杆对照)\n数据分析(文件分析)\n决策技术(多标准决策分析)\n数据表现(亲和图、思维导图)\n人际关系与团队技能(引导式研讨会、观察法)\n原型法\n系统交互图",
                    "需求文件\n需求跟踪矩阵"
                },
                {
                    "规划过程组",
                    "定义范围",
                    "明确项目边界，制定详细的项目范围说明书",
                    "项目章程\n项目管理计划\n项目文件(需求文件、假设日志、风险登记册)",
                    "专家判断\n数据分析(产品分析)\n决策(多标准决策分析)\n人际关系与团队技能(引导)",
                    "项目范围说明书"
                },
                {
                    "规划过程组",
                    "创建WBS",
                    "将项目范围分解为可管理的工作包",
                    "项目范围说明书\n项目管理计划\n需求文件\n事业环境因素\n组织过程资产",
                    "专家判断\n分解",
                    "WBS\nWBS词典\n范围基准"
                },
                {
                    "监控过程组",
                    "确认范围",
                    "由客户或发起人正式验收已完成的可交付成果",
                    "项目管理计划\n需求文件\n核实的可交付成果\n工作绩效数据",
                    "检查\n决策",
                    "验收的可交付成果\n变更请求\n工作绩效信息\n项目文件更新"
                },
                {
                    "监控过程组",
                    "控制范围",
                    "监督范围状态，管理范围基准变更，防止范围蔓延",
                    "项目管理计划\n项目文件(需求文件、需求跟踪矩阵、WBS、范围基准)\n工作绩效数据\n批准的变更请求",
                    "数据分析(偏差分析、趋势分析)\n会议",
                    "工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            // 填充数据到表格
            for (int i = 0; i < scopeData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    scopeData[i, 0],  // 组
                    scopeData[i, 1],  // 过程
                    scopeData[i, 2],  // 目的
                    scopeData[i, 3],  // 输入
                    scopeData[i, 4],  // 工具与技术
                    scopeData[i, 5]   // 输出
                );
            }

            // 数据加载完成后重新调整行高
            dataGridView.PerformLayout();

            // 强制刷新以确保行高正确计算
            dataGridView.Refresh();
        }

        private void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ControlHelper.dgvMain_CellPainting(sender, e, mergeCells, dataGridView);
        }
    }
}

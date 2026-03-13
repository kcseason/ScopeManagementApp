
using PMPManagementApp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeManagementApp.UserControls
{
    public class RiskManagementControl : UserControl
    {
        private DataGridView dataGridView;
        private Dictionary<(int, int, int), string> mergeCells = new Dictionary<(int, int, int), string>
        {
            { (0, 1, 5), "规划过程组" }
        };
        public RiskManagementControl()
        {
            InitializeComponent();
            LoadRiskData();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            
            this.BackColor = SystemColors.ControlLight;

            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                GridColor = SystemColors.ControlDark,
                BorderStyle = BorderStyle.Fixed3D,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                ColumnHeadersVisible = false,
                Font = new Font("微软雅黑", 18)
            };

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.LightBlue,
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.TopLeft,
                Font = new Font("微软雅黑", 18)
            };
            dataGridView.DefaultCellStyle = rowStyle;

            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.RowTemplate.Height = 0;

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
            this.Controls.Add(dataGridView);
        }

        private void LoadRiskData()
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

            string[,] riskData = {
                {
                    "规划过程组",
                    "规划风险管理",
                    "定义如何实施项目风险管理活动",
                    "项目管理计划\n项目文件(干系人登记册、需求文件、假设日志、成本估算、进度计划、范围基准)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析)\n会议",
                    "风险管理计划"
                },
                {
                    "规划过程组",
                    "识别风险",
                    "识别单个项目风险以及整体项目风险的来源，并记录风险特征",
                    "项目管理计划\n项目文件(假设日志、成本估算、持续时间估算、问题日志、资源需求、进度计划、范围基准、干系人登记册)\n协议\n采购文档\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(核对单分析、假设条件和制约因素分析、SWOT分析)\n人际关系与团队技能(头脑风暴、访谈)\n提示清单\n会议",
                    "风险登记册"
                },
                {
                    "规划过程组",
                    "实施定性风险分析",
                    "通过评估单个项目风险发生的概率和影响以及其他特征，对风险进行优先级排序，从而为后续分析或行动提供基础",
                    "项目管理计划\n项目文件(假设日志、成本估算、持续时间估算、问题日志、资源需求、风险登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(风险概率和影响评估、概率和影响矩阵、风险数据质量评估、风险分类、紧迫性评估)\n人际关系与团队技能(会议)",
                    "项目文件更新(风险登记册)"
                },
                {
                    "规划过程组",
                    "实施定量风险分析",
                    "就已识别的单个项目风险和不确定性的其他来源对整体项目目标的综合影响进行定量分析",
                    "项目管理计划\n项目文件(成本管理计划、范围基准、进度管理计划、风险登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(敏感性分析、预期货币价值分析、建模与仿真)\n会议",
                    "项目文件更新(风险登记册)"
                },
                {
                    "规划过程组",
                    "规划风险应对",
                    "为处理整体项目风险敞口，以及应对单个项目风险，而制定可选方案、选择应对策略并商定应对行动",
                    "项目管理计划\n项目文件(成本管理计划、需求文件、进度管理计划、范围基准、风险登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析、成本效益分析)\n决策(投票)\n人际关系与团队技能(谈判)\n会议",
                    "项目文件更新(风险登记册、假设日志)\n变更请求"
                },
                {
                    "执行过程组",
                    "实施风险应对",
                    "执行商定的风险应对计划",
                    "项目管理计划\n项目文件(风险登记册、假设日志、进度计划、成本估算)\n组织过程资产",
                    "专家判断\n人际关系与团队技能(影响力)",
                    "项目文件更新(风险登记册、假设日志、问题日志)\n工作绩效数据"
                },
                {
                    "监控过程组",
                    "监督风险",
                    "在整个项目期间，监督商定的风险应对计划的实施、跟踪已识别风险、识别和分析新风险，以及评估风险管理过程的有效性",
                    "项目管理计划\n项目文件(经验教训登记册、风险登记册、假设日志、问题日志)\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "数据分析(技术绩效分析、储备分析)\n审计\n会议",
                    "工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            for (int i = 0; i < riskData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    riskData[i, 0],
                    riskData[i, 1],
                    riskData[i, 2],
                    riskData[i, 3],
                    riskData[i, 4],
                    riskData[i, 5]
                );
            }

            dataGridView.PerformLayout();
            dataGridView.Refresh();
        }

        private void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ControlHelper.dgvMain_CellPainting(sender, e, mergeCells, dataGridView);
        }
    }
}

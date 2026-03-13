using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeManagementApp.UserControls
{
    public class QualityManagementControl : UserControl
    {
        private DataGridView dataGridView;

        public QualityManagementControl()
        {
            InitializeComponent();
            LoadQualityData();
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

            this.Controls.Add(dataGridView);
        }

        private void LoadQualityData()
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

            string[,] qualityData = {
                {
                    "规划过程组",
                    "规划质量管理",
                    "识别项目及其可交付成果的质量要求和/或标准，并书面描述项目将如何证明符合质量要求",
                    "项目管理计划\n项目文件(假设日志、经验教训登记册、风险登记册、需求文件、资源需求、干系人登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(成本效益分析、质量成本、标杆对照)\n会议",
                    "质量管理计划\n质量测量指标\n项目管理计划更新"
                },
                {
                    "管理质量过程组",
                    "管理质量",
                    "把组织的质量政策应用于项目，并将质量管理计划转化为可执行的质量活动",
                    "项目管理计划\n项目文件(经验教训登记册、质量测量指标、测试与评估文件)\n批准的变更请求\n质量控制测量结果\n项目文件\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "数据分析(备选方案分析、文件分析、过程分析、根本原因分析)\n检查\n测试/产品评估\n会议",
                    "质量报告\n测试与评估文件\n项目文件更新\n组织过程资产更新"
                },
                {
                    "监控过程组",
                    "控制质量",
                    "监督并记录质量管理活动的执行结果，以评估绩效，确保项目输出完整、正确且满足客户期望",
                    "项目管理计划\n项目文件(质量测量指标、测试与评估文件、经验教训登记册)\n批准的变更请求\n可交付成果\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "数据分析(检查、测试/产品评估、根本原因分析)\n检查\n测试/产品评估",
                    "质量控制测量结果\n核实的可交付成果\n工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            for (int i = 0; i < qualityData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    qualityData[i, 0],
                    qualityData[i, 1],
                    qualityData[i, 2],
                    qualityData[i, 3],
                    qualityData[i, 4],
                    qualityData[i, 5]
                );
            }

            dataGridView.PerformLayout();
            dataGridView.Refresh();
        }
    }
}

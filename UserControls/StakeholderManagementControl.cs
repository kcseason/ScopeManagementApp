
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeManagementApp
{
    public class StakeholderManagementControl : UserControl
    {
        private DataGridView dataGridView;

        public StakeholderManagementControl()
        {
            InitializeComponent();
            LoadStakeholderData();
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

        private void LoadStakeholderData()
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

            string[,] stakeholderData = {
                {
                    "启动过程组",
                    "识别干系人",
                    "识别能影响项目或受项目影响的人员、群体或组织，并分析他们对项目的影响程度",
                    "项目章程\n商业文件\n协议\n采购文档\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析)\n会议",
                    "干系人登记册"
                },
                {
                    "规划过程组",
                    "规划干系人参与",
                    "根据干系人的需求、期望、利益和对项目的潜在影响，制定项目干系人参与策略",
                    "项目管理计划\n项目文件(干系人登记册、假设日志、变更日志、问题日志、经验教训登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析)\n会议",
                    "干系人参与计划"
                },
                {
                    "执行过程组",
                    "管理干系人参与",
                    "与干系人进行沟通和协作，以满足其需求与期望，处理问题，并促进干系人合理参与项目活动",
                    "项目管理计划\n项目文件(变更日志、问题日志、经验教训登记册、干系人登记册、干系人参与计划)\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "人际关系与团队技能(基本规则、领导力、情商、影响力、政治意识)\n ground rules\n会议",
                    "问题日志\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                },
                {
                    "监控过程组",
                    "监督干系人参与",
                    "监督项目干系人关系，并通过修订参与策略和计划来调整干系人参与策略和计划",
                    "项目管理计划\n项目文件(问题日志、经验教训登记册、干系人参与计划)\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "数据分析(备选方案分析、根本原因分析)\n会议",
                    "工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新"
                }
            };

            for (int i = 0; i < stakeholderData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    stakeholderData[i, 0],
                    stakeholderData[i, 1],
                    stakeholderData[i, 2],
                    stakeholderData[i, 3],
                    stakeholderData[i, 4],
                    stakeholderData[i, 5]
                );
            }

            dataGridView.PerformLayout();
            dataGridView.Refresh();
        }
    }
}

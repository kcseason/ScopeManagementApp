using PMPManagementApp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeManagementApp.UserControls
{
    public class ResourceManagementControl : UserControl
    {
        private DataGridView dataGridView;
        private Dictionary<(int, int, int), string> mergeCells = new Dictionary<(int, int, int), string>
        {
            { (0, 1, 2), "规划过程组" },
            { (0, 3, 5), "监控过程组" }
        };
        public ResourceManagementControl()
        {
            InitializeComponent();
            LoadResourceData();
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

        private void LoadResourceData()
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

            string[,] resourceData = {
                {
                    "规划过程组",
                    "规划资源管理",
                    "定义如何估算、获取、管理和利用团队以及实物资源",
                    "项目管理计划\n项目文件(假设日志、成本估算、风险登记册、干系人登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n数据分析(备选方案分析、成本效益分析)\n会议",
                    "资源管理计划\n团队章程"
                },
                {
                    "规划过程组",
                    "估算活动资源",
                    "估算执行项目所需的团队资源，以及材料、设备和用品的类型和数量",
                    "项目管理计划\n项目文件(活动清单、活动属性、假设日志、成本估算、资源分解结构、风险登记册)\n事业环境因素\n组织过程资产",
                    "专家判断\n自下而上估算\n数据分析(备选方案分析)\n会议",
                    "资源需求\n估算依据"
                },
                {
                    "执行过程组",
                    "获取资源",
                    "获取项目所需的团队成员、设施、设备、材料、用品和其他资源",
                    "项目管理计划\n项目文件(资源需求、估算依据、资源分解结构)\n事业环境因素\n组织过程资产",
                    "决策(多标准决策分析)\n人际关系与团队技能(谈判、预分派、虚拟团队)\n预分派",
                    "实物资源分配单\n项目团队派工单\n资源日历\n变更请求\n项目管理计划更新\n项目文件更新\n事业环境因素更新\n组织过程资产更新"
                },
                {
                    "执行过程组",
                    "建设团队",
                    "提高工作能力，促进团队成员互动，改善团队整体氛围，以提高项目绩效",
                    "项目管理计划\n项目文件(资源管理计划、团队章程、项目团队派工单、资源日历、经验教训登记册)\n事业环境因素\n组织过程资产",
                    "人际关系与团队技能(冲突管理、影响力、激励、谈判、团队建设活动)\n认可与奖励\n培训\n个人和团队评估",
                    "团队绩效评价\n变更请求\n项目管理计划更新\n项目文件更新\n事业环境因素更新\n组织过程资产更新"
                },
                {
                    "执行过程组",
                    "管理团队",
                    "跟踪团队成员工作表现，提供反馈，解决问题并管理团队变更，以优化项目绩效",
                    "项目管理计划\n项目文件(资源管理计划、团队章程、项目团队派工单、资源日历、团队绩效评价、经验教训登记册)\n工作绩效报告\n协议\n组织过程资产",
                    "人际关系与团队技能(冲突管理、影响力、领导力)\n项目管理信息系统",
                    "变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                },
                {
                    "监控过程组",
                    "控制资源",
                    "确保按计划为项目分配实物资源，并根据需要监督资源实际使用情况，并采取必要纠正措施",
                    "项目管理计划\n项目文件(资源需求、估算依据、资源分解结构、资源日历、团队绩效评价)\n工作绩效数据\n事业环境因素\n组织过程资产",
                    "数据分析(绩效审查、资源优化技术)\n项目管理信息系统",
                    "工作绩效信息\n变更请求\n项目管理计划更新\n项目文件更新\n组织过程资产更新"
                }
            };

            for (int i = 0; i < resourceData.GetLength(0); i++)
            {
                dataGridView.Rows.Add(
                    resourceData[i, 0],
                    resourceData[i, 1],
                    resourceData[i, 2],
                    resourceData[i, 3],
                    resourceData[i, 4],
                    resourceData[i, 5]
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

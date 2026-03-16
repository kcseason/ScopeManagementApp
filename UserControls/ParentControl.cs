using ScopeManagementApp;

namespace PMPManagementTool.UserControls
{
    public partial class ParentControl : UserControl
    {
        public DataGridView dataGridView;
        public string ControlName;
        private SearchForm searchForm;

        public ParentControl()
        {
            InitializeComponent();
        }

        public virtual void InitializeComponent()
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

            dataGridView.KeyDown += DataGridView_KeyDown; ;
            this.Controls.Add(dataGridView);
        }

        private void DataGridView_KeyDown(object? sender, KeyEventArgs e)
        {
            // 处理Ctrl+F快捷键
            if (e.Control && e.KeyCode == Keys.F)
            {
                ShowSearchForm();
                e.Handled = true;
            }
        }

        private void ShowSearchForm()
        {
            // 显示搜索窗体（修复：每次都检查并创建新实例）
            if (searchForm == null || searchForm.IsDisposed)
            {
                searchForm = new SearchForm((MainForm)this.FindForm());
            }

            // 确保窗体可见并获得焦点
            if (!searchForm.Visible)
            {
                searchForm.Show();
            }

            searchForm.BringToFront();
            searchForm.Activate();
        }

        public void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e, Dictionary<(int, int, int), string> mergeCells)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            foreach (var item in mergeCells)
            {
                if (item.Key.Item1 == e.ColumnIndex)
                {
                    if (item.Key.Item2 == e.RowIndex)
                    {
                        using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        using (Pen gridLinePen = new Pen(dataGridView.GridColor))
                        {
                            // 1. 擦除原本內容
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            // 2. 繪製左右邊框
                            if (e.ColumnIndex == 0)
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                            // 4. 繪製文字 (只在起始行繪製，計算兩行總高度)
                            Rectangle mergedArea = e.CellBounds;
                            mergedArea.Height = (item.Key.Item3 - item.Key.Item2) * mergedArea.Height;

                            TextRenderer.DrawText(e.Graphics, item.Value, e.CellStyle.Font,
                                mergedArea, e.CellStyle.ForeColor,
                                TextFormatFlags.Left | TextFormatFlags.Top);
                        }

                        // 5. 阻止系統重複繪製
                        e.Handled = true;
                    }
                    else if (item.Key.Item3 == e.RowIndex)
                    {
                        using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        using (Pen gridLinePen = new Pen(dataGridView.GridColor))
                        {
                            // 1. 擦除原本內容
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            // 2. 繪製左右邊框
                            if (e.ColumnIndex == 0)
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                            // 3. 根據行位置繪製頂/底橫線
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        }

                        // 5. 阻止系統重複繪製
                        e.Handled = true;
                    }
                    else if (e.RowIndex > item.Key.Item2 && e.RowIndex < item.Key.Item3)
                    {
                        using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        using (Pen gridLinePen = new Pen(dataGridView.GridColor))
                        {
                            // 1. 擦除原本內容
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            // 2. 繪製左右邊框
                            if (e.ColumnIndex == 0)
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                        }

                        // 5. 阻止系統重複繪製
                        e.Handled = true;
                    }
                }
            }
        }
    }
}

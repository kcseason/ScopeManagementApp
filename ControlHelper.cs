namespace PMPManagementApp
{
    public static class ControlHelper
    {
        public static void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e, Dictionary<(int, int, int), string> mergeCells, DataGridView dataGridView)
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

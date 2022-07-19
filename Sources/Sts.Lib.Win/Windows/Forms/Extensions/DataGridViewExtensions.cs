using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sts.Lib.Win.Windows.Forms.Extensions;

public static class DataGridViewExtensions
{
    public static T GetCellValueOrDefault<T>(this System.Windows.Forms.DataGridView dataGridView, int row, int col, T def)
    {
        return GetCellValueOrDefault(dataGridView.Rows, row, col, def);
    }

    public static T GetSelectedCellValueOrDefault<T>(this System.Windows.Forms.DataGridView dataGridView, int row, int col, T def)
    {
        return GetCellValueOrDefault(dataGridView.SelectedRows, row, col, def);
    }

    public static IEnumerable<DataGridViewRow> GetRows(this System.Windows.Forms.DataGridView dataGridView)
    {
        return dataGridView?.Rows?.OfType<DataGridViewRow>()??Array.Empty<DataGridViewRow>();
    }
    public static IEnumerable<DataGridViewColumn> GetColumns(this System.Windows.Forms.DataGridView dataGridView)
    {
        return dataGridView?.Columns?.OfType<DataGridViewColumn>()??Array.Empty<DataGridViewColumn>();
    }
    public static IEnumerable<DataGridViewColumn> GetSelectedColumns(this System.Windows.Forms.DataGridView dataGridView)
    {
        return dataGridView?.SelectedColumns?.OfType<DataGridViewColumn>()??Array.Empty<DataGridViewColumn>();
    }

    public static IEnumerable<DataGridViewRow> GetSelectedRows(this System.Windows.Forms.DataGridView dataGridView)
    {
        return dataGridView?.SelectedRows?.OfType<DataGridViewRow>()??Array.Empty<DataGridViewRow>();
    }

    public static IEnumerable<DataGridViewCell> GetCells(this DataGridViewRow dataGridViewRow)
    {
        return  dataGridViewRow?.Cells?.OfType<DataGridViewCell>()??Array.Empty<DataGridViewCell>();
    }

    private static T GetCellValueOrDefault<T>(System.Collections.ICollection collection, int row, int col, T def)
    {
        var gridViewRow = collection?.OfType<DataGridViewRow>()?.ElementAtOrDefault(row);

        if (gridViewRow == null)
        {
            return def;
        }

        var gridViewCell = gridViewRow.Cells.OfType<DataGridViewCell>().ElementAtOrDefault(col);

        if (gridViewCell == null)
        {
            return def;
        }

        var value = gridViewCell?.Value;

        if (value is T v)
        {
            return v;
        }

        return def;
    }
}
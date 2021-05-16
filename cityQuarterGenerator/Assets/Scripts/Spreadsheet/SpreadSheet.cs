using System.Collections.Generic;
using UnityEngine;

namespace MathUtils.Spreadsheet
{
    public abstract class Spreadsheet<T> where T : SpreadsheetBaseValue
    {
        protected readonly List<SpreadsheetCell<T>> Cells;
        public int RowsCount { get; }
        public int ColumnsCount { get; }
        
        public Spreadsheet(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            Cells = new List<SpreadsheetCell<T>>(rowsCount * columnsCount);
        }


        protected void SetCellReference(int rowIndex, int columnIndex, SpreadsheetCell<T> cell)
        {
            Cells[rowIndex * ColumnsCount + columnIndex] = cell;
        }

        private void SetCellValue(int rowIndex, int columnIndex, SpreadsheetCell<T> sourceCell)
        {
            var cell = Cells[rowIndex * ColumnsCount + columnIndex];
            cell.ColumnIndex = sourceCell.ColumnIndex;
            cell.CellValue = sourceCell.CellValue.GetCopy();
            cell.RowIndex = sourceCell.RowIndex;
        }

        public SpreadsheetCell<T> GetCell(int rowIndex, int columnIndex)
        {
            return Cells[rowIndex * ColumnsCount + columnIndex];
        }
        
        public SpreadsheetCell<T> GetCell(int index)
        {
            return Cells[index];
        }
        
        public SpreadsheetCell<T> GetCellCopy(int rowIndex, int columnIndex)
        {
            return Cells[rowIndex * ColumnsCount + columnIndex].GetCopy();
        }
        
        public virtual void SetTheSameValues(Spreadsheet<T> table)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    table.SetCellValue(i, j, GetCell(i, j));
                }
            }
        }
    }
}
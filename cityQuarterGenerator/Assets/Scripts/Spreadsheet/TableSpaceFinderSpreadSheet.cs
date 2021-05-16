using System.Collections.Generic;
using UnityEngine;

namespace MathUtils.Spreadsheet
{
    public class TableSpaceFinderSpreadSheet : Spreadsheet<SpaceFinderSpreadSheetCellValue>
    {
        public List<int> ActiveCells { get; private set; }

        public TableSpaceFinderSpreadSheet(int rowsCount, int columnsCount)
            : base(rowsCount, columnsCount)
        {
            ActiveCells = new List<int>(rowsCount * columnsCount);
            
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    Cells.Add(new SpreadsheetCell<SpaceFinderSpreadSheetCellValue>
                    {
                        RowIndex = i, ColumnIndex = j, CellValue = new SpaceFinderSpreadSheetCellValue()
                    });
                    ActiveCells.Add(i * ColumnsCount + j);
                }
            }
        }

        public void SetCellInactive(int rowIndex, int columnIndex)
        {
            int index = rowIndex * ColumnsCount + columnIndex;
            SetCellInactive(index);
        }

        public void SetCellInactive(int index)
        {
            SpreadsheetCell<SpaceFinderSpreadSheetCellValue> temp = Cells[index];

            var tempCellValue = (SpaceFinderSpreadSheetCellValue) temp.CellValue;

            if (tempCellValue.IsActive)
            {
                tempCellValue.IsActive = false;
                ActiveCells.Remove(index);
            }
        }

        public void SetCellInactive(SpreadsheetCell<SpaceFinderSpreadSheetCellValue> cell)
        {
            SetCellInactive(cell.RowIndex, cell.ColumnIndex);
        }

        /*public List<SpreadsheetCell<SpaceFinderSpreadSheetCellValue>> GetCellsOfRadiusFromCell(
            SpreadsheetCell<SpaceFinderSpreadSheetCellValue> cell, float radius, float cellSize)
        {
            int indexOffset = Mathf.CeilToInt(radius / cellSize);
            int rowStart = cell.RowIndex - indexOffset;

            if (rowStart < 0)
            {
                rowStart = 0;
            }

            int columnStart = cell.ColumnIndex - indexOffset;

            if (columnStart < 0)
            {
                columnStart = 0;
            }

            int rowEnd = cell.RowIndex + indexOffset;

            if (rowEnd > RowsCount - 1)
            {
                rowEnd = RowsCount - 1;
            }

            int columnEnd = cell.ColumnIndex + indexOffset;

            if (columnEnd > ColumnsCount - 1)
            {
                columnEnd = ColumnsCount - 1;
            }

            int count = (rowEnd - rowStart + 1) * (columnEnd - columnStart + 1);

            List<SpreadsheetCell<SpaceFinderSpreadSheetCellValue>>
                cells = new List<SpreadsheetCell<SpaceFinderSpreadSheetCellValue>>(count);
            float extendedRadius = radius + cellSize / 2;
            float sqrExtendedRadius = extendedRadius * extendedRadius;

            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = columnStart; j <= columnEnd; j++)
                {
                    var checkingCell = GetCell(i, j);

                    if ((((SpaceFinderSpreadSheetCellValue) cell.CellValue).Position -
                         ((SpaceFinderSpreadSheetCellValue) checkingCell.CellValue).Position).sqrMagnitude <
                        sqrExtendedRadius)
                    {
                        cells.Add(checkingCell);
                    }
                }
            }

            return cells;
        }
*/
        public TableSpaceFinderSpreadSheet GetCopy()
        {
            var copy = new TableSpaceFinderSpreadSheet(RowsCount, ColumnsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    copy.SetCellReference(i, j, GetCellCopy(i, j));
                }
            }

            return copy;
        }

        public void SetCellCenterPos(int rowIndex, int columnIndex, Vector2 position)
        {
            ((SpaceFinderSpreadSheetCellValue) Cells[rowIndex * ColumnsCount + columnIndex].CellValue).Position = position;
        }

        public override void SetTheSameValues(Spreadsheet<SpaceFinderSpreadSheetCellValue> table)
        {
            if (table is TableSpaceFinderSpreadSheet sheet)
            {
                base.SetTheSameValues(sheet);
                sheet.ActiveCells = new List<int>(ActiveCells);
            }
        }
    }
}
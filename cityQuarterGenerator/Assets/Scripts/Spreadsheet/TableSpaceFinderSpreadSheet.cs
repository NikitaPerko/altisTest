using System.Collections.Generic;
using UnityEngine;

namespace MathUtils.Spreadsheet
{
    public class TableSpaceFinderSpreadSheet : Spreadsheet<SpaceFinderSpreadSheetCellValue>
    {
        private readonly float _cellSize;
        public List<int> RandomActiveCells { get; private set; }

        public int lastActiveRandomCellIndex;

        public TableSpaceFinderSpreadSheet(int rowsCount, int columnsCount, float cellSize)
            : base(rowsCount, columnsCount)
        {
            _cellSize = cellSize;
            RandomActiveCells = new List<int>(rowsCount * columnsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    Cells.Add(new SpreadsheetCell<SpaceFinderSpreadSheetCellValue>
                    {
                        RowIndex = i, ColumnIndex = j, CellValue = new SpaceFinderSpreadSheetCellValue()
                    });
                    RandomActiveCells.Add(i * ColumnsCount + j);
                }
            }

            for (int i = 0; i < RandomActiveCells.Count; i++)
            {
                int randomIndex = Random.Range(0, RandomActiveCells.Count);
                int temp = RandomActiveCells[i];
                RandomActiveCells[i] = RandomActiveCells[randomIndex];
                RandomActiveCells[randomIndex] = temp;
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

            var tempCellValue = temp.CellValue;

            if (tempCellValue.IsActive)
            {
                tempCellValue.IsActive = false;
                lastActiveRandomCellIndex++;
            }
        }

        public void SetCellInactive(SpreadsheetCell<SpaceFinderSpreadSheetCellValue> cell)
        {
            SetCellInactive(cell.RowIndex, cell.ColumnIndex);
        }

        public SpreadsheetCell<SpaceFinderSpreadSheetCellValue> GetRandomActiveCell()
        {
            return GetCell(RandomActiveCells[lastActiveRandomCellIndex]);
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
            var copy = new TableSpaceFinderSpreadSheet(RowsCount, ColumnsCount, _cellSize);

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
            (Cells[rowIndex * ColumnsCount + columnIndex].CellValue).Position = position;
        }

        public override void SetTheSameValues(Spreadsheet<SpaceFinderSpreadSheetCellValue> table)
        {
            if (table is TableSpaceFinderSpreadSheet sheet)
            {
                base.SetTheSameValues(sheet);
                sheet.RandomActiveCells = new List<int>(RandomActiveCells);
            }
        }

        public void DrawGizmos()
        {
            /* for (var index = 0; index < Cells.Count; index++)
             {
                 var cell = Cells[index];
                 var pos = cell.CellValue.Position;
                 Gizmos.color = cell.CellValue.IsActive ? Color.green : Color.red;
                 Gizmos.DrawCube(new Vector3(pos.x, 1, pos.y), Vector3.one * _cellSize);
             }*/
        }
    }
}
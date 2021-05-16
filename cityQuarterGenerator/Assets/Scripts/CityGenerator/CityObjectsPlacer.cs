using System.Collections.Generic;
using MathUtils.Spreadsheet;
using UnityEngine;

namespace CityGenerator
{
    public class CityObjectsPlacer
    {
        private BoundsOctree<CityElement> _octree;
        private TableSpaceFinderSpreadSheet _spreadsheet;
        private float cellSize;

        public void PlaceObjects(float x, float y, List<CityObject> objectsToPlace, AnalyzisResult analyzisResult)
        {
            cellSize = analyzisResult.cellSize;

            float maxBorder = x > y ? x : y;
            _octree = new BoundsOctree<CityElement>(maxBorder, new Vector3(0f, 0f), cellSize, 1f);
            
            int rowsCount = (int) (x / cellSize);
            int columnsCount = (int) (y / cellSize);

            _spreadsheet = new TableSpaceFinderSpreadSheet(rowsCount, columnsCount);

            float xCellPos = cellSize / 2;
            float yCellPos = y - cellSize / 2;

            for (int i = 0; i < _spreadsheet.RowsCount; i++)
            {
                float rowStartXCellPos = xCellPos;

                for (int j = 0; j < _spreadsheet.ColumnsCount; j++)
                {
                    _spreadsheet.SetCellCenterPos(i, j, new Vector2(xCellPos, yCellPos));
                    xCellPos += cellSize;
                }

                yCellPos -= cellSize;
                xCellPos = rowStartXCellPos;
            }
            
            foreach (var objectToPlace in objectsToPlace)
            {
                
            }
        }

        public void DrawGizmos()
        {
            _octree?.DrawAllBounds();
            _octree?.DrawAllObjects();

            if (_spreadsheet != null)
            {
                for (int i = 0; i < _spreadsheet.RowsCount; i++)
                {
                    for (int j = 0; j < _spreadsheet.ColumnsCount; j++)
                    {
                      //  var cellPosition = ((SpaceFinderSpreadSheetCellValue) _spreadsheet.GetCell(i, j).CellValue).Position;
                      //  Gizmos.DrawWireCube(new Vector3(cellPosition.x, 0, cellPosition.y), Vector3.one * cellSize);
                    }
                }
            }
        }
    }
}
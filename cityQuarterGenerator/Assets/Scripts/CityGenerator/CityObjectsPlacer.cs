using System.Collections.Generic;
using MathUtils.Spreadsheet;
using UnityEngine;

namespace CityGenerator
{
    public class CityObjectsPlacer
    {
        private BoundsOctree<CityElement> _octree;
        private TableSpaceFinderSpreadSheet _spreadsheet;
        private Vector3 minBoundsSize;

        public void PlaceObjects(float x, float y, List<CityObject> objectsToPlace, AnalyzisResult analyzisResult)
        {
            /* objectsToPlace.Sort((a, b) =>
             {
                 float diff = a.objectInfo.BoundingBoxVolume - b.objectInfo.BoundingBoxVolume;
 
                 if (diff > 0)
                 {
                     return 1;
                 }
 
                 if (diff < 0)
 
                 {
                     return -1;
                 }
 
                 return 0;
             });*/

            minBoundsSize = analyzisResult.minBoundsSize;

            CreateSpreadSheet(x, y, objectsToPlace.Count);

            _octree = new BoundsOctree<CityElement>(new Vector3(x, analyzisResult.maxYSize, y),
                new Vector3(x / 2, analyzisResult.maxYSize / 2, y / 2), minBoundsSize, 1f);

            int placedObjectIndex = 0;

            while (placedObjectIndex < objectsToPlace.Count &&
                   _spreadsheet.lastActiveRandomCellIndex < _spreadsheet.RandomActiveCells.Count)
            {
                bool finded = false;
                var activeCell = _spreadsheet.GetRandomActiveCell();

                int i = placedObjectIndex;

                for (; i < objectsToPlace.Count; i++)
                {
                    var objectToPlace = objectsToPlace[i];
                    var objectTransform = objectToPlace.Object.transform;

                    if (!activeCell.CellValue.IsActive)
                    {
                        Debug.LogError("Cell is not active");
                    }

                    Vector3 position = objectTransform.position;
                    position.x = activeCell.CellValue.Position.x;
                    position.y = objectToPlace.objectInfo.CorrectYPos;
                    position.z = activeCell.CellValue.Position.y;

                    objectTransform.position = position;
                    var bounds = objectToPlace.MeshRenderer.bounds;

                    if (!_octree.IsColliding(bounds))
                    {
                        var node = _octree.Add(objectToPlace.objectInfo, bounds);

                        if (node != null)
                        {
                            finded = true;
                            break;
                        }
                    }
                }

                if (finded)
                {
                    var t = objectsToPlace[i];
                    objectsToPlace[i] = objectsToPlace[placedObjectIndex];
                    objectsToPlace[placedObjectIndex] = t;
                    placedObjectIndex++;
                }

                _spreadsheet.SetCellInactive(activeCell);
            }

            for (var index = placedObjectIndex; index < objectsToPlace.Count; index++)
            {
                Object.Destroy(objectsToPlace[index].Object);
            }
        }

        private void CreateSpreadSheet(float x, float y, int objectsCount)
        {
            float cellSize = 1 / Mathf.Pow(x * y * objectsCount, 0.2f);
            int rowsCount = (int) (x / cellSize);
            int columnsCount = (int) (y / cellSize);

            _spreadsheet = new TableSpaceFinderSpreadSheet(rowsCount, columnsCount, cellSize);

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
        }

        public void DrawGizmos()
        {
            _octree?.DrawAllBounds();
            _octree?.DrawAllObjects();
            _spreadsheet?.DrawGizmos();
        }
    }
}
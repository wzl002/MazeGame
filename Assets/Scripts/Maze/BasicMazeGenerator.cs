using UnityEngine;
using System.Collections;

//Maze generater
public abstract class MazeGenerator {


	private int mazeRows;
	private int mazeColumns;
	private MazeCell[,] mazeCells;

    public int RowCount { get { return mazeRows; } }
    public int ColumnCount { get { return mazeColumns; } }

    public MazeGenerator(int rows, int columns){
		mazeRows = Mathf.Abs(rows);
		mazeColumns = Mathf.Abs(columns);
		if (mazeRows == 0) {
			mazeRows = 1;
		}
		if (mazeColumns == 0) {
			mazeColumns = 1;
		}
		mazeCells = new MazeCell[rows,columns];
		for (int row = 0; row < rows; row++) {
			for(int column = 0; column < columns; column++){
				mazeCells[row,column] = new MazeCell();
			}
		}
	}

	public abstract void GenerateMaze();

	public MazeCell GetMazeCell(int row, int column){
		if (row >= 0 && column >= 0 && row < mazeRows && column < mazeColumns) {
			return mazeCells[row,column];
		}else{
			Debug.Log(row+" "+column);
			throw new System.ArgumentOutOfRangeException();
		}
	}

	protected void SetMazeCell(int row, int column, MazeCell cell){
		if (row >= 0 && column >= 0 && row < mazeRows && column < mazeColumns) {
			mazeCells[row,column] = cell;
		}else{
			throw new System.ArgumentOutOfRangeException();
		}
	}
}

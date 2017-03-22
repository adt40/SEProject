using System;

public class Square
{
    private Coordinate pos;
    private int isBomb;
    private bool hasFlag;
    private bool hasClicked;
    private int numAdjBombs;

	public Square(Coordinate pos, int isBomb)
	{
        this.pos = pos;
        this.isBomb = isBomb;
        hasFlag = false;
        hasClicked = false;
        numAdjBombs = 0; //init value, will change with Map calculation
	}

    public Coordinate getPos()
    {
        return pos;
    }

    public void setPos(Coordinate pos)
    {
        this.pos = pos;
    }

    public int isBomb()
    {
        return isBomb;
    }

    public void setBomb(int isBomb)
    {
        this.isBomb = isBomb;
    }

    public boolean hasFlag()
    {
        return hasFlag;
    }

    public void setFlag(boolean hasFlag)
    {
        this.hasFlag = hasFlag;
    }

    public boolean hasClicked()
    {
        return hasClicked;
    }

    public void setClicked(boolean hasClicked)
    {
        this.hasClicked = hasClicked;
    }

    public int getNumAdjBombs()
    {
        return numAdjBombs;
    }

    public void setNumAdjBombs(int numAdjBombs)
    {
        this.numAdjBombs = numAdjBombs;
    }

}

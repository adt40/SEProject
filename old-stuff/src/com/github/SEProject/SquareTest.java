package com.github.SEProject;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class SquareTest {

	Coordinate testPos;
	Square testSquare;
	
	@Before
	public void setUp(){
		testPos = new Coordinate(3, 4);
		testSquare = new Square(testPos, 1);
	}
	
	@Test
	public void testGetters() {
		assertEquals(testSquare.getPos(), new Coordinate(3, 4));
		assertEquals(testSquare.isBomb(), 1);
		assertFalse(testSquare.hasClicked());
		assertFalse(testSquare.hasFlag());
		assertEquals(testSquare.getNumAdjBombs(), 0);
	}
	
	@Test
	public void testSetters(){
		Coordinate newPos = new Coordinate(6, 7);
		testSquare.setPos(newPos);
		assertEquals(testSquare.getPos(), new Coordinate(6, 7));
		testSquare.setBomb(0);
		assertEquals(testSquare.isBomb(), 0);
		testSquare.setFlag(true);
		assertTrue(testSquare.hasFlag());
		testSquare.setClicked(true);
		assertTrue(testSquare.hasClicked());
		testSquare.setNumAdjBombs(3);
		assertEquals(testSquare.getNumAdjBombs(), 3);
		
	}

}

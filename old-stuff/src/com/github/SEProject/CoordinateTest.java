package com.github.SEProject;

import static org.junit.Assert.*;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import com.github.SEProject.Coordinate;

public class CoordinateTest {
	
	Coordinate test1;
	
	@Before
	public void setUp(){
		test1 = new Coordinate(5, 1);
	}

	@Test
	public void testConstructorandGetters() {
		assertEquals(5, test1.getX());
		assertEquals(1, test1.getY());
	}
	
	@Test
	public void testSetters(){
		test1.setX(3);
		test1.setY(7);
		
		assertEquals(3, test1.getX());
		assertEquals(7, test1.getY());
	}
	
	@Test
	public void testHashCode(){
		assertEquals(test1.hashCode(), 1117);		
	}
	
	@Test
	public void testEqualsAllCases(){
		assertTrue(test1.equals(test1));
		assertFalse(test1.equals(null));
		String otherObject = "Other";
		assertFalse(test1.equals(otherObject));
		Coordinate test2 = new Coordinate(4, 2);
		Coordinate test3 = new Coordinate(5, 2);
		Coordinate test4 = new Coordinate(5, 1);
		assertFalse(test1.equals(test2));
		assertFalse(test1.equals(test3));
		assertTrue(test1.equals(test4));
	}
}

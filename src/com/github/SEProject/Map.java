package com.github.SEProject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.Random;

public class Map {

	private int width, height;
	private int numBombs;
	private HashMap<Coordinate, Square> squares;
	private Generator generator;
	
	public Map(int width, int height, int numBombs) {
		this.width = width;
		this.height = height;
		this.numBombs = numBombs;
		generator = new Generator();
		squares = generator.generate(width, height, numBombs);
	}
	
	public Map(File mapFile) {
		//width, height, and numbombs set in generator method
		generator = new Generator();
		squares = generator.generate(mapFile);
	}
	
	public void setAdjBombVals() {
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				squares.get(new Coordinate(i,j)).setNumAdjBombs(
						squares.get(new Coordinate(i+1,j)).isBomb() +
						squares.get(new Coordinate(i-1,j)).isBomb() +
						squares.get(new Coordinate(i,j+1)).isBomb() +
						squares.get(new Coordinate(i,j-1)).isBomb() +
						squares.get(new Coordinate(i+1,j+1)).isBomb() +
						squares.get(new Coordinate(i+1,j-1)).isBomb() +
						squares.get(new Coordinate(i-1,j+1)).isBomb() +
						squares.get(new Coordinate(i-1,j-1)).isBomb());
			}
		}
	}
	

	public int getWidth() {
		return width;
	}

	public void setWidth(int width) {
		this.width = width;
	}

	public int getHeight() {
		return height;
	}

	public void setHeight(int height) {
		this.height = height;
	}

	public int getNumBombs() {
		return numBombs;
	}

	public void setNumBombs(int numBombs) {
		this.numBombs = numBombs;
	}

	public Square getSquare(Coordinate c) {
		return squares.get(c);
	}

	public void addSquare(Coordinate c, Square s) {
		//Might not ever be used, check if can be deleted later
		squares.put(c, s);
	}
	
	
	private class Generator {
		
		public Generator(){};
		
		public HashMap<Coordinate,Square> generate(int width, int height, int numBombs) {
			HashMap<Coordinate,Square> squares = new HashMap<>();
			for (int i = 0; i < width; i++) {
				for (int j = 0; j < height; j++) {
					Coordinate c = new Coordinate(i,j);
					squares.put(c, new Square(c,0));
				}
			}
			int k = 0;
			while (k < numBombs) {
				Random rng = new Random();
				int x = rng.nextInt(width);
				int y = rng.nextInt(height);
				Coordinate c = new Coordinate(x,y);
				Square s = squares.get(c);
				if (s.isBomb() == 0) {
					s.setBomb(1);
				}
			}
			return squares;
		}
		
		//If the file picker returns the path of the file, we should change this 
		//to accept that string rather than the file itself
		public HashMap<Coordinate,Square> generate(File mapFile) {
			HashMap<Coordinate, Square> squares = new HashMap<>();
			FileReader fr = null;
			BufferedReader br = null;
			try  {
				fr = new FileReader(mapFile.getAbsolutePath());
				br = new BufferedReader(fr);

				width = Integer.parseInt(br.readLine());
				height = Integer.parseInt(br.readLine());
				
				String line = "";
				
				for (int y = 0; y < height; y++) {
					line = br.readLine();
					for (int x = 0; x < width; x++) {
						Coordinate c = new Coordinate(x,y);
						if (line.charAt(x) == 'X') {
							squares.put(c, new Square(c,1));
							numBombs++;
						} else {
							squares.put(c, new Square(c,0));
						}
					}
				}
				br.close();
				fr.close();
			} catch (IOException e) {
				e.printStackTrace();
			} catch (NumberFormatException e) {
				e.printStackTrace();
			}
			
			return squares;
		}
		
		
		public void createMapFile(String filename) {
			FileWriter fw = null;
			BufferedWriter bw = null;
			
			try {
				fw = new FileWriter(filename);
				bw = new BufferedWriter(fw);
				
				bw.write(width);
				bw.newLine();
				bw.write(height);
				bw.newLine();
				bw.flush();
				
				for (int y = 0; y < height; y++) {
					String line = "";
					for (int x = 0; x < width; x++) {
						Coordinate c = new Coordinate(x,y);
						if (squares.get(c).isBomb() == 1) {
							line += 'X';
						} else {
							line += 'O';
						}
					}
					bw.write(line);
					bw.newLine();
					bw.flush();
				}
				bw.close();
				fw.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}		
}

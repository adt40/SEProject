/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.github.SEProject;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JOptionPane;
public class GamePanel extends JPanel {
	
    private JButton start;
    private int mouseX, mouseY;
    private int mapX, mapY;
    private JButton buttons[][];
    private Map map;
    
    
    
    public GamePanel(int x, int y, int bombs){
    	
        this.setLayout(null);
        
        
        /* Leaving this out for now
        start = new JButton();
        start.setText("Start Game");
        start.setBounds(125, 235, 250, 30);
        start.addActionListener(new StartButtonListener());
        */
        
        this.setLayout(new GridLayout(x, y, 0, 0));
        
        mapX = x;
        mapY = y;
        buttons = new JButton[x][y];
        map = new Map(x, y, bombs);
        
        for (int i = 0; i < buttons.length; i++) {
        	for (int j = 0; j < buttons[i].length; j++) {
        		buttons[i][j] = new JButton();
        		buttons[i][j].addActionListener(new MapButtonListener());
        		this.add(buttons[i][j]);
            }
        }		
        
        //this.add(start);
    }
    
    
    
    
    
    private class StartButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// start game
		}
    	
    }
    
    
    
    private class MapButtonListener implements ActionListener{

        @Override
        public void actionPerformed(ActionEvent e) {
        	
            JButton source = (JButton) e.getSource();
            for (int i = 0; i < buttons.length; i++) {
                for (int j = 0; j < buttons[i].length; j++) {
                    if (buttons[i][j].equals(source)) {
                        Coordinate c = new Coordinate(i,j);
                        Square square = map.getSquare(c);
                        if (square.isBomb() == 1) {
                        	buttons[i][j].setText("B");
                        	
                        } else {
                        	int numAdj = square.getNumAdjBombs();
                        	buttons[i][j].setText(numAdj + "");
                        	if (numAdj == 0) {
                        		//revealZeroes(i,j);
                        	}
                        }
                    }
                }
            }
        }
    }
    
    //stack overflows right now because it hits already revealed zeros, need to add check for this
    public void revealZeroes(int i, int j) {
    	if (i != mapX - 1) {
    		Square squareRight = map.getSquare(new Coordinate(i+1,j));
    		if (squareRight.getNumAdjBombs() == 0) {
    			buttons[i+1][j].setText("0");
    			revealZeroes(i+1, j);
    		}
    	}
    	if (i != 0) {
    		Square squareLeft = map.getSquare(new Coordinate(i-1,j));
    		if (squareLeft.getNumAdjBombs() == 0) {
    			buttons[i-1][j].setText("0");
    			revealZeroes(i-1, j);
    		}
    	}
    	if (j != mapY - 1) {
    		Square squareDown = map.getSquare(new Coordinate(i,j+1));
    		if (squareDown.getNumAdjBombs() == 0) {
    			buttons[i][j+1].setText("0");
    			revealZeroes(i, j+1);
    		}
    	}
    	if (j != 0) {
    		Square squareUp = map.getSquare(new Coordinate(i,j-1));
    		if (squareUp.getNumAdjBombs() == 0) {
    			buttons[i][j-1].setText("0");
    			revealZeroes(i, j-1);
    		}
    	}
    	
    }
    
    
    
    
    //what is this
    /*
    private class Clicker implements MouseListener{
        boolean pressed = false;
        @Override
        public void mouseClicked(MouseEvent me) {

                pressed = true;//To change body of generated methods, choose Tools | Templates.
        }

        @Override
        public void mousePressed(MouseEvent me) {
            throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        }

        @Override
        public void mouseReleased(MouseEvent me) {
            if(pressed==true){
                //change the button to "clicked"
            }
        }

        @Override
        public void mouseEntered(MouseEvent me) {
            throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        }

        @Override
        public void mouseExited(MouseEvent me) {
            throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        }
        
    }
    */
}

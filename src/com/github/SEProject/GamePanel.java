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
    private JButton buttons[][];
    private Map map;
    
    
    
    public GamePanel(int x, int y, int bombs){
    	
        this.setLayout(null);
        start = new JButton();
        start.setText("Start Game");
        start.setBounds(125, 235, 250, 30);
        start.addActionListener(new StartButtonListener());
        
        //JPanel buttonPanel = new JPanel();
        this.setLayout(new GridLayout(x, y, 0, 0));
        
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
                        
                    }
                }
            }
        }
    }
    
    
    
    
    
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

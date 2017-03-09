/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minesweeper;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JOptionPane;
public class GamePanel extends JPanel {
    JButton start;
    int mouseX, mouseY;
    static JButton stuff[][];
    static Map newGame;
    public GamePanel(int x, int y, int bombs){
        this.setLayout(null);
        start = new JButton();
        start.setText("Start Game");
	start.setBounds(125, 235, 250, 30);
	start.addActionListener(new MapStuff());
        JButton[][] stuff = new JButton[x][y];
	Map newGame = new Map(x, y, bombs);
	for (int i = 0; i < stuff.length; i++) {
                for (int j = 0; j < stuff[i].length; j++) {
                    stuff[i][j].addActionListener(new MapStuff());
                    
                }
            }		
	
        this.add(start);
    }
    private class MapStuff implements ActionListener{

        @Override
        public void actionPerformed(ActionEvent ae) {
            JButton[][] mapSquare = new JButton[5][5];
            JButton source = (JButton) ae.getSource();
            for (int i = 0; i < stuff.length; i++) {
                for (int j = 0; j < stuff[i].length; j++) {
                    if (stuff[i][j].equals(source)) {
                        Coordinate c = new Coordinate(i,j);
                        Square square = newGame.getSquare(c);
                    }
                }
            }
        }
        
    }
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
}

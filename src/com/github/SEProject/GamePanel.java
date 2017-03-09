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
import java.awt.event.MouseMotionListener;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JOptionPane;
public class GamePanel extends JPanel {
    JButton start;
    int mouseX, mouseY;
    GamePanel(){
        this.setLayout(null);
        start = new JButton();
        start.setText("Start Game");
	start.setBounds(125, 235, 250, 30);
	start.addActionListener(new MapStuff());
        
        this.add(start);
    }
    private class MapStuff implements ActionListener{

        @Override
        public void actionPerformed(ActionEvent ae) {
            JButton[][] mapSquare = new JButton[5][5];
            JButton source = (JButton) ae.getSource();
            for (int i = 0; i < mapSquare.length; i++) {
                for (int j = 0; j < mapSquare[i].length; j++) {
                    if (mapSquare[i][j].equals(source)) {
                        Coordinate c = new Coordinate(i,j);
                        //Square currentSquare = Map.getSquare(c);
                        i = i+mapSquare.length;
                        break;
                    }
		}
            }
        }
        
    }
}

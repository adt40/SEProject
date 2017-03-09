/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minesweeper;

import javax.swing.JFrame;
import javax.swing.WindowConstants;
import java.awt.Container;
public class Window extends JFrame {
    public Window(){
        GamePanel panel = new GamePanel();
        Container container = this.getContentPane();
        container.add(panel);
        this.setSize(600, 600);
        this.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        this.setVisible(true);
    }
        
}

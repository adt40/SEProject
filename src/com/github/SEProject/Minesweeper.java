/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minesweeper;
import java.awt.GridLayout;
import javax.swing.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;


public class Minesweeper extends JPanel{
    private JButton mines[][];
    private static int rows;
    private static int columns;
    
    public void generateButton(int row, int column){
        setLayout(new GridLayout(row, column));
        
    }
public static void main(String args[]){
        rows = 10;
        columns = 10;
        Window w = new Window();
        Map gameMap = new Map(rows, columns, 10);
        
    }
    
}

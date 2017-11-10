/*
  written: by Dawit Hailu
  objective: 
      given two rectangles A and B, 
      with top left coordinates (x, y) and bottom right coordinates (x', y')
      such that x <= x' and y >= y'
      find if A and B intersect
*/

using System;
class MainClass{
  public static void Main(){
    Rectangle rect1 = new Rectangle(-22, -5, 0, -70);
    Rectangle rect2 = new Rectangle(0, 14, 12.3, -5);
    Console.WriteLine(checkIntersection(rect1, rect2));
  }
  public static bool checkIntersection(Rectangle a, Rectangle b){
    //range covered by the two rectangles along the x axis
    var xRange = Math.Max(a.maxX, b.maxX) - Math.Min(a.minX, b.minX);
    
    //range covered by the two rectangles along the y axis
    var yRange = Math.Max(a.maxY, b.maxY) - Math.Min(a.minY, b.minY);
    
    //compare if the length covered by the two rectangle is less or equals sum of their width
    //and also less or equals some of their length for the x and y axis respectively 
    return (xRange <= a.width() + b.width()) && (yRange <= a.length() + b.length());
  }
}
class Rectangle{
  //getters and setters
  public double maxX{get; set;}
  public double maxY{get; set;}
  public double minX{get; set;}
  public double minY{get; set;}
  
  //returns width of a rectagle
  public double width() { return maxX - minX; }
  
  //returns length of a rectangle
  public double length() { return maxY - minY; }
  
  //constractor function sets x1 to x and x2 to x' 
  //and y1 to y and y2 to y' according to the requirments
  public Rectangle(double x1, double y1, double x2, double y2){
    // since we are asuming x <= x' and y >= y' the following line holds true
    minX = x1;
    maxX = x2;
    maxY = y1;
    minY = y2;
  }
}
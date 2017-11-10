using System;
class MainClass{
  public static void Main(){
    Rectangle rect1 = new Rectangle(-22, -5, 0, -70);
    Rectangle rect2 = new Rectangle(0, 14, 12.3, -5);
    Console.WriteLine(checkIntersection(rect1, rect2));
  }
  public static bool checkIntersection(Rectangle a, Rectangle b){
    var xRange = Math.Max(a.maxX, b.maxX) - Math.Min(a.minX, b.minX);
    var yRange = Math.Max(a.maxY, b.maxY) - Math.Min(a.minY, b.minY);
    return (xRange <= a.width() + b.width()) && (yRange <= a.length() + b.length());
  }
}
class Rectangle{
  public double maxX{get; set;}
  public double maxY{get; set;}
  public double minX{get; set;}
  public double minY{get; set;}
  public double width() { return maxX - minX; }
  public double length() { return maxY - minY; }
  public Rectangle(double x1, double y1, double x2, double y2){
    minX = x1;
    maxX = x2;
    maxY = y1;
    minY = y2;
  }
}
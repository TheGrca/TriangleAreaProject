using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleAreaProject
{

    public class Program
    {
        static void Main(string[] args)
        {
            int pointNumber = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                bool isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Insert a number of how many points you want to insert: ");
                    if (int.TryParse(Console.ReadLine(), out pointNumber))
                    {
                        if (pointNumber <= 0)
                        {
                            Console.WriteLine("Point number cannot be a negative number nor zero!\n");
                        }
                        else if(pointNumber <= 2)
                        {
                            Console.WriteLine("Point number cannot be a less then 3!\n");
                        }
                        else
                        {
                            isNumber = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Point number must be a number!\n");
                    }
                }

                CoordinatePoint[] points = new CoordinatePoint[pointNumber];

                for (int i = 0; i < pointNumber; i++)
                {
                    int x = 0, y = 0;
                    bool isValidPoint = false;
                    while (!isValidPoint)
                    {
                        Console.WriteLine($"Insert the coordinates for the point {i + 1}: ");
                        Console.WriteLine("X => ");
                        if (int.TryParse(Console.ReadLine(), out x))
                        {
                            Console.WriteLine("Y => ");
                            if (int.TryParse(Console.ReadLine(), out y))
                            {
                                bool isUnique = true;
                                for (int j = 0; j < i; j++)
                                {
                                    if (points[j].X == x && points[j].Y == y)
                                    {
                                        isUnique = false;
                                        Console.WriteLine("This point already exists. Please enter different coordinates.");
                                        break;
                                    }
                                }

                                if (isUnique)
                                {
                                    isValidPoint = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for Y coordinate.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for X coordinate.");
                        }
                    }
                    points[i] = new CoordinatePoint(x, y);
                }

                    FindLargestTriangle(points);
                    Console.WriteLine("Do you want to calculate again? (Type any key to continue or 'No' to exit!)");
                    string result = Console.ReadLine();
                    if (result.ToLower().Replace(" ", "").Equals("no")){
                        tryAgain = false;
                     }
            }
        }

        static void FindLargestTriangle(CoordinatePoint[] points)
        {
            double maxTriangleArea = 0;
            CoordinatePoint A = null, B = null, C = null;

            for(int i = 0; i < points.Length; i++)
            {
                for(int j = i + 1; j < points.Length; j++)
                {
                    for(int k = j + 1; k < points.Length; k++)
                    {
                        double triangleArea = GetTriangleArea(points[i], points[j], points[k]);
                        if(triangleArea > maxTriangleArea)
                        {
                            maxTriangleArea = triangleArea;
                            A = points[i];
                            B = points[j];
                            C = points[k];
                        }
                    }
                }
            }

            Console.WriteLine("Largest triangle area: " + maxTriangleArea);
            Console.WriteLine("Points: ");
            Console.WriteLine("A: (" + A.X + ", " + A.Y + ")");
            Console.WriteLine("B: (" + B.X + ", " + B.Y + ")");
            Console.WriteLine("C: (" + C.X + ", " + C.Y + ")");
        }

        static double GetTriangleArea(CoordinatePoint A, CoordinatePoint B, CoordinatePoint C) { 
            double P = Math.Abs((A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2);
            return P;
        }
    }
}

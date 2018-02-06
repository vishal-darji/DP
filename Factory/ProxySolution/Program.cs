﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create math proxy

            MathProxy proxy = new MathProxy();

            // Do the math

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

            // Wait for user

            Console.ReadKey();
        }
    }
    /// <summary>

  /// The 'Subject interface

  /// </summary>

  public interface IMath

  {
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Div(double x, double y);
  }
 
  /// <summary>

  /// The 'RealSubject' class

  /// </summary>

  class Math : IMath

  {
    public double Add(double x, double y) { return x + y; }
    public double Sub(double x, double y) { return x - y; }
    public double Mul(double x, double y) { return x * y; }
    public double Div(double x, double y) { return x / y; }
  }
 
  /// <summary>

  /// The 'Proxy Object' class

  /// </summary>

  class MathProxy : IMath
  {
      private Math _math = new Math();
      private bool Authenticate()
      {
          return true;
      }
      public double Add(double x, double y)
      {
          if (Authenticate())
          {
              return _math.Add(x, y);
          }
          else
          {
              return 0;
          }
          
      }
      public double Sub(double x, double y)
      {
          if (Authenticate())
          {
              return _math.Sub(x, y);
          }
          else
          {
              return 0;
          }
      }
      public double Mul(double x, double y)
      {
          if (Authenticate())
          {
              return _math.Mul(x, y);
          }
          else
          {
              return 0;
          }
      }
      public double Div(double x, double y)
      {
          if (Authenticate())
          {
              return _math.Div(x, y);
          }
          else
          {
              return 0;
          }
      }
  }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length,double width,double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get=>this.length;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("cannot be zero or negative");
                   
                }
                length = value;

            }
        }

        public double Width
        {
            get => this.width;
           private set { 
                if (value<=0)
                {
                 

                    throw new ArgumentException("cannot be zero or negative");
                }
                width = value;

            }
        }

        

        public double Height
        {
            get => this.height;
           private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("cannot be zero or negative");
                   
                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * length * height + 2 * width * height;
        }

        public double Volume()
        {
            return length * width * height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().Trim();
        }



    }
}

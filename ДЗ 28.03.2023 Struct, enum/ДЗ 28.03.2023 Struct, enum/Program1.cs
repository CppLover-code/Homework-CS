namespace ДЗ_28._03._2023_Struct__enum
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-3d vector-\n");
            Vector vector = new Vector(5,6,7);
            Console.WriteLine(vector);

            vector.Mult(2);
            Console.WriteLine(vector);

            Vector vector1 = new Vector(6,7,8);
            Vector vector2;// = new Vector(); //vector2 = vector2.Add(vector,vector1);
            vector2 = vector + vector1;
            Console.WriteLine(vector);
            Console.WriteLine(vector1);
            Console.WriteLine(vector2);
            Console.WriteLine();
            Vector vector3;
            vector3 = vector1 - vector;
            Console.WriteLine(vector);
            Console.WriteLine(vector1);
            Console.WriteLine(vector3);
            Console.WriteLine();

        }
        struct Vector
        {
            int x;
            int y;
            int z;
            public Vector(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public override string ToString()
            {
                return " 3-D Vector:" + "\n coord X - " + x + "\n coord Y - " + y + "\n coord Z - " + z;
            }
            public void Mult(int numb)
            {
                this.x *= numb;
                this.y *= numb;
                this.z *= numb;
            }
            public Vector Add(Vector a, Vector b)
            {
                Vector temp = new Vector();
                temp.x = a.x + b.x;
                temp.y = a.y + b.y;
                temp.z = a.z + b.z;
                return temp;
            }
            public static Vector operator +(Vector a, Vector b)
            {
                return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            }
            public static Vector operator -(Vector a, Vector b)
            {
                return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
            }            
        }
    }
}
using System;
using System.Collections.Generic;

namespace AIP4
{
    public class ParkingLot
    {
        public static int Size { get; set; }
        //public static bool MidleExists { get; set; } = false;

        private static int cLeft;
        private static int cRight;
        private static Chosen chosenSide;
        public static int chosenOne;

        public static void InitChosenOne()
        {
            cLeft = 1;
            cRight = Size - 1;

            chosenSide = Chosen.left;

            chosenOne = 0;
        }
        public static bool NextChosen()

        {
            if( cLeft == cRight)
            {
                return false;
            }

            if( chosenSide == Chosen.right)
            {
                chosenSide = Chosen.left;
                chosenOne = cLeft++;
                return true;
            }
            else            // Chosen.Left
            {
                chosenSide = Chosen.right;
                chosenOne = cRight--;
                return true;
            }

        }

        List<Car> Cars = new List<Car>() ;

        int[,] CarsMatrix;

        public ParkingLot( int size )
        {
            Size = size;

            for( int i = 0; i < Size; i++)
            {
                Cars.Add(new Car());
            }

            ClearMatrix();
            InitChosenOne();
            Run();
        }

        public void ClearMatrix()
        {
            CarsMatrix = new int[Size, Size];
        }
        public void PrintMatrix()
        {
            for( int i = 0; i < Size; i++)
            {
                for( int j = 0; j < Size; j++)
                {
                    Console.Write( CarsMatrix[i,j] + "  ");
                }
                Console.Write("\n");
            }
        }

        public void PrintPark()
        {
            ClearMatrix();
            foreach( Car car in Cars)
            {
                CarsMatrix[car.X, car.Y] = car.Number + 1 ;

            }
            PrintMatrix();
        }

        public void Run()
        {
            PrintPark();

            foreach( Car car in Cars )
            {
                car.NextStep();
            }


            if( NextChosen() == false)
            {
                chosenOne = -1;
            }


            var input = Console.Read();

            //if( input == "\ ")
            //{
            //    Run();
            //}

            Run();

        }


    }
}

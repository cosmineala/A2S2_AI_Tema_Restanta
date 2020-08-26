using System;
namespace AIP4
{

    public class Car
    {
        public static int GlobalNumber = 1;

        public int Number { get; set; }

        public Role role { get; set; }
        public Move move { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int TX { get; set; }
        public int TY { get; set; }


        public Car()
        {
            Number = Car.GlobalNumber++;

            X = Number - 1;
            Y = 0;

            TX = ParkingLot.Size - Number;
            TY = ParkingLot.Size - 1;


            if( ParkingLot.Size / 2 != 0 && Number == ParkingLot.Size / 2 + 1 )
            {
                role = Role.midle;
                ParkingLot.MidleExists = true;
            }
            else
            {
                if (Number <= ParkingLot.Size / 2)
                {
                    role = Role.left;
                }
                else
                {
                    role = Role.right;
                }
            }

        }

        void MoveUp()
        {
            Y--;
        }
        void MoveDown()
        {
            Y++;
        }
        void MoveRight()
        {
            X++;
        }
        void MoveLeft()
        {
            X--;
        }

        public bool HasFinished()
        {
            if( X == TX && Y == TY )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NextStep()
        {
            switch ( move )
            {
                case Move.alighn_horizontal:
                    if( role == Role.right)
                    {
                        MoveLeft();
                    }
                    else
                    {
                        MoveRight();
                    }
                    if( X == TX)
                    {
                        move = Move.alignh_vertical;
                    }
                    break;

                case Move.alignh_vertical:
                    MoveUp();
                    if( Y == TY)
                    {

                    }
            }

        }




    }
}

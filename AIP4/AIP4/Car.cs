using System;
namespace AIP4
{

    public class Car
    {
        public static int GlobalNumber = 0;

        public int Number { get; set; }

        //public Role role { get; set; }
        public Move move { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int TX { get; set; }
        public int TY { get; set; }

        //int ttx;
        //int tty;


        public Car()
        {
            Number = Car.GlobalNumber++;

            X = Number;
            Y = 0;

            TX = ParkingLot.Size - Number - 1;
            TY = ParkingLot.Size - 1;

            move = Move.initial_down;


            //if( ParkingLot.Size / 2 != 0 && Number == ParkingLot.Size / 2 + 1 )
            //{
            //    role = Role.midle;
            //    ParkingLot.MidleExists = true;
            //}
            //else
            //{
            //    if (Number <= ParkingLot.Size / 2)
            //    {
            //        role = Role.left;
            //    }
            //    else
            //    {
            //        role = Role.right;
            //    }
            //}

            //if( role == Role.left)
            //{
            //    ttx = ParkingLot.Size / 2 - 1;
            //  //  tty = ParkingLot.Size / 2 - 1 + Number;
            //}
            //else
            //{
            //    ttx = ParkingLot.Size / 2 ;
            //  //  tty = ParkingLot.Size / 2 - 1 + Number;
            //}



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
            if (Number == ParkingLot.Size / 2 + 1)
            {
                if (Y < TY)
                {
                    MoveDown();
                }
                return;
            }

            switch ( move )
            {
                case Move.initial_down:
                    if( Number != ParkingLot.chosenOne)
                    {
                        MoveDown();
                    }
                    else
                    {
                        move = Move.horizontal;
                        NextStep();
                    }
                    break;

                case Move.horizontal:
                    if( X != TX)
                    {
                        if( X < TX)
                        {
                            MoveRight();
                        }
                        else
                        {
                            MoveLeft();
                        }
                    }
                    else
                    {
                        move = Move.vertical;
                        NextStep();
                    }
                    break;

                case Move.vertical:
                    if( Y < TY)
                    {
                        MoveDown();

                        Console.WriteLine("Car " + Number + " will move to Y " + Y);
                    }
                    else
                    {
                        move = Move.done;
                    }
                    break;

                case Move.done:
                    break;// Do nothing

            }

        }

        //public void NextStep()
        //{
        //    switch ( move )
        //    {
        //        case Move.alighn_horizontal:
        //            if( role == Role.right)
        //            {
        //                MoveLeft();
        //            }
        //            else
        //            {
        //                MoveRight();
        //            }
        //            if( X == TX)
        //            {
        //                move = Move.alignh_vertical;
        //            }
        //            break;

        //        case Move.alignh_vertical:
        //            MoveUp();
        //            if( Y == tty)
        //            {
        //                move = Move.
        //            }
        //    }

        //}




    }
}

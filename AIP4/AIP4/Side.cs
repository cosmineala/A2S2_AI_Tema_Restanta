using System;
namespace AIP4
{
    public enum Role
    {
        left,
        right,
        midle,
        right_joker
    }

    public enum Move
    {
        alighn_horizontal,
        alignh_vertical,

        jump_over,
        hold_vertical,
        hold_horizontal,

        run_horizontal,
        run_verical,

        right_joker_move
        
    }
}

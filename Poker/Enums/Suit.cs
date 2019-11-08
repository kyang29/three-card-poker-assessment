using System.ComponentModel.DataAnnotations;

namespace Poker.Enums
{
    public enum Suit
    {
        [Display(Name = "h")]
        Hearts,

        [Display(Name = "d")]
        Diamonds,

        [Display(Name = "s")]
        Spades,

        [Display(Name = "c")]
        Clovers
    }
}

namespace Nemocnice.application.ViewModels
{
    public class LekarskeSluzbyViewModel
    {
        public int Id { get; set; }
        public string? Ukon { get; set; }
        public string? Ockovani { get; set; }
        public string? Vysetreni { get; set; }
        public DateTime Datum { get; set; }
    }
}

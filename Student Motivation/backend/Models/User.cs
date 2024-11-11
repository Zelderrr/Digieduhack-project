namespace MyGameBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; } = 0;
        public int CharacterPower { get; set; } = 10;
        public List<Weapon> Inventory { get; set; } = new List<Weapon>();
    }

    public class Weapon
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public int Power { get; set; } = 10;

        public void Upgrade()
        {
            Power += 50;
        }
    }
}
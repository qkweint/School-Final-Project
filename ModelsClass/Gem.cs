namespace ModelsClass
{
    public class Gem
    {
        public int gemID { get; set; }
        public string name { get; set; }
        public double weight { get; set; }
        public int price { get; set; }

        public Gem() { }
        public Gem(int gemID, string name, double weight, int price)
        {
            this.gemID = gemID;
            this.name = name;
            this.weight = weight;
            this.price = price;
        }
    }
}
namespace _5M09konPojazdPlik
{
    class Pojazd
    {
        public int id {  get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public string kolor { get; set; }
        public int rocznik { get; set; }
        public int przebieg { get; set; }
        public int cena { get; set; }
        public string grafika { get; set; }

        public override string ToString()
        {
            string s = $"Pojazd: {marka} {model}, kolor: {kolor}," +
                $"cena: {cena} zł, przebieg: {przebieg} km, rocznik: {rocznik}"; 
            return s;
        }
    }
    internal class Program
    {
        private static List<Pojazd> pojazdy = new List<Pojazd>();

        static void Main(string[] args)
        {
            Console.WriteLine("pojazdy");
            wczytajPojazdy();
            wypiszPojazdy();

        }

        private static void wypiszPojazdy()
        {
            foreach (var item in pojazdy)
                Console.WriteLine(item);
        }

        private static void wczytajPojazdy()
        {
            string wiersz;
            string nazwaPliku = "C:\\Users\\mm\\source\\repos\\5M09konPojazdPlik\\5M09konPojazdPlik\\pojazd.txt";
            using (FileStream plik = File.OpenRead(nazwaPliku))
            {
                using (TextReader pl = new StreamReader(plik))
                {
                    while ((wiersz = pl.ReadLine()) != null)
                    {
                        if (wiersz.Length == 0) break;
                        Pojazd p = new Pojazd();
                        string[] s = wiersz.Split(";");
                        p.id = int.Parse(s[0]);
                        p.marka = s[1];
                        p.model = s[2];
                        p.kolor = s[3];
                        p.rocznik = int.Parse(s[4]);
                        p.przebieg = int.Parse(s[5]);
                        p.cena = int.Parse(s[6]);
                        p.grafika = s[7];
                        pojazdy.Add(p);
                        wiersz = "";
                    }
                }
            }
        }
    }
}

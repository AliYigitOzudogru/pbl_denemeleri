using System;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.CursorVisible = false;

        int width = 120;   // alan genişliği
        int height = 40;   // alan yüksekliği

        int blockWidth = 40; // blok genişliği (3 blok)
        int blockHeight = 40; // blok yüksekliği (tek satır alan)

        // 1️⃣ Alanın sınırlarını yatay ve dikey çizgilerle çizelim

        // Yatay çizgiler (üst ve alt sınır)
        for (int x = 0; x <= width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("-");
            Console.SetCursorPosition(x, height);
            Console.Write("-");
        }

        // Dikey çizgiler (sol ve sağ sınırlar + blok içi bölmeler)
        for (int y = 0; y <= height; y++)
        {
            // Alanın sol ve sağ sınırları
            Console.SetCursorPosition(0, y);
            Console.Write("|");
            Console.SetCursorPosition(width, y);
            Console.Write("|");

            // Blokları ayıran dikey çizgiler
            Console.SetCursorPosition(blockWidth, y);
            Console.Write("|");
            Console.SetCursorPosition(2 * blockWidth, y);
            Console.Write("|");
        }

        Console.SetCursorPosition(0, height + 1);
        Console.CursorVisible = true;
        Console.WriteLine("\nAlan çizimi tamamlandı!");
    }
}

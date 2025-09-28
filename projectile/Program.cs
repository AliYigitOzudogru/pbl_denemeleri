using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.CursorVisible = false;

        int width = 120;
        int height = 40;
        int blockWidth = 40;

        // Alan çizimi (bloklar dahil)
        for (int x = 0; x <= width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("-");
            Console.SetCursorPosition(x, height);
            Console.Write("-");
        }
        for (int y = 0; y <= height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("|");
            Console.SetCursorPosition(width, y);
            Console.Write("|");
            Console.SetCursorPosition(blockWidth, y);
            Console.Write("|");
            Console.SetCursorPosition(2 * blockWidth, y);
            Console.Write("|");
        }

        // Kullanıcıdan girişler
        Console.SetCursorPosition(0, height + 2);
        Console.Write("Hızı girin (m/s): ");
        double V = Convert.ToDouble(Console.ReadLine());

        Console.Write("Açıyı girin (derece, -85 ile 85): ");
        double angle = Convert.ToDouble(Console.ReadLine());

        Console.Write("Rüzgar hızı (m/s, pozitif sağa, negatif sola): ");
        double Vwind = Convert.ToDouble(Console.ReadLine());

        // Fizik hesaplamaları
        double rad = angle * Math.PI / 180;
        double Vx = V * Math.Cos(rad);
        double Vy = V * Math.Sin(rad);
        double g = -1; // soruda sabit verilmiş

        // Ölçeklendirme
        double maxX = Math.Abs((Vx + Vwind) * 2); // tahmini yatay menzil
        double maxY = Vy * Vy / (2 * Math.Abs(g)) + 1; // tahmini maksimum yükseklik
        double xScale = (width - 2) / maxX;
        double yScale = (height - 2) / maxY;

        double t = 0;
        double dt = 0.1;

        // Eğik atış animasyonu
        while (true)
        {
            double x = (Vx + Vwind) * t;
            double y = Vy * t - 0.5 * g * t * t;

            if (y < -1) break; // tamamen alanın altına düşerse dur

            int posX = 1 + (int)(x * xScale);
            int posY = height - 1 - (int)(y * yScale);

            // Sadece alan içinde görünür
            if(posX >= 1 && posX < width && posY >= 1 && posY < height)
            {
                Console.SetCursorPosition(posX, posY);
                Console.Write("*");
            }

            t += dt;
            Thread.Sleep(50);
        }

        Console.SetCursorPosition(0, height + 3);
        Console.CursorVisible = true;
        Console.WriteLine("Atış tamamlandı!");
    }
}

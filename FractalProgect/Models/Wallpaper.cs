using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FractalProgect.Models
{
    public class Wallpaper
    {
        Wallpaper() { }

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int // Перечесление с названиями режимов установки картинки на рабочий стол
        {
            Fill, //Заливка
            Tiled,
            Centered, //По центру
            Stretched
        }

        public static void Set(Uri uri, Style style) //Установки изображения на рабочий стол
        {
            System.IO.Stream s = new System.Net.WebClient().OpenRead(uri.ToString()); // Открытие/чтение файла

            System.Drawing.Image img = System.Drawing.Image.FromStream(s); //Создание изображения по открытому файлу
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp"); //Временный путь для сохраниния гифки
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp); //Сохранение

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true); //Создание ключа длля доступа к рабочему столу

            //Выбор и установка режима
            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 10.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 6.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            //Установка гифки на экран рабочего стола
            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static bool IsFree(string filePath) //Метод проверки доступности файла
        {
            try
            {
                using (var fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None)) //Попытка обратится к файлу
                {
                    return true; //Если получилось то файл свободен
                }
            }
            catch (IOException)
            {
                return false; //Если нет, файл занят другим процессом
            }
        }


        public static string[] SortArray(string[] arr) // Метод для сортирока массива строк по их длинне (алгоритм пузырька)
        {
            bool sort = false;
            while (!sort)
            {
                sort = true;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i].Length < arr[i - 1].Length)
                    {
                        var temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        sort = false;
                    }
                }
            }

            return arr;
        }
    }
}

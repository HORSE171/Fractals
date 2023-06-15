using FractalProgect.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace FractalProgect
{
    public partial class Form1 : Form
    {
        Fractal fractal = null;
        private Thread thread; // переменная для хранения потока
        private Thread thread2;  // переменная для хранения потока
        public Form1()
        {
            //Отчистка всех старых изобрадений из папок с изображениями
            string path = @"C:\img\pif";
             Directory.CreateDirectory(path);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            path = @"C:\img\koh";
            Directory.CreateDirectory(path);
            files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            path = @"C:\img\krug";
            Directory.CreateDirectory(path);
            files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            path = @"C:\img\serpinski";
            Directory.CreateDirectory(path);
            files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            path = @"C:\img\wind";
            Directory.CreateDirectory(path);
            files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            InitializeComponent(); //Инициализация элементов и компонент формы

            CreateMenu(); //Вызов метода инициализации меню (ширина высота цвет и т.д)
        }
        private void CreateMenu() // Метод инициализации меню (ширина высота цвет и т.д)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            menuContainer.Text = "";
            menuContainer.BackColor = Color.White;
            menuContainer.Height = this.Height - 42;
            menuContainer.Dock = DockStyle.Right;
            menuContainer.Width = (this.Width / 100) * 40;

            fractalsContainer.Text = "";
            fractalsContainer.Height = (this.Height / 100) * 40;
            testContainer.Height = (this.Height / 100) * 60;

            //trackBar1.BackColor = Color.FromArgb(0, 255, 0, 0);

            koh.Text = "Кох";
            serpinski.Text = "Серпинский";
            pifagor.Text = "Пифагор";
            krug.Text = "Круговой";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) // Метод который отрабатывает при обновлении пикчер бокса или перерисовке пикчербокса 
        {
            if (fractal != null) //Если обьект фрактала существует
            {
              pictureBox1.Image = fractal.Start(e.Graphics);//Создаем фрактал через метод описанный в класе фрактала
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e) // Метод для отслеживания изменений в трекбаре отвечающего за силу ветра для дерева пифагора
        {
            if (pifagor.Checked) // Если сейчас идет работа с деревом пифагора
            {
                try
                {
                    int pocolenie = trackBar2.Value; // получение значения с трекбара
                    fractal = new Pifagor(pictureBox1.Width, pictureBox1.Height, pocolenie, trackBar1.Value); // Создание дерева с учетом ветра
                    pictureBox1.Refresh(); // Обновление пикчер бокса
                }
                catch (Exception){}  
            }
            else
            {
                trackBar1.Value = 0;
                MessageBox.Show("Нужно выбрать дерево Пифагора", "Exception", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void svaeButton_Click(object sender, EventArgs e) //Метод для создания гифки
        {
            try
            {
                string dir = "";
                //В зависимости от выбраного типа фрактала
                if (koh.Checked)
                {
                    dir = @"C:\img\koh"; //Устанавливаем нужную ссылку на папку для хранения изображений
                }
                else if (serpinski.Checked)
                {
                    dir = @"C:\img\serpinski";
                }
                else if (pifagor.Checked)
                {
                    dir = @"C:\img\pif";
                }
                else if (krug.Checked)
                {
                    dir = @"C:\img\krug";
                }

                string[] files = Directory.GetFiles(dir); //Считываем пути всех файлов из выбранной папки

                if (files.Length > 0) //Если там есть файлы
                {
                    List<string> paths = new List<string>();


                    files = Wallpaper.SortArray(files); //Сортируем все выбранные файлы по длинне + сортировка по алфовиту была автоматом

                    foreach (string file in files)
                    {
                        if (file.Contains(".png"))
                        {
                            paths.Add(file); //Добавлем в список название файлов которые уже существуют в папаке
                        }
                    }
                    if (paths.Count < 3)
                        throw new Exception("Нужно создать все поколения дял создания GIF");

                    if (serpinski.Checked)
                        paths.Reverse();

                    Bitmap[] bitmaparr = new Bitmap[paths.Count]; // Массив для хранения всех существующих изображенй

                    for (int i = 0; i < bitmaparr.Length; i++)
                    {
                        bitmaparr[i] = new Bitmap(paths[i]); //Создание и добавление в массив всех изображений из папки 
                    }

                    //Создание гифки из множества сохраненных картинок в массиве bitmaparr
                    GifBitmapEncoder gEnc = new GifBitmapEncoder();
                    foreach (Bitmap bmpImage in bitmaparr)
                    {
                        var bmp = bmpImage.GetHbitmap();
                        var src = Imaging.CreateBitmapSourceFromHBitmap(
                            bmp,
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        gEnc.Frames.Add(BitmapFrame.Create(src));
                    }

                    // Создание, перезапись гифки
                    using (FileStream fs = new FileStream(@"C:\img\pif\test.gif", FileMode.Create))
                    {
                        gEnc.Save(fs); //Сохранение гифки
                    }

                    // Запуск гифки при помощи стандартных утилит виндовс
                    Process.Start(@"C:\img\pif\test.gif");

                    
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Нужно создать все поколения дял создания GIF", "Exception", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e) //Метод для обработки изменения трекбара отвечающего за выставление покаления фрактала
        {
            try
            {
                fractal = null;
                int pocolenie = trackBar2.Value; //Установка поколения

                //Проверка выбранного фрактала
                if (koh.Checked)
                {
                    if (pocolenie > 7) return; // Проверка на поколение, если выбрано поколение больше 7, просто выходим из метода
                    fractal = new Koh(pictureBox1.Width, pictureBox1.Height, pocolenie); //Создание объекта фрактала
                    pictureBox1.Refresh(); //Обновление пикчер бокса, для отображжения новго изображения
                }
                else if (serpinski.Checked)
                {
                    if (pocolenie > 5) return; // -:-
                    fractal = new Serpinski(pictureBox1.Width, pictureBox1.Height, pocolenie); // -:-
                    pictureBox1.Refresh();// -:-
                }
                else if (pifagor.Checked)
                {
                    fractal = new Pifagor(pictureBox1.Width, pictureBox1.Height, pocolenie, trackBar1.Value); // -:-
                    pictureBox1.Refresh(); // -:-
                }
                else if (krug.Checked)
                {
                    if (pocolenie > 7) return; // -:-
                    fractal = new Krug(pictureBox1.Width, pictureBox1.Height, pocolenie); // -:-
                    pictureBox1.Refresh(); // -:-
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Метод который реагирует на нажатие конпки  Установить на экран рабочего стола
        {

            try
            {
                if (thread2 != null) // Если поток существует
                    if (thread2.IsAlive) // Если он жив
                        thread2.Abort(); // Убить поток


                string dir = "";
                //В зависимости от выбраного типа фрактала
                if (koh.Checked)
                {
                    dir = @"C:\img\koh"; //Устанавливаем нужную ссылку на папку для хранения изображений
                }
                else if (serpinski.Checked)
                {
                    dir = @"C:\img\serpinski";
                }
                else if (pifagor.Checked)
                {
                    dir = @"C:\img\pif";
                }
                else if (krug.Checked)
                {
                    dir = @"C:\img\krug";
                }

                string[] files = Directory.GetFiles(dir); //Считываем пути всех файлов из выбранной папки

                if (files.Length > 0) //Если там есть файлы
                {
                    List<string> paths = new List<string>();


                    files = Wallpaper.SortArray(files); //Сортируем все выбранные файлы по длинне + сортировка по алфовиту была автоматом

                    foreach (string file in files)
                    {
                        if (file.Contains(".png"))
                        {
                            paths.Add(file); //Добавлем в список название файлов которые уже существуют в папаке
                        }
                    }

                    if (paths.Count < 3) // Если меньше 3х поколений созданно
                        throw new Exception("Недостаточно изображений"); // Выкидываем исключение

                    thread2 = new Thread(SetW); // Создаем поток с указателем на метод который будет отрабатывать в этом потоке
                    thread2.Start(paths); // Запускаем поток и передаем ему пути к файлам

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void SetW(object array) // Метод динамического изменения экрана рабочего стола
        {
            List<string> arr = array as List<string>; // Распаковываем наш параметр из типа object в нужным нам тип
            while (true) // Бесконечный цикл
            {
                for (int i = 0; i < arr.Count; i++) // Перебираем все пути к файлам изображения
                {
                    Uri uri = new Uri($@"{arr[i]}"); // Создаем ссылку на изображение
                    Wallpaper.Set(uri, Wallpaper.Style.Centered); // Устанавливаем на рабочий стол
                    Thread.Sleep(30); // Приостанавливаем поток
                }
            }

        }

        private void Wind_Click(object sender, EventArgs e) // Метод для создания и запуска потока ветра
        {
            if (!pifagor.Checked)
            {
                MessageBox.Show("Выберите дерево Пифагора", "Exception", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            thread = new Thread(MakeWind); // создание потока, и передача метода который будет работать в этом потоке
            thread.Start(); // Запуск потока
        }

        private void button2_Click(object sender, EventArgs e) // Метод для унечтожения потока
        {
            if (thread != null) // Если поток существует
                if (thread.IsAlive) // Если поток активен
                    thread.Abort(); // Убить поток
            if (thread2 != null) // Если поток существует
                if (thread2.IsAlive) // Если поток активен
                    thread2.Abort(); // Убить поток

        }

        private void MakeWind() // Метод для изменения ветра, который работает в отдельном потоке
        {
            bool flag = true; // переменная для проверки созданно ли все поколение дерева при ветре
            bool flag2 = true; // Переменная для проверки стоил ли перезапускать поток
            int _tr1 = 0; // Переменная для хранения значения трекбара1 
            int _tr2 = 0; // Переменная для хранения значения трекбара2
            int w = 0; // Переменная для хранения значения ширины пикчербокса
            int h = 0; // Переменная для хранения значения высоты пикчербокса
            int old = 0;
            Invoke(new Action(() => w = pictureBox1.Width)); // получение данных о ширине пикчербокса при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
            Invoke(new Action(() => h = pictureBox1.Height)); // получение данных о высоте пикчербокса при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
            if (pifagor.Checked) //Если выбран фрактал прифагора
            {
                bool vektor = true; // переменная которая отвечает за направление ветра
                while (true) // Бесконечный цикл
                {
                    Invoke(new Action(() => _tr2 = trackBar2.Value)); // получение данных из трекбара2 пикчербокса при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
                    Invoke(new Action(() => _tr1 = trackBar1.Value)); // получение данных из трекбара1 пикчербокса при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
                    if (vektor) // Если направление в +
                    {
                        for (int i = _tr1; i < 10; i++) // Изменяем значение ветра с текущего положение до максимума
                        {
                            fractal = new Pifagor(w, h, _tr2, i); // Создание дерева с учетом ветра
                            Invoke(new Action(() => pictureBox1.Refresh())); // вызов обновления пикчербокса при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
                            Invoke(new Action(() => trackBar1.Value = i)); // Меняем значение трекбара с ветром при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
                            Thread.Sleep(30); // приостановка потока на 0.1с, чтобы анимация не была слишком быстрой
                        }
                        vektor = false; // Установка ветра в -
                        flag = false;
                    }
                    else // Если направление в -
                    {
                        for (int i = _tr1; i >= -9; i--)  // Изменяем значение ветра с текущего положение до минимума
                        {
                            fractal = new Pifagor(w, h, _tr2, i); // Создание дерева с учетом ветра
                            Invoke(new Action(() => pictureBox1.Refresh())); // вызов обновления пикчербокса при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
                            Invoke(new Action(() => trackBar1.Value = i)); // Меняем значение трекбара с ветром при помощи Invoke который обеспечивает доступ к элементу пользовательского интерфейса из потока пользовательского интерфейса
                            Thread.Sleep(30); // приостановка потока на 0.1с, чтобы анимация не была слишком быстрой
                        }
                        vektor = true; // меняем направление ветра в +
                        flag = true;
                    }


                    if (old != _tr2) // Если новое поколение отличается от текущего поколения
                        flag2 = true; // Устанавливаем флаг что нужно перезапустить поток

                    if (flag && flag2 && old != _tr2) // Если еслть все условия для создания/пересодания потока 
                    {
                        old = _tr2; // запоминаем текущее поколение

                        if (thread2 != null) // если поток существует
                            if (thread2.IsAlive) // если поток жив
                                thread2.Abort(); // Убиваем поток

                        string dir = @"C:\img\wind"; // Путь к папке с нашими изображениями

                        string[] files = Directory.GetFiles(dir); //Считываем пути всех файлов из выбранной папки

                        if (files.Length > 0) //Если там есть файлы
                        {
                            List<string> paths = new List<string>(); // Пути к изображениям

                            files = Wallpaper.SortArray(files); //Сортируем все выбранные файлы по длинне + сортировка по алфовиту была автоматом

                            foreach (string file in files)
                            {
                                if (file.Contains(".png") && file.Contains($"_{_tr2}_"))
                                {
                                    paths.Add(file); //Добавлем в список название файлов которые уже существуют в папаке
                                }
                            }

                            if (paths.Count > 0) // Если есть изображения
                            {
                                thread2 = new Thread(SetW); // создаем поток
                                thread2.Start(paths); // Запускам поток, и передаем ссылки на изображения
                            }
                        }
                        flag2 = false;
                    }
                }
            }
        }

        private void koh_CheckedChanged(object sender, EventArgs e) // Метод который отслеживаем инмененеие в значении чекбокса 
        {
            if (koh.Checked) // Если ВКЛ
            {
                int pocolenie = trackBar2.Value; //Установка поколения
                if (pocolenie > 7) pocolenie = 6; // Проверка на поколение, если выбрано поколение больше 7, просто ограничиваем до 6
                fractal = new Koh(pictureBox1.Width, pictureBox1.Height, pocolenie); //Создание объекта фрактала
                pictureBox1.Refresh(); //Обновление пикчер бокса, для отображжения новго изображения
            }
        }

        private void pifagor_CheckedChanged(object sender, EventArgs e) // Метод который отслеживаем инмененеие в значении чекбокса 
        {
            if (pifagor.Checked) // Если ВКЛ
            {
                int pocolenie = trackBar2.Value; //Установка поколения
                fractal = new Pifagor(pictureBox1.Width, pictureBox1.Height, pocolenie, trackBar1.Value);//Создание объекта фрактала
                pictureBox1.Refresh();//Обновление пикчер бокса, для отображжения новго изображения
            }
        }

        private void serpinski_CheckedChanged(object sender, EventArgs e) // Метод который отслеживаем инмененеие в значении чекбокса 
        {
            if (serpinski.Checked) // Если ВКЛ
            {
                int pocolenie = trackBar2.Value; //Установка поколения
                if (pocolenie > 5) pocolenie = 4; // Проверка на поколение, если выбрано поколение больше 5, просто ограничиваем до 4
                fractal = new Serpinski(pictureBox1.Width, pictureBox1.Height, pocolenie); //Создание объекта фрактала
                pictureBox1.Refresh();//Обновление пикчер бокса, для отображжения новго изображения
            }
        }

        private void krug_CheckedChanged(object sender, EventArgs e) // Метод который отслеживаем инмененеие в значении чекбокса 
        {
            if (krug.Checked) // Если ВКЛ
            {
                int pocolenie = trackBar2.Value; //Установка поколения
                if (pocolenie > 7) pocolenie = 6; // Проверка на поколение, если выбрано поколение больше 7, просто ограничиваем до 6
                fractal = new Krug(pictureBox1.Width, pictureBox1.Height, pocolenie); //Создание объекта фрактала
                pictureBox1.Refresh(); //Обновление пикчер бокса, для отображжения новго изображения
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Метод который отрабатывает при закрытии формы
        {
            if (thread != null) // Если поток существует
                if (thread.IsAlive) // Если поток активен
                    thread.Abort(); // Убить поток
            if (thread2 != null) // Если поток существует
                if (thread2.IsAlive) // Если поток активен
                    thread2.Abort(); // Убить поток

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

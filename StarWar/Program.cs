using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

//Рязанцев Дмитрий
namespace StarWar
{
    
    public class Program
    {
        //        2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
        //3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
        //4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
        //5. *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или позиция).
        //Рязанцев Дмитрий

        public static void Main()
        {
            Console.Clear();
            Form form = new Form();
            Form formMenu = new Form();
            Button btnAdd = new Button();

            form.Width = 800;
            form.Height = 600;
            if ((form.Width > 1000) || (form.Height > 1000) || (form.Width < 0) || (form.Height < 0))
                throw new ArgumentOutOfRangeException();

            btnAdd.BackColor = Color.Gray;
            btnAdd.Text = "Играть";
            btnAdd.Click += (sender, args) => { formMenu.Close(); };

            formMenu.Width = 800;
            formMenu.Height = 600;            
            formMenu.Controls.Add(btnAdd);
            formMenu.Show();

            WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
            WMP.settings.setMode("loop", false);
            WMP.URL = "Sounds\\Sound_06777.mp3";

            Application.Run(formMenu);

            form.Show();
            Game.Init(form);
            
            WMP.URL = "Sounds\\Список воспроизведения1.wpl";
            //WMPLib.WindowsMediaPlayer WMP2 = new WMPLib.WindowsMediaPlayer();
            //WMP.settings.setMode("loop", true);
            
            //WMP.URL = "Sounds\\Power Blade – Уровень 5_ Музыка из игры Dendy скачать-10.1-171.2.mp3";
            //WMP.m += new EventHandler(Media_Ended);
            Application.Run(form);

            

        }
       
    }




}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для LVLCompl.xaml
    /// </summary>
    public partial class LVLCompl : Window
    {
        /// <summary>
        /// результат возвращения данного диалога
        /// </summary>
        bool result;

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="t">время прохождения уровня</param>
        /// <param name="st">кол-во шагов для прохождения уровня</param>
        /// <param name="LM">сообщение от уровня</param>
        public LVLCompl(TimeSpan t, int st, LevelMes LM)
        {
            InitializeComponent();
            result = false;

            // вывод результатов
            time.Text = $"Время: {t.ToString(@"hh\:mm\:ss")}";
            steps.Text = $"Шаги: {st}";

            // вывод сообщения от уровня
            switch (LM)
            {
                case LevelMes.NewLevel:
                    {
                        LVLMes.Visibility = Visibility.Visible;
                        break;
                    }
                case LevelMes.NewRecord:
                    {
                        LVLMes.Text = "Новый рекорд";
                        LVLMes.Visibility = Visibility.Visible;
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// при закрытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // проиграть звук нажатия кнопки
            (this.Tag as SoundPlayer).Play();
            // определить DialogResult
            DialogResult = result;
        }

        /// <summary>
        /// выход в главное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            // выход
            Close();
        }

        /// <summary>
        /// следующий уровень
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextLVLButton_Click(object sender, RoutedEventArgs e)
        {
            // результат равен true
            result = true;
            // выход
            Close();
        }
    }
}

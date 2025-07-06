using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Media;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для LVL_Info.xaml
    /// </summary>
    public partial class LVL_Info : Window
    {
        /// <summary>
        /// информация о всех уровнях
        /// </summary>
        LVLs levels;
        /// <summary>
        /// звук проигрывания нажатия на кнопку
        /// </summary>
        SoundPlayer bClickMus;


        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public LVL_Info()
        {
            InitializeComponent();
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="d">информация для окна</param>
        public LVL_Info(LVLInf_TagData d)
        {
            InitializeComponent();

            // взять информацию о уровнях
            levels = d.Levels;
            bClickMus = d.BClickMus;

            // вывод информации:

            TextBlock textBlock = new TextBlock();

            // Отображения кол-во уровней
            textBlock.Text = $"Уровни({levels.Count}):"; textBlock.FontSize = 30;
            textBlock.FontWeight = FontWeights.Bold; textBlock.TextDecorations = TextDecorations.Underline;
            lstBOX.Items.Add(textBlock);
            // отступ
            lstBOX.Items.Add(new TextBlock());

            // отображение данных самих уровней
            for (int i = 0; i < levels.Count; i++)
            {
                // номер, пройден или нет
                textBlock = new TextBlock();
                textBlock.FontSize = 20; textBlock.FontWeight = FontWeights.Bold;
                textBlock.Text = $"{i + 1}. Уровень {(levels.Items[i].IsSolved ? "" : "не ")}пройден.";
                lstBOX.Items.Add(textBlock);

                // если уровень пройден
                if (levels.Items[i].IsSolved)
                {
                    // написать за какое время, за какое ко-во шагов
                    string tab = string.Empty;
                    for (int k = 0; k < (i + 1).ToString().Length; k++) tab += ' ';
                    textBlock = new TextBlock();
                    textBlock.FontSize = 20; textBlock.FontWeight = FontWeights.Bold;
                    textBlock.Text = $"{tab}Время: {levels.Items[i].Time.ToString(@"hh\:mm\:ss")}      кол-во ходов: {levels.Items[i].Steps}";
                    lstBOX.Items.Add(textBlock);
                }

                // отступ
                lstBOX.Items.Add(new TextBlock());
            }

        }

        /// <summary>
        /// при закрытии окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // проиграть звук нажатия на кнопку
            bClickMus.Play();
        }
    }

    /// <summary>
    /// класс, содержащий информацию для этого диалог-окна
    /// </summary>
    public class LVLInf_TagData
    {
        /// <summary>
        /// информация о уровнях
        /// </summary>
        public LVLs Levels { get; }
        /// <summary>
        /// мелодия при нажатие на кнопку
        /// </summary>
        public SoundPlayer BClickMus { get; }

        /// <summary>
        /// конмтруктор с параметрами
        /// </summary>
        /// <param name="l">все уровни</param>
        /// <param name="s">мелодия</param>
        public LVLInf_TagData(LVLs l, SoundPlayer s)
        {
            Levels = l;
            BClickMus = s;
        }
    }
}

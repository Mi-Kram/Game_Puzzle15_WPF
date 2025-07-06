using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.Threading;


namespace Main
{

    #region Программа, где для цифр используется шаблон кнопки

    ///// <summary>
    ///// Логика взаимодействия для MainWindow.xaml
    ///// </summary>
    //public partial class MainWindow : Window
    //{
    //    /// <summary>
    //    /// класс, хранящий информацию цифры, которая бдет перещена в другую ячейку
    //    /// </summary>
    //    class DigImageData
    //    {
    //        /// <summary>
    //        /// кнопка с изображением определённой цифры
    //        /// </summary>
    //        Button button;

    //        /// <summary>
    //        /// изначальный Margin
    //        /// </summary>
    //        Thickness autoThickness;

    //        /// <summary>
    //        /// новая позиция кнопки в сетке 4х4
    //        /// </summary>
    //        (int row, int col) newPos;

    //        public Button Button { get => button; set { button = value; } }
    //        public Thickness AutoThickness { get => autoThickness; set { autoThickness = value; } }
    //        public (int row, int col) NewPos { get => newPos; set { newPos = value; } }

    //        /// <summary>
    //        /// конструктор по умолчанию
    //        /// </summary>
    //        public DigImageData()
    //        {
    //            button = null;
    //            autoThickness = new Thickness();
    //            newPos = (0, 0);
    //        }
    //        /// <summary>
    //        /// конструктор с параметрами
    //        /// </summary>
    //        /// <param name="i">Кнопка</param>
    //        /// <param name="t">Изначальный margin</param>
    //        /// <param name="p">новая позиция в сетке 4х4</param>
    //        public DigImageData(Button i, Thickness t, (int r, int c) p)
    //        {
    //            button = i;
    //            autoThickness = t;
    //            newPos = p;
    //        }
    //    }

    //    /// <summary>
    //    /// звук нажатия кнопки
    //    /// </summary>
    //    SoundPlayer butClick;

    //    /// <summary>
    //    /// звук нажатия цифры
    //    /// </summary>
    //    SoundPlayer digClick;

    //    /// <summary>
    //    /// фоновая музыка
    //    /// </summary>
    //    MediaPlayer backgroundMusik;

    //    /// <summary>
    //    /// информация о цифре, которая перемещается по сетке
    //    /// </summary>
    //    DigImageData curMoovingImg;

    //    /// <summary>
    //    /// поле 4х4 с текущим расположением цифр
    //    /// </summary>
    //    int[,] matrix;

    //    /// <summary>
    //    /// все уровни и информация о них
    //    /// </summary>
    //    LVLs levels;

    //    /// <summary>
    //    /// текущий уровень
    //    /// </summary>
    //    LVL currentLVL;

    //    /// <summary>
    //    /// таймер для отображения потраченного времени на уровень
    //    /// </summary>
    //    DispatcherTimer timer;

    //    /// <summary>
    //    /// время начала решения 
    //    /// </summary>
    //    DateTime start;
    //    /// <summary>
    //    /// время конца решения 
    //    /// </summary>
    //    DateTime end;

    //    /// <summary>
    //    /// кол-во шагов при решении
    //    /// </summary>
    //    int st;

    //    /// <summary>
    //    /// конструктор по умолчанию
    //    /// </summary>
    //    public MainWindow()
    //    {
    //        InitializeComponent();

    //        levels = new LVLs();
    //        timer = new DispatcherTimer();
    //        timer.Tick += Timer_Tick;
    //        timer.Interval = new TimeSpan(0, 0, 1);
    //        st = 0;

    //        butClick = new SoundPlayer(Environment.CurrentDirectory + @"\Resources\Media\ButClick.wav");
    //        digClick = new SoundPlayer(Environment.CurrentDirectory + @"\Resources\Media\DigClick.wav");

    //        backgroundMusik = new MediaPlayer();
    //        backgroundMusik.Open(new Uri(Environment.CurrentDirectory + @"\Resources\Media\BackGroundM.wav"));
    //        backgroundMusik.MediaEnded += BackgroundMusik_MediaEnded;
    //        backgroundMusik.Play();

    //        curMoovingImg = null;
    //        curMoovingImg = null;

    //        // загрузить данные (уровни и их инфо)
    //        ReadConfig();
    //    }

    //    /// <summary>
    //    /// после завершения проигрывания фоновой музыки
    //    /// метод запускает музыку сначала
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void BackgroundMusik_MediaEnded(object sender, EventArgs e)
    //    {
    //        // сброс проигрывателя к началу
    //        backgroundMusik.Stop();
    //        // запуск проигрывателя
    //        backgroundMusik.Play();
    //    }

    //    /// <summary>
    //    /// Каждую секунду меняет значение в StatusBar, "Время"
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Timer_Tick(object sender, EventArgs e)
    //    {
    //        // отображение в statusBar времени (часы:минуты:секунды)
    //        time.Content = (DateTime.Now - start).ToString(@"hh\:mm\:ss");
    //    }

    //    /// <summary>
    //    /// Чтение конфиг-файла
    //    /// </summary>
    //    private void ReadConfig()
    //    {
    //        try
    //        {
    //            // прочитать все строки (1 строка = 1 уровень)
    //            string[] lvls = File.ReadAllLines(Environment.CurrentDirectory + @"\Resources\config.txt");

    //            // обработка каждой строки
    //            foreach (string item in lvls)
    //            {
    //                AddLVL(item);
    //            }
    //        }
    //        catch { }
    //    }

    //    /// <summary>
    //    /// про-парсить и добавить уровень
    //    /// </summary>
    //    /// <param name="lvl">строка данных уровня</param>
    //    private void AddLVL(string lvl)
    //    {
    //        // новый уровень
    //        LVL newLVL = null;

    //        try
    //        {
    //            // делим строку на части по символу '|'
    //            string[] parts = lvl.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
    //            int len = parts.Count();

    //            if (len >= 1)
    //            {
    //                // делим первую часть по символу пробелу
    //                string[] nums = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    //                if (nums.Length != 16) return; // если данные уровня некорректны - выход без добавления уровня

    //                // преобразовать в массив из чисел
    //                int[] arr = new int[16];
    //                for (int i = 0; i < 16; i++) arr[i] = int.Parse(nums[i]);

    //                // проверка на корестность данных
    //                int[] tmp = arr.OrderBy(i => i).ToArray();
    //                for (int i = 0; i < 16; i++)
    //                    if (tmp[i] != i) return; // выход при некорректных данных

    //                // заполнить матрицу (уровень, расположение цифр)
    //                int[,] m = new int[4, 4];
    //                for (int i = 0; i < 4; i++)
    //                    for (int j = 0; j < 4; j++)
    //                        m[i, j] = arr[i * 4 + j];

    //                // создание нового уровня
    //                newLVL = new LVL(m);

    //                // если была указана доп. информация
    //                if (len >= 2)
    //                {
    //                    // пройден ли уровень
    //                    if (!bool.TryParse(parts[1], out bool isSolved)) isSolved = false;

    //                    // если уровень пройден и указано больше информации
    //                    if (isSolved && len >= 4)
    //                    {
    //                        // получить время прохождения уровня
    //                        string[] timeSPL = parts[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

    //                        if (timeSPL.Count() == 3)
    //                        {
    //                            TimeSpan TS = new TimeSpan(int.Parse(timeSPL[0]), int.Parse(timeSPL[1]), int.Parse(timeSPL[2]));
    //                            int ST = int.Parse(parts[3]); // получить кол-во шагов

    //                            // присваивание доп. информации
    //                            newLVL.Time = TS;
    //                            newLVL.Steps = ST;
    //                            newLVL.IsSolved = true;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch { }

    //        // если новый уровень получилось прочитать
    //        if (newLVL != null)
    //        {
    //            // добавление уровня
    //            levels.Items.Add(newLVL);

    //            // создание кнопки для уровня
    //            Button button = new Button();

    //            // определить какой шаблон присвоить кнопке

    //            // если уровень открытый
    //            if (levels.Items.Count == 1 || levels.Items[levels.Items.Count - 2].IsSolved)
    //            {
    //                button.Template = (ControlTemplate)FindResource("ImgTemplOpenLVL");
    //            }
    //            // иначе - уровень закрыт/не доступен
    //            else
    //            {
    //                button.Template = (ControlTemplate)FindResource("ImgTemplCloseLVL");
    //                button.IsEnabled = false;
    //            }

    //            button.Width = 67; button.Height = 67;
    //            button.Click += StartLVL_Click;
    //            button.Content = levels.Count.ToString();
    //            if (levels.Count.ToString().Length <= 2) button.FontSize = 50;
    //            else if (levels.Count.ToString().Length == 3) button.FontSize = 35;
    //            else button.FontSize = 5;
    //            button.VerticalAlignment = VerticalAlignment.Center;
    //            button.HorizontalAlignment = HorizontalAlignment.Center;

    //            // добавление кнопки уровня в панель
    //            SCRlvlPanel.Children.Add(button);
    //        }
    //    }

    //    /// <summary>
    //    /// нажатие на определённый уровень, и начать данный уровень
    //    /// </summary>
    //    /// <param name="sender">кнопка, на которую нажали</param>
    //    /// <param name="e"></param>
    //    private void StartLVL_Click(object sender, RoutedEventArgs e)
    //    {
    //        // проигрывание щелчка по кнопке
    //        butClick.Play();
    //        // получить номер уровня в виде строки
    //        string numLVL = (sender as Button).Content as string;
    //        // найти уровень по номеру
    //        currentLVL = levels.GetLVL(int.Parse(numLVL));

    //        // склонировать поле 4х4 с расположением цифр
    //        matrix = currentLVL.Matrix.Clone() as int[,];
    //        // перемешать цифры на экране
    //        GenerateNewLVL();
    //        // отобразить уровень на statusBar
    //        curLVL.Content = "Уровень: " + numLVL;
    //        // включить игровое поле
    //        playGrid.Visibility = Visibility.Visible;
    //        // выключить поле с уровнями
    //        levelGrid.Visibility = Visibility.Hidden;
    //    }

    //    /// <summary>
    //    /// поменять значение местами
    //    /// </summary>
    //    /// <param name="a">первый параметр</param>
    //    /// <param name="b">второй параметр</param>
    //    private void swap(ref int a, ref int b)
    //    {
    //        int tmp = a;
    //        a = b;
    //        b = tmp;
    //    }

    //    /// <summary>
    //    /// изменить порядок цифр на доске согласно matrix (текущему уровню)
    //    /// </summary>
    //    private void GenerateNewLVL()
    //    {
    //        for (int i = 0; i < 4; i++)
    //        {
    //            for (int j = 0; j < 4; j++)
    //            {
    //                // если клетка пустая - перейти к следующей итерации
    //                if (matrix[i, j] == 0) continue;

    //                // получить текущую цифру
    //                Button image = GetImage(matrix[i, j]);
    //                // если цифра найдена - поменять расположение
    //                if (image != null)
    //                {
    //                    Grid.SetRow(image, i);
    //                    Grid.SetColumn(image, j);
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// получить цифру по номеру
    //    /// </summary>
    //    /// <param name="num">номер цифры</param>
    //    /// <returns></returns>
    //    private Button GetImage(int num)
    //    {
    //        switch (num)
    //        {
    //            case 1: return N1;
    //            case 2: return N2;
    //            case 3: return N3;
    //            case 4: return N4;
    //            case 5: return N5;
    //            case 6: return N6;
    //            case 7: return N7;
    //            case 8: return N8;
    //            case 9: return N9;
    //            case 10: return N10;
    //            case 11: return N11;
    //            case 12: return N12;
    //            case 13: return N13;
    //            case 14: return N14;
    //            case 15: return N15;
    //            default: return null;
    //        }
    //    }

    //    /// <summary>
    //    /// получить номер по цифре(Button)
    //    /// </summary>
    //    /// <param name="image">цифра</param>
    //    /// <returns></returns>
    //    private int GetNum(Button button)
    //    {
    //        switch (button.Name)
    //        {
    //            case "N1": return 1;
    //            case "N2": return 2;
    //            case "N3": return 3;
    //            case "N4": return 4;
    //            case "N5": return 5;
    //            case "N6": return 6;
    //            case "N7": return 7;
    //            case "N8": return 8;
    //            case "N9": return 9;
    //            case "N10": return 10;
    //            case "N11": return 11;
    //            case "N12": return 12;
    //            case "N13": return 13;
    //            case "N14": return 14;
    //            case "N15": return 15;
    //            default: return 0;
    //        }
    //    }

    //    /// <summary>
    //    /// получить координаты числа в матрице
    //    /// </summary>
    //    /// <param name="num">искомое число</param>
    //    /// <returns>(индекс строки, индекс столбца), если num не найден, то вернуть (-1,-1)</returns>
    //    private (int, int) GetPos(int num)
    //    {
    //        for (int i = 0; i < 4; i++)
    //            for (int j = 0; j < 4; j++)
    //                if (matrix[i, j] == num) return (i, j); // если num найден

    //        return (-1, -1); // если num не найден
    //    }

    //    /// <summary>
    //    /// найти координаты пустой ячейки (равной нулю) вокруг цифры(num)
    //    /// </summary>
    //    /// <param name="num"></param>
    //    /// <returns></returns>
    //    private (int, int) GetEmptyPos(int num)
    //    {
    //        // получить позицию цифры num
    //        (int row, int col) pos = GetPos(num);

    //        // если позиция найдена
    //        if (pos != (-1, -1))
    //        {
    //            // поиск пустой ячейки(равной нулю) вокруг данной позиции
    //            // если такая есть, вернуть координаты
    //            int x, y;

    //            x = pos.row - 1; y = pos.col;
    //            if (x >= 0 && x < 4 && matrix[x, y] == 0) return (x, y);

    //            x = pos.row; y = pos.col + 1;
    //            if (y >= 0 && y < 4 && matrix[x, y] == 0) return (x, y);

    //            x = pos.row + 1; y = pos.col;
    //            if (x >= 0 && x < 4 && matrix[x, y] == 0) return (x, y);

    //            x = pos.row; y = pos.col - 1;
    //            if (y >= 0 && y < 4 && matrix[x, y] == 0) return (x, y);
    //        }

    //        // если координаты не найдены
    //        return (-1, -1);
    //    }

    //    /// <summary>
    //    /// проверка на подеду
    //    /// </summary>
    //    /// <returns>true - выйигрышь, false - проинрышь</returns>
    //    private bool IsWin()
    //    {
    //        int cnt = 1;
    //        for (int i = 0; i < 4; i++)
    //            for (int j = 0; j < 4; j++)
    //                // если что-то не на своём месте, вернуть false
    //                if (i * 4 + j != 15 && matrix[i, j] != cnt++) return false;

    //        // если всё собрано
    //        return true;
    //    }

    //    /// <summary>
    //    /// нажатие на цифру
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e">цифра на которую нажали</param>
    //    private void Image_Click(object sender, RoutedEventArgs e)
    //    {
    //        // получить номер по картинке
    //        int imgNum = GetNum(sender as Button);
    //        //получить координаты новой позиции (пустой ячейки)
    //        (int row, int col) newPos = GetEmptyPos(imgNum);

    //        // если координата есть
    //        if (newPos != (-1, -1))
    //        {
    //            // проиграть звук нажатия по цифре
    //            digClick.Play();

    //            // если таймер выключен
    //            if (!timer.IsEnabled)
    //            {
    //                // записать время начала решения головоломки
    //                start = DateTime.Now;
    //                // запустить таймер
    //                timer.Start();
    //            }

    //            // записать цифру, которая движется/меняет ячейку
    //            curMoovingImg = new DigImageData(sender as Button, (sender as Button).Margin, newPos);

    //            // получить старую координату 
    //            (int row, int col) ZPos = GetPos(imgNum);

    //            // получить margin для анимации
    //            Thickness AnimTh;
    //            double m = curMoovingImg.AutoThickness.Left;
    //            // если картинка движется вправо или влево
    //            if (newPos.col != ZPos.col)
    //            {
    //                double w = curMoovingImg.Button.ActualWidth;
    //                // если картинка движется вправо
    //                if (newPos.col > ZPos.col)
    //                {
    //                    AnimTh = new Thickness(w + 2 * m, m, -w - m, m);
    //                }
    //                // иначе - если картинка движется влево
    //                else
    //                {
    //                    AnimTh = new Thickness(-w - m, m, w + 2 * m, m);
    //                }
    //            }
    //            // иначе - если картинка движется вверх или вниз
    //            else
    //            {
    //                double h = curMoovingImg.Button.ActualHeight;
    //                // если картинка движется вниз
    //                if (newPos.row > ZPos.row)
    //                {
    //                    AnimTh = new Thickness(m, h + 2 * m, m, -h - m);
    //                }
    //                // иначе - если картинка движется вниз
    //                else
    //                {
    //                    AnimTh = new Thickness(m, -h - m, m, h + 2 * m);
    //                }

    //            }
    //            // начать анимацию
    //            AnimateImageMove(curMoovingImg.Button, AnimTh);

    //            // поменть значение в матрице
    //            swap(ref matrix[ZPos.row, ZPos.col], ref matrix[newPos.row, newPos.col]);

    //            // изменить кол-во ходов
    //            steps.Content = $"Ходов: {++st}";

    //            // если всё собрано
    //            if (IsWin())
    //            {
    //                // определить конечное время
    //                end = DateTime.Now;
    //                //остановить таймер
    //                timer.Stop();
    //                // обработка завершённого уровня
    //                LevelCompleted();
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Анимировать движение цифры
    //    /// </summary>
    //    /// <param name="img">Цифра</param>
    //    /// <param name="th">Новое, временное значение margin для перемещения от текущего</param>
    //    private void AnimateImageMove(Button img, Thickness th)
    //    {
    //        ThicknessAnimation ta = new ThicknessAnimation(th, TimeSpan.FromMilliseconds(100));
    //        ta.AutoReverse = false;
    //        // после завершения анимации запустить метод Ta_Completed
    //        ta.Completed += Ta_Completed;

    //        img.BeginAnimation(Image.MarginProperty, ta);
    //    }

    //    /// <summary>
    //    /// после завершения анимации перемещения цифры
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Ta_Completed(object sender, EventArgs e)
    //    {
    //        // установить новые позиции для цифры
    //        Grid.SetColumn(curMoovingImg.Button, curMoovingImg.NewPos.col);
    //        Grid.SetRow(curMoovingImg.Button, curMoovingImg.NewPos.row);

    //        // убрать параметры из анимации по Button.MarginProperty
    //        curMoovingImg.Button.BeginAnimation(Button.MarginProperty, null);

    //        // присвоить стандартное значение margin
    //        curMoovingImg.Button.Margin = curMoovingImg.AutoThickness;
    //        // записать, что текущих движущхся цифр нет
    //        curMoovingImg = null;
    //    }

    //    /// <summary>
    //    /// обработчик завершённого уровня
    //    /// </summary>
    //    private void LevelCompleted()
    //    {
    //        // получить время прохождения уровня
    //        TimeSpan t = end - start;
    //        time.Content = t.ToString(@"hh\:mm\:ss");

    //        // если уровень был ранее собран
    //        if (currentLVL.IsSolved)
    //        {
    //            // переписать результат, если он лучше старого
    //            if (currentLVL.Time > t) currentLVL.Time = t;
    //            if (currentLVL.Steps > st) currentLVL.Steps = st;
    //        }
    //        // если уровень пройден впервые
    //        else
    //        {
    //            // записать результаты
    //            currentLVL.Time = t;
    //            currentLVL.Steps = st;
    //            currentLVL.IsSolved = true;

    //            // разблокировать следующий уровень
    //            UnlockNextLVL();
    //        }

    //        // окно-сообщение о прохождение уровне | возвращает:
    //        // true - перейти к следующему уровню, false - выход в главное меню
    //        LVLCompl compl = new LVLCompl(t, st);
    //        compl.Tag = butClick;
    //        var res = compl.ShowDialog();

    //        // сброс данных
    //        time.Content = "00:00:00";
    //        steps.Content = "Ходов: 0";
    //        st = 0;

    //        // переход к следующему уровню
    //        if (res == true)
    //        {
    //            int numLVL = 0; // номер следующего уровня
    //            for (int i = 0; i < levels.Count; i++)
    //            {
    //                // если найден текущий уровень (который только что прошёлся)
    //                if (levels.Items[i] == currentLVL)
    //                {
    //                    // если он был последним
    //                    if (i + 1 == levels.Count)
    //                    {
    //                        // включить главное меню
    //                        menuGrid.Visibility = Visibility.Visible;
    //                        // выключить игровую доску
    //                        playGrid.Visibility = Visibility.Hidden;
    //                        // обнулить текущий уровень
    //                        currentLVL = null;

    //                        // выйти из метода
    //                        return;
    //                    }
    //                    // иначе
    //                    numLVL = i + 2; // номер следующего уровня
    //                    currentLVL = levels.Items[i + 1]; // выбрать следующий уровень
    //                    break; // выход из цикла
    //                }
    //            }

    //            // обновить в statusBar новый текущий уровень
    //            curLVL.Content = "Уровень: " + numLVL;
    //            // выбрать новую схему нового уровня
    //            matrix = currentLVL.Matrix.Clone() as int[,];
    //            // отобразить её пользователю
    //            GenerateNewLVL();
    //        }
    //        // выход в меню
    //        else
    //        {
    //            // включить главное меню
    //            menuGrid.Visibility = Visibility.Visible;
    //            // выключить игровую доску
    //            playGrid.Visibility = Visibility.Hidden;
    //            // обнулить текущий уровень
    //            currentLVL = null;

    //            // выйти из метода
    //            return;
    //        }
    //    }

    //    /// <summary>
    //    /// Разблокировать следующий уровень
    //    /// </summary>
    //    private void UnlockNextLVL()
    //    {
    //        foreach (Button button in SCRlvlPanel.Children)
    //        {
    //            // если найден первый заблокированный уровень
    //            if (!button.IsEnabled)
    //            {
    //                // разблокировать
    //                button.IsEnabled = true;
    //                // присвоить кнопке шаблон открытого уровня
    //                button.Template = (ControlTemplate)FindResource("ImgTemplOpenLVL");
    //                //выход из метода
    //                return;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Подробная информаци о уровнях
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void LVLsInfo_Click(object sender, RoutedEventArgs e)
    //    {
    //        // проиграть звук нажатия по кнопке
    //        butClick.Play();

    //        // создание диалогового окна
    //        LVL_Info info = new LVL_Info(new LVLInf_TagData(levels, butClick));

    //        // запуск окна
    //        info.ShowDialog();
    //    }

    //    /// <summary>
    //    /// нажатие на кнопку PLAY в главном меню
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Play_Click(object sender, RoutedEventArgs e)
    //    {
    //        // проиграть звук нажатия по кнопке
    //        butClick.Play();
    //        // включить меню выбора уровня
    //        levelGrid.Visibility = Visibility.Visible;
    //    }


    //    /// <summary>
    //    /// отмена выбора уровня, нажатие на levelGrid, а не на уровень
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void levelGrid_MouseDown(object sender, MouseButtonEventArgs e)
    //    {
    //        // выключить меню выбора уровня
    //        levelGrid.Visibility = Visibility.Hidden;
    //    }

    //    /// <summary>
    //    /// изменение размера окна
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    //    {
    //        // изменение размера кнопки PLAY в главном меню
    //        double w = ActualWidth / 10, h = ActualHeight / 10;
    //        double tmp = Math.Min(w, h);
    //        playButton.Height = tmp * 3;
    //        playButton.Width = tmp * 7;


    //        // изменение размера окна меню выбора уровня
    //        w = ActualWidth / 5;
    //        h = ActualHeight / 5;
    //        //SCRlevelGrid.Margin = new Thickness(w, h, w, h);
    //        LVLsMenuGrid.Margin = new Thickness(w, h, w, h);


    //        // изменение размера игровой доски 
    //        tmp = Math.Min(ActualHeight - 100, ActualWidth);
    //        playBoard.Height = tmp;
    //        playBoard.Width = tmp;
    //        board.Orientation = tmp == ActualWidth ? Orientation.Horizontal : Orientation.Vertical;
    //    }

    //    /// <summary>
    //    /// выход из уровня
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void ExitFromLVL_Click(object sender, RoutedEventArgs e)
    //    {
    //        // проиграть звук нажатия по кнопке
    //        butClick.Play();

    //        // остановка таймера
    //        timer.Stop();
    //        // обнуление текущего уровня
    //        currentLVL = null;
    //        // включение главного меню
    //        menuGrid.Visibility = Visibility.Visible;
    //        // выключение игровой доски
    //        playGrid.Visibility = Visibility.Hidden;
    //        // обнуление данных о прохождение
    //        time.Content = "00:00:00";
    //        steps.Content = "Ходов: 0";
    //        st = 0;
    //    }

    //    /// <summary>
    //    /// начать уровень сначала
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Restart_Click(object sender, RoutedEventArgs e)
    //    {
    //        // проиграть звук нажатия по кнопке
    //        butClick.Play();

    //        // остановить таймер
    //        timer.Stop();
    //        // получить схему текущего уровня
    //        matrix = currentLVL.Matrix.Clone() as int[,];
    //        // отобразить уровень пользователю
    //        GenerateNewLVL();
    //        // сброс данных
    //        time.Content = "00:00:00";
    //        steps.Content = "Ходов: 0";
    //        st = 0;
    //    }

    //    /// <summary>
    //    /// закрытие окна - созранить данные
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    //    {
    //        try
    //        {
    //            // открыть конфиг-файл
    //            FileStream fs = new FileStream(Environment.CurrentDirectory + @"\Resources\config.txt", FileMode.Create, FileAccess.Write);
    //            StreamWriter sw = new StreamWriter(fs);

    //            foreach (LVL lvl in levels.Items)
    //            {
    //                // строка данных одного уровня
    //                string str = string.Empty;

    //                // записать схему уровня
    //                for (int i = 0; i < 4; i++)
    //                    for (int j = 0; j < 4; j++)
    //                        str += $"{lvl.Matrix[i, j]} ";

    //                // записать остальные данные если уровень пройден
    //                if (lvl.IsSolved) str += $"|{lvl.IsSolved}|{lvl.Time.ToString(@"hh\:mm\:ss")}|{lvl.Steps}";

    //                // записать в файл
    //                sw.WriteLine(str);
    //            }

    //            // закрыть поток конфиг-файла
    //            sw.Close();
    //            fs.Close();
    //        }
    //        catch { }
    //    }

    //    /// <summary>
    //    /// закрыть программу
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void Close_Click(object sender, RoutedEventArgs e)
    //    {
    //        // проиграть звук нажатия по кнопке
    //        butClick.Play();
    //        // закрыть
    //        Close();
    //    }

    //    /// <summary>
    //    /// Включить выключить фоновую музыку
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void StartStopMusik(object sender, RoutedEventArgs e)
    //    {
    //        // если музыка выключена
    //        if (!IsBGMusikEnable.IsChecked) backgroundMusik.Play();
    //        // иначе - если музыка включена
    //        else backgroundMusik.Stop();

    //        // отобразить пользователю новое значение
    //        IsBGMusikEnable.IsChecked = !IsBGMusikEnable.IsChecked;
    //    }
    //}

    #endregion





    #region Программа, где для цифр используется Rectangle

    /// <summary>
    /// Сообщение от уровня после прохождении
    /// </summary>
    public enum LevelMes
    {
        /// <summary>
        /// нет сообщения
        /// </summary>
        NONE,
        /// <summary>
        /// открыт новый уровень
        /// </summary>
        NewLevel,
        /// <summary>
        /// поставлен новый рекорд
        /// </summary>
        NewRecord
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// класс, хранящий информацию цифры, которая будет перещена в другую ячейку
        /// </summary>
        class DigImageData
        {
            /// <summary>
            /// прямоугольник с изображением определённой цифры
            /// </summary>
            Rectangle rectangle;

            /// <summary>
            /// изначальный Margin
            /// </summary>
            Thickness autoThickness;

            /// <summary>
            /// новая позиция кнопки в сетке 4х4
            /// </summary>
            (int row, int col) newPos;

            /// <summary>
            /// прямоугольник с изображением определённой цифры
            /// </summary>
            public Rectangle Rectangle { get => rectangle; set { rectangle = value; } }
            /// <summary>
            /// изначальный Margin
            /// </summary>
            public Thickness AutoThickness { get => autoThickness; set { autoThickness = value; } }
            /// <summary>
            /// новая позиция кнопки в сетке 4х4
            /// </summary>
            public (int row, int col) NewPos { get => newPos; set { newPos = value; } }

            /// <summary>
            /// конструктор по умолчанию
            /// </summary>
            public DigImageData()
            {
                rectangle = null;
                autoThickness = new Thickness();
                newPos = (0, 0);
            }
            /// <summary>
            /// конструктор с параметрами
            /// </summary>
            /// <param name="i">Кнопка</param>
            /// <param name="t">Изначальный margin</param>
            /// <param name="p">новая позиция в сетке 4х4</param>
            public DigImageData(Rectangle i, Thickness t, (int r, int c) p)
            {
                rectangle = i;
                autoThickness = t;
                newPos = p;
            }
        }

        /// <summary>
        /// звук нажатия кнопки
        /// </summary>
        SoundPlayer butClick;

        /// <summary>
        /// звук нажатия цифры
        /// </summary>
        SoundPlayer digClick;

        /// <summary>
        /// фоновая музыка
        /// </summary>
        MediaPlayer backgroundMusik;

        /// <summary>
        /// информация о цифре, которая перемещается по сетке
        /// </summary>
        DigImageData curMoovingImg;

        /// <summary>
        /// поле 4х4 с текущим расположением цифр (схема уровня)
        /// </summary>
        int[,] matrix;

        /// <summary>
        /// все уровни и информация о них
        /// </summary>
        LVLs levels;

        /// <summary>
        /// текущий уровень
        /// </summary>
        LVL currentLVL;

        /// <summary>
        /// таймер для отображения потраченного времени на уровень
        /// </summary>
        DispatcherTimer timer;

        /// <summary>
        /// время начала решения 
        /// </summary>
        DateTime start;
        /// <summary>
        /// время конца решения 
        /// </summary>
        DateTime end;

        /// <summary>
        /// кол-во шагов при решении
        /// </summary>
        int st;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            levels = new LVLs();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            st = 0;

            butClick = new SoundPlayer(Environment.CurrentDirectory + @"\Resources\Media\ButClick.wav");
            digClick = new SoundPlayer(Environment.CurrentDirectory + @"\Resources\Media\DigClick.wav");

            backgroundMusik = new MediaPlayer();
            backgroundMusik.Open(new Uri(Environment.CurrentDirectory + @"\Resources\Media\BackGroundM.wav"));
            backgroundMusik.MediaEnded += BackgroundMusik_MediaEnded;
            backgroundMusik.Play();

            curMoovingImg = null;
            curMoovingImg = null;

            // загрузить данные (уровни и их информацию)
            ReadConfig();
        }

        /// <summary>
        /// после завершения проигрывания фоновой музыки
        /// метод запускает музыку сначала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundMusik_MediaEnded(object sender, EventArgs e)
        {
            // сброс проигрывателя к началу
            backgroundMusik.Stop();
            // запуск проигрывателя
            backgroundMusik.Play();
        }

        /// <summary>
        /// Каждую секунду меняет значение в StatusBar, "Время"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // отображение в statusBar текущее время прохождения уровня (часы:минуты:секунды)
            time.Content = (DateTime.Now - start).ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Чтение конфиг-файла
        /// </summary>
        private void ReadConfig()
        {
            try
            {
                // прочитать все строки (1 строка = 1 уровень)
                string[] lvls = File.ReadAllLines(Environment.CurrentDirectory + @"\Resources\config.txt");

                // обработка каждой строки
                foreach (string item in lvls)
                {
                    // добавить уровень
                    AddLVL(item);
                }
            }
            catch { }
        }

        /// <summary>
        /// про-парсить и добавить уровень
        /// </summary>
        /// <param name="lvl">строка данных уровня</param>
        private void AddLVL(string lvl)
        {
            // новый уровень
            LVL newLVL = null;

            // парсим строку
            try
            {
                // делим строку на части по символу '|'
                string[] parts = lvl.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                int len = parts.Count();

                if (len >= 1)
                {
                    // делим первую часть по символу пробелу
                    string[] nums = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (nums.Length != 16) return; // если данные уровня некорректны - выход без добавления уровня

                    // преобразовать в массив из чисел
                    int[] arr = new int[16];
                    for (int i = 0; i < 16; i++) arr[i] = int.Parse(nums[i]);

                    // проверка на корестность данных
                    int[] tmp = arr.OrderBy(i => i).ToArray();
                    for (int i = 0; i < 16; i++)
                        if (tmp[i] != i) return; // выход при некорректных данных

                    // заполнить матрицу (уровень, расположение цифр)
                    int[,] m = new int[4, 4];
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            m[i, j] = arr[i * 4 + j];

                    // создание нового уровня
                    newLVL = new LVL(m);

                    // если была указана доп. информация
                    if (len >= 2)
                    {
                        // пройден ли уровень
                        if (!bool.TryParse(parts[1], out bool isSolved)) isSolved = false;

                        // если уровень пройден и указано больше информации
                        if (isSolved && len >= 4)
                        {
                            // получить время прохождения уровня
                            string[] timeSPL = parts[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                            if (timeSPL.Count() == 3)
                            {
                                TimeSpan TS = new TimeSpan(int.Parse(timeSPL[0]), int.Parse(timeSPL[1]), int.Parse(timeSPL[2]));
                                int ST = int.Parse(parts[3]); // получить кол-во шагов

                                // присваивание доп. информации
                                newLVL.Time = TS;
                                newLVL.Steps = ST;
                                newLVL.IsSolved = true;
                            }
                        }
                    }
                }
            }
            catch { }

            // если новый уровень получилось прочитать
            if (newLVL != null)
            {
                // добавление уровня
                levels.Items.Add(newLVL);

                // создание кнопки для уровня
                Button button = new Button();

                // определить какой шаблон присвоить кнопке

                // если уровень открытый
                if (levels.Items.Count == 1 || levels.Items[levels.Items.Count - 2].IsSolved)
                {
                    button.Template = (ControlTemplate)FindResource("ImgTemplOpenLVL");
                }
                // иначе - уровень закрыт/не доступен/заблокирован
                else
                {
                    button.Template = (ControlTemplate)FindResource("ImgTemplCloseLVL");
                    button.IsEnabled = false;
                }

                button.Width = 67; button.Height = 67;
                button.Click += StartLVL_Click;
                button.Content = levels.Count.ToString();
                if (levels.Count.ToString().Length <= 2) button.FontSize = 50;
                else if (levels.Count.ToString().Length == 3) button.FontSize = 35;
                else button.FontSize = 5;
                button.VerticalAlignment = VerticalAlignment.Center;
                button.HorizontalAlignment = HorizontalAlignment.Center;

                // добавление кнопки уровня в панель
                SCRlvlPanel.Children.Add(button);
            }
        }

        /// <summary>
        /// нажатие на определённый уровень, и начать данный уровень
        /// </summary>
        /// <param name="sender">кнопка, на которую нажали</param>
        /// <param name="e"></param>
        private void StartLVL_Click(object sender, RoutedEventArgs e)
        {
            // проигрывание щелчка по кнопке
            butClick.Play();
            // получить номер уровня в виде строки
            string numLVL = (sender as Button).Content as string;
            // найти уровень по номеру
            currentLVL = levels.GetLVL(int.Parse(numLVL));

            // склонировать поле 4х4 с расположением цифр
            matrix = currentLVL.Matrix.Clone() as int[,];
            // перемешать цифры на экране
            GenerateNewLVL();
            // отобразить уровень на statusBar
            curLVL.Content = "Уровень: " + numLVL;
            // включить игровое поле
            playGrid.Visibility = Visibility.Visible;
            // выключить поле с уровнями
            levelGrid.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// поменять значение местами
        /// </summary>
        /// <param name="a">первый параметр</param>
        /// <param name="b">второй параметр</param>
        private void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// изменить порядок цифр на доске согласно matrix (текущему уровню)
        /// </summary>
        private void GenerateNewLVL()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // если клетка пустая - перейти к следующей итерации
                    if (matrix[i, j] == 0) continue;

                    // получить текущую цифру
                    Rectangle rect = GetImage(matrix[i, j]);
                    // если цифра найдена - поменять расположение
                    if (rect != null)
                    {
                        Grid.SetRow(rect, i);
                        Grid.SetColumn(rect, j);
                    }
                }
            }
        }

        /// <summary>
        /// получить цифру по номеру
        /// </summary>
        /// <param name="num">номер цифры</param>
        /// <returns>Прямоугольник с цифрой равной номеру, если такая не найдена - null</returns>
        private Rectangle GetImage(int num)
        {
            switch (num)
            {
                case 1: return N1;
                case 2: return N2;
                case 3: return N3;
                case 4: return N4;
                case 5: return N5;
                case 6: return N6;
                case 7: return N7;
                case 8: return N8;
                case 9: return N9;
                case 10: return N10;
                case 11: return N11;
                case 12: return N12;
                case 13: return N13;
                case 14: return N14;
                case 15: return N15;
                default: return null;
            }
        }

        /// <summary>
        /// получить номер по цифре(Button)
        /// </summary>
        /// <param name="image">цифра</param>
        /// <returns>Номер равный цифре на картинке, если такой не найден - null</returns>
        private int GetNum(Rectangle rectangle)
        {
            switch (rectangle.Name)
            {
                case "N1": return 1;
                case "N2": return 2;
                case "N3": return 3;
                case "N4": return 4;
                case "N5": return 5;
                case "N6": return 6;
                case "N7": return 7;
                case "N8": return 8;
                case "N9": return 9;
                case "N10": return 10;
                case "N11": return 11;
                case "N12": return 12;
                case "N13": return 13;
                case "N14": return 14;
                case "N15": return 15;
                default: return 0;
            }
        }

        /// <summary>
        /// получить координаты числа в матрице
        /// </summary>
        /// <param name="num">искомое число</param>
        /// <returns>(индекс строки, индекс столбца), если num не найден, то вернуть (-1,-1)</returns>
        private (int, int) GetPos(int num)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (matrix[i, j] == num) return (i, j); // если num найден

            return (-1, -1); // если num не найден
        }

        /// <summary>
        /// найти координату пустой ячейки (равной нулю) вокруг цифры(num)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private (int, int) GetEmptyPos(int num)
        {
            // получить позицию цифры num
            (int row, int col) pos = GetPos(num);

            // если позиция найдена
            if (pos != (-1, -1))
            {
                // поиск пустой ячейки(равной нулю) вокруг данной позиции
                // если такая есть, вернуть координаты
                int x, y;

                x = pos.row - 1; y = pos.col;
                if (x >= 0 && x < 4 && matrix[x, y] == 0) return (x, y);

                x = pos.row; y = pos.col + 1;
                if (y >= 0 && y < 4 && matrix[x, y] == 0) return (x, y);

                x = pos.row + 1; y = pos.col;
                if (x >= 0 && x < 4 && matrix[x, y] == 0) return (x, y);

                x = pos.row; y = pos.col - 1;
                if (y >= 0 && y < 4 && matrix[x, y] == 0) return (x, y);
            }

            // если координата не найдена
            return (-1, -1);
        }

        /// <summary>
        /// проверка на подеду
        /// </summary>
        /// <returns>true - выйигрышь, false - проинрышь</returns>
        private bool IsWin()
        {
            int cnt = 1;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    // если что-то не на своём месте, вернуть false
                    if (i * 4 + j != 15 && matrix[i, j] != cnt++) return false;

            // если всё собрано
            return true;
        }

        /// <summary>
        /// нажатие на цифру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">цифра на которую нажали</param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // получить номер по картинке
            int imgNum = GetNum(sender as Rectangle);
            //получить координаты новой позиции (пустой ячейки)
            (int row, int col) newPos = GetEmptyPos(imgNum);

            // если координата есть
            if (newPos != (-1, -1))
            {
                // проиграть звук нажатия по цифре
                digClick.Play();

                // если таймер выключен
                if (!timer.IsEnabled)
                {
                    // записать время начала решения головоломки
                    start = DateTime.Now;
                    // запустить таймер
                    timer.Start();
                }

                // записать цифру, которая движется/меняет ячейку
                curMoovingImg = new DigImageData(sender as Rectangle, (sender as Rectangle).Margin, newPos);

                // получить старую координату 
                (int row, int col) ZPos = GetPos(imgNum);

                // получить margin для анимации
                Thickness AnimTh;
                double m = curMoovingImg.AutoThickness.Left;
                // если картинка движется вправо или влево
                if (newPos.col != ZPos.col)
                {
                    double w = curMoovingImg.Rectangle.ActualWidth;
                    // если картинка движется вправо
                    if (newPos.col > ZPos.col)
                    {
                        AnimTh = new Thickness(w + 2 * m, m, -w - m, m);
                    }
                    // иначе - если картинка движется влево
                    else
                    {
                        AnimTh = new Thickness(-w - m, m, w + 2 * m, m);
                    }
                }
                // иначе - если картинка движется вверх или вниз
                else
                {
                    double h = curMoovingImg.Rectangle.ActualHeight;
                    // если картинка движется вниз
                    if (newPos.row > ZPos.row)
                    {
                        AnimTh = new Thickness(m, h + 2 * m, m, -h - m);
                    }
                    // иначе - если картинка движется вниз
                    else
                    {
                        AnimTh = new Thickness(m, -h - m, m, h + 2 * m);
                    }

                }
                // начать анимацию
                AnimateImageMove(curMoovingImg.Rectangle, AnimTh);

                // поменть значение в матрице
                swap(ref matrix[ZPos.row, ZPos.col], ref matrix[newPos.row, newPos.col]);

                // изменить кол-во ходов
                steps.Content = $"Ходов: {++st}";

                // если всё собрано
                if (IsWin())
                {
                    // определить конечное время
                    end = DateTime.Now;
                    //остановить таймер
                    timer.Stop();
                    // обработка завершённого уровня
                    LevelCompleted();
                }
            }
        }

        /// <summary>
        /// Анимировать движение цифры
        /// </summary>
        /// <param name="rect">Цифра</param>
        /// <param name="th">Новое, временное значение margin для перемещения от текущего</param>
        private void AnimateImageMove(Rectangle rect, Thickness th)
        {
            // анмация перемещения цифры
            ThicknessAnimation ta = new ThicknessAnimation(th, TimeSpan.FromMilliseconds(100));
            ta.AutoReverse = false;
            // после завершения анимации запустить метод Ta_Completed
            ta.Completed += Ta_Completed;

            // начать анимацию перемещения цифры
            rect.BeginAnimation(Image.MarginProperty, ta);
        }

        /// <summary>
        /// после завершения анимации перемещения цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ta_Completed(object sender, EventArgs e)
        {
            // установить новые позиции для цифры
            Grid.SetColumn(curMoovingImg.Rectangle, curMoovingImg.NewPos.col);
            Grid.SetRow(curMoovingImg.Rectangle, curMoovingImg.NewPos.row);

            // убрать параметры из анимации по Button.MarginProperty
            curMoovingImg.Rectangle.BeginAnimation(Button.MarginProperty, null);

            // присвоить стандартное значение margin
            curMoovingImg.Rectangle.Margin = curMoovingImg.AutoThickness;
            // записать, что текущих движущхся цифр нет
            curMoovingImg = null;
        }

        /// <summary>
        /// обработчик завершённого уровня
        /// </summary>
        private void LevelCompleted()
        {
            // сообщение уровня
            LevelMes levelMes = LevelMes.NONE;

            // получить время прохождения уровня
            TimeSpan t = end - start;
            time.Content = t.ToString(@"hh\:mm\:ss");

            // если уровень был ранее собран
            if (currentLVL.IsSolved)
            {
                // переписать результат, если он лучше старого
                // и если найден более лучший результат, сообщение уровня = новый рекорд
                if (currentLVL.Time > t) { currentLVL.Time = t; levelMes = LevelMes.NewRecord; }
                if (currentLVL.Steps > st) { currentLVL.Steps = st; levelMes = LevelMes.NewRecord; }
            }
            // если уровень пройден впервые
            else
            {
                // записать результаты
                currentLVL.Time = t;
                currentLVL.Steps = st;
                currentLVL.IsSolved = true;

                // разблокировать следующий уровень
                UnlockNextLVL();
                // сообщение уровня = открыт новый уровень
                levelMes = LevelMes.NewLevel;
            }

            // окно-сообщение о прохождение уровне | возвращает:
            // true - перейти к следующему уровню, false - выход в главное меню
            LVLCompl compl = new LVLCompl(t, st, levelMes);
            compl.Tag = butClick;
            var res = compl.ShowDialog();

            // сброс данных
            time.Content = "00:00:00";
            steps.Content = "Ходов: 0";
            st = 0;

            // переход к следующему уровню
            if (res == true)
            {
                int numLVL = 0; // номер следующего уровня
                for (int i = 0; i < levels.Count; i++)
                {
                    // если найден текущий уровень (который только что прошёлся)
                    if (levels.Items[i] == currentLVL)
                    {
                        // если он был последним
                        if (i + 1 == levels.Count)
                        {
                            // включить главное меню
                            menuGrid.Visibility = Visibility.Visible;
                            // выключить игровую доску
                            playGrid.Visibility = Visibility.Hidden;
                            // обнулить текущий уровень
                            currentLVL = null;

                            // выйти из метода
                            return;
                        }
                        // иначе
                        numLVL = i + 2; // номер следующего уровня
                        currentLVL = levels.Items[i + 1]; // выбрать следующий уровень
                        break; // выход из цикла
                    }
                }

                // обновить в statusBar новый текущий уровень
                curLVL.Content = "Уровень: " + numLVL;
                // выбрать новую схему нового уровня
                matrix = currentLVL.Matrix.Clone() as int[,];
                // отобразить её пользователю
                GenerateNewLVL();
            }
            // выход в меню
            else
            {
                // включить главное меню
                menuGrid.Visibility = Visibility.Visible;
                // выключить игровую доску
                playGrid.Visibility = Visibility.Hidden;
                // обнулить текущий уровень
                currentLVL = null;

                // выйти из метода
                return;
            }
        }

        /// <summary>
        /// Разблокировать следующий уровень
        /// </summary>
        private void UnlockNextLVL()
        {
            foreach (Button button in SCRlvlPanel.Children)
            {
                // если найден первый заблокированный уровень
                if (!button.IsEnabled)
                {
                    // разблокировать
                    button.IsEnabled = true;
                    // присвоить кнопке шаблон открытого уровня
                    button.Template = (ControlTemplate)FindResource("ImgTemplOpenLVL");
                    //выход из метода
                    return;
                }
            }
        }

        /// <summary>
        /// Подробная информаци о уровнях
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LVLsInfo_Click(object sender, RoutedEventArgs e)
        {
            // проиграть звук нажатия по кнопке
            butClick.Play();

            // создание диалогового окна
            LVL_Info info = new LVL_Info(new LVLInf_TagData(levels, butClick));

            // запуск окна
            info.ShowDialog();
        }

        /// <summary>
        /// нажатие на кнопку PLAY в главном меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            // проиграть звук нажатия по кнопке
            butClick.Play();
            // включить меню выбора уровня
            levelGrid.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// отмена выбора уровня, нажатие на levelGrid, а не на уровень
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void levelGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // выключить меню выбора уровня
            levelGrid.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// изменение размера окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // изменение размера кнопки PLAY в главном меню
            double w = ActualWidth / 10, h = ActualHeight / 10;
            double tmp = Math.Min(w, h);
            playButton.Height = tmp * 3;
            playButton.Width = tmp * 7;


            // изменение размера окна меню выбора уровня
            w = ActualWidth / 5;
            h = ActualHeight / 5;
            LVLsMenuGrid.Margin = new Thickness(w, h, w, h);


            // изменение размера игровой доски 
            tmp = Math.Min(ActualHeight - 100, ActualWidth);
            playBoard.Height = tmp;
            playBoard.Width = tmp;
            board.Orientation = tmp == ActualWidth ? Orientation.Horizontal : Orientation.Vertical;
        }

        /// <summary>
        /// выход из уровня
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitFromLVL_Click(object sender, RoutedEventArgs e)
        {
            // проиграть звук нажатия по кнопке
            butClick.Play();

            // остановка таймера
            timer.Stop();
            // обнуление текущего уровня
            currentLVL = null;
            // включение главного меню
            menuGrid.Visibility = Visibility.Visible;
            // выключение игровой доски
            playGrid.Visibility = Visibility.Hidden;
            // обнуление данных о прохождение
            time.Content = "00:00:00";
            steps.Content = "Ходов: 0";
            st = 0;
        }

        /// <summary>
        /// начать уровень сначала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            // проиграть звук нажатия по кнопке
            butClick.Play();

            // остановить таймер
            timer.Stop();
            // получить схему текущего уровня
            matrix = currentLVL.Matrix.Clone() as int[,];
            // отобразить уровень пользователю
            GenerateNewLVL();
            // сброс данных
            time.Content = "00:00:00";
            steps.Content = "Ходов: 0";
            st = 0;
        }

        /// <summary>
        /// закрытие окна - сохранить данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // открыть конфиг-файл
                FileStream fs = new FileStream(Environment.CurrentDirectory + @"\Resources\config.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                foreach (LVL lvl in levels.Items)
                {
                    // строка данных одного уровня
                    string str = string.Empty;

                    // записать схему уровня
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            str += $"{lvl.Matrix[i, j]} ";

                    // записать остальные данные если уровень пройден
                    if (lvl.IsSolved) str += $"|{lvl.IsSolved}|{lvl.Time.ToString(@"hh\:mm\:ss")}|{lvl.Steps}";

                    // записать в файл
                    sw.WriteLine(str);
                }

                // закрыть поток конфиг-файла
                sw.Close();
                fs.Close();
            }
            catch { }
        }

        /// <summary>
        /// закрыть программу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // проиграть звук нажатия по кнопке
            butClick.Play();
            // закрыть
            Close();
        }

        /// <summary>
        /// Включить выключить фоновую музыку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopMusik(object sender, RoutedEventArgs e)
        {
            // если музыка выключена
            if (!IsBGMusikEnable.IsChecked) backgroundMusik.Play();
            // иначе - если музыка включена
            else backgroundMusik.Stop();

            // отобразить пользователю новое значение
            IsBGMusikEnable.IsChecked = !IsBGMusikEnable.IsChecked;
        }
    }

    #endregion

}



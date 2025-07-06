using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{

    /// <summary>
    /// класс, хранящий список уровней
    /// </summary>
    public class LVLs
    {
        /// <summary>
        /// список уровней
        /// </summary>
        public List<LVL> Items { get; set; }

        /// <summary>
        /// кол-во уровней
        /// </summary>
        public int Count { get => Items.Count; }


        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public LVLs()
        {
            Items = new List<LVL>();
        }

        /// <summary>
        /// поиск и возврат уровня по номеру
        /// </summary>
        /// <param name="num">НОМЕР уровня</param>
        /// <returns>Уровень, если такого нет - null</returns>
        public LVL GetLVL(int num)
        {
            // если такого уровня нет
            if (num < 1 || num > Items.Count) return null;

            return Items[num - 1];
        }
    }

    /// <summary>
    /// класс, хранящий информацию о уровне
    /// </summary>
    public class LVL
    {
        /// <summary>
        /// схема уровня
        /// </summary>
        public int[,] Matrix { get; set; }
        /// <summary>
        /// пройден ли уровень
        /// </summary>
        public bool IsSolved { get; set; }
        /// <summary>
        /// время прохождения уровня
        /// </summary>
        public TimeSpan Time { get; set; }
        /// <summary>
        /// кол-во шагов при прохождении
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// конструктор со схемой уровня
        /// </summary>
        /// <param name="matrix">схема уровня</param>
        public LVL(int[,] matrix)
        {
            Matrix = matrix;
            Time = new TimeSpan();
            IsSolved = false;
            Steps = 0;
        }
    }
}

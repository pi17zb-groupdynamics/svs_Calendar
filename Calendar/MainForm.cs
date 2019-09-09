using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar {
    public partial class MainForm : Form {

        /// <summary>
        /// Список событий
        /// </summary>
        List<Event> _events = new List<Event>();

        /// <summary>
        /// Текущая выбранная дата в календаре
        /// </summary>
        DateTime CurentDate { get => calendar.SelectionStart; }

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm() {
            InitializeComponent();

            BuildEvents();
            bindingSource.DataSource = SelectDayEvents();

        }// Конструктор

        /// <summary>
        /// Возвращает список с текущими событиями (день который выбран в календаре)
        /// </summary>
        /// <returns></returns>
        private List<Event> SelectDayEvents() {

            // Начало дня
            DateTime startDay = new DateTime(CurentDate.Year, CurentDate.Month, CurentDate.Day, 0, 0, 0);
            // Конец дня
            DateTime endDay = new DateTime(CurentDate.Year, CurentDate.Month, CurentDate.Day, 23, 59, 59);

            // Выборка событий
            return _events.Where(it => it.DateTimeEvent >= startDay && it.DateTimeEvent <= endDay).OrderBy(it => it.DateTimeEvent).ToList();

        }// SelectDayEvents


        /// <summary>
        /// Генератор списка заметок (для тестирования)
        /// </summary>
        private void BuildEvents() {

            // Добавляем заметки в список
            _events.Add(new Event {
                Text = "Заметка 1"
            });

            _events.Add(new Event {
                DateTimeEvent = DateTime.Now.AddMinutes(1),
                Text = "Заметка 2"
            });

            _events.Add(new Event {
                DateTimeEvent = DateTime.Now.AddMinutes(2),
                Text = "Заметка 3"
            });

            _events.Add(new Event {
                DateTimeEvent = DateTime.Now.AddDays(-1),
                Text = "Заметка на вчера",
                IsReaded = true
            });

            _events.Add(new Event {
                DateTimeEvent = DateTime.Now.AddDays(1),
                Text = "Заметка на завтра"
            });

        }// BuildEvents



        // СОБЫТИЯ /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Событие при изменении даты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendar_DateChanged(object sender, DateRangeEventArgs e) {
            bindingSource.DataSource = SelectDayEvents();
        }// Calendar_DateChanged



    }// class MainForm
}

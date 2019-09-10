using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            // Обновляем данные
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
            _events.Add(new Event(DateTime.Now.AddSeconds(10)) {
                Text = "Заметка 1"
            });

            _events.Add(new Event(DateTime.Now.AddMinutes(1)) {
                Text = "Заметка 2"
            });

            _events.Add(new Event(DateTime.Now.AddMinutes(2)) {
                Text = "Заметка 3"
            });

            _events.Add(new Event(DateTime.Now.AddDays(-1)) {
                Text = "Заметка на вчера",
                IsReaded = true
            });

            _events.Add(new Event(DateTime.Now.AddDays(1)) {
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

        /// <summary>
        /// При добавлении Заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e) {

            // Создаем новый объект
            Event ev = new Event(calendar.SelectionStart);

            // Вызываем форму редактирования этого объекта
            DialogResult res = new EventForm(ev).ShowDialog();

            // Если вернули ОК, то добавляем объект в коллекцию
            if (res == DialogResult.OK) {
                _events.Add(ev);
                bindingSource.DataSource = SelectDayEvents();
            }// if

        }// AddBtn_Click

        /// <summary>
        /// При удалении заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e) {

            // Проверяем выделена ли строка
            if (dgvEvents.SelectedRows.Count != 1)
                return;

            // Получаем текущий объект
            Event selEvent = dgvEvents.SelectedRows?[0].DataBoundItem as Event;

            // Запрос подтверждение удаления заметки
            var result = MessageBox.Show("Подтвердите удаление", "Удаление заметки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Если выбрали да удаляем заметку
            if (result == DialogResult.Yes) {
                _events.Remove(selEvent);
                // Обновляем данные
                bindingSource.DataSource = SelectDayEvents();
            }// if

        }// DeleteBtn_Click

        /// <summary>
        /// При двойном щелчке мыши на запись вызываем форму редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            
            // Проверяем выделена ли строка
            if (dgvEvents.SelectedRows.Count != 1)
                return;

            // Получаем текущий объект
            Event selEvent = dgvEvents.SelectedRows?[0].DataBoundItem as Event;

            // Вызываем форму редактирования этого объекта
            DialogResult res = new EventForm(selEvent).ShowDialog();

            // Если подтвердили изменение обновляем данные формы, т.к. могли изменить дату события
            if(res == DialogResult.OK)
                bindingSource.DataSource = SelectDayEvents();

        }// DgvEvents_CellDoubleClick

        /// <summary>
        /// Проверяет существуют ли оповещения и уведомляет пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerEvents_Tick(object sender, EventArgs e) {
            DateTime dateTimeNow = DateTime.Now;
            var res = _events.Where(it => it.Notify && !it.IsReaded);

            DateTime min = res.Max(it => it.NotifyTime);
            Event minEvent = res.Where(it => it.NotifyTime == min).First();
            
            foreach (var it in res.Where(it => it.NotifyTime <= dateTimeNow)) {
                it.IsReaded = true;
                MessageBox.Show(it.Text, "Уведомление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Обновляем данные
                bindingSource.DataSource = SelectDayEvents();

            }// foreach

        }// TimerEvents_Tick


    }// class MainForm
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Calendar {
    public partial class MainForm : Form {

        /// <summary>
        /// Настройки приложения
        /// </summary>
        private Settings _s = new Settings();

        /// <summary>
        /// Список событий
        /// </summary>
        private List<Event> _events = new List<Event>();

        /// <summary>
        /// Имя файла для записи
        /// </summary>
        private string _path = @"data.xml";

        /// <summary>
        /// Текущая выбранная дата в календаре
        /// </summary>
        private DateTime CurentDate { get => calendar.SelectionStart; }


        // МЕТОДЫ /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm() {
            InitializeComponent();

            // Если есть файл то загружаем данные из него
            if (File.Exists(_path) && File.Exists(_s.Path))
                Deserialize();
            else
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

        /// <summary>
        /// Сериализует коллекцию в файл
        /// </summary>
        private void Serialize() {
            
            // Открываем файловый поток для записи настроек
            using (FileStream fs = File.Create(_s.Path)) {
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                xs.Serialize(fs, _s);
            }// using

            // Открываем файловый поток для записи данных
            using (FileStream fs = File.Create(_path)) {
                XmlSerializer xs = new XmlSerializer(typeof(List<Event>));
                xs.Serialize(fs, _events);
            }// using
                
        }// Serialize

        /// <summary>
        /// Десериализуем коллекцию из файла
        /// </summary>
        private void Deserialize() {

            // Загружаем настройи из файла
            using (FileStream fs = File.OpenRead(_s.Path)) {
                // Десериализуем настройки приложения
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                _s = (Settings)xs.Deserialize(fs);
            }// using

            // Загружаем данные из файла
            using (FileStream fs = File.OpenRead(_path)) {
                XmlSerializer xs = new XmlSerializer(typeof(List<Event>));
                _events = (List<Event>)xs.Deserialize(fs);
            }// using

        }// Deserialize

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

                try {
                    // Отпрвляем сообщения на все адреса
                    foreach (var addr in _s.GetMails())
                        it.SendToMail(addr);
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }// try catch

                // отмечаем как прочитано
                it.IsReaded = true;

                // выводим ообщение пользователю
                MessageBox.Show(it.Text, "Уведомление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Обновляем данные
                bindingSource.DataSource = SelectDayEvents();

            }// foreach

        }// TimerEvents_Tick

        /// <summary>
        /// Перед закрытием формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Записываем данные в файл перед закрытием
            Serialize();
        }// MainForm_FormClosing

        /// <summary>
        /// При нажатии кнопки Настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsBtn_Click(object sender, EventArgs e) {
            new SettingsForm(_s).ShowDialog();
        }// SettingsBtn_Click

        /// <summary>
        /// При нажатии кнопки Информация о приложении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoBtn_Click(object sender, EventArgs e) {
            new InfoForm().ShowDialog();
        }// InfoBtn_Click
    }// class MainForm
}

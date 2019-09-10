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
    public partial class EventForm : Form {

        /// <summary>
        /// Копия объекта для редактирования
        /// </summary>
        Event _event;

        /// <summary>
        /// Настоящий объект, не изменяется пока не нажата кнопка ОК
        /// </summary>
        Event _oldEvent;

        // МЕТОДЫ //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="e"></param>
        public EventForm(Event e) {

            InitializeComponent();


            // Записываем текущий объект
            _oldEvent = e;

            // Клонируем объект и все изменения производим в копии а не в оригинале
            _event = e.Clone() as Event;

            LoadFromObject();



        }// EventForm

        /// <summary>
        /// Загружает все данные из объекта
        /// </summary>
        private void LoadFromObject() {

            timeToEvent.Items.AddRange(Event.NotifyTimeList.Select(it => it.Key).ToArray());
            timeToEvent.Text = _event.NotifyTime;
            
            notify.Checked = _event.Notify;
            dateTimeEvent.Value = _event.DateTimeEvent;
            text.Text = _event.Text;
        }// LoadFromObject

        // СОБЫТИЯ //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// При нажатии кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e) {

            // Записываем изменения в объект
            _oldEvent.CloneFrom(_event);

            // При изменнии отменчаем то собтие не прочитано
            _oldEvent.IsReaded = false;

        }// BtnOk_Click

        /// <summary>
        /// При изменении текста заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Text_TextChanged(object sender, EventArgs e) {
            _event.Text = text.Text;
        }// Text_TextChanged

        /// <summary>
        /// При изменении чек бокса "Увеомлять о событии"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_CheckedChanged(object sender, EventArgs e) {
            _event.Notify = notify.Checked;
        }// Notify_CheckedChanged

        /// <summary>
        /// При изменении даты времени заметки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimeEvent_ValueChanged(object sender, EventArgs e) {
            _event.DateTimeEvent = dateTimeEvent.Value;
        }// DateTimeEvent_ValueChanged

        /// <summary>
        /// При изенении оповестить за ... мин. до
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeToEvent_SelectedIndexChanged(object sender, EventArgs e) {
            _event.NotifyTime = timeToEvent.Text;
        }// TimeToEvent_SelectedIndexChanged


    }// class EventForm
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar {

    /// <summary>
    /// Информация о заметке
    /// </summary>
    public class Event : ICloneable {

        // ПОЛЯ //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Дата и время заметки
        /// </summary>
        public DateTime DateTimeEvent { get; set; }

        /// <summary>
        /// Текст заметки
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// Уведомлять пользователя
        /// </summary>
        public bool Notify { get; set; } = true;

        /// <summary>
        /// Определяет прочитано ли уведомление
        /// </summary>
        public bool IsReaded { get; set; } = false;

        /// <summary>
        /// Список доступных значений уведомления за ... мин
        /// </summary>
        public static List<string> NotifyTimeList { get; set; }
            = new List<string>() {
                "одновременно",
                "за 5 мин.",
                "за 10 мин.",
                "за 15 мин.",
                "за 1 час",
                "за 1 день"
            };

        private int _notifyTime { get; set; } = 0;


        // МЕТОДЫ //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="d"></param>
        public Event(DateTime d) {
            DateTimeEvent = d;
        }// Конструктор


        /// <summary>
        /// Возвращает новый объект созданный на основе текущего
        /// </summary>
        /// <returns></returns>
        public object Clone() {
            return new Event(new DateTime(DateTimeEvent.Ticks)) {
                Text = Text,
                Notify = Notify,
                IsReaded = IsReaded
            };
        }// Clone

        /// <summary>
        /// Копирует данные из другого объекта
        /// </summary>
        public void CloneFrom(Event ev) {
            DateTimeEvent = ev.DateTimeEvent;
            Text = ev.Text;
            Notify = ev.Notify;
            IsReaded = ev.IsReaded;
        }// CloneFrom

        /// <summary>
        /// Возврат строки с временем и текстом заметки
        /// </summary>
        public override string ToString() {
            return $"{DateTimeEvent.ToShortTimeString()} - {Text}";
        }// ToString

    }// class Event
}

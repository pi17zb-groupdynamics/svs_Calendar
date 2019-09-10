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
        public static Dictionary<string, int> NotifyTimeList { get; set; }
            = new Dictionary<string, int>() {
                { "одновременно", 0 },
                { "за 5 мин.", 5 },
                { "за 10 мин.", 10 },
                { "за 15 мин.", 15 },
                { "за 1 час", 60 },
                { "за 1 день", 1440 }
            };

        /// <summary>
        /// Значение в минутах за сколько времени оповещать пользователя
        /// </summary>
        private int _notifyTime = 0;

        /// <summary>
        /// Уведомлять за ... (5, 10 мин) до
        /// </summary>
        public string NotifyTime {
            get => NotifyTimeList.Where(it => it.Value == _notifyTime).First().Key;
            set {
                // Проверка и присваивание значеня свойству
                if (!NotifyTimeList.TryGetValue(value, out _notifyTime))
                    throw new Exception($"Присваивается недопустимая величина {value}");
            }// set
        }// NotifyTime


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

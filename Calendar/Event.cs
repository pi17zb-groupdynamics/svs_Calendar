using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar {

    /// <summary>
    /// Информация о заметке
    /// </summary>
    public class Event {

        /// <summary>
        /// Дата и время заметки
        /// </summary>
        public DateTime DateTimeEvent { get; set; } = DateTime.Now;

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
        /// Возврат строки с временем и текстом заметки
        /// </summary>
        public override string ToString() {
            return $"{DateTimeEvent.ToShortTimeString()} - {Text}";
        }// ToString

    }// class Event
}

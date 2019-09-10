using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar {

    /// <summary>
    /// Класс для хранения настроек приложения
    /// </summary>
    public class Settings {

        /// <summary>
        /// Имя файла настроек
        /// </summary>
        public string Path { get; set; } = "settings.xml";

        /// <summary>
        /// Строка с адресами email
        /// </summary>
        public string MailAddress { get; set; }

        /// <summary>
        /// Возвращает массив адресов для уведомления
        /// </summary>
        /// <returns></returns>
        public string[] GetMails() {
            return MailAddress
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(it => it.Trim())
                .ToArray();
        }// GetMails


    }// class Settings
}

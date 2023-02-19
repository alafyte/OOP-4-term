using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    /*3. Создайте свой атрибут валидации (см. таблицу с вариантами).*/
    public class TermAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is uint term)
            {
                if (term > 0 && term < 9)
                    return true;
                else
                    ErrorMessage = "Некорректное значение семестра";
            }
            return false;
        }
    }
}

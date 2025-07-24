using System.Text;

namespace Leetcode.Easy;

public class DeleteCharactersToMakeFancyString
{
    /// <summary>
    /// 1957. Delete Characters to Make Fancy String
    /// </summary>
    /*
     * Есть строка, сделать так, чтобы не было подстрок с одинаковыми символами
     * длиннее, чем 2 подряд
     * Решение:
     * Идемс по строке и считаем, сколько раз предыдущий символ равен текущему
     * Если не равен - сбрасываем счетчик до 1 - у нас уникальная подстрока
     * Иначе не добавляем ее в конечную
     */
    public string MakeFancyString(string s)
    {
        var count = 1;
        var sb = new StringBuilder(s.Length);
        sb.Append(s[0]);
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
                count++;
            else
                count = 1;
            if (count < 3)
                sb.Append(s[i]);
        }

        return sb.ToString();
    }
}
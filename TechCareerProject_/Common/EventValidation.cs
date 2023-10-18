using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechCareerProject_.Common
{
    public static class EventValidation
    {
        public static void CheckIdKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Sayı dışındaki karakterleri engelle 
            }
        }

        public static void CheckFirstNameAndLastNameKeyPress(KeyPressEventArgs e)
        {
            CheckSpaceCharacter(e);
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Harf dışındaki karakterleri engelle
            }
        }

        public static void CheckPriceKeyPress(KeyPressEventArgs e,TextBox txt)
        {
            // Yalnızca sayılar, ondalık nokta ve geri tuşa izin verilir
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                e.Handled = true; // Sayı veya ondalık nokta dışındaki karakterleri engelle
            }

            // Birden fazla ondalık nokta girişini engelle
            if (e.KeyChar == ',' && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        public static void CheckTCKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Sayı dışındaki karakterleri engelle
            }
        }

        public static void CheckTCTextChange(EventArgs e ,TextBox txt)
        {
            string text = txt.Text;

            // TC kimlik numarası 11 haneli olmalı
            if (text.Length > 11)
            {
                txt.Text = text.Substring(0, 11); // 11 hane sınırlaması
                txt.SelectionStart = 11; // Cursor'ı metnin sonuna taşı
            }
        }

        public static void CheckSpaceCharacter(KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Boşluk karakterini engelle
            }
        }
    }
}

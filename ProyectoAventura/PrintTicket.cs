using System;

namespace PrintTicket
{
    internal class PrintTicket
    {

        public static string Today()
        {
            DateTime today = DateTime.Now;
            string formatted_date = (today.ToString("dd-MM-yyyy").Replace('-', '/'));
            return formatted_date;
        }

        public static void Ticket(int entrada, double precio_entrada)
        {
            string tipo_entrada;

            if (entrada == 1)
            {
                tipo_entrada = "Entrada Individual";
            }
            else if (entrada == 2)
            {
                tipo_entrada = "Entrada con Pasaporte";
            }
            else
            {
                tipo_entrada = "Entrada";
            }

            string nombre = "CIRCUITO AVENTURA";
            string direccion = "Filo Serrano, D5881 Merlo, San Luis";
            string telefono = "+54 266 488-3207";
            string linea = "***********************************************";

            TextFormat.TextFormat.Format($"{nombre}\n{linea}\n\nDirección: {direccion}\nTelefono: {telefono}\n\n{linea}\n\nRECIBO DE COMPRA\n\n{linea}\n\nDescripción:               {tipo_entrada}\nFecha:                                {PrintTicket.Today()}\n\n{linea}\nTOTAL ${precio_entrada:F2}\n{linea}\nMUCHAS GRACIAS!", ConsoleColor.Gray, ConsoleColor.Black, "center", "center");
        }
            
    }
}

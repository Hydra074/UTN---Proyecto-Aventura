using PlaySound;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Circuito Aventura";
        double precio_entrada = 1500;

        double precio_ticket;
        double resumen_total_individuales = 0;
        double resumen_total_pasaportes = 0;
        double resumen_total_personas = 0;
        double resumen_total_recaudado = 0;
        double resumen_recaudacion_individuales = 0;
        double resumen_recaudacion_pasaportes = 0;
        double resumen_total_personas_pasaportes = 0;
        double resumen_total_personas_10y15 = 0;
        double resumen_promedio;
        double resumen_acumulador_edades = 0;

        do
        {
            Console.CursorVisible = false;
            PrintMenu.MainMenu();
            bool terminar_proceso = false;
            double cantidad_integrantes = 0;
            double contador_integrantes = 0;

            char tecla_presionada = Console.ReadKey(true).KeyChar;
            switch (tecla_presionada)
            {
                // Entrada individual
                case '1':
                    PrintMenu.IndividualEntry();

                    do
                    {
                        TextFormat.TextFormat.Format("\n\n\nEdad: ", ConsoleColor.White, ConsoleColor.Black, "left", "top");
                        double edad;
                        if (double.TryParse(Console.ReadLine(), out edad))
                        {
                            if (edad != 0)
                            {
                                if (edad > 180)
                                {
                                    Console.CursorVisible = false;
                                    Console.Clear();
                                    TextFormat.TextFormat.Format("El dato proporcionado es inválido. Por favor, inténtelo nuevamente.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                    Console.ResetColor();
                                    PlaySound.PlaySound.ErrorSound();
                                    TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    PrintMenu.IndividualEntry();
                                }
                                else if (edad >= 16)
                                {
                                    precio_ticket = precio_entrada;
                                    Console.Clear();
                                    PrintTicket.PrintTicket.Ticket(1, precio_ticket);
                                    PlaySound.PlaySound.SuccessfulSound();
                                    TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");

                                    resumen_total_recaudado += 1500;
                                    resumen_recaudacion_individuales += 1500;
                                    resumen_total_individuales += 1;
                                    resumen_acumulador_edades += edad;
                                    resumen_total_personas += 1;

                                    Console.ReadKey(true);
                                    terminar_proceso = true;
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    Console.Clear();
                                    TextFormat.TextFormat.Format("No puede pasar, es menor de 16 años.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                    Console.ResetColor();
                                    PlaySound.PlaySound.ErrorSound();
                                    TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    PrintMenu.IndividualEntry();
                                }
                            }
                            else
                            {
                                terminar_proceso = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dato inválido, intente nuevamente.");
                        }
                    } while (terminar_proceso == false);
                    break;

                // Entrada grupal
                case '2':
                    do
                    {
                        PrintMenu.PassportEntry();
                        TextFormat.TextFormat.Format("\n\nIntegrantes en el grupo (4-10): ", ConsoleColor.White, ConsoleColor.Black, "left", "top");
                        
                        if (double.TryParse(Console.ReadLine(), out cantidad_integrantes))
                        {
                            if (cantidad_integrantes == 0)
                            {
                                terminar_proceso = true;
                            }

                            else
                            {
                                if (cantidad_integrantes < 4 || cantidad_integrantes > 10)
                                {
                                    Console.CursorVisible = false;
                                    Console.Clear();
                                    TextFormat.TextFormat.Format("La cantidad de integrantes ingresada es inválida. Debe estar en un rango de 4 a 10.\nPor favor, inténtelo nuevamente.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                    PlaySound.PlaySound.ErrorSound();
                                    TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }

                                else
                                {
                                    double contador_personas = 0;
                                    double contador_menores = 0;
                                    double contador_mayores = 0;
                                    double contador_edad_0_3 = 0;
                                    double acumulador_edades = 0;
                                    double contador_edad_4_10 = 0;
                                    double contador_edad_11_15 = 0;
                                    double contador_personas_10y15 = 0;
                                    double contador_adultos_responsables = 0;
                                    double precio_pasaporte = 0;
                                    bool finish_process = false;

                                    do
                                    {
                                        finish_process = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format($"\n\n\n\nA continuación ingrese las edades de los {cantidad_integrantes} integrantes del grupo: ", ConsoleColor.White, ConsoleColor.Black, "left", "top");
                                        Console.WriteLine();
                                        TextFormat.TextFormat.Format($"\n\n\n\n\n{contador_integrantes + 1}° Edad: ", ConsoleColor.White, ConsoleColor.Black, "left", "top");
                                        if (double.TryParse(Console.ReadLine(), out double edad))
                                        {
                                            contador_integrantes++;
                                            if (edad != 0)
                                            {
                                                if (edad >= 10 && edad <= 15)
                                                {
                                                    contador_personas_10y15++;
                                                }

                                                if (edad >= 21)
                                                {
                                                    contador_adultos_responsables++;
                                                }

                                                if (edad > 0 && edad <= 3)
                                                {
                                                    contador_personas++;
                                                    contador_edad_0_3++;
                                                    acumulador_edades += edad;
                                                    contador_menores++;
                                                }
                                                else if (edad >= 4 && edad <= 10)
                                                {
                                                    contador_personas++;
                                                    contador_edad_4_10++;
                                                    acumulador_edades += edad;
                                                    contador_menores++;
                                                }
                                                else if (edad >= 11 && edad <= 15)
                                                {
                                                    contador_personas++;
                                                    contador_edad_11_15++;
                                                    acumulador_edades += edad;
                                                    contador_menores++;
                                                }
                                                else if (edad > 15 && edad <= 180)
                                                {
                                                    contador_personas++;
                                                    acumulador_edades += edad;
                                                    contador_mayores++;
                                                }

                                                else
                                                {
                                                    Console.CursorVisible = false;
                                                    Console.Clear();
                                                    contador_integrantes = 0;

                                                    TextFormat.TextFormat.Format("La edad proporcionada es inválida. Por favor, inténtelo nuevamente.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                                    PlaySound.PlaySound.ErrorSound();
                                                    TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                                    Console.ReadKey(true);
                                                    Console.Clear();
                                                    contador_integrantes = 0;
                                                    finish_process = true;
                                                }
                                            }

                                            else
                                            {
                                                Console.CursorVisible = false;
                                                Console.Clear();
                                                contador_integrantes = 0;
                                                TextFormat.TextFormat.Format("La edad proporcionada es inválida. Por favor, inténtelo nuevamente.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                                PlaySound.PlaySound.ErrorSound();
                                                TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                                Console.ReadKey(true);
                                                Console.Clear();
                                                contador_integrantes = 0;
                                                finish_process = true;
                                            }
                                        }

                                        else
                                        {
                                            Console.CursorVisible = false;
                                            Console.Clear();
                                            contador_integrantes = 0;
                                            TextFormat.TextFormat.Format("El dato proporcionado es inválido. Por favor, inténtelo nuevamente.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                            PlaySound.PlaySound.ErrorSound();
                                            TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                            Console.ReadKey(true);
                                            Console.Clear();
                                            contador_integrantes = 0;
                                            finish_process = true;
                                        }
                                    } while (contador_integrantes != cantidad_integrantes || finish_process == true);

                                    precio_pasaporte += (contador_edad_0_3 * (precio_entrada * 0.10));
                                    precio_pasaporte += (contador_edad_4_10 * (precio_entrada * 0.50) * 0.85);
                                    precio_pasaporte += (contador_edad_11_15 * (precio_entrada * 0.80) * 0.85);
                                    precio_pasaporte += ((contador_mayores * precio_entrada) * 0.85);
                                    precio_ticket = precio_pasaporte;

                                    if (contador_adultos_responsables == 0 & contador_menores != 0)
                                    {
                                        terminar_proceso = true;
                                        Console.CursorVisible = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format($"No se puede concretar este pasaporte. No hay mayores de 21 años.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                        PlaySound.PlaySound.ErrorSound();
                                        TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        terminar_proceso = true;
                                    }

                                    else if ((contador_menores > 0 & contador_menores <= 5) & contador_adultos_responsables < 1)
                                    {
                                        terminar_proceso = true;
                                        Console.CursorVisible = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format($"No se puede concretar este pasaporte. No hay suficientes mayores de 21 años.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                        PlaySound.PlaySound.ErrorSound();
                                        TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        terminar_proceso = true;
                                    }

                                    else if ((contador_menores >= 6 & contador_menores <= 10) & contador_adultos_responsables < 2)
                                    {
                                        terminar_proceso = true;
                                        Console.CursorVisible = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format($"No se puede concretar este pasaporte. No hay suficientes mayores de 21 años.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                        PlaySound.PlaySound.ErrorSound();
                                        TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        terminar_proceso = true;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        TextFormat.TextFormat.Format($"¿Desea comprar el pasaporte grupal por ${precio_pasaporte}? (s/n)", ConsoleColor.Yellow, ConsoleColor.Black, "center", "center");

                                        do
                                        {
                                            tecla_presionada = char.ToLower(Console.ReadKey(true).KeyChar);

                                            switch (tecla_presionada)
                                            {
                                                case 's':
                                                    resumen_total_personas += contador_personas;
                                                    resumen_total_personas_10y15 += contador_personas_10y15;
                                                    resumen_recaudacion_pasaportes += precio_pasaporte;
                                                    resumen_total_recaudado += precio_pasaporte;
                                                    resumen_total_personas_pasaportes += contador_personas;
                                                    resumen_total_pasaportes++;
                                                    resumen_acumulador_edades += acumulador_edades;
                                                    contador_integrantes = 0;
                                                    Console.Clear();
                                                    PrintTicket.PrintTicket.Ticket(2, precio_ticket);
                                                    PlaySound.PlaySound.SuccessfulSound();
                                                    TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                                    Console.ReadKey();
                                                    terminar_proceso = true;
                                                    break;

                                                case 'n':
                                                    contador_integrantes = 0;
                                                    terminar_proceso = true;
                                                    break;

                                                default:
                                                    break;
                                            }
                                        } while (terminar_proceso = false);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.CursorVisible = false;
                            Console.Clear();
                            TextFormat.TextFormat.Format("El dato proporcionado es inválido. Por favor, inténtelo nuevamente.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                            Console.ResetColor();
                            PlaySound.PlaySound.ErrorSound();
                            TextFormat.TextFormat.Format("Pulse una tecla para continuar...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                    } while (terminar_proceso == false);
                    break;

                // Cerrar programa
                case '3':
                    
                    if (resumen_total_personas == 0)
                    {
                        resumen_promedio = 0;
                    }
                    else
                    {
                        resumen_promedio = resumen_acumulador_edades / resumen_total_personas;
                    }
                    
                    Console.Clear();
                    TextFormat.TextFormat.Format($"Total de individuales: {resumen_total_individuales} - Total de grupos: {resumen_total_pasaportes} - Personas total: {resumen_total_personas}\nRecaudación: con Pasaportes: ${resumen_recaudacion_pasaportes:F2} | Individuales: ${resumen_recaudacion_individuales:F2} Total: ${resumen_total_recaudado:F2}\nPersonas con pasaporte: {resumen_total_personas_pasaportes} - Personas entre 10 y 15: {resumen_total_personas_10y15}\nEdad promedio: {resumen_promedio:F3}", ConsoleColor.Blue, ConsoleColor.Black, "center", "center");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    TextFormat.TextFormat.Format($"¿Está seguro de que desea cerrar la aplicación? (s/n)", ConsoleColor.Yellow, ConsoleColor.Black, "center", "center");

                    do
                    {
                        tecla_presionada = char.ToLower(Console.ReadKey(true).KeyChar);

                        switch (tecla_presionada)
                        {
                            case 's':
                                    Environment.Exit(0);
                                    break;
                                
                            case 'n':
                                    terminar_proceso = true;
                                    break;

                            default:
                                    break;
                        }
                    } while (terminar_proceso = false);
                    break;
                }
        } while (true);
    }
}
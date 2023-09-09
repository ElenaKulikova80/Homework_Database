using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetKlientKredit();
        }

        const string connectionString = "Host=localhost;port=5432;Username=postgres;Password=12345;Database=sberbank;";

        #region ADONET
        ///<summary>
        ///Подключение к БД и вывод содержимого всех таблиц
        ///</summary>
        static void GetKlientKredit()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = " select dogovor_id, dogovor_data_dogovora, dogovor_tip_dogovora, klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, " +
                          " klient_mesto_rab, klient_plata, kredit_tip, kredit_proc_stavka " +
                          " from public.\"Dogovor\" " +
                          " inner join public.\"Klient\" on public.\"Klient\".klient_id = public.\"Dogovor\".klient_id " +
                          " inner join public.\"Kredit\" on public.\"Kredit\".kredit_id=public.\"Dogovor\".kredit_id";
                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    var reader = cmd.ExecuteReader();
                    int i = 1;

                    while (reader.Read())
                    {
                        int fieldsCount = reader.FieldCount;

                        Console.WriteLine($"Клиент {i}");

                        for (int j = 0; j < fieldsCount; j++)
                        {
                            Console.WriteLine(reader.GetName(j) + ": " + reader.GetValue(j));
                        }

                        Console.WriteLine();
                        i++;
                    }
                    cmd.Dispose();
                    connection.Close();
                }

                connection.Open();
                string response1;

                while (true)
                {
                    Console.WriteLine("Ввести новые значения? Y/N");
                    response1 = Console.ReadLine();
                    if (response1 == "Y" || response1 == "y" || response1 == "N" || response1=="n")
                    {
                        break;
                    }
                }
                    
                if (response1 == "Y" || response1=="y")
                {
                    string response2;

                    while (true)
                    {
                        Console.WriteLine("В какую таблицу добавить новые данные, в таблицу 'Клиент' или в таблицу 'Кредит'? C/K");
                        response2 = Console.ReadLine();
                        if (response2 == "C" || response2 == "c" || response2 == "K" || response2 == "k")
                        {
                            break;
                        }
                    }
                        
                    if (response2=="C" || response2 == "c")
                    {
                        sql = @"
                        INSERT INTO public.""Klient""(klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, klient_mesto_rab, klient_plata) 
                        VALUES (:klient_fio, :klient_nom_pasporta, :klient_adres, :klient_telefon, :klient_mesto_rab, :klient_plata);
                        ";

                        using (var cmd2 = new NpgsqlCommand(sql, connection))
                        {
                            Console.WriteLine("Введите ФИО клиента:");
                            string klient_fio = Console.ReadLine();
                            Console.WriteLine("Введите номер паспорта клиента:");
                            string klient_nom_pasporta = Console.ReadLine();
                            Console.WriteLine("Введите адрес клиента:");
                            string klient_adres = Console.ReadLine();
                            Console.WriteLine("Введите номер телефона клиента:");
                            string klient_telefon = Console.ReadLine();
                            Console.WriteLine("Введите место работы клиента:");
                            string klient_mesto_rab = Console.ReadLine();
                            Console.WriteLine("Введите ежемесячную плату для клиента:");
                            string klient_plata = Console.ReadLine();

                            var parameters = cmd2.Parameters;

                            parameters.Add(new NpgsqlParameter("klient_fio", klient_fio));
                            parameters.Add(new NpgsqlParameter("klient_nom_pasporta", Convert.ToInt32(klient_nom_pasporta)));
                            parameters.Add(new NpgsqlParameter("klient_adres", klient_adres));
                            parameters.Add(new NpgsqlParameter("klient_telefon", klient_telefon));
                            parameters.Add(new NpgsqlParameter("klient_mesto_rab", klient_mesto_rab));
                            parameters.Add(new NpgsqlParameter("klient_plata", Convert.ToInt32(klient_plata)));


                            var affectedRowsCount = cmd2.ExecuteNonQuery().ToString();

                            Console.WriteLine($"Insert into Klient table. Affected rows count: {affectedRowsCount}");
                        }

                            
                    } else if(response2=="K" || response2 == "k")
                    {
                        Console.WriteLine("K");
                    } else
                    {
                        Console.WriteLine("Введите 'D' для таблицы Договор или 'K' для таблицы Кредит");
                    }
                } else if (response1=="N" || response1=="n")
                {
                        
                } 
                    
                //}
            }

        }
        #endregion
    }
}

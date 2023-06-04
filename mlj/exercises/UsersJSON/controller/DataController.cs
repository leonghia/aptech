using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersJSON.util;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace UsersJSON.controller
{
    internal static class DataController
    {

        private static bool CheckExistence<T>(HashSet<T> set, T e) where T : IEquatable<T>
        {
            foreach(var item in set)
            {
                if (item.Equals(e))
                {
                    return true;
                }
            }
            return false;
        }

      

        private static int CheckExistence<T>(Dictionary<T, int> dict, T e) where T : IEquatable<T>
        {
            foreach (var item in dict)
            {
                if (item.Key.Equals(e))
                {
                    return item.Value;
                }
            }
            throw new KeyNotFoundException();
        }


        

        public static void ImportData(UsersData usersData)
        {

            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            HashSet<string> cityNames = new HashSet<string>();
            HashSet<string> cardTypeNames = new HashSet<string>();
            HashSet<string> currencyNames = new HashSet<string>();
            HashSet<UsersData.User.Hair> hairColorsAndTypes = new HashSet<UsersData.User.Hair>();
            HashSet<string> universityNames = new HashSet<string>();
            HashSet<UsersData.User.Company> companies = new HashSet<UsersData.User.Company>();

            Dictionary<string, int> citiesFromDB = new Dictionary<string, int>();
            Dictionary<string, int> cardTypesFromDB = new Dictionary<string, int>();
            Dictionary<string, int> currenciesFromDB = new Dictionary<string, int>();
            Dictionary<string, int> universitiesFromDB = new Dictionary<string, int>();
            Dictionary<UsersData.User.Address, int> addressesFromDB = new Dictionary<UsersData.User.Address, int>();
            Dictionary<UsersData.User.Bank, int> banksFromDB = new Dictionary<UsersData.User.Bank, int>();
            Dictionary<UsersData.User.Company, int> companiesFromDB = new Dictionary<UsersData.User.Company, int>();
            Dictionary<UsersData.User.Hair, int> hairsFromDB = new Dictionary<UsersData.User.Hair, int>();

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                /*
                 * In the first completed loop, we add cities, card_types,
                 * currencies, hairs and universities
                 */
                foreach(var user in usersData.users)
                {
                    if (!cityNames.Contains(user.address.city))
                    {
                        cmd = new MySqlCommand("sp_add_city", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", user.address.city);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cityNames.Add(user.address.city);
                            Console.WriteLine("Add city successfully");
                        }
                        

                    }

                    if (!cityNames.Contains(user.company.address.city))
                    {
                        cmd = new MySqlCommand("sp_add_city", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        

                        cmd.Parameters.AddWithValue("@name", user.company.address.city == null ? "N/A" : user.company.address.city);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cityNames.Add(user.company.address.city);
                            Console.WriteLine("Add city successfully");
                        }
                    }



                    if (!cardTypeNames.Contains(user.bank.cardType))
                    {
                        cmd = new MySqlCommand("sp_add_card_type", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", user.bank.cardType);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cardTypeNames.Add(user.bank.cardType);
                            Console.WriteLine("Add card type successfully");
                        }
                        
                    }

                    if (!currencyNames.Contains(user.bank.currency))
                    {
                        cmd = new MySqlCommand("sp_add_currency", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", user.bank.currency);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            currencyNames.Add(user.bank.currency);
                            Console.WriteLine("Add currency successfully");
                        }
                        
                    }

                    if (!CheckExistence(hairColorsAndTypes, user.hair))
                    {
                        cmd = new MySqlCommand("sp_add_hair", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@color", user.hair.color);
                        cmd.Parameters.AddWithValue("@type", user.hair.type);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            hairColorsAndTypes.Add(user.hair);
                            Console.WriteLine("Add hair successfully");
                        }
                        
                    }

                    if (!universityNames.Contains(user.university))
                    {
                        cmd = new MySqlCommand("sp_add_university", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", user.university);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            universityNames.Add(user.university);
                            Console.WriteLine("Add university successfully");
                        }
                       
                    }

                    
                }

                /*
                 * We retrieve cities, card_types,
                 * currencies, hairs and universities
                 * from database
                 */
                cmd = new MySqlCommand("SELECT id, name FROM cities;", conn);
                cmd.CommandType = CommandType.Text;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        citiesFromDB.Add(name, id);
                    }
                    
                }

                    

                
                



                cmd = new MySqlCommand("SELECT id, name FROM card_types", conn);
                cmd.CommandType = CommandType.Text;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        cardTypesFromDB.Add(name, id);
                    }
                }
                

                

                cmd = new MySqlCommand("SELECT id, name FROM currencies", conn);
                cmd.CommandType = CommandType.Text;
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        currenciesFromDB.Add(name, id);
                    }
                }

                

                cmd = new MySqlCommand("SELECT id, color, type FROM hair", conn);
                cmd.CommandType = CommandType.Text;
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string color = reader.GetString(1);
                        string type = reader.GetString(2);

                        UsersData.User.Hair hair = new UsersData.User.Hair();
                        hair.color = color;
                        hair.type = type;

                        hairsFromDB.Add(hair, id);
                    }
                }

                

                cmd = new MySqlCommand("SELECT id, name FROM universities", conn);
                cmd.CommandType = CommandType.Text;
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        universitiesFromDB.Add(name, id);
                    }
                }

                

                

                /*
                 * In the second completed loop, we add addresses and banks
                 */
                foreach(var user in usersData.users)
                {
                    cmd = new MySqlCommand("sp_add_address", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@address", user.address.address);
                    cmd.Parameters.AddWithValue("@city_id", CheckExistence(citiesFromDB, user.address.city));
                    cmd.Parameters.AddWithValue("@coordinates_lat", user.address.coordinates.lat);
                    cmd.Parameters.AddWithValue("@coordinates_lng", user.address.coordinates.lng);
                    cmd.Parameters.AddWithValue("@postal_code", user.address.postalCode);
                    cmd.Parameters.AddWithValue("@state", user.address.state);

                    if (cmd.ExecuteNonQuery() > 0)
                    {

                        Console.WriteLine("Add address for user successfully");
                    }

                    cmd = new MySqlCommand("sp_add_address", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@address", user.company.address.address);
                    cmd.Parameters.AddWithValue("@city_id", CheckExistence(citiesFromDB, user.company.address.city == null ? "N/A" : user.company.address.city));
                    cmd.Parameters.AddWithValue("@coordinates_lat", user.company.address.coordinates.lat);
                    cmd.Parameters.AddWithValue("@coordinates_lng", user.company.address.coordinates.lng);
                    cmd.Parameters.AddWithValue("@postal_code", user.company.address.postalCode);
                    cmd.Parameters.AddWithValue("@state", user.company.address.state);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add address for company successfully");
                    }


                    cmd = new MySqlCommand("sp_add_bank", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@card_expire", user.bank.cardExpire);
                    cmd.Parameters.AddWithValue("@card_number", user.bank.cardNumber);
                    cmd.Parameters.AddWithValue("@card_type_id", CheckExistence(cardTypesFromDB, user.bank.cardType));
                    cmd.Parameters.AddWithValue("@currency_id", CheckExistence(currenciesFromDB, user.bank.currency));
                    cmd.Parameters.AddWithValue("@iban", user.bank.iban);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add bank successfully");
                    }
                }

                /*
                 * We retrieve addresses from database
                 */
                cmd = new MySqlCommand("SELECT addresses.id, address, cities.name, coordinates_lat, coordinates_lng, postal_code, state FROM addresses JOIN cities ON addresses.city_id = cities.id", conn);
                cmd.CommandType = CommandType.Text;
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string address = reader.GetString(1);
                        string city = reader.GetString(2);
                        decimal coordinates_lat = reader.GetDecimal(3);
                        
                        decimal coordinates_lng = reader.GetDecimal(4);
                        string postal_code = reader.GetString(5);
                        string state = reader.GetString(6);

                        UsersData.User.Address address1 = new UsersData.User.Address();
                        address1.address = address;
                        address1.city = city;                       
                        address1.coordinates.lat = coordinates_lat;
                        address1.coordinates.lng = coordinates_lng;
                        address1.postalCode = postal_code;
                        address1.state = state;

                        addressesFromDB.Add(address1, id);
                        
                    }
                }

                

                /*
                 * In the third completed loop, we add companies
                 */
                foreach(var user in usersData.users)
                {
                    if (!CheckExistence(companies, user.company))
                    {
                        cmd = new MySqlCommand("sp_add_company", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@address_id", CheckExistence(addressesFromDB, user.company.address));
                       
                        cmd.Parameters.AddWithValue("@name", user.company.name);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            companies.Add(user.company);
                            Console.WriteLine("Add company successfully");
                        }
                    }
                }

                /*
                 * We retrieve the banks and companies from database
                 */
                cmd = new MySqlCommand("SELECT banks.id, card_expire, card_number, card_types.name, currencies.name, iban FROM banks JOIN card_types ON banks.card_type_id = card_types.id JOIN currencies ON banks.currency_id = currencies.id", conn);
                cmd.CommandType = CommandType.Text;
               

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string card_expire = reader.GetString(1);
                        string card_number = reader.GetString(2);
                        string card_type = reader.GetString(3);
                        string currency = reader.GetString(4);
                        string iban = reader.GetString(5);


                        UsersData.User.Bank bank = new UsersData.User.Bank();
                        bank.cardExpire = card_expire;
                        bank.cardNumber = card_number;
                        bank.cardType = card_type;
                        bank.currency = currency;
                        bank.iban = iban;

                        banksFromDB.Add(bank, id);
                    }
                }

                

                cmd = new MySqlCommand("SELECT co.id, ad.address, ci.name, ad.coordinates_lat, ad.coordinates_lng, ad.postal_code, ad.state, co.name FROM companies co JOIN addresses ad ON co.address_id = ad.id JOIN cities ci ON ad.city_id = ci.id;", conn);
                cmd.CommandType = CommandType.Text;
              

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string address = reader.GetString(1);
                        string city = reader.GetString(2);
                        decimal coordinates_lat = reader.GetDecimal(3);
                        decimal coordinates_lng = reader.GetDecimal(4);
                        string postal_code = reader.GetString(5);
                        string state = reader.GetString(6);
                        string name = reader.GetString(7);

                        UsersData.User.Company company = new UsersData.User.Company();
                        company.address.address = address;
                        company.address.city = city;
                        company.address.coordinates.lat = coordinates_lat;
                        company.address.coordinates.lng = coordinates_lng;
                        company.address.postalCode = postal_code;
                        company.address.state = state;
                        company.name = name;

                        companiesFromDB.Add(company, id);
                    }
                }

                

                

                /*
                 * In the fourth also final completed loop, we add users
                 */
                foreach(var user in usersData.users)
                {
                    cmd = new MySqlCommand("sp_add_user", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", user.id);
                    cmd.Parameters.AddWithValue("@first_name", user.firstName);
                    cmd.Parameters.AddWithValue("@last_name", user.lastName);
                    cmd.Parameters.AddWithValue("@maiden_name", user.maidenName);
                    cmd.Parameters.AddWithValue("@age", user.age);
                    cmd.Parameters.AddWithValue("@gender", user.gender);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@phone", user.phone);
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@birth_date", user.birthDate);
                    cmd.Parameters.AddWithValue("@image", user.image);
                    cmd.Parameters.AddWithValue("@blood_group", user.bloodGroup);
                    cmd.Parameters.AddWithValue("@height", user.height);
                    cmd.Parameters.AddWithValue("@weight", user.weight);
                    cmd.Parameters.AddWithValue("@eye_color", user.eyeColor);
                    cmd.Parameters.AddWithValue("@hair_id", CheckExistence(hairsFromDB, user.hair));
                    cmd.Parameters.AddWithValue("@domain", user.domain);
                    cmd.Parameters.AddWithValue("@ip", user.ip);
                    cmd.Parameters.AddWithValue("@address_id", CheckExistence(addressesFromDB, user.address));
                    cmd.Parameters.AddWithValue("@mac_address", user.macAddress);
                    cmd.Parameters.AddWithValue("@university_id", CheckExistence(universitiesFromDB, user.university));
                    cmd.Parameters.AddWithValue("@bank_id", CheckExistence(banksFromDB, user.bank));

                    cmd.Parameters.AddWithValue("@company_id", CheckExistence(companiesFromDB, user.company));
                    
                    cmd.Parameters.AddWithValue("@department", user.company.department);
                    cmd.Parameters.AddWithValue("@title", user.company.title);
                    cmd.Parameters.AddWithValue("@ein", user.ein);
                    cmd.Parameters.AddWithValue("@ssn", user.ssn);
                    cmd.Parameters.AddWithValue("@user_agent", user.userAgent);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Add user successfully");
                    }
                }


                Console.WriteLine("IMPORT ALL DATA SUCCESSFULLY");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            
        }

        public static void ClearData()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;

            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();

                cmd = new MySqlCommand("sp_clear_all", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                Console.WriteLine("CLEAR ALL DATA SUCCESSFULLY");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }
}

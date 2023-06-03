using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UsersJSON
{
    internal class UsersData
    {

        public User[] users { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }

        internal class User
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string maidenName { get; set; }
            public int age { get; set; }
            public string gender { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string birthDate { get; set; }
            public string image { get; set; }
            public string bloodGroup { get; set; }
            public decimal height { get; set; }
            public decimal weight { get; set; }
            public string eyeColor { get; set; }
            public Hair hair { get; set; }
            public string domain { get; set; }
            public string ip { get; set; }
            public Address address { get; set; }
            public string macAddress { get; set; }
            public string university { get; set; }
            public Bank bank { get; set; }
            public Company company { get; set; }
            public string ein { get; set; }
            public string ssn { get; set; }
            public string userAgent { get; set; }

            public override string ToString()
            {
                return $"id: {id}\n" +
                    $"firstName: {firstName}\n" +
                    $"lastName: {lastName}\n" +
                    $"maidenName: {maidenName}\n" +
                    $"age: {age}\n" +
                    $"gender: {gender}\n" +
                    $"email: {email}\n" +
                    $"phone: {phone}\n" +
                    $"username: {username}\n" +
                    $"password: {password}\n" +
                    $"birthDate: {birthDate}\n" +
                    $"image: {image}\n" +
                    $"bloodGroup: {bloodGroup}\n" +
                    $"height: {height}\n" +
                    $"weight: {weight}\n" +
                    $"eyeColor: {eyeColor}\n" +
                    $"hair: \n" +
                    $"{hair}\n" +
                    $"domain: {domain}\n" +
                    $"ip: {ip}\n" +
                    $"address: \n" +
                    $"{address.ToString(1)}\n" +
                    $"macAddress: {macAddress}\n" +
                    $"university: {university}\n" +
                    $"bank: \n" +
                    $"{bank}\n" +
                    $"company: \n" +
                    $"{company}\n" +
                    $"ein: {ein}\n" +
                    $"ssn: {ssn}\n" +
                    $"userAgent: {userAgent}\n";
            }

            internal class Hair : IEquatable<Hair>
            {
                public string color { get; set; }
                public string type { get; set; }

                public bool Equals(Hair? other)
                {
                    return this.color.Equals(other.color) && this.type.Equals(other.type);
                }

                public override string ToString()
                {
                    return $"\tcolor: {color}\n" +
                        $"\ttype: {type}\n";
                }


            }

            internal class Address : IEquatable<Address>
            {
                public string address { get; set; }
                public string city { get; set; }
                public Coordinates coordinates { get; set; }
                public string postalCode { get; set; }
                public string state { get; set; }

                public Address()
                {
                    coordinates = new Coordinates();
                }

                public bool Equals(Address? other)
                {
                    return this.coordinates.Equals(other.coordinates) && this.postalCode.Equals(other.postalCode);
                }

                public string ToString(int tabs)
                {
                    if (tabs == 1)
                    {
                        return $"\taddress: {address}\n" +
                        $"\tcity: {city}\n" +
                        $"\tcoordinates: \n" +
                        $"{coordinates.ToString(2)}\n" +
                        $"\tpostalCode: {postalCode}\n" +
                        $"\tstate: {state}\n";
                    }
                    else
                    {
                        return $"\t\taddress: {address}\n" +
                        $"\t\tcity: {city}\n" +
                        $"\t\tcoordinates: \n" +
                        $"{coordinates.ToString(3)}\n" +
                        $"\t\tpostalCode: {postalCode}\n" +
                        $"\t\tstate: {state}\n";
                    }
                    
                }

                internal class Coordinates : IEquatable<Coordinates>
                {
                    public decimal lat { get; set; }
                    public decimal lng { get; set; }

                    public bool Equals(Coordinates? other)
                    {
                        return 1 == 1;
                    }

                    public string ToString(int tabs)
                    {
                        switch (tabs)
                        {
                            case 1:
                                return $"\tlat: {lat}\n" +
                            $"\tlng: {lng}\n";
                            case 2:
                                return $"\t\tlat: {lat}\n" +
                            $"\t\tlng: {lng}\n";
                            case 3:
                                return $"\t\t\tlat: {lat}\n" +
                            $"\t\t\tlng: {lng}\n";
                            default:
                                return $"lat: {lat}\n" +
                            $"lng: {lng}\n";
                        }
                        
                    }
                }
            }

            internal class Bank : IEquatable<Bank>
            {
                public string cardExpire { get; set; }
                public string cardNumber { get; set; }
                public string cardType { get; set; }
                public string currency { get; set; }
                public string iban { get; set; }

                public bool Equals(Bank? other)
                {
                    return this.cardNumber.Equals(other.cardNumber) && this.iban.Equals(other.iban);
                }

                public override string ToString()
                {
                    return $"\tcardExpire: {cardExpire}\n" +
                        $"\tcardNumber: {cardNumber}\n" +
                        $"\tcardType: {cardType}\n" +
                        $"\tcurrency: {currency}\n" +
                        $"\tiban: {iban}\n";
                }
            }

            internal class Company : IEquatable<Company>
            {
                public Address address { get; set; }
                public string department { get; set; }
                public string name { get; set; }
                public string title { get; set; }

                public Company()
                {
                    address = new Address();
                }

                public bool Equals(Company? other)
                {
                    return this.name.Equals(other.name) && this.address.Equals(other.address);
                }

                public override string ToString()
                {
                    return $"\taddress: \n" +
                        $"{address.ToString(2)}\n" +
                        $"\tdepartment: {department}\n" +
                        $"\tname: {name}\n" +
                        $"\ttitle: {title}\n";
                }


            }
        }

        public void Display()
        {
            foreach (User user in users)
            {
                Console.WriteLine(user);
                Console.WriteLine(new String('-', 150));
            }
        }
    }

}

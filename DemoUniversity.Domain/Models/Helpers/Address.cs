using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models.Helpers;

public class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }
        public int ApartmentNumber { get; private set; }

        public Address(string city, string street, int houseNumber, int apartmentNumber)
        {
            if (city == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (street == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (houseNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (apartmentNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (city.CheckStringLength())
            {
                City = city;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }

            if (street.CheckStringLength())
            {
                Street = street;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }

            if (houseNumber.CheckRange(1, 400))
            {
                HouseNumber = houseNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {400}");
            }

            if (apartmentNumber.CheckRange(1, 999))
            {
                ApartmentNumber = apartmentNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {999}");
            }
        }

        /// <summary>
        /// Метод для обновления адреса
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="houseNumber">Номер дома</param>
        /// <param name="apartmentNumber">Номер квартиры</param>
        public void UpdateAddress(string city, string street, int houseNumber, int apartmentNumber)
        {
            if (city == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (street == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (houseNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (apartmentNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (city.CheckStringLength())
            {
                City = city;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }


            if (street.CheckStringLength())
            {
                Street = street;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }


            if (houseNumber.CheckRange(1, 400))
            {
                HouseNumber = houseNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {400}");
            }


            if (apartmentNumber.CheckRange(1, 999))
            {
                ApartmentNumber = apartmentNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {999}");
            }
        }
    }
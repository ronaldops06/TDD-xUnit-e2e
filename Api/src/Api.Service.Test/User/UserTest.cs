using Domain.Dtos.User;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameUpdated { get; set; }
        public static string UserEmailUpdated { get; set; }
        public static Guid UserId { get; set; }

        public List<UserDtoResult> listUserDto = new List<UserDtoResult>();
        public UserDto userDto;
        public UserDtoResult userDtoResult;
        public UserDto userDtoUpdate;
        public UserDtoResult userDtoUpdateResult;

        public UserTest()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdated = Faker.Name.FullName();
            UserEmailUpdated = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };

                listUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoResult = new UserDtoResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDto
            {
                Id = UserId,
                Name = UserNameUpdated,
                Email = UserEmailUpdated
            };

            userDtoUpdateResult = new UserDtoResult
            {
                Id = UserId,
                Name = UserNameUpdated,
                Email = UserEmailUpdated,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}

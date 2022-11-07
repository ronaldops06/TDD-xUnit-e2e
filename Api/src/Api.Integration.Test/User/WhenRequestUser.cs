using Domain.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.User
{
    public class WhenRequestUser : BaseIntegration
    {
        private string _name { get; set; }
        private string _email {get; set; }

        [Fact(DisplayName = "CRUD de Usuário")]
        public async Task Eh_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new UserDto()
            {
                Email = _email,
                Name = _name
            };

            //Post
            var response = await PostJsonAsync(userDto, $"{hostApi}/Users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDtoResult>(postResult);
            
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.False(registroPost.Id == default(Guid));
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_email, registroPost.Email);

            //GetAll
            response = await client.GetAsync($"{hostApi}/Users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);

            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() > 0);
            Assert.True(listFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            userDto.Id = registroPost.Id;
            userDto.Name = Faker.Name.FullName();

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/Users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroUpdated = JsonConvert.DeserializeObject<UserDtoResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, registroUpdated.Name);

            //Get
            response = await client.GetAsync($"{hostApi}/Users/{registroUpdated.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelected = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            
            Assert.NotNull(registroSelected);
            Assert.Equal(registroUpdated.Name, registroSelected.Name);
            Assert.Equal(registroUpdated.Email, registroSelected.Email);

            //Delete
            response = await client.DeleteAsync($"{hostApi}/Users/{registroUpdated.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await client.GetAsync($"{hostApi}/Users/{registroUpdated.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
